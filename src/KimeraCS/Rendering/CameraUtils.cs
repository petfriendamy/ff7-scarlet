using KimeraCS.Core;
using OpenTK.Mathematics;

namespace KimeraCS.Rendering
{
    using static FF7BattleSkeleton;
    using static FF7BattleAnimation;
    using static FF7PModel;
    using static Utils;

    /// <summary>
    /// Utility class for camera calculations and management.
    /// Follows Single Responsibility Principle by handling only camera-related logic.
    /// </summary>
    public static class CameraUtils
    {
        /// <summary>
        /// Gets default camera state with standard rotation angles and no offset.
        /// </summary>
        public static CameraState GetDefaultCameraState()
        {
            return new CameraState
            {
                Alpha = 0,
                Beta = 0,
                Gamma = 0,
                Distance = -10,
                PanX = 0,
                PanY = 0,
                PanZ = 0
            };
        }

        /// <summary>
        /// Resets camera for a skeleton model based on its bounding box.
        /// Uses adjusted distance to make models fill more of the viewport while keeping them centered.
        /// </summary>
        /// <param name="skeleton">The skeleton model</param>
        /// <param name="frame">The animation frame to calculate bounding box from</param>
        /// <returns>Camera state configured to fit the model, centered and filling viewport</returns>
        public static CameraState ResetCameraForSkeleton(BattleSkeleton skeleton, BattleFrame frame)
        {
            return ResetCameraForSkeleton(skeleton, frame, 0, 0);
        }

        /// <summary>
        /// Resets camera for a skeleton model based on its bounding box.
        /// Automatically fits the model to the viewport size with proper centering.
        /// </summary>
        /// <param name="skeleton">The skeleton model</param>
        /// <param name="frame">The animation frame to calculate bounding box from</param>
        /// <param name="viewportWidth">Width of the viewport (0 to use default)</param>
        /// <param name="viewportHeight">Height of the viewport (0 to use default)</param>
        /// <returns>Camera state configured to fit the model, centered and filling viewport</returns>
        public static CameraState ResetCameraForSkeleton(BattleSkeleton skeleton, BattleFrame frame, int viewportWidth, int viewportHeight)
        {
            Vector3 p_min = new(), p_max = new();
            ComputeBattleBoundingBox(skeleton, frame, ref p_min, ref p_max);

            // Calculate model center
            Vector3 modelCenter = new Vector3(
                (p_min.X + p_max.X) / 2.0f,
                (p_min.Y + p_max.Y) / 2.0f,
                (p_min.Z + p_max.Z) / 2.0f);

            // Calculate model dimensions
            float modelWidth = p_max.X - p_min.X;
            float modelHeight = p_max.Y - p_min.Y;
            float modelDepth = p_max.Z - p_min.Z;

            // Use the larger model dimension to ensure it fits
            float maxModelDimension = Math.Max(modelWidth, Math.Max(modelHeight, modelDepth));

            // Calculate distance to fit the model in the viewport
            float distance;
            if (viewportWidth > 0 && viewportHeight > 0)
            {
                // Use aspect ratio to determine proper distance
                float aspectRatio = (float)viewportWidth / viewportHeight;

                // Calculate distance based on FOV (60 degrees) and model size
                // tan(30°) ≈ 0.577, so we use this to fit the model
                float fovFactor = 1.155f; // 2 * tan(30°)

                // Calculate distance needed to fit the model with padding
                distance = -(maxModelDimension / fovFactor * 1.5f);
            }
            else
            {
                // Default: use scene radius
                float sceneRadius = ComputeSceneRadius(p_min, p_max);
                distance = -1.5f * sceneRadius;
            }

            // Don't set pan - let the rendering system handle centering
            // The pan will be handled by SetCameraAroundModel which uses the bounding box
            return new CameraState
            {
                Alpha = 180,
                Beta = 0,
                Gamma = 0,
                Distance = distance,
                PanX = 0,
                PanY = 0,
                PanZ = 0
            };
        }

        /// <summary>
        /// Resets camera for a P-Model based on its bounding box.
        /// Automatically fits the model to the viewport size with proper centering.
        /// </summary>
        /// <param name="model">The P-Model</param>
        /// <returns>Camera state configured to fit the model, centered and filling viewport</returns>
        public static CameraState ResetCameraForPModel(PModel model)
        {
            return ResetCameraForPModel(model, 0, 0);
        }

