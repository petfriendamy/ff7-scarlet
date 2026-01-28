using OpenTK.Mathematics;

namespace KimeraCS.Core
{
    using static FF7BattleAnimation;

    using static FF7TEXTexture;
    using static FF7PModel;

    using static Utils;

    public static class FF7BattleSkeleton
    {

        //
        // Battle Skeleton Structure
        //
        public struct BattleSkeleton
        {
            public string fileName;
            public ModelType skeletonType;                 //  0 - Enemy Model, 1 - Battle Location, 2 - PC Battle Model?
            public int unk1;                               //  Always 1?
            public int unk2;                               //  Always 1?
            public int nBones;
            public int unk3;                               //  Always 0?
            public int nJoints;
            public int nTextures;
            public int nsSkeletonAnims;
            public int unk4;                               //  Num Skeleton Anims + 2?
            public int nWeapons;
            public int nsWeaponsAnims;
            public int unk5;                               //  Always 0?
            public int unk6;                             //  Global len?

            public List<BattleBone> bones;
            public List<TEX> textures;
            public List<PModel> wpModels;
            public uint[] TexIDS;
            public bool IsBattleLocation;

            //  Constructor for the Battle Skeleton (battle.lgp files with ??AA filename format)
            public BattleSkeleton(byte[] skeleton, byte[][] pFiles, byte[][] textureData, string name)
            {
                int pSuffix1, pSuffix2, pSuffix2End;
                string baseBattleSkeletonName;
                //string weaponFileName;
                string? strFileDirectoryName;
                int bi, ti, ji;

                //PModel tmpWPModel;
                TEX tmpTEX;

                BattleBone tmpbBone;

                fileName = Path.GetFileName(name).ToUpper();
                strFileDirectoryName = Path.GetDirectoryName(fileName);

                textures = new List<TEX>();
                bones = new List<BattleBone>();
                wpModels = new List<PModel>();

                // Read memory fileBuffer
                using (var fileMemory = new MemoryStream(skeleton))
                {
                    using (var memReader = new BinaryReader(fileMemory))
                    {
                        skeletonType = (ModelType)memReader.ReadInt32();
                        unk1 = memReader.ReadInt32();
                        unk2 = memReader.ReadInt32();
                        nBones = memReader.ReadInt32();

                        unk3 = memReader.ReadInt32();
                        nJoints = memReader.ReadInt32();
                        nTextures = memReader.ReadInt32();
                        nsSkeletonAnims = memReader.ReadInt32();

                        unk4 = memReader.ReadInt32();
                        nWeapons = memReader.ReadInt32();
                        nsWeaponsAnims = memReader.ReadInt32();
                        unk5 = memReader.ReadInt32();
                        unk6 = memReader.ReadInt32();

                        baseBattleSkeletonName = fileName.Substring(0, 2);
                        pSuffix1 = 'A';

                        if (nBones == 0)
                        {
                            // It's Battle Location
                            IsBattleLocation = true;

                            pSuffix1 = 'A';
                            pSuffix2 = 'M';

                            for (ji = 0; ji < nJoints; ji++)
                            {
                                if (pSuffix2 > 'Z')
                                {
                                    pSuffix2 = 'A';
                                    pSuffix1++;
                                }

                                tmpbBone = new BattleBone() 
                                {
                                    Models = new List<PModel>(),
                                };

                                LoadBattleLocationPiece(ref tmpbBone, nBones,
                                                        pFiles[ji], 
                                                        baseBattleSkeletonName + Convert.ToChar(pSuffix1) +
                                                                                    Convert.ToChar(pSuffix2));
                                nBones++;
                                bones.Add(tmpbBone);

                                pSuffix2++;
                            }
                        }
                        else
                        {
                            //  It's a character battle model
                            IsBattleLocation = false;

                            // Read Battle Bones files
                            pSuffix2 = 'M';
                            int modelPos = 0;
                            byte[] currModel;

                            for (bi = 0; bi < nBones; bi++)
                            {
                                if (pSuffix2 > 'Z')
                                {
                                    pSuffix1++;
                                    pSuffix2 = 'A';
                                }

                                currModel = Array.Empty<byte>();
                                if (modelPos < pFiles.Length)
                                {
                                    currModel = pFiles[modelPos];
                                }

                                bones.Add(new BattleBone(memReader, currModel,
                                                         baseBattleSkeletonName + Convert.ToChar(pSuffix1) +
                                                                                  Convert.ToChar(pSuffix2)));
                                modelPos += bones[bi].nModels;

                                pSuffix2++;
                            }

                            //  Read Battle Weapon files
                            /*pSuffix2End = 'K' + nWeapons;
                            ;
                            if (nWeapons > 0)
                            {
                                for (pSuffix2 = 'K'; pSuffix2 < pSuffix2End; pSuffix2++)
                                {
                                    weaponFileName = baseBattleSkeletonName + 'C' + Convert.ToChar(pSuffix2);

                                    if (File.Exists(strFileDirectoryName + "\\" + weaponFileName))
                                    {
                                        tmpWPModel = new PModel();

                                        LoadPModel(ref tmpWPModel, strFileDirectoryName, weaponFileName);
                                        wpModels.Add(tmpWPModel);
                                    }
                                    else
                                    {
                                        tmpWPModel = new PModel();
                                        wpModels.Add(tmpWPModel);
                                    }
                                }
                            }*/
                        }

                        //  Read Battle Textures files
                        TexIDS = new uint[nTextures];

                        textures = new List<TEX>();

                        ti = 0;

                        pSuffix2End = 'C' + nTextures;

                        for (pSuffix2 = 'C'; pSuffix2 < pSuffix2End; pSuffix2++)
                        {
                            tmpTEX = new TEX() 
                            {
                                TEXfileName = baseBattleSkeletonName.ToUpper() + "A" + Convert.ToChar(pSuffix2),
                            };
                                
                            if (ReadTEXTexture(ref tmpTEX, textureData[ti], tmpTEX.TEXfileName) == 0)
                            {
                                LoadTEXTexture(ref tmpTEX);
                                LoadBitmapFromTEXTexture(ref tmpTEX);
                            }

                            TexIDS[ti] = tmpTEX.texID;

                            textures.Add(tmpTEX);

                            ti++;
                        }
                    }
                }
            }
        }



        //
        // Battle Skeleton Bone Structure
        //
        public struct BattleBone
        {
            public int parentBone;
            public float len;
            public int hasModel;
            public List<PModel> Models;
            //  -------------Extra Atributes----------------
            public int nModels;
            public float resizeX;
            public float resizeY;
            public float resizeZ;

            public BattleBone(BinaryReader memReader, byte[] pFile, string modelName)
            {
                PModel tmpbPModel;

                parentBone = memReader.ReadInt32();
                len = memReader.ReadSingle();
                hasModel = memReader.ReadInt32();
                nModels = 0;

                Models = new List<PModel>();

                if (hasModel != 0 && pFile.Length > 0)
                {
                    nModels = 1;

                    tmpbPModel = new PModel();
                    LoadPModel(ref tmpbPModel, pFile, modelName);
                    Models.Add(tmpbPModel);
                }

                resizeX = 1;
                resizeY = 1;
                resizeZ = 1;
            }
        }

        public static void LoadBattleLocationPiece(ref BattleBone bBone, int boneIndex, byte[] pModel, string modelName)
        {
            PModel bLocBone;

            bBone.parentBone = boneIndex;
            bBone.hasModel = 1;
            bBone.nModels = 1;

            bLocBone = new PModel();
            LoadPModel(ref bLocBone, pModel, modelName);
            bBone.Models.Add(bLocBone);

            bBone.len = ComputeDiameter(bLocBone.BoundingBox) / 2;
            bBone.resizeX = 1;
            bBone.resizeY = 1;
            bBone.resizeZ = 1;
        }

        //
        // Battle Skeleton functions
        //
        public static void ComputeBattleBoneBoundingBox(BattleBone bBone, ref Vector3 p_min, ref Vector3 p_max)
        {
            int mi;
            double[] MV_matrix = new double[16];

            Vector3 p_min_aux;
            Vector3 p_max_aux;
            Vector3 p_min_aux_trans = new Vector3();
            Vector3 p_max_aux_trans = new Vector3();

            // Build base transform using pure math
            Matrix4 baseMatrix = Matrix4.CreateScale(bBone.resizeX, bBone.resizeY, bBone.resizeZ);

            if (bBone.hasModel == 1)
            {
                p_max.X = float.NegativeInfinity;
                p_max.Y = float.NegativeInfinity;
                p_max.Z = float.NegativeInfinity;

                p_min.X = float.PositiveInfinity;
                p_min.Y = float.PositiveInfinity;
                p_min.Z = float.PositiveInfinity;

                for (mi = 0; mi < bBone.nModels; mi++)
                {
                    // Build model transform
                    Matrix4 modelMatrix = baseMatrix;
                    modelMatrix *= Matrix4.CreateTranslation(bBone.Models[mi].repositionX, bBone.Models[mi].repositionY, bBone.Models[mi].repositionZ);
                    modelMatrix *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)bBone.Models[mi].rotateBeta));
                    modelMatrix *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians((float)bBone.Models[mi].rotateAlpha));
                    modelMatrix *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians((float)bBone.Models[mi].rotateGamma));
                    modelMatrix *= Matrix4.CreateScale(bBone.resizeX, bBone.resizeY, bBone.resizeZ);

                    p_min_aux.X = bBone.Models[mi].BoundingBox.min_x;
                    p_min_aux.Y = bBone.Models[mi].BoundingBox.min_y;
                    p_min_aux.Z = bBone.Models[mi].BoundingBox.min_z;

                    p_max_aux.X = bBone.Models[mi].BoundingBox.max_x;
                    p_max_aux.Y = bBone.Models[mi].BoundingBox.max_y;
                    p_max_aux.Z = bBone.Models[mi].BoundingBox.max_z;

                    MV_matrix = Matrix4ToDoubleArray(modelMatrix);

                    ComputeTransformedBoxBoundingBox(MV_matrix, ref p_min_aux, ref p_max_aux, ref p_min_aux_trans, ref p_max_aux_trans);

                    if (p_max.X < p_max_aux_trans.X) p_max.X = p_max_aux_trans.X;
                    if (p_max.Y < p_max_aux_trans.Y) p_max.Y = p_max_aux_trans.Y;
                    if (p_max.Z < p_max_aux_trans.Z) p_max.Z = p_max_aux_trans.Z;

                    if (p_min.X > p_min_aux_trans.X) p_min.X = p_min_aux_trans.X;
                    if (p_min.Y > p_min_aux_trans.Y) p_min.Y = p_min_aux_trans.Y;
                    if (p_min.Z > p_min_aux_trans.Z) p_min.Z = p_min_aux_trans.Z;
                }
            }
            else
            {
                p_max.X = 0;
                p_max.Y = 0;
                p_max.Z = 0;

                p_min.X = 0;
                p_min.Y = 0;
                p_min.Z = 0;
            }
        }

        public static void ComputeBattleBoundingBox(BattleSkeleton bSkeleton, BattleFrame bFrame, ref Vector3 p_min, ref Vector3 p_max)
        {
            double[] rot_mat = new double[16];
            double[] MV_matrix = new double[16];

            Vector3 p_max_bone = new Vector3();
            Vector3 p_min_bone = new Vector3();
            Vector3 p_max_bone_trans = new Vector3();
            Vector3 p_min_bone_trans = new Vector3();

            int[] joint_stack = new int[bSkeleton.nBones * 4];
            Matrix4[] matrixStack = new Matrix4[bSkeleton.nBones + 2];
            int matrixStackPtr = 0;
            int jsp, bi, iframeCnt;

            jsp = 0;
            joint_stack[jsp] = -1;

            p_max.X = float.NegativeInfinity;
            p_max.Y = float.NegativeInfinity;
            p_max.Z = float.NegativeInfinity;
            p_min.X = float.PositiveInfinity;
            p_min.Y = float.PositiveInfinity;
            p_min.Z = float.PositiveInfinity;

            // Build initial transform using pure math
            Matrix4 currentMatrix = Matrix4.Identity;
            currentMatrix *= Matrix4.CreateTranslation((float)bFrame.startX, (float)bFrame.startY, (float)bFrame.startZ);

            BuildRotationMatrixWithQuaternions(bFrame.bones[0].alpha, bFrame.bones[0].beta, bFrame.bones[0].gamma, ref rot_mat);
            Matrix4 rotMatrix = DoubleArrayToMatrix4(rot_mat);
            currentMatrix *= rotMatrix;

            matrixStack[matrixStackPtr++] = currentMatrix;

            for (bi = 0; bi < bSkeleton.nBones; bi++)
            {
                while (!(bSkeleton.bones[bi].parentBone == joint_stack[jsp]) && jsp > 0)
                {
                    matrixStackPtr--;
                    currentMatrix = matrixStack[matrixStackPtr];
                    jsp--;
                }
                matrixStack[matrixStackPtr++] = currentMatrix;

                if (bSkeleton.nBones > 1) iframeCnt = 1;
                else iframeCnt = 0;
                BuildRotationMatrixWithQuaternions(bFrame.bones[bi + iframeCnt].alpha,
                                                   bFrame.bones[bi + iframeCnt].beta,
                                                   bFrame.bones[bi + iframeCnt].gamma, ref rot_mat);
                rotMatrix = DoubleArrayToMatrix4(rot_mat);
                currentMatrix *= rotMatrix;

                ComputeBattleBoneBoundingBox(bSkeleton.bones[bi], ref p_min_bone, ref p_max_bone);

                MV_matrix = Matrix4ToDoubleArray(currentMatrix);

                ComputeTransformedBoxBoundingBox(MV_matrix, ref p_min_bone, ref p_max_bone, ref p_min_bone_trans, ref p_max_bone_trans);

                if (p_max.X < p_max_bone_trans.X) p_max.X = p_max_bone_trans.X;
                if (p_max.Y < p_max_bone_trans.Y) p_max.Y = p_max_bone_trans.Y;
                if (p_max.Z < p_max_bone_trans.Z) p_max.Z = p_max_bone_trans.Z;

                if (p_min.X > p_min_bone_trans.X) p_min.X = p_min_bone_trans.X;
                if (p_min.Y > p_min_bone_trans.Y) p_min.Y = p_min_bone_trans.Y;
                if (p_min.Z > p_min_bone_trans.Z) p_min.Z = p_min_bone_trans.Z;

                currentMatrix *= Matrix4.CreateTranslation(0, 0, bSkeleton.bones[bi].len);
                jsp++;
                joint_stack[jsp] = bi;
            }
        }

        /// <summary>
        /// Computes the bounding box for a battle skeleton in local model space only.
        /// Unlike ComputeBattleBoundingBox, this ignores the battle frame's start position (startX, startY, startZ).
        /// This is useful for model viewers where we want to center the model regardless of its battle position.
        /// </summary>
        /// <param name="bSkeleton">The battle skeleton</param>
        /// <param name="bFrame">The animation frame</param>
        /// <param name="p_min">Output parameter for the minimum bounding box point</param>
        /// <param name="p_max">Output parameter for the maximum bounding box point</param>
        public static void ComputeBattleBoundingBoxForViewer(BattleSkeleton bSkeleton, BattleFrame bFrame, ref Vector3 p_min, ref Vector3 p_max)
        {
            double[] rot_mat = new double[16];
            double[] MV_matrix = new double[16];

            Vector3 p_max_bone = new Vector3();
            Vector3 p_min_bone = new Vector3();
            Vector3 p_max_bone_trans = new Vector3();
            Vector3 p_min_bone_trans = new Vector3();

            int[] joint_stack = new int[bSkeleton.nBones * 4];
            Matrix4[] matrixStack = new Matrix4[bSkeleton.nBones + 2];
            int matrixStackPtr = 0;
            int jsp, bi, iframeCnt;

            jsp = 0;
            joint_stack[jsp] = -1;

            p_max.X = float.NegativeInfinity;
            p_max.Y = float.NegativeInfinity;
            p_max.Z = float.NegativeInfinity;
            p_min.X = float.PositiveInfinity;
            p_min.Y = float.PositiveInfinity;
            p_min.Z = float.PositiveInfinity;

            // Build initial transform using pure math - start with Identity (no battle position translation)
            // This ensures the bounding box is in local model space only
            Matrix4 currentMatrix = Matrix4.Identity;

            BuildRotationMatrixWithQuaternions(bFrame.bones[0].alpha, bFrame.bones[0].beta, bFrame.bones[0].gamma, ref rot_mat);
            Matrix4 rotMatrix = DoubleArrayToMatrix4(rot_mat);
            currentMatrix *= rotMatrix;

            matrixStack[matrixStackPtr++] = currentMatrix;

            for (bi = 0; bi < bSkeleton.nBones; bi++)
            {
                while (!(bSkeleton.bones[bi].parentBone == joint_stack[jsp]) && jsp > 0)
                {
                    matrixStackPtr--;
                    currentMatrix = matrixStack[matrixStackPtr];
                    jsp--;
                }
                matrixStack[matrixStackPtr++] = currentMatrix;

                if (bSkeleton.nBones > 1) iframeCnt = 1;
                else iframeCnt = 0;
                BuildRotationMatrixWithQuaternions(bFrame.bones[bi + iframeCnt].alpha,
                                                   bFrame.bones[bi + iframeCnt].beta,
                                                   bFrame.bones[bi + iframeCnt].gamma, ref rot_mat);
                rotMatrix = DoubleArrayToMatrix4(rot_mat);
                currentMatrix *= rotMatrix;

                ComputeBattleBoneBoundingBox(bSkeleton.bones[bi], ref p_min_bone, ref p_max_bone);

                MV_matrix = Matrix4ToDoubleArray(currentMatrix);

                ComputeTransformedBoxBoundingBox(MV_matrix, ref p_min_bone, ref p_max_bone, ref p_min_bone_trans, ref p_max_bone_trans);

                if (p_max.X < p_max_bone_trans.X) p_max.X = p_max_bone_trans.X;
                if (p_max.Y < p_max_bone_trans.Y) p_max.Y = p_max_bone_trans.Y;
                if (p_max.Z < p_max_bone_trans.Z) p_max.Z = p_max_bone_trans.Z;

                if (p_min.X > p_min_bone_trans.X) p_min.X = p_min_bone_trans.X;
                if (p_min.Y > p_min_bone_trans.Y) p_min.Y = p_min_bone_trans.Y;
                if (p_min.Z > p_min_bone_trans.Z) p_min.Z = p_min_bone_trans.Z;

                currentMatrix *= Matrix4.CreateTranslation(0, 0, bSkeleton.bones[bi].len);
                jsp++;
                joint_stack[jsp] = bi;
            }
        }
    }
}
