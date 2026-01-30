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

        private static void DrawBattleSkeleton(RenderingContext renderContext, int weaponIndex, int currFrame = -1, Vector3? p_min = null, Vector3? p_max = null)
        {
            var modelData = renderContext.ModelData;
            if (modelData != null)
            {
                var bSkeleton = modelData.BattleSkeleton;
                var bAnimationsPack = modelData.BattleAnimations;
                var anim = renderContext.Animation;

                if (bAnimationsPack.SkeletonAnimations.Count == 0)
                    return;

                int animIndex = Math.Max(0, Math.Min(anim.AnimationIndex, bAnimationsPack.SkeletonAnimations.Count - 1));

                if (bAnimationsPack.SkeletonAnimations[animIndex].frames.Count == 0)
                    return;

                if (currFrame == -1)
                    currFrame = anim.CurrentFrame;

                currFrame = Math.Max(0, Math.Min(currFrame, bAnimationsPack.SkeletonAnimations[animIndex].frames.Count - 1));

                var bFrame = bAnimationsPack.SkeletonAnimations[animIndex].frames[currFrame];
                var wpFrame = new BattleFrame();
                if (bSkeleton.wpModels.Count > 0 && bAnimationsPack.WeaponAnimations.Count > 0)
                {
                    int wpAnimIndex = Math.Max(0, Math.Min(anim.AnimationIndex, bAnimationsPack.WeaponAnimations.Count - 1));
                    if (bAnimationsPack.WeaponAnimations[wpAnimIndex].frames.Count > 0)
                    {
                        int wpFrameIndex = Math.Max(0, Math.Min(anim.CurrentFrame, bAnimationsPack.WeaponAnimations[wpAnimIndex].frames.Count - 1));
                        wpFrame = bAnimationsPack.WeaponAnimations[wpAnimIndex].frames[wpFrameIndex];
                    }
                }
                int animWeaponIndex = anim.WeaponAnimationIndex;

                int iBoneIdx, jsp, itmpbones;
                int[] joint_stack = new int[bSkeleton.nBones + 1];
                double[] rot_mat = new double[16];

                Vector3 computedPMin, computedPMax;
                if (!p_min.HasValue || !p_max.HasValue)
                {
                    computedPMin = new Vector3();
                    computedPMax = new Vector3();
                    ComputeBattleBoundingBox(bSkeleton, bFrame, ref computedPMin, ref computedPMax);
                    p_min = computedPMin;
                    p_max = computedPMax;
                }
                else
                {
                    computedPMin = p_min.Value;
                    computedPMax = p_max.Value;
                }

                jsp = 0;
                joint_stack[jsp] = -1;

                if (bSkeleton.nBones > 1) itmpbones = 1;
                else itmpbones = 0;

                GL.MatrixMode(MatrixMode.Modelview);
                GL.PushMatrix();
                GL.Translated(bFrame.startX, bFrame.startY, bFrame.startZ);

                // Apply model rotation around center point
                if (renderContext.Transform.RotateX != 0 || renderContext.Transform.RotateY != 0)
                {
                    Vector3 center = new Vector3(
                        (computedPMin.X + computedPMax.X) / 2,
                        (computedPMin.Y + computedPMax.Y) / 2,
                        (computedPMin.Z + computedPMax.Z) / 2
                    );
                    GL.Translated(center.X, center.Y, center.Z);
                    GL.Rotated(renderContext.Transform.RotateY, 0, 1, 0);
                    GL.Rotated(renderContext.Transform.RotateX, 1, 0, 0);
                    GL.Translated(-center.X, -center.Y, -center.Z);
                }

                // Debug.Print bFrame.bones[0].alpha; ", "; bFrame.bones[0].Beta; ", "; bFrame.bones[0].Gamma
                if (bFrame.bones != null && bFrame.bones.Count > 0)
                {
                    BuildRotationMatrixWithQuaternions(bFrame.bones[0].alpha, bFrame.bones[0].beta, bFrame.bones[0].gamma, ref rot_mat);
                    GL.MultMatrixd(rot_mat);
                }

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

                        int boneFrameIndex = iBoneIdx + itmpbones;
                        if (bFrame.bones != null && boneFrameIndex < bFrame.bones.Count)
                        {
                            BuildRotationMatrixWithQuaternions(bFrame.bones[boneFrameIndex].alpha,
                                                               bFrame.bones[boneFrameIndex].beta,
                                                               bFrame.bones[boneFrameIndex].gamma,
                                                               ref rot_mat);
                            GL.MultMatrixd(rot_mat);
                        }

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

                    if (wpFrame.bones != null && wpFrame.bones.Count > 0)
                    {
                        BuildRotationMatrixWithQuaternions(wpFrame.bones[0].alpha, wpFrame.bones[0].beta, wpFrame.bones[0].gamma, ref rot_mat);
                        GL.MultMatrixd(rot_mat);
                    }

                    GL.MatrixMode(MatrixMode.Modelview);
                    GL.PushMatrix();

                    int wpModelIndex = Math.Max(0, Math.Min(weaponIndex, bSkeleton.wpModels.Count - 1));
                    GL.Translated(bSkeleton.wpModels[wpModelIndex].repositionX,
                                 bSkeleton.wpModels[wpModelIndex].repositionY,
                                 bSkeleton.wpModels[wpModelIndex].repositionZ);

                    GL.Rotated(bSkeleton.wpModels[wpModelIndex].rotateAlpha, 1, 0, 0);
                    GL.Rotated(bSkeleton.wpModels[wpModelIndex].rotateBeta, 0, 1, 0);
                    GL.Rotated(bSkeleton.wpModels[wpModelIndex].rotateGamma, 0, 0, 1);

                    GL.Scaled(bSkeleton.wpModels[wpModelIndex].resizeX, bSkeleton.wpModels[wpModelIndex].resizeY, bSkeleton.wpModels[wpModelIndex].resizeZ);

                    SetDefaultOGLRenderState();

                    PModel tmpwpModel = new PModel();
                    tmpwpModel = bSkeleton.wpModels[wpModelIndex];
                    DrawPModel(ref tmpwpModel, ref bSkeleton.TexIDS, false, renderContext);
                    bSkeleton.wpModels[wpModelIndex] = tmpwpModel;
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
                            ComputePModelBoundingBox(pModel, ref p_min, ref p_max);

                            SetCameraAroundModel(ref p_min, ref p_max,
                                                 ctx.Camera.PanX, ctx.Camera.PanY, ctx.Camera.PanZ + ctx.Camera.Distance,
                                                 ctx.Camera.Alpha, ctx.Camera.Beta, ctx.Camera.Gamma, 1, 1, 1);

                            SetLights(ctx.Lighting, (float)(-2 * ComputeSceneRadius(p_min, p_max)));

                            GL.MatrixMode(MatrixMode.Modelview);
                            GL.PushMatrix();

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

                            DrawPModel(ref pModel, ref texIds, false, ctx);

                            GL.PopMatrix();

                            break;

                        case ModelType.K_AA_SKELETON:
                        case ModelType.K_MAGIC_SKELETON:
                            int animIndex = ctx.Animation.AnimationIndex;
                            int currentFrame = ctx.Animation.CurrentFrame;

                            if (battleAnims.SkeletonAnimations.Count == 0)
                                break;

                            animIndex = Math.Max(0, Math.Min(animIndex, battleAnims.SkeletonAnimations.Count - 1));

                            if (battleAnims.SkeletonAnimations[animIndex].frames.Count == 0)
                                break;

                            currentFrame = Math.Max(0, Math.Min(currentFrame, battleAnims.SkeletonAnimations[animIndex].frames.Count - 1));

                            ComputeBattleBoundingBox(battleSkel, battleAnims.SkeletonAnimations[animIndex].frames[currentFrame],
                                                     ref p_min, ref p_max);

                            SetCameraAroundModel(ref p_min, ref p_max,
                                                 ctx.Camera.PanX, ctx.Camera.PanY, ctx.Camera.PanZ + ctx.Camera.Distance,
                                                 ctx.Camera.Alpha, ctx.Camera.Beta, ctx.Camera.Gamma, 1, 1, 1);

                            SetLights(ctx.Lighting, (float)(-2 * ComputeSceneRadius(p_min, p_max)));

                            DrawBattleSkeleton(ctx, 0, currentFrame, p_min, p_max);

                            GL.Disable(EnableCap.Lighting);

                            //SelectBattleBoneAndModel(battleSkel, battleAnims.SkeletonAnimations[ctx.Animation.AnimationIndex].frames[ctx.Animation.CurrentFrame],
                            //    tmpbFrame, ctx.Animation.WeaponAnimationIndex, ctx.Selection.SelectedBone, ctx.Selection.SelectedBonePiece);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw new KimeraException("Error Drawing current model.", ex);
                }
            }
        }

        private static void ApplyModelTransformAroundCenter(ModelTransform transform, Vector3 p_min, Vector3 p_max)
        {
            Vector3 center = new Vector3(
                (p_min.X + p_max.X) / 2,
                (p_min.Y + p_max.Y) / 2,
                (p_min.Z + p_max.Z) / 2
            );

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.Translated(center.X, center.Y, center.Z);
            GL.Rotated(transform.RotateY, 0, 1, 0);
            GL.Rotated(transform.RotateX, 1, 0, 0);
            GL.Translated(-center.X, -center.Y, -center.Z);
        }
    }
}