        /// <summary>
        /// Resets camera for a P-Model based on its bounding box.
        /// Automatically fits the model to the viewport size with proper centering.
        /// </summary>
        /// <param name="model">The P-Model</param>
        /// <param name="viewportWidth">Width of the viewport (0 to use default)</param>
        /// <param name="viewportHeight">Height of the viewport (0 to use default)</param>
        /// <returns>Camera state configured to fit the model, centered and filling viewport</returns>
        public static CameraState ResetCameraForPModel(PModel model, int viewportWidth, int viewportHeight)
        {
            Vector3 p_min = new(), p_max = new();
            ComputePModelBoundingBox(model, ref p_min, ref p_max);

            // Calculate model dimensions
            float modelWidth = p_max.X - p_min.X;
            float modelHeight = p_max.Y - p_min.Y;
            float modelDepth = p_max.Z - p_min.Z;

            // Use the larger model dimension to ensure it fits
            float maxModelDimension = Math.Max(modelWidth, Math.Max(modelHeight, modelDepth));

            // Calculate distance to fit the model in the viewport
            float distance;
            if (viewportWidth > 0 && viewportHeight > 0)
            {
                // Calculate distance based on FOV (60 degrees) and model size
                // tan(30°) ≈ 0.577, so we use this to fit the model
                float fovFactor = 1.155f; // 2 * tan(30°)

                // Calculate distance needed to fit the model with padding
                distance = -(maxModelDimension / fovFactor * 1.5f);
            }
            else
            {
                // Default: use scene radius
                float sceneRadius = ComputeSceneRadius(p_min, p_max);
                distance = -1.5f * sceneRadius;
            }

            // Don't set pan - rendering system handles centering from bounding box
            return new CameraState
            {
                Alpha = 180,
                Beta = 0,
                Gamma = 0,
                Distance = distance,
                PanX = 0,
                PanY = 0,
                PanZ = 0
            };
        }

        /// <summary>
        /// Calculates the zoom delta for mouse wheel scrolling based on model diameter.
        /// This provides proportional zoom relative to model size.
        /// </summary>
        /// <param name="modelDiameter">The model's diameter</param>
        /// <param name="mouseDelta">The mouse wheel delta</param>
        /// <returns>The amount to adjust camera distance</returns>
        public static float CalculateZoomDelta(float modelDiameter, int mouseDelta)
        {
            return mouseDelta * modelDiameter / 1000f;
        }

        /// <summary>
        /// Calculates the scene radius from a bounding box.
        /// The radius is half the diagonal distance plus the distance from center to origin.
        /// </summary>
        /// <param name="p_min">Minimum bounding box point</param>
        /// <param name="p_max">Maximum bounding box point</param>
        /// <returns>The scene radius</returns>
        public static float ComputeSceneRadius(Vector3 p_min, Vector3 p_max)
        {
            float modelRadius, distanceOrigin;

            Vector3 centerModel = new Vector3(
                (p_min.X + p_max.X) / 2.0f,
                (p_min.Y + p_max.Y) / 2.0f,
                (p_min.Z + p_max.Z) / 2.0f);

            Vector3 origin = new Vector3(0, 0, 0);

            modelRadius = CalculateDistance(p_min, p_max) / 2;
            distanceOrigin = CalculateDistance(centerModel, origin);

            return modelRadius + distanceOrigin;
        }

        /// <summary>
        /// Calculates the distance between two 3D points.
        /// </summary>
        private static float CalculateDistance(Vector3 v0, Vector3 v1)
        {
            float deltaX = v1.X - v0.X;
            float deltaY = v1.Y - v0.Y;
            float deltaZ = v1.Z - v0.Z;

            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }

        /// <summary>
        /// Represents a positioned model for scene-wide bounding box computation.
        /// </summary>
        public struct PositionedModel
        {
            public BattleSkeleton Skeleton;
            public BattleFrame Frame;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
        }

        /// <summary>
        /// Computes a scene-wide bounding box that includes all positioned models.
        /// This is used for model viewers that display multiple enemies in formation.
        /// </summary>
        /// <param name="models">Array of positioned models</param>
        /// <param name="p_min">Output parameter for the minimum bounding box point</param>
        /// <param name="p_max">Output parameter for the maximum bounding box point</param>
        /// <param name="sceneCenter">Output parameter for the calculated scene center</param>
        /// <returns>The scene radius for camera distance calculation</returns>
        public static float ComputeSceneBoundingBox(PositionedModel[] models, ref Vector3 p_min, ref Vector3 p_max, ref Vector3 sceneCenter)
        {
            p_min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            p_max = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            if (models.Length == 0)
            {
                // Default to origin if no models
                p_min = new Vector3(-1, -1, -1);
                p_max = new Vector3(1, 1, 1);
                sceneCenter = new Vector3(0, 0, 0);
                return 1.0f;
            }

            // Aggregate bounding boxes from all positioned models
            for (int i = 0; i < models.Length; i++)
            {
                Vector3 modelMin = new(), modelMax = new();
                ComputeBattleBoundingBoxAtPosition(
                    models[i].Skeleton,
                    models[i].Frame,
                    models[i].PositionX,
                    models[i].PositionY,
                    models[i].PositionZ,
                    ref modelMin,
                    ref modelMax);

                // Union with overall bounds
                if (modelMin.X < p_min.X) p_min.X = modelMin.X;
                if (modelMin.Y < p_min.Y) p_min.Y = modelMin.Y;
                if (modelMin.Z < p_min.Z) p_min.Z = modelMin.Z;

                if (modelMax.X > p_max.X) p_max.X = modelMax.X;
                if (modelMax.Y > p_max.Y) p_max.Y = modelMax.Y;
                if (modelMax.Z > p_max.Z) p_max.Z = modelMax.Z;
            }

            // Calculate scene center
            sceneCenter = new Vector3(
                (p_min.X + p_max.X) / 2.0f,
                (p_min.Y + p_max.Y) / 2.0f,
                (p_min.Z + p_max.Z) / 2.0f);

            // Calculate scene radius
            float modelRadius = CalculateDistance(p_min, p_max) / 2.0f;
            Vector3 origin = new Vector3(0, 0, 0);
            float distanceOrigin = CalculateDistance(sceneCenter, origin);

            return modelRadius + distanceOrigin;
        }

        /// <summary>
        /// Resets camera for a centered scene based on scene-wide bounding box.
        /// The scene is translated so its center is at the origin, ensuring rotations
        /// happen around the scene center rather than an offset point.
        /// </summary>
        /// <param name="sceneMin">Minimum scene bounding box point</param>
        /// <param name="sceneMax">Maximum scene bounding box point</param>
        /// <param name="sceneCenter">Center of the scene (for reference)</param>
        /// <param name="viewportWidth">Width of the viewport</param>
        /// <param name="viewportHeight">Height of the viewport</param>
        /// <returns>Camera state configured to fit the scene, centered at origin</returns>
        public static CameraState ResetCameraForCenteredScene(Vector3 sceneMin, Vector3 sceneMax, Vector3 sceneCenter,
                                                               int viewportWidth, int viewportHeight)
        {
            // Calculate scene dimensions
            float sceneWidth = sceneMax.X - sceneMin.X;
            float sceneHeight = sceneMax.Y - sceneMin.Y;
            float sceneDepth = sceneMax.Z - sceneMin.Z;

            // Use the larger dimension to ensure it fits
            float maxDimension = Math.Max(sceneWidth, Math.Max(sceneHeight, sceneDepth));

            // Calculate distance to fit the scene in the viewport
            float distance;
            if (viewportWidth > 0 && viewportHeight > 0)
            {
                float fovFactor = 1.155f; // 2 * tan(30°)
                distance = -(maxDimension / fovFactor * 1.5f);
            }
            else
            {
                float sceneRadius = ComputeSceneRadius(sceneMin, sceneMax);
                distance = -2.0f * sceneRadius;
            }

            // The scene will be centered at origin during drawing, so camera looks at origin
            return new CameraState
            {
                Alpha = 180,
                Beta = 0,
                Gamma = 0,
                Distance = distance,
                PanX = 0,
                PanY = 0,
                PanZ = 0
            };
        }
    }
}