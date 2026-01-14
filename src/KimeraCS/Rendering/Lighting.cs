using OpenTK.Mathematics;

namespace KimeraCS.Rendering
{
    class Lighting
    {
        public const int LIGHT_STEPS = 20;

        // Light indices (matches GLRenderer arrays)
        public const int LIGHT_RIGHT = 0;
        public const int LIGHT_LEFT = 1;
        public const int LIGHT_FRONT = 2;
        public const int LIGHT_REAR = 3;

        /// <summary>
        /// Modern lighting setup using provided configuration.
        /// This overload is decoupled from FrmSkeletonEditor and can be used in other applications.
        /// </summary>
        /// <param name="config">Lighting configuration specifying which lights are enabled and their positions.</param>
        /// <param name="sceneDiameter">The diameter of the scene, used to scale light positions.</param>
        public static void SetLights(LightingConfig config, float sceneDiameter)
        {
            GLRenderer.LightingEnabled = config.AnyLightEnabled;

            if (!config.AnyLightEnabled)
                return;

            float light_x = sceneDiameter / LIGHT_STEPS * config.PosXScroll;
            float light_y = sceneDiameter / LIGHT_STEPS * config.PosYScroll;
            float light_z = sceneDiameter / LIGHT_STEPS * config.PosZScroll;

            // Right light
            GLRenderer.LightEnabled[LIGHT_RIGHT] = config.RightLightEnabled;
            if (config.RightLightEnabled)
            {
                GLRenderer.LightPositions[LIGHT_RIGHT] = new Vector3(light_z, light_y, light_x);
                GLRenderer.LightColors[LIGHT_RIGHT] = new Vector3(0.5f, 0.5f, 0.5f);
            }

            // Left light
            GLRenderer.LightEnabled[LIGHT_LEFT] = config.LeftLightEnabled;
            if (config.LeftLightEnabled)
            {
                GLRenderer.LightPositions[LIGHT_LEFT] = new Vector3(-light_z, light_y, light_x);
                GLRenderer.LightColors[LIGHT_LEFT] = new Vector3(0.5f, 0.5f, 0.5f);
            }

            // Front light
            GLRenderer.LightEnabled[LIGHT_FRONT] = config.FrontLightEnabled;
            if (config.FrontLightEnabled)
            {
                GLRenderer.LightPositions[LIGHT_FRONT] = new Vector3(light_x, light_y, light_z);
                GLRenderer.LightColors[LIGHT_FRONT] = new Vector3(1f, 1f, 1f);
            }

            // Rear light
            GLRenderer.LightEnabled[LIGHT_REAR] = config.RearLightEnabled;
            if (config.RearLightEnabled)
            {
                GLRenderer.LightPositions[LIGHT_REAR] = new Vector3(light_x, light_y, -light_z);
                GLRenderer.LightColors[LIGHT_REAR] = new Vector3(0.75f, 0.75f, 0.75f);
            }
        }
    }
}
