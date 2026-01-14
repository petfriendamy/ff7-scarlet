using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace KimeraCS.Core
{
    using Rendering;
    using static Utils;

    public static class FF7PModel
    {

        public const int PPOLY_TAG2 = 0xCFCEA00;  //217901568
        public const int I_COMPUTENORMALS_VERTEXTHRESHOLD = 58;

        public struct PHeader
        {
            public int version;
            public int off04;
            public int vertexColor;
            public int numVerts;
            public int numNormals;
            public int numXYZ;
            public int numTexCs;
            public int numNormIdx;
            public int numEdges;
            public int numPolys;
            public int off28;
            public int off2C;
            public int mirex_h;
            public int numGroups;
            public int mirex_g;
            public int off3C;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public int[] unknown;
        }

        public struct PEdge
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public ushort[] Verts;

            // This is for create a new deep copy of PEdge
            // We will use normally the creator like '= new PEdge();' but there are some exceptions
            public PEdge(PEdge pedgeIn)
            {
                Verts = new ushort[pedgeIn.Verts.Length];
                pedgeIn.Verts.CopyTo(Verts, 0);
            }
        }

        public struct PPolygon
        {
            public short tag1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public ushort[] Verts;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public ushort[] Normals;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public ushort[] Edges;
            public int tag2;

            // This is for create a new empty PPolygon with arrays defined
            public PPolygon(int tag2In)
            {
                tag1 = 0;
                tag2 = tag2In;

                Verts = new ushort[3];
                Normals = new ushort[3];
                Edges = new ushort[3];
            }

            // This is for create a new deep copy of PPolygon
            // We will use normally the creator like '= new PPolygon();' but there are some exceptions
            public PPolygon(PPolygon ppolygonIn)
            {
                tag1 = ppolygonIn.tag1;
                tag2 = ppolygonIn.tag2;

                Verts = new ushort[ppolygonIn.Verts.Length];
                ppolygonIn.Verts.CopyTo(Verts, 0);

                Normals = new ushort[ppolygonIn.Normals.Length];
                ppolygonIn.Normals.CopyTo(Normals, 0);

                Edges = new ushort[ppolygonIn.Edges.Length];
                ppolygonIn.Edges.CopyTo(Edges, 0);
            }
        }

        // Masks for field_8 and field_C:
        // 0x1: V_WIREFRAME
        // 0x2: V_TEXTURE
        // 0x4: V_LINEARFILTER
        // 0x8: V_PERSPECTIVE
        // 0x10: V_TMAPBLEND
        // 0x20: V_WRAP_U
        // 0x40: V_WRAP_V
        // 0x80: V_UNKNOWN80
        // 0x100: V_COLORKEY
        // 0x200: V_DITHER
        // 0x400: V_ALPHABLEND
        // 0x800: V_ALPHATEST
        // 0x1000: V_ANTIALIAS
        // 0x2000: V_CULLFACE
        // 0x4000: V_NOCULL
        // 0x8000: V_DEPTHTEST
        // 0x10000: V_DEPTHMASK
        // 0x20000: V_SHADEMODE
        // 0x40000: V_SPECULAR
        // 0x80000: V_LIGHTSTATE
        // 0x100000: V_FOG
        // 0x200000: V_TEXADDR
        public struct PHundret
        {
            public int field_0;
            public int field_4;
            public int field_8;            // Render state part value (if it's actually changed)
            public int field_C;            // Change render state part?
            public int texID;              // Texture identifier for the corresponding group. For consistency sake should be the same as on the group,
                                           // but this is the one FF7 actually uses.
            public int texture_set_ptr;    //This should be filled in real time
            public int field_18;
            public int field_1C;
            public int field_20;
            public int shademode;
            public int lightstate_ambient;
            public int field_2C;
            public int lightstate_material_ptr;
            public int srcblend;
            public int destblend;
            public int field_3C;
            public int alpharef;
            public int blend_mode;     // 0 - Average, source color / 2 + destination color / 2.
                                       // 1 - Additive, source color + destination color.
                                       // 2 - Subtractive, broken and unused but it should be destination color - source color.
                                       // 3 - Not sure, but it seems broken and is never used.
                                       // 4 - No blending (FF8 only)
            public int zSort;          // Filled in real time
            public int field_4C;
            public int field_50;
            public int field_54;
            public int field_58;
            public int vertex_alpha;
            public int field_60;
        }

        public struct PGroup
        {
            public int polyType;    //  Specifies the Polygon Type for this Group:
                                    //  1 - nontextured Polygons
                                    //  2 - textured Polygons with normals
                                    //  3 - textured Polygons without normals
            public int offsetPoly;
            public int numPoly;
            public int offsetVert;
            public int numVert;
            public int offsetEdge;
            public int numEdge;
            public int off1C;
            public int off20;
            public int off24;
            public int off28;
            public int offsetTex;
            public int texFlag;
            public int texID;
            // added attributes
            public float repGroupX, repGroupY, repGroupZ;
            public float rszGroupX, rszGroupY, rszGroupZ;
            public float rotGroupAlpha, rotGroupBeta, rotGroupGamma;
            public Quaterniond rotationQuaternionGroup;
            public int DListNum;
            public bool HiddenQ;           // Hidden groups aren't rendered and can't be changed _
                                           // save for the basic geometrical transformations(rotation, scaling and panning),
                                           // palletizzed opeartions and group deletion
            public int realGID;            // We will use this as maintain the real Group position number of the list for
                                           // Remove/Duplicate/Add features. This is the Border DListNum?
        }

        public struct PBoundingBox
        {
            public int unknown4bytes;           // It seems that there are 4bytes before BoundingBox. This 4 bytes are unknown.

            public float max_x;
            public float max_y;
            public float max_z;
            public float min_x;
            public float min_y;
            public float min_z;
        }

        public struct PModel
        {
            public string fileName;
            public PHeader Header;
            public Vector3[] Verts;
            public Vector3[] Normals;
            public Vector3[] XYZ;
            public Vector2[] TexCoords;
            public Color[] Vcolors;
            public Color[] Pcolors;
            public PEdge[] Edges;
            public PPolygon[] Polys;
            public PHundret[] Hundrets;
            public PGroup[] Groups;
            public PBoundingBox BoundingBox;
            public int[] NormalIndex;
            // added attributes
            public float repositionX, repositionY, repositionZ;
            public float resizeX, resizeY, resizeZ;
            public float rotateAlpha, rotateBeta, rotateGamma;
            public Quaterniond rotationQuaternion;
            public float diameter;
            public int DListNum;

        }


        public static void LoadPModel(ref PModel Model, string strPFolder, string strPFileName)
        {
            byte[] fileBuffer;
            string strPFullFileName = strPFolder + "\\" + strPFileName;

            // Let's read P file into memory.
            // First check if exists
            if (!File.Exists(strPFullFileName))
            {
                //  Debug.Print fileName
                throw new PFileNotFoundException("Error opening .P Model " + strPFileName + " file.",
                                                 strPFileName);
            }

            // Read All P Model file into memory
            fileBuffer = File.ReadAllBytes(strPFullFileName);

            LoadPModel(ref Model, fileBuffer, strPFileName);
        }

        public static void LoadPModel(ref PModel Model, byte[] data, string strPFileName)
        {
            using (var ms = new MemoryStream(data))
            using (var memReader = new BinaryReader(ms))
            {
                LoadPModel(ref Model, memReader, strPFileName);
            }
        }

        public static void LoadPModel(ref PModel Model, BinaryReader memReader, string strPFileName)
        {
            //// Read P Model structure.
            // Put name of P file
            Model.fileName = strPFileName.ToUpper();

            // Header
            Model.Header = new PHeader();
            ReadPHeader(memReader, ref Model.Header, strPFileName);

            // Check numVerts
            if (Model.Header.numVerts <= 0)
            {
                throw new ApplicationException("The number of vertices of the P Model: " + Model.fileName +
                                               " is not correct.");
            }

            // Verts
            Model.Verts = new Vector3[Model.Header.numVerts];
            ReadPVerts(memReader, Model.Header.numVerts, ref Model.Verts);

            // Normals
            Model.Normals = new Vector3[Model.Header.numNormals];
            ReadPNormals(memReader, Model.Header.numNormals, ref Model.Normals);

            // TryVerts
            if (Model.Header.numXYZ > 0)
            {
                Model.XYZ = new Vector3[Model.Header.numXYZ];
                ReadPXYZ(memReader, Model.Header.numXYZ, ref Model.XYZ);
            }
            //else
            //{
            //    Model.Header.numXYZ = 200;
            //    Model.XYZ = new Point3D[Model.Header.numXYZ];
            //}

            // Texture Coordinates
            Model.TexCoords = new Vector2[Model.Header.numTexCs];
            ReadPTexCoords(memReader, Model.Header.numTexCs, ref Model.TexCoords);

            //  Vertex Colors
            Model.Vcolors = new Color[Model.Header.numVerts];
            ReadPPVColors(memReader, Model.Header.numVerts, ref Model.Vcolors);

            //  Polygon Colors
            Model.Pcolors = new Color[Model.Header.numPolys];
            ReadPPVColors(memReader, Model.Header.numPolys, ref Model.Pcolors);

            // Edges
            Model.Edges = new PEdge[Model.Header.numEdges];
            ReadPEdges(memReader, Model.Header.numEdges, ref Model.Edges);

            // Polygons
            Model.Polys = new PPolygon[Model.Header.numPolys];
            ReadPPolygons(memReader, Model.Header.numPolys, ref Model.Polys);

            // Hundrets
            Model.Hundrets = new PHundret[Model.Header.mirex_h];
            ReadPHundrets(memReader, Model.Header.mirex_h, ref Model.Hundrets);

            // Groups
            Model.Groups = new PGroup[Model.Header.numGroups];
            ReadPGroups(memReader, Model.Header.numGroups, ref Model.Groups);

            // BoundingBox
            Model.BoundingBox = new PBoundingBox();
            ReadPBoundingBox(memReader, ref Model.BoundingBox);

            // NormalIndex
            Model.NormalIndex = new int[Model.Header.numNormIdx];
            ReadPNormalIndex(memReader, Model.Header.numNormIdx, ref Model.NormalIndex);

            // added attributes
            Model.resizeX = 1;
            Model.resizeY = 1;
            Model.resizeZ = 1;
            Model.rotateAlpha = 0;
            Model.rotateBeta = 0;
            Model.rotateGamma = 0;

            Model.rotationQuaternion.X = 0;
            Model.rotationQuaternion.Y = 0;
            Model.rotationQuaternion.Z = 0;
            Model.rotationQuaternion.W = 1;

            Model.repositionX = 0;
            Model.repositionY = 0;
            Model.repositionZ = 0;
            Model.diameter = ComputeDiameter(Model.BoundingBox);

            Model.DListNum = 0;

            AssignRealGID(ref Model);
        }



        /////////////////////////////////////////////////////////////////////////////////////////////
        // Load Model functions
        private static int ReadPHeader(BinaryReader memReader, ref PHeader Header, string fileName)
        {
            memReader.BaseStream.Seek(0, SeekOrigin.Begin);
            Header.version = memReader.ReadInt32();
            Header.off04 = memReader.ReadInt32();

            if (Header.version != 1 || Header.off04 != 1)
            {
                throw new FileFormatException("The file header of the P file " + Path.GetFileName(fileName) + " is not correct.", fileName);
            }

            Header.vertexColor = memReader.ReadInt32();
            Header.numVerts = memReader.ReadInt32();
            Header.numNormals = memReader.ReadInt32();
            Header.numXYZ = memReader.ReadInt32();
            Header.numTexCs = memReader.ReadInt32();
            Header.numNormIdx = memReader.ReadInt32();
            Header.numEdges = memReader.ReadInt32();
            Header.numPolys = memReader.ReadInt32();
            Header.off28 = memReader.ReadInt32();
            Header.off2C = memReader.ReadInt32();
            Header.mirex_h = memReader.ReadInt32();
            Header.numGroups = memReader.ReadInt32();
            Header.mirex_g = memReader.ReadInt32();
            Header.off3C = memReader.ReadInt32();

            Header.unknown = new int[16];

            for (var i = 0; i < 16; i++) Header.unknown[i] = memReader.ReadInt32();

            return 1;
        }

        private static void ReadPVerts(BinaryReader memReader, long numVerts, ref Vector3[] Verts)
        {
            for (var i = 0; i < numVerts; i++)
            {
                Verts[i].X = memReader.ReadSingle();
                Verts[i].Y = memReader.ReadSingle();
                Verts[i].Z = memReader.ReadSingle();
            }
        }

        private static void ReadPNormals(BinaryReader memReader, long numNormals, ref Vector3[] Normals)
        {
            if (numNormals > 0)
            {
                for (var i = 0; i < numNormals; i++)
                {
                    Normals[i].X = memReader.ReadSingle();
                    Normals[i].Y = memReader.ReadSingle();
                    Normals[i].Z = memReader.ReadSingle();
                }
            }
        }

        private static void ReadPXYZ(BinaryReader memReader, long numTryVerts, ref Vector3[] TryVerts)
        {
            for (var i = 0; i < numTryVerts; i++)
            {
                TryVerts[i].X = memReader.ReadSingle();
                TryVerts[i].Y = memReader.ReadSingle();
                TryVerts[i].Z = memReader.ReadSingle();
            }
        }

        private static void ReadPTexCoords(BinaryReader memReader, long numTexCs, ref Vector2[] TexCoordinates)
        {
            if (numTexCs > 0)
            {
                for (var i = 0; i < numTexCs; i++)
                {
                    TexCoordinates[i].X = memReader.ReadSingle();
                    TexCoordinates[i].Y = memReader.ReadSingle();
                }
            }
        }

        private static void ReadPPVColors(BinaryReader memReader, long numVerts, ref Color[] Vcolors)
        {
            byte red, green, blue, alpha;

            for (var i = 0; i < numVerts; i++)
            {
                blue = memReader.ReadByte();
                green = memReader.ReadByte();
                red = memReader.ReadByte();
                alpha = memReader.ReadByte();

                Vcolors[i] = Color.FromArgb(alpha, red, green, blue);
            }
        }

        private static void ReadPEdges(BinaryReader memReader, long numEdges, ref PEdge[] Edges)
        {
            for (var i = 0; i < numEdges; i++)
            {
                Edges[i].Verts = new ushort[2];

                Edges[i].Verts[0] = memReader.ReadUInt16();
                Edges[i].Verts[1] = memReader.ReadUInt16();
            }
        }

        private static void ReadPPolygons(BinaryReader memReader, long numPolys, ref PPolygon[] Polys)
        {
            for (var i = 0; i < numPolys; i++)
            {
                Polys[i].tag1 = memReader.ReadInt16();

                Polys[i].Verts = new ushort[3];
                Polys[i].Verts[0] = memReader.ReadUInt16();
                Polys[i].Verts[1] = memReader.ReadUInt16();
                Polys[i].Verts[2] = memReader.ReadUInt16();

                Polys[i].Normals = new ushort[3];
                Polys[i].Normals[0] = memReader.ReadUInt16();
                Polys[i].Normals[1] = memReader.ReadUInt16();
                Polys[i].Normals[2] = memReader.ReadUInt16();

                Polys[i].Edges = new ushort[3];
                Polys[i].Edges[0] = memReader.ReadUInt16();
                Polys[i].Edges[1] = memReader.ReadUInt16();
                Polys[i].Edges[2] = memReader.ReadUInt16();

                Polys[i].tag2 = memReader.ReadInt32();
            }
        }

        private static void ReadPHundrets(BinaryReader memReader, long numHundrets, ref PHundret[] Hundrets)
        {
            for (var i = 0; i < numHundrets; i++)
            {
                Hundrets[i].field_0 = memReader.ReadInt32();
                Hundrets[i].field_4 = memReader.ReadInt32();
                Hundrets[i].field_8 = memReader.ReadInt32();
                Hundrets[i].field_C = memReader.ReadInt32();
                Hundrets[i].texID = memReader.ReadInt32();
                Hundrets[i].texture_set_ptr = memReader.ReadInt32();
                Hundrets[i].field_18 = memReader.ReadInt32();
                Hundrets[i].field_1C = memReader.ReadInt32();
                Hundrets[i].field_20 = memReader.ReadInt32();
                Hundrets[i].shademode = memReader.ReadInt32();
                Hundrets[i].lightstate_ambient = memReader.ReadInt32();
                Hundrets[i].field_2C = memReader.ReadInt32();
                Hundrets[i].lightstate_material_ptr = memReader.ReadInt32();
                Hundrets[i].srcblend = memReader.ReadInt32();
                Hundrets[i].destblend = memReader.ReadInt32();
                Hundrets[i].field_3C = memReader.ReadInt32();
                Hundrets[i].alpharef = memReader.ReadInt32();
                Hundrets[i].blend_mode = memReader.ReadInt32();
                Hundrets[i].zSort = memReader.ReadInt32();
                Hundrets[i].field_4C = memReader.ReadInt32();
                Hundrets[i].field_50 = memReader.ReadInt32();
                Hundrets[i].field_54 = memReader.ReadInt32();
                Hundrets[i].field_58 = memReader.ReadInt32();
                Hundrets[i].vertex_alpha = memReader.ReadInt32();
                Hundrets[i].field_60 = memReader.ReadInt32();
            }
        }

        private static void ReadPGroups(BinaryReader memReader, long numGroups, ref PGroup[] Groups)
        {
            for (var i = 0; i < numGroups; i++)
            {
                Groups[i].polyType = memReader.ReadInt32();
                Groups[i].offsetPoly = memReader.ReadInt32();
                Groups[i].numPoly = memReader.ReadInt32();
                Groups[i].offsetVert = memReader.ReadInt32();
                Groups[i].numVert = memReader.ReadInt32();
                Groups[i].offsetEdge = memReader.ReadInt32();
                Groups[i].numEdge = memReader.ReadInt32();
                Groups[i].off1C = memReader.ReadInt32();
                Groups[i].off20 = memReader.ReadInt32();
                Groups[i].off24 = memReader.ReadInt32();
                Groups[i].off28 = memReader.ReadInt32();
                Groups[i].offsetTex = memReader.ReadInt32();
                Groups[i].texFlag = memReader.ReadInt32();
                Groups[i].texID = memReader.ReadInt32();
                // added attributes
                Groups[i].rszGroupX = 1;
                Groups[i].rszGroupY = 1;
                Groups[i].rszGroupZ = 1;
                Groups[i].repGroupX = 0;
                Groups[i].repGroupY = 0;
                Groups[i].repGroupZ = 0;
                Groups[i].rotGroupAlpha = 0;
                Groups[i].rotGroupBeta = 0;
                Groups[i].rotGroupGamma = 0;

                Groups[i].rotationQuaternionGroup = new Quaterniond(0, 0, 0, 1);

                Groups[i].DListNum = -1;
                Groups[i].HiddenQ = false;
                Groups[i].realGID = i;
            }
        }

        private static void ReadPBoundingBox(BinaryReader memReader, ref PBoundingBox BoundingBox)
        {
            // There are .P models, like magic/bari_a1 and magic/bari_a2 that
            // does not seem to have this unknown4bytes.
            if (memReader.BaseStream.Length - memReader.BaseStream.Position - 24 > 0)
                BoundingBox.unknown4bytes = memReader.ReadInt32();           // It seems that there are 4bytes before BoundingBox. This 4 bytes are unknown.

            BoundingBox.max_x = memReader.ReadSingle();
            BoundingBox.max_y = memReader.ReadSingle();
            BoundingBox.max_z = memReader.ReadSingle();

            // There are .P models, like magic/bari_a2 that
            // does not seem to have min_x.
            if (memReader.BaseStream.Length - memReader.BaseStream.Position - 12 > 0)
            {
                BoundingBox.min_x = memReader.ReadSingle();
                BoundingBox.min_y = memReader.ReadSingle();
                BoundingBox.min_z = memReader.ReadSingle();
            }
        }

        private static void ReadPNormalIndex(BinaryReader memReader, int numNormIdx, ref int[] NormalIndex)
        {
            for (var i = 0; (i < numNormIdx && memReader.BaseStream.Position < memReader.BaseStream.Length); i++)
                NormalIndex[i] = memReader.ReadInt32();
        }

        // In this procedure we will check the realGID assigned when loading
        // the model is correct (this equals the offsetPoly incremental number order).
        public static void AssignRealGID(ref PModel Model)
        {
            int iGroupIdx, iGroupIdxCheck, iMinOffsetPoly = 0, iMaxOffsetPoly = 999999, iGroupFound = 0, iRealGIDCounter = 0;

            if (Model.Header.numGroups > 1)
            {

                iGroupIdx = 0;
                while (iGroupIdx < Model.Header.numGroups)
                {

                    if (iGroupIdx == 0)
                    {
                        iGroupIdxCheck = 0;
                        while (Model.Groups[iGroupIdxCheck].offsetPoly != 0 &&
                               Model.Groups[iGroupIdxCheck].numPoly > 0) iGroupIdxCheck++;

                        iGroupFound = iGroupIdxCheck;
                    }
                    else
                    {
                        iGroupIdxCheck = 0;
                        while (iGroupIdxCheck < Model.Header.numGroups)
                        {
                            if (Model.Groups[iGroupIdxCheck].offsetPoly < iMaxOffsetPoly &&
                                Model.Groups[iGroupIdxCheck].offsetPoly > iMinOffsetPoly)
                            {
                                iMaxOffsetPoly = Model.Groups[iGroupIdxCheck].offsetPoly;
                                iGroupFound = iGroupIdxCheck;
                            }

                            iGroupIdxCheck++;
                        }
                    }

                    Model.Groups[iGroupFound].realGID = iRealGIDCounter;
                    iMinOffsetPoly = Model.Groups[iGroupFound].offsetPoly;
                    iMaxOffsetPoly = 99999999;
                    iRealGIDCounter++;

                    iGroupIdx++;
                }
            }
        }


        //  ---------------------------------------------------------------------------------------------------------
        //  ----------------------------------------- AUXILIARY FUNCTIONS -------------------------------------------
        //  ---------------------------------------------------------------------------------------------------------
        public static float ComputeDiameter(PBoundingBox BoundingBox)
        {
            float diffx, diffy, diffz;

            diffx = BoundingBox.max_x - BoundingBox.min_x;
            diffy = BoundingBox.max_y - BoundingBox.min_y;
            diffz = BoundingBox.max_z - BoundingBox.min_z;

            if (diffx > diffy)
            {
                if (diffx > diffz) return diffx;
                else return diffz;
            }
            else
            {
                if (diffy > diffz) return diffy;
                else return diffz;
            }
        }

        public static void ComputePModelBoundingBox(PModel Model, ref Vector3 p_min, ref Vector3 p_max)
        {
            Vector3 p_min_aux = new Vector3();
            Vector3 p_max_aux = new Vector3();

            p_min_aux.X = Model.BoundingBox.min_x;
            p_min_aux.Y = Model.BoundingBox.min_y;
            p_min_aux.Z = Model.BoundingBox.min_z;

            p_max_aux.X = Model.BoundingBox.max_x;
            p_max_aux.Y = Model.BoundingBox.max_y;
            p_max_aux.Z = Model.BoundingBox.max_z;

            // Build transformation matrix using pure math (no GL state)
            Matrix4 modelMatrix = CreateModelViewMatrix(
                Model.repositionX, Model.repositionY, Model.repositionZ,
                Model.rotateAlpha, Model.rotateBeta, Model.rotateGamma,
                Model.resizeX, Model.resizeY, Model.resizeZ);

            // Convert Matrix4 to double[16] for ComputeTransformedBoxBoundingBox
            double[] MV_matrix = Matrix4ToDoubleArray(modelMatrix);

            ComputeTransformedBoxBoundingBox(MV_matrix, ref p_min_aux, ref p_max_aux, ref p_min, ref p_max);
        }

        /// <summary>
        /// Converts OpenTK Matrix4 to double[16] array in OpenGL column-major order
        /// </summary>
        public static double[] Matrix4ToDoubleArray(Matrix4 m)
        {
            return
            [
                m.M11, m.M12, m.M13, m.M14,
                m.M21, m.M22, m.M23, m.M24,
                m.M31, m.M32, m.M33, m.M34,
                m.M41, m.M42, m.M43, m.M44
            ];
        }
    }
}