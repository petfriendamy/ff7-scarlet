using KimeraCS.Core;
using OpenTK.Graphics.OpenGL.Compatibility;
using OpenTK.Mathematics;

#nullable enable
namespace KimeraCS.Rendering
{
    using static FF7BattleAnimation;
    using static FF7BattleAnimationsPack;

    using static FF7BattleSkeleton;
    using static FF7PModel;
    using static Lighting;
    using static Utils;

    public static class ModelDrawing
    {
        public static uint[] tex_ids = new uint[1];
        public const int LETTER_SIZE = 5;
        public const float DEFAULT_NORMAL_SCALE = 1.0f;
        public const int DEFAULT_NORMAL_COLOR = 2;


        //  ---------------------------------------------------------------------------------------------------
        //  ================================== GENERIC FIELD/BATTLE DRAW  =====================================
        //  ---------------------------------------------------------------------------------------------------
        private static void DrawPModel(ref PModel Model, ref uint[] tex_ids, bool HideHiddenGroupsQ,
                                      RenderingContext? renderContext = null)
        {
            // Get current legacy matrices - these contain the full camera + bone transforms
            double[] projMatrix = new double[16];
            GL.GetDouble(GetPName.ProjectionMatrix,projMatrix);
            var legacyProjection = ToMatrix4(projMatrix);

            double[] mvMatrix = new double[16];
            GL.GetDouble(GetPName.ModelviewMatrix,mvMatrix);
            var legacyModelView = ToMatrix4(mvMatrix);

            // Save original matrices
            var savedProjection = GLRenderer.ProjectionMatrix;
            var savedView = GLRenderer.ViewMatrix;
            var savedModel = GLRenderer.ModelMatrix;

            // Use the legacy matrices directly for full compatibility
            // This ensures bone transforms and camera setup match exactly
            GLRenderer.ProjectionMatrix = legacyProjection;
            GLRenderer.ViewMatrix = Matrix4.Identity;
            GLRenderer.ModelMatrix = legacyModelView;

            GLRenderer.DrawPModelModern(ref Model, tex_ids, HideHiddenGroupsQ);

            // Restore original matrices
            GLRenderer.ProjectionMatrix = savedProjection;
            GLRenderer.ViewMatrix = savedView;
            GLRenderer.ModelMatrix = savedModel;
        }


        //  ---------------------------------------------------------------------------------------------------
        //  ======================================== BATTLE DRAW  =============================================
        //  ---------------------------------------------------------------------------------------------------
        private static void DrawBattleSkeletonBone(BattleBone bBone, uint[] texIDS, RenderingContext renderContext)
        {
            int iModelIdx;
            PModel tmpbModel = new PModel();

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.Scaled(bBone.resizeX, bBone.resizeY, bBone.resizeZ);

            if (bBone.hasModel > 0)
            {

                for (iModelIdx = 0; iModelIdx < bBone.nModels; iModelIdx++)
                {

                    GL.PushMatrix();
                    GL.Translated(bBone.Models[iModelIdx].repositionX, 
                                    bBone.Models[iModelIdx].repositionY, 
                                    bBone.Models[iModelIdx].repositionZ);

                    GL.Rotated(bBone.Models[iModelIdx].rotateAlpha, 1, 0, 0);
                    GL.Rotated(bBone.Models[iModelIdx].rotateBeta, 0, 1, 0);
                    GL.Rotated(bBone.Models[iModelIdx].rotateGamma, 0, 0, 1);

                    GL.Scaled(bBone.Models[iModelIdx].resizeX, 
                                bBone.Models[iModelIdx].resizeY, 
                                bBone.Models[iModelIdx].resizeZ);
                        
                    SetDefaultOGLRenderState();

                    tmpbModel = bBone.Models[iModelIdx];
                    DrawPModel(ref tmpbModel, ref texIDS, false, renderContext);
                    bBone.Models[iModelIdx] = tmpbModel;

                    GL.PopMatrix();
                }
            }

            GL.PopMatrix();
        }

        private static void DrawBattleSkeleton(RenderingContext renderContext, int weaponIndex,
                                               float centerX = 0, float centerY = 0, float centerZ = 0,
                                               int currFrame = -1, bool ignoreBattlePosition = false)
        {
            var modelData = renderContext.ModelData;
            if (modelData != null)
            {
                var bSkeleton = modelData.BattleSkeleton;
                var bAnimationsPack = modelData.BattleAnimations;
                var anim = renderContext.Animation;
                if (currFrame == -1)
                    currFrame = anim.CurrentFrame;
                var bFrame = bAnimationsPack.SkeletonAnimations[anim.AnimationIndex].frames[currFrame];
                var wpFrame = new BattleFrame();
                if (bSkeleton.wpModels.Count > 0 && bAnimationsPack.WeaponAnimations.Count > 0)
                {
                    wpFrame = bAnimationsPack.WeaponAnimations[anim.AnimationIndex].frames[anim.CurrentFrame];
                }
                int animWeaponIndex = anim.WeaponAnimationIndex;

                int iBoneIdx, jsp, itmpbones;
                int[] joint_stack = new int[bSkeleton.nBones + 1];
                double[] rot_mat = new double[16];

                jsp = 0;
                joint_stack[jsp] = -1;

                if (bSkeleton.nBones > 1) itmpbones = 1;
                else itmpbones = 0;

                GL.MatrixMode(MatrixMode.Modelview);
                GL.PushMatrix();

                // First position the skeleton at its world location
                // When ignoreBattlePosition is true, we skip this for model viewer centering
                if (!ignoreBattlePosition)
                {
                    GL.Translated(bFrame.startX, bFrame.startY, bFrame.startZ);
                }

                // Then apply centering to move the model's center to origin
                // This ensures rotation happens around the model's center
                GL.Translated(-centerX, -centerY, -centerZ);

                // Debug.Print bFrame.bones[0].alpha; ", "; bFrame.bones[0].Beta; ", "; bFrame.bones[0].Gamma
                BuildRotationMatrixWithQuaternions(bFrame.bones[0].alpha, bFrame.bones[0].beta, bFrame.bones[0].gamma, ref rot_mat);
                GL.MultMatrixd(rot_mat);

                for (iBoneIdx = 0; iBoneIdx < bSkeleton.nBones; iBoneIdx++)
                {
                    if (bSkeleton.IsBattleLocation)
                    {
                        DrawBattleSkeletonBone(bSkeleton.bones[iBoneIdx], bSkeleton.TexIDS, renderContext);
                    }
                    else
                    {
                        while (!(bSkeleton.bones[iBoneIdx].parentBone == joint_stack[jsp]) && jsp > 0)
                        {
                            GL.PopMatrix();
                            jsp--;
                        }

                        GL.PushMatrix();

                        // -- Commented in KimeraVB6
                        //GL.Rotated(bFrame.bones[bi + 1].beta, 0, 1, 0);
                        //GL.Rotated(bFrame.bones[bi + 1].alpha, 1, 0, 0);
                        //GL.Rotated(bFrame.bones[bi + 1].gamma, 0, 0, 1);

                        BuildRotationMatrixWithQuaternions(bFrame.bones[iBoneIdx + itmpbones].alpha,
                                                           bFrame.bones[iBoneIdx + itmpbones].beta,
                                                           bFrame.bones[iBoneIdx + itmpbones].gamma,
                                                           ref rot_mat);
                        GL.MultMatrixd(rot_mat);

                        DrawBattleSkeletonBone(bSkeleton.bones[iBoneIdx], bSkeleton.TexIDS,
                                               renderContext);

                        GL.Translated(0, 0, bSkeleton.bones[iBoneIdx].len);

                        jsp++;
                        joint_stack[jsp] = iBoneIdx;
                    }
                }

                if (!bSkeleton.IsBattleLocation)
                {
                    while (jsp > 0)
                    {
                        GL.PopMatrix();
                        jsp--;
                    }
                }
                GL.PopMatrix();

                //if (weaponIndex > -1 && bSkeleton.nWeapons > 0)       // -- Commented in KimeraVB6
                if (animWeaponIndex > -1 && bSkeleton.wpModels.Count > 0 && bAnimationsPack.WeaponAnimations.Count > 0)
                {
                    GL.PushMatrix();
                    GL.Translated(wpFrame.startX, wpFrame.startY, wpFrame.startZ);

                    // -- Commented in KimeraVB6
                    //GL.Rotated(wpFrame.bones[0].beta, 0, 1, 0);
                    //GL.Rotated(wpFrame.bones[0].alpha, 1, 0, 0);
                    //GL.Rotated(wpFrame.bones[0].gamma, 0, 0, 1);

                    BuildRotationMatrixWithQuaternions(wpFrame.bones[0].alpha, wpFrame.bones[0].beta, wpFrame.bones[0].gamma, ref rot_mat);
                    GL.MultMatrixd(rot_mat);

                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.PushMatrix();

                    GL.Translated(bSkeleton.wpModels[weaponIndex].repositionX,
                                 bSkeleton.wpModels[weaponIndex].repositionY,
                                 bSkeleton.wpModels[weaponIndex].repositionZ);

                    GL.Rotated(bSkeleton.wpModels[weaponIndex].rotateAlpha, 1, 0, 0);
                    GL.Rotated(bSkeleton.wpModels[weaponIndex].rotateBeta, 0, 1, 0);
                    GL.Rotated(bSkeleton.wpModels[weaponIndex].rotateGamma, 0, 0, 1);

                    GL.Scaled(bSkeleton.wpModels[weaponIndex].resizeX, bSkeleton.wpModels[weaponIndex].resizeY, bSkeleton.wpModels[weaponIndex].resizeZ);

                    SetDefaultOGLRenderState();

                    PModel tmpwpModel = new PModel();
                    tmpwpModel = bSkeleton.wpModels[weaponIndex];
                    DrawPModel(ref tmpwpModel, ref bSkeleton.TexIDS, false, renderContext);
                    bSkeleton.wpModels[weaponIndex] = tmpwpModel;
                    GL.PopMatrix();

                    GL.PopMatrix();
                }
            }
        }



        //  ---------------------------------------------------------------------------------------------------
        //  ======================================= SKELETON DRAW  ============================================
        //  ---------------------------------------------------------------------------------------------------

        /// <summary>
        /// Draws the current skeleton/model using the provided context.
        /// If ctx.ModelData is set, uses that model data (fully decoupled).
        /// Otherwise falls back to static model data for backward compatibility.
        /// </summary>
        public static void DrawSkeletonModel(RenderingContext ctx)
        {
            double[] rot_mat = new double[16];

            Vector3 p_min = new Vector3();
            Vector3 p_max = new Vector3();

            // Use context model data if provided, otherwise fall back to statics
            var modelData = ctx.ModelData;
            if (modelData != null)
            {
                PModel pModel = modelData.PModel;
                uint[] texIds = modelData.TextureIds;
                BattleSkeleton battleSkel = modelData.BattleSkeleton;
                BattleAnimationsPack battleAnims = modelData.BattleAnimations;

                try
                {
                    switch (ctx.ModelType)
                    {
                        case ModelType.K_3DS_MODEL:
                        case ModelType.K_P_FIELD_MODEL:
                        case ModelType.K_P_BATTLE_MODEL:
                        case ModelType.K_P_MAGIC_MODEL:
                        {
                            ComputePModelBoundingBox(pModel, ref p_min, ref p_max);

                            // Calculate model dimensions and center
                            float modelWidth = p_max.X - p_min.X;
                            float modelHeight = p_max.Y - p_min.Y;
                            float modelDepth = p_max.Z - p_min.Z;

                            float centerX = p_min.X + (modelWidth * 0.5f);
                            float centerY = p_min.Y + (modelHeight * 0.5f);
                            float centerZ = p_min.Z + (modelDepth * 0.5f);

                            // For P-Model, the bounding box is in local space (before model transforms)
                            // The camera should look at the center of where the model WILL be after transforms
                            // Estimated world center = local center + model reposition
                            float worldCenterX = centerX + pModel.repositionX;
                            float worldCenterY = centerY + pModel.repositionY;
                            float worldCenterZ = centerZ + pModel.repositionZ;

                            // Position camera to look at the world center
                            float cameraX = worldCenterX + ctx.Camera.PanX;
                            float cameraY = worldCenterY + ctx.Camera.PanY;
                            float cameraZ = worldCenterZ + ctx.Camera.PanZ + ctx.Camera.Distance;

                            SetCameraAroundModel(ref p_min, ref p_max,
                                                 cameraX, cameraY, cameraZ,
                                                 ctx.Camera.Alpha, ctx.Camera.Beta, ctx.Camera.Gamma, 1, 1, 1);

                            SetLights(ctx.Lighting, (float)(-2 * ComputeSceneRadius(p_min, p_max)));

                            GL.MatrixMode(MatrixMode.Modelview);
                            GL.PushMatrix();

                            // Apply model's own transformations first
                            GL.Translated(pModel.repositionX,
                                         pModel.repositionY,
                                         pModel.repositionZ);

                            BuildRotationMatrixWithQuaternionsXYZ(pModel.rotateAlpha,
                                                                  pModel.rotateBeta,
                                                                  pModel.rotateGamma,
                                                                  ref rot_mat);

                            GL.MultMatrixd(rot_mat);
                            GL.Scaled(pModel.resizeX,
                                     pModel.resizeY,
                                     pModel.resizeZ);

                            // After all model transforms, center the model at origin
                            // The local center (centerX, centerY, centerZ) is now in the transformed space
                            GL.Translated(-centerX, -centerY, -centerZ);

                            DrawPModel(ref pModel, ref texIds, false, ctx);

                            GL.PopMatrix();

                            break;
                        }

                        case ModelType.K_AA_SKELETON:
                        case ModelType.K_MAGIC_SKELETON:
                        {
                            // Compute local model bounding box (without battle position)
                            // This gives us the model's bounds in its own local space
                            ComputeBattleBoundingBoxForViewer(battleSkel, battleAnims.SkeletonAnimations[ctx.Animation.AnimationIndex].frames[ctx.Animation.CurrentFrame],
                                                     ref p_min, ref p_max);

                            // Calculate model center in local space
                            float centerX = (p_min.X + p_max.X) * 0.5f;
                            float centerY = (p_min.Y + p_max.Y) * 0.5f;
                            float centerZ = (p_min.Z + p_max.Z) * 0.5f;

                            // Calculate scene radius for camera distance
                            float sceneRadius = ComputeSceneRadius(p_min, p_max);

                            // Following the reference implementation pattern:
                            // Camera position = -center + pan (to bring model to origin) + distance
                            // This way the model appears at origin and rotations happen around center
                            float cameraX = -centerX + ctx.Camera.PanX;
                            float cameraY = -centerY + ctx.Camera.PanY;
                            float cameraZ = -centerZ + ctx.Camera.PanZ + ctx.Camera.Distance;

                            SetCameraAroundModel(ref p_min, ref p_max,
                                                 cameraX, cameraY, cameraZ,
                                                 ctx.Camera.Alpha, ctx.Camera.Beta, ctx.Camera.Gamma, 1, 1, 1);

                            SetLights(ctx.Lighting, -2.0f * sceneRadius);

                            GL.MatrixMode(MatrixMode.Modelview);
                            GL.PushMatrix();

                            // Draw skeleton - no additional centering needed since camera handles it
                            // But we still need to pass the center values for the bone translation
                            DrawBattleSkeleton(ctx, 0, 0, 0, 0, -1, true);

                            GL.PopMatrix();

                            GL.Disable(EnableCap.Lighting);

                            //SelectBattleBoneAndModel(battleSkel, battleAnims.SkeletonAnimations[ctx.Animation.AnimationIndex].frames[ctx.Animation.CurrentFrame],
                            //    tmpbFrame, ctx.Animation.WeaponAnimationIndex, ctx.Selection.SelectedBone, ctx.Selection.SelectedBonePiece);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new KimeraException("Error Drawing current model.", ex);
                }
            }
        }
    }
}

