using KimeraCS.Core;

namespace KimeraCS.Rendering
{
    using static FF7PModel;
    using static FF7BattleSkeleton;
    using static FF7BattleAnimationsPack;

    /// <summary>
    /// Camera state for 3D viewport rendering.
    /// </summary>
    public struct CameraState
    {
        public float Alpha;     // X-axis rotation
        public float Beta;      // Y-axis rotation
        public float Gamma;     // Z-axis rotation
        public float Distance;  // Camera distance from origin
        public float PanX;      // Horizontal pan offset
        public float PanY;      // Vertical pan offset
        public float PanZ;      // Depth pan offset

        public static CameraState Default => new CameraState
        {
            Alpha = 0,
            Beta = 0,
            Gamma = 0,
            Distance = -10,
            PanX = 0,
            PanY = 0,
            PanZ = 0
        };

        /// <summary>
        /// Creates a copy of this camera state with adjusted distance.
        /// </summary>
        public CameraState WithDistance(float newDistance)
        {
            var result = this;
            result.Distance = newDistance;
            return result;
        }

        /// <summary>
        /// Creates a copy of this camera state with adjusted pan values.
        /// </summary>
        public CameraState WithPan(float panX, float panY, float panZ)
        {
            var result = this;
            result.PanX = panX;
            result.PanY = panY;
            result.PanZ = panZ;
            return result;
        }

        /// <summary>
        /// Creates a copy of this camera state with adjusted rotation angles.
        /// </summary>
        public CameraState WithRotation(float alpha, float beta, float gamma)
        {
            var result = this;
            result.Alpha = alpha;
            result.Beta = beta;
            result.Gamma = gamma;
            return result;
        }
    }

    /// <summary>
    /// Model transformation state (resize/reposition).
    /// </summary>
    public struct ModelTransform
    {
        public float ResizeX;
        public float ResizeY;
        public float ResizeZ;
        public float RepositionX;
        public float RepositionY;
        public float RepositionZ;

        public static ModelTransform Default => new ModelTransform
        {
            ResizeX = 1,
            ResizeY = 1,
            ResizeZ = 1,
            RepositionX = 0,
            RepositionY = 0,
            RepositionZ = 0
        };
    }

    /// <summary>
    /// Lighting configuration for the renderer.
    /// </summary>
    public struct LightingConfig
    {
        public bool FrontLightEnabled;
        public bool RearLightEnabled;
        public bool RightLightEnabled;
        public bool LeftLightEnabled;
        public float PosXScroll;
        public float PosYScroll;
        public float PosZScroll;

        public static LightingConfig Default => new LightingConfig
        {
            FrontLightEnabled = true,
            RearLightEnabled = false,
            RightLightEnabled = false,
            LeftLightEnabled = false,
            PosXScroll = 0,
            PosYScroll = 0,
            PosZScroll = 0
        };

        public bool AnyLightEnabled => FrontLightEnabled || RearLightEnabled || RightLightEnabled || LeftLightEnabled;
    }

    /// <summary>
    /// Animation playback state.
    /// </summary>
    public struct AnimationState
    {
        public int CurrentFrame;
        public int AnimationIndex;
        public int WeaponAnimationIndex;

        public static AnimationState Default => new AnimationState
        {
            CurrentFrame = 0,
            AnimationIndex = 0,
            WeaponAnimationIndex = -1
        };
    }

    /// <summary>
    /// Model data for rendering. Contains the actual models and animations
    /// needed for different model types.
    /// </summary>
    public class SkeletonModelData
    {
        // P-Model data (for K_P_FIELD_MODEL, K_P_BATTLE_MODEL, K_P_MAGIC_MODEL, K_3DS_MODEL)
        public PModel PModel { get; set; }
        public uint[] TextureIds { get; set; } = Array.Empty<uint>();

        // Battle skeleton data (for K_AA_SKELETON, K_MAGIC_SKELETON)
        public BattleSkeleton BattleSkeleton { get; set; }
        public BattleAnimationsPack BattleAnimations { get; set; }
    }

    /// <summary>
    /// Complete rendering context combining all state needed for rendering.
    /// This allows Core rendering functions to be independent of form state.
    /// </summary>
    public class RenderingContext
    {
        public ModelType ModelType { get; set; }
        public CameraState Camera { get; set; }
        public ModelTransform Transform { get; set; }
        public LightingConfig Lighting { get; set; }
        public AnimationState Animation { get; set; }
        public SkeletonModelData? ModelData { get; set; }

        public RenderingContext()
        {
            Camera = CameraState.Default;
            Transform = ModelTransform.Default;
            Lighting = LightingConfig.Default;
            Animation = AnimationState.Default;
            ModelData = null; // Must be set by caller if using context-based rendering
        }

        /// <summary>
        /// Creates a context with model data for fully decoupled rendering.
        /// Use this from external applications that have their own model data.
        /// </summary>
        public static RenderingContext CreateWithModelData(
            ModelType modelType,
            SkeletonModelData modelData,
            CameraState camera,
            AnimationState animation,
            LightingConfig lighting)
        {
            return new RenderingContext
            {
                ModelType = modelType,
                Camera = camera,
                Animation = animation,
                Lighting = lighting,
                ModelData = modelData
            };
        }
    }
}
