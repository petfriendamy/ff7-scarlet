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
            Vector3 p_min = new(), p_max = new();
            ComputeBattleBoundingBox(skeleton, frame, ref p_min, ref p_max);
            
            // Calculate model center
            Vector3 modelCenter = new Vector3(
                (p_min.X + p_max.X) / 2.0f,
                (p_min.Y + p_max.Y) / 2.0f,
                (p_min.Z + p_max.Z) / 2.0f);
            
            float sceneRadius = ComputeSceneRadius(p_min, p_max);
            
            return new CameraState
            {
                Alpha = 200,
                Beta = 45,
                Gamma = 0,
                Distance = -1.5f * sceneRadius,  // Reduced from -2 to make models fill more viewport
                PanX = -modelCenter.X,  // Offset to center model horizontally
                PanY = -modelCenter.Y,  // Offset to center model vertically
                PanZ = -modelCenter.Z   // Offset to center model in depth
            };
        }

        /// <summary>
        /// Resets camera for a P-Model based on its bounding box.
        /// Uses adjusted distance to make models fill more of the viewport while keeping them centered.
        /// </summary>
        /// <param name="model">The P-Model</param>
        /// <returns>Camera state configured to fit the model, centered and filling viewport</returns>
        public static CameraState ResetCameraForPModel(PModel model)
        {
            Vector3 p_min = new(), p_max = new();
            ComputePModelBoundingBox(model, ref p_min, ref p_max);
            
            // Calculate model center
            Vector3 modelCenter = new Vector3(
                (p_min.X + p_max.X) / 2.0f,
                (p_min.Y + p_max.Y) / 2.0f,
                (p_min.Z + p_max.Z) / 2.0f);
            
            float sceneRadius = ComputeSceneRadius(p_min, p_max);
            
            return new CameraState
            {
                Alpha = 200,
                Beta = 45,
                Gamma = 0,
                Distance = -1.5f * sceneRadius,  // Reduced from -2 to make models fill more viewport
                PanX = -modelCenter.X,  // Offset to center model horizontally
                PanY = -modelCenter.Y,  // Offset to center model vertically
                PanZ = -modelCenter.Z   // Offset to center model in depth
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
    }
}