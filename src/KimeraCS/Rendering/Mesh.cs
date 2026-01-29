using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using KimeraCS.Core;

namespace KimeraCS.Rendering
{
    using static FF7PModel;

    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
        public Vector3 Position;    // 12 bytes
        public Vector3 Normal;      // 12 bytes
        public Vector2 TexCoord;    // 8 bytes
        public Vector4 Color;       // 16 bytes
        // Total: 48 bytes

        public static readonly int SizeInBytes = Marshal.SizeOf<Vertex>();
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LineVertex
    {
        public Vector3 Position;    // 12 bytes
        public Vector4 Color;       // 16 bytes
        // Total: 28 bytes

        public static readonly int SizeInBytes = Marshal.SizeOf<LineVertex>();
    }

    public class GroupMesh : IDisposable
    {
        public int VAO { get; private set; }
        public int VBO { get; private set; }
        public int EBO { get; private set; }
        public int VertexCount { get; private set; }
        public int IndexCount { get; private set; }
        public int TextureID { get; set; }
        public bool TexFlag { get; set; }  // True if this group uses textures
        public int BlendMode { get; set; }
        public int SrcBlend { get; set; }
        public int DstBlend { get; set; }
        public int AlphaRef { get; set; }
        public int ShadeMode { get; set; }
        public bool Hidden { get; set; }
        public Matrix4 GroupTransform { get; set; }

        private bool _disposed;

        public GroupMesh()
        {
            GroupTransform = Matrix4.Identity;
        }

        public void Upload(Vertex[] vertices, uint[] indices)
        {
            VertexCount = vertices.Length;
            IndexCount = indices.Length;

            VAO = GL.GenVertexArray();
            VBO = GL.GenBuffer();
            EBO = GL.GenBuffer();

            GL.BindVertexArray(VAO);

            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * Vertex.SizeInBytes, vertices, BufferUsage.StaticDraw);
            
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsage.StaticDraw);
            
