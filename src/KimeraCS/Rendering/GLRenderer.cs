using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using KimeraCS.Core;

namespace KimeraCS.Rendering
{
    using static FF7PModel;
    using static Utils;

    /// <summary>
    /// Per-context OpenGL resources. Each GL context needs its own VAOs, VBOs, and shaders.
    /// </summary>
    internal class ContextResources : IDisposable
    {
        public ShaderProgram ModelShader { get; set; }
        public ShaderProgram LineShader { get; set; }
        public ShaderProgram PointShader { get; set; }
        public Dictionary<string, PModelMesh> MeshCacheByName { get; } = new Dictionary<string, PModelMesh>();
        public Dictionary<string, PModelMesh> PColorMeshCacheByName { get; } = new Dictionary<string, PModelMesh>();
        public bool Initialized { get; set; }

        public void ClearMeshCache()
        {
            foreach (var mesh in MeshCacheByName.Values)
            {
                mesh.Dispose();
            }
            MeshCacheByName.Clear();

            foreach (var mesh in PColorMeshCacheByName.Values)
            {
                mesh.Dispose();
            }
            PColorMeshCacheByName.Clear();
        }

        public void Dispose()
        {
            ClearMeshCache();
            ModelShader?.Dispose();
            LineShader?.Dispose();
            PointShader?.Dispose();
            ModelShader = null;
            LineShader = null;
            PointShader = null;
            Initialized = false;
        }
    }

    /// <summary>
    /// Modern OpenGL renderer that manages shaders and mesh rendering.
    /// Supports multiple GL contexts (e.g., frmSkeletonEditor and frmPEditor).
    /// </summary>
    public static class GLRenderer
    {
        // Per-context resources
        private static Dictionary<string, ContextResources> _contexts = new Dictionary<string, ContextResources>();
        private static string _currentContextId = null;

        // Matrices (shared - set before rendering in each context)
        public static Matrix4 ProjectionMatrix { get; set; } = Matrix4.Identity;
        public static Matrix4 ViewMatrix { get; set; } = Matrix4.Identity;
        public static Matrix4 ModelMatrix { get; set; } = Matrix4.Identity;

        // Lighting - 4 lights (0=Right, 1=Left, 2=Front, 3=Rear)
        public const int MAX_LIGHTS = 4;
        public static Vector3[] LightPositions { get; } = new Vector3[MAX_LIGHTS]
        {
            new Vector3(100, 0, 0),   // Right
            new Vector3(-100, 0, 0),  // Left
            new Vector3(0, 0, 100),   // Front
            new Vector3(0, 0, -100)   // Rear
        };
        public static Vector3[] LightColors { get; } = new Vector3[MAX_LIGHTS]
        {
            new Vector3(0.5f, 0.5f, 0.5f),  // Right - dim
            new Vector3(0.5f, 0.5f, 0.5f),  // Left - dim
            new Vector3(1f, 1f, 1f),         // Front - full
            new Vector3(0.75f, 0.75f, 0.75f) // Rear - 75%
        };
        public static bool[] LightEnabled { get; } = new bool[MAX_LIGHTS] { false, false, true, false };
        public static float AmbientStrength { get; set; } = 0.6f;
        public static bool LightingEnabled { get; set; } = false;

        // Legacy single-light properties (for backwards compatibility)
        public static Vector3 LightPosition
        {
            get => LightPositions[2]; // Front light
            set => LightPositions[2] = value;
        }
        public static Vector3 LightColor
        {
            get => LightColors[2];
            set => LightColors[2] = value;
        }

        // Camera position (for specular lighting)
        public static Vector3 ViewPosition { get; set; } = new Vector3(0, 0, 100);

        /// <summary>
        /// Set the current GL context. Call this after MakeCurrent() on a GLControl.
        /// </summary>
        public static void SetCurrentContext(string contextId)
        {
            _currentContextId = contextId;
        }

        /// <summary>
        /// Get the current context's resources, or null if not initialized.
        /// </summary>
        private static ContextResources CurrentContext
        {
            get
            {
                if (_currentContextId == null) return null;
                _contexts.TryGetValue(_currentContextId, out var ctx);
                return ctx;
            }
        }

        /// <summary>
        /// Initialize the modern renderer for the current context.
        /// Call after MakeCurrent() and SetCurrentContext().
        /// </summary>
        public static void Initialize()
        {
            if (_currentContextId == null)
            {
                System.Diagnostics.Debug.WriteLine("GLRenderer.Initialize: No context set");
                return;
            }

            // Check if already initialized for this context
            if (_contexts.TryGetValue(_currentContextId, out var existing) && existing.Initialized)
            {
                return;
            }

            try
            {
                var ctx = new ContextResources();

                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string shadersPath = Path.Combine(basePath, "Shaders");

                // Load model shader
                string modelVert = File.ReadAllText(Path.Combine(shadersPath, "model.vert"));
                string modelFrag = File.ReadAllText(Path.Combine(shadersPath, "model.frag"));
                ctx.ModelShader = new ShaderProgram(modelVert, modelFrag);

                // Load line shader
                string lineVert = File.ReadAllText(Path.Combine(shadersPath, "line.vert"));
                string lineFrag = File.ReadAllText(Path.Combine(shadersPath, "line.frag"));
                ctx.LineShader = new ShaderProgram(lineVert, lineFrag);

                // Load point shader
                string pointVert = File.ReadAllText(Path.Combine(shadersPath, "point.vert"));
                string pointFrag = File.ReadAllText(Path.Combine(shadersPath, "point.frag"));
                ctx.PointShader = new ShaderProgram(pointVert, pointFrag);

                ctx.Initialized = true;
                _contexts[_currentContextId] = ctx;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GLRenderer initialization failed for context {_currentContextId}: {ex.Message}");
            }
        }

        /// <summary>
        /// Check if the renderer is ready for the current context.
        /// </summary>
        public static bool IsReady
        {
            get
            {
                var ctx = CurrentContext;
                return ctx != null && ctx.Initialized && ctx.ModelShader != null;
            }
        }

        /// <summary>
        /// Get or create a mesh for the given PModel in the current context.
        /// Uses fileName as cache key since GetHashCode() for structs can cause collisions.
        /// </summary>
        public static PModelMesh GetOrCreateMesh(ref PModel model)
        {
            var ctx = CurrentContext;
            if (ctx == null) return null;

            // Use fileName as key since it's unique per model file
            // Fall back to GetHashCode if fileName is null/empty
            string cacheKey = !string.IsNullOrEmpty(model.fileName)
                ? model.fileName
                : model.GetHashCode().ToString();

            if (!ctx.MeshCacheByName.TryGetValue(cacheKey, out PModelMesh mesh))
            {
                mesh = PModelMesh.FromPModel(model);
                ctx.MeshCacheByName[cacheKey] = mesh;
            }

            return mesh;
        }

        /// <summary>
        /// Invalidate cached mesh for a model in the current context.
        /// </summary>
        public static void InvalidateMesh(ref PModel model)
        {
            var ctx = CurrentContext;
            if (ctx == null) return;

            string cacheKey = !string.IsNullOrEmpty(model.fileName)
                ? model.fileName
                : model.GetHashCode().ToString();

            if (ctx.MeshCacheByName.TryGetValue(cacheKey, out PModelMesh mesh))
            {
                mesh.Dispose();
                ctx.MeshCacheByName.Remove(cacheKey);
            }

            if (ctx.PColorMeshCacheByName.TryGetValue(cacheKey, out PModelMesh pcolorMesh))
            {
                pcolorMesh.Dispose();
                ctx.PColorMeshCacheByName.Remove(cacheKey);
            }
        }

        /// <summary>
        /// Invalidate cached mesh for a model in ALL contexts.
        /// Call this when a model is modified.
        /// </summary>
        public static void InvalidateMeshAllContexts(ref PModel model)
        {
            string cacheKey = !string.IsNullOrEmpty(model.fileName)
                ? model.fileName
                : model.GetHashCode().ToString();

            foreach (var ctx in _contexts.Values)
            {
                if (ctx.MeshCacheByName.TryGetValue(cacheKey, out PModelMesh mesh))
                {
                    mesh.Dispose();
                    ctx.MeshCacheByName.Remove(cacheKey);
                }

                if (ctx.PColorMeshCacheByName.TryGetValue(cacheKey, out PModelMesh pcolorMesh))
                {
                    pcolorMesh.Dispose();
                    ctx.PColorMeshCacheByName.Remove(cacheKey);
                }
            }
        }

        /// <summary>
        /// Clear all cached meshes in the current context.
        /// </summary>
        public static void ClearMeshCache()
        {
            CurrentContext?.ClearMeshCache();
        }

        /// <summary>
        /// Clear all cached meshes in ALL contexts.
        /// </summary>
        public static void ClearAllMeshCaches()
        {
            foreach (var ctx in _contexts.Values)
            {
                ctx.ClearMeshCache();
            }
        }

        /// <summary>
        /// Draw a PModel using modern OpenGL.
        /// </summary>
        public static void DrawPModelModern(ref PModel model, uint[] texIds, bool hideHidden)
        {
            var ctx = CurrentContext;
            if (ctx == null || !ctx.Initialized) return;

            var mesh = GetOrCreateMesh(ref model);
            if (mesh?.Groups == null) return;

            // Enable depth testing (matches legacy behavior)
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);
            GL.DepthMask(true);

            ctx.ModelShader.Use();
            ctx.ModelShader.SetMatrix4("projection", ProjectionMatrix);
            ctx.ModelShader.SetMatrix4("view", ViewMatrix);
            ctx.ModelShader.SetBool("enableLighting", LightingEnabled);
            ctx.ModelShader.SetVector3Array("lightPos", LightPositions);
            ctx.ModelShader.SetVector3Array("lightColor", LightColors);
            ctx.ModelShader.SetBoolArray("lightEnabled", LightEnabled);
            ctx.ModelShader.SetVector3("viewPos", ViewPosition);
            ctx.ModelShader.SetFloat("ambientStrength", AmbientStrength);
            ctx.ModelShader.SetInt("texture0", 0);

            for (int g = 0; g < mesh.Groups.Length; g++)
            {
                var group = mesh.Groups[g];
                if (group == null) continue;
                if (group.Hidden && hideHidden) continue;

                Matrix4 groupModel = ModelMatrix * group.GroupTransform;
                ctx.ModelShader.SetMatrix4("model", groupModel);

                ApplyBlendMode(group.BlendMode, group.SrcBlend, group.DstBlend);

                // Set base alpha based on blend mode (matches legacy behavior)
                // BLEND_AVG (0) with smooth shading uses 0.5 alpha, otherwise 1.0
                float baseAlpha = (group.BlendMode == 0 && group.ShadeMode != 1) ? 0.5f : 1.0f;
                ctx.ModelShader.SetFloat("baseAlpha", baseAlpha);

                if (group.AlphaRef > 0)
                {
                    ctx.ModelShader.SetBool("enableAlphaTest", true);
                    ctx.ModelShader.SetFloat("alphaRef", group.AlphaRef / 255.0f);
                }
                else
                {
                    ctx.ModelShader.SetBool("enableAlphaTest", false);
                }

                // Check if texture exists and is valid in current GL context
                // Must check TexFlag - groups with texFlag == 0 should not use textures
                bool hasTexture = group.TexFlag && group.TextureID >= 0 && texIds != null && group.TextureID < texIds.Length;
                if (hasTexture)
                {
                    uint texId = texIds[group.TextureID];
                    // Verify texture is valid in this GL context (textures aren't shared between contexts)
                    if (texId > 0 && GL.IsTexture((int)texId))
                    {
                        GL.ActiveTexture(TextureUnit.Texture0);
                        GL.BindTexture(TextureTarget.Texture2d, (int)texId);
                        ctx.ModelShader.SetBool("useTexture", true);
                    }
                    else
                    {
                        ctx.ModelShader.SetBool("useTexture", false);
                    }
                }
                else
                {
                    ctx.ModelShader.SetBool("useTexture", false);
                }

                group.Draw();
            }

            GL.UseProgram(0);
        }

        private static void ApplyBlendMode(int blendMode, int srcBlend, int dstBlend)
        {
            switch (blendMode)
            {
                case 0: // BLEND_AVG
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
                    break;

                case 1: // BLEND_ADD
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.One);
                    break;

                case 2: // BLEND_SUB
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactor.Zero, BlendingFactor.OneMinusSrcColor);
                    break;

                case 3: // BLEND_25P
                    GL.Enable(EnableCap.Blend);
                    GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.One);
                    break;

                case 4: // BLEND_NONE
                default:
                    GL.Disable(EnableCap.Blend);
                    break;
            }
        }

        /// <summary>
        /// Dispose resources for the current context.
        /// </summary>
        public static void Shutdown()
        {
            if (_currentContextId != null && _contexts.TryGetValue(_currentContextId, out var ctx))
            {
                ctx.Dispose();
                _contexts.Remove(_currentContextId);
            }
        }

        /// <summary>
        /// Dispose all resources for all contexts.
        /// </summary>
        public static void ShutdownAll()
        {
            foreach (var ctx in _contexts.Values)
            {
                ctx.Dispose();
            }
            _contexts.Clear();
            _currentContextId = null;
        }
    }
}