            // Position attribute (location = 0)
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Vertex.SizeInBytes, 0);

            // Normal attribute (location = 1)
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, Vertex.SizeInBytes, 12);

            // TexCoord attribute (location = 2)
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, Vertex.SizeInBytes, 24);

            // Color attribute (location = 3)
            GL.EnableVertexAttribArray(3);
            GL.VertexAttribPointer(3, 4, VertexAttribPointerType.Float, false, Vertex.SizeInBytes, 32);

            GL.BindVertexArray(0);
        }

        public void Draw()
        {
            GL.BindVertexArray(VAO);
            GL.DrawElements(PrimitiveType.Triangles, IndexCount, DrawElementsType.UnsignedInt, 0);
            GL.BindVertexArray(0);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (VAO != 0)
                {
                    GL.DeleteVertexArray(VAO);
                    VAO = 0;
                }
                if (VBO != 0)
                {
                    GL.DeleteBuffer(VBO);
                    VBO = 0;
                }
                if (EBO != 0)
                {
                    GL.DeleteBuffer(EBO);
                    EBO = 0;
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~GroupMesh()
        {
            Dispose(false);
        }
    }

    public class PModelMesh : IDisposable
    {
        public GroupMesh[] Groups { get; private set; } = Array.Empty<GroupMesh>();
        private bool _disposed;

        public static PModelMesh FromPModel(PModel model, bool usePolygonColors = false)
        {
            var mesh = new PModelMesh();
            mesh.Groups = new GroupMesh[model.Header.numGroups];

            for (int g = 0; g < model.Header.numGroups; g++)
            {
                var group = model.Groups[g];
                var hundret = model.Hundrets[g];
                var groupMesh = new GroupMesh();

                var vertices = new List<Vertex>();
                var indices = new List<uint>();

                for (int p = group.offsetPoly; p < group.offsetPoly + group.numPoly; p++)
                {
                    // For polygon colors, get the color once per polygon (same for all 3 vertices)
                    Vector4 polyColor = new Vector4(1f, 1f, 1f, 1f);
                    if (usePolygonColors && model.Pcolors != null && p < model.Pcolors.Length)
                    {
                        Color c = model.Pcolors[p];
                        polyColor = new Vector4(c.R / 255f, c.G / 255f, c.B / 255f, c.A / 255f);
                    }

                    for (int v = 0; v < 3; v++)
                    {
                        int vertIdx = model.Polys[p].Verts[v] + group.offsetVert;

                        // Position
                        Vector3 position = new Vector3(
                            model.Verts[vertIdx].X,
                            model.Verts[vertIdx].Y,
                            model.Verts[vertIdx].Z);

                        // Normal
                        Vector3 normal = Vector3.UnitY;
                        if (model.Normals != null && model.Normals.Length > 0 &&
                            model.NormalIndex != null && vertIdx < model.NormalIndex.Length)
                        {
                            int normIdx = model.NormalIndex[vertIdx];
                            if (normIdx >= 0 && normIdx < model.Normals.Length)
                            {
                                normal = new Vector3(
                                    model.Normals[normIdx].X,
                                    model.Normals[normIdx].Y,
                                    model.Normals[normIdx].Z);
                            }
                        }

                        // Texture coordinates
                        Vector2 texCoord = Vector2.Zero;
                        if (model.TexCoords != null && group.texFlag == 1)
                        {
                            int texIdx = group.offsetTex + model.Polys[p].Verts[v];
                            if (texIdx >= 0 && texIdx < model.TexCoords.Length)
                            {
                                texCoord = new Vector2(
                                    model.TexCoords[texIdx].X,
                                    model.TexCoords[texIdx].Y);
                            }
                        }

                        // Color: use polygon color or vertex color based on mode
                        Vector4 color;
                        if (usePolygonColors)
                        {
                            color = polyColor;
                        }
                        else
                        {
                            // Vertex color
                            // NOTE: Legacy code does NOT use the alpha from vertex colors - it uses 0.5f or 1.0f
                            // based on blend_mode. We use 1.0f here; blending is handled by the blend mode.
                            color = new Vector4(1f, 1f, 1f, 1f);
                            if (model.Vcolors != null && vertIdx < model.Vcolors.Length)
                            {
                                Color c = model.Vcolors[vertIdx];
                                color = new Vector4(c.R / 255f, c.G / 255f, c.B / 255f, 1f);
                            }
                        }

                        vertices.Add(new Vertex
                        {
                            Position = position,
                            Normal = normal,
                            TexCoord = texCoord,
                            Color = color
                        });
                        indices.Add((uint)(vertices.Count - 1));
                    }
                }

                if (vertices.Count > 0)
                {
                    groupMesh.Upload(vertices.ToArray(), indices.ToArray());
                }

                // Copy render state from Group and Hundret
                groupMesh.TextureID = group.texID;  // Use group's texID, not hundret's
                groupMesh.TexFlag = group.texFlag == 1;  // True if textures are used
                groupMesh.BlendMode = hundret.blend_mode;
                groupMesh.SrcBlend = hundret.srcblend;
                groupMesh.DstBlend = hundret.destblend;
                groupMesh.AlphaRef = hundret.alpharef;
                groupMesh.ShadeMode = hundret.shademode;
                groupMesh.Hidden = group.HiddenQ;

                // Build group transform matrix
                groupMesh.GroupTransform = BuildGroupTransform(group);

                mesh.Groups[g] = groupMesh;
            }

            return mesh;
        }

        private static Matrix4 BuildGroupTransform(PGroup group)
        {
            // Scale
            Matrix4 scale = Matrix4.CreateScale(
                group.rszGroupX != 0 ? group.rszGroupX : 1f,
                group.rszGroupY != 0 ? group.rszGroupY : 1f,
                group.rszGroupZ != 0 ? group.rszGroupZ : 1f);

            // Rotation from quaternion
            Matrix4 rotation;
            if (group.rotationQuaternionGroup.W != 0 ||
                group.rotationQuaternionGroup.X != 0 ||
                group.rotationQuaternionGroup.Y != 0 ||
                group.rotationQuaternionGroup.Z != 0)
            {
                var q = new Quaternion(
                    (float)group.rotationQuaternionGroup.X,
                    (float)group.rotationQuaternionGroup.Y,
                    (float)group.rotationQuaternionGroup.Z,
                    (float)group.rotationQuaternionGroup.W);
                rotation = Matrix4.CreateFromQuaternion(q);
            }
            else
            {
                // Use Euler angles if quaternion is zero
                rotation = Matrix4.CreateRotationX(group.rotGroupAlpha) *
                           Matrix4.CreateRotationY(group.rotGroupBeta) *
                           Matrix4.CreateRotationZ(group.rotGroupGamma);
            }

            // Translation
            Matrix4 translation = Matrix4.CreateTranslation(
                group.repGroupX, group.repGroupY, group.repGroupZ);

            return scale * rotation * translation;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (Groups != null)
                {
                    foreach (var group in Groups)
                    {
                        group?.Dispose();
                    }
                    Groups = Array.Empty<GroupMesh>();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~PModelMesh()
        {
            Dispose(false);
        }
    }
}
