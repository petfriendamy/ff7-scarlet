#version 330 core

in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoord;
in vec4 VertexColor;

uniform sampler2D texture0;
uniform bool useTexture;
uniform bool enableLighting;

// Multi-light support (4 lights: Right, Left, Front, Rear)
#define MAX_LIGHTS 4
uniform vec3 lightPos[MAX_LIGHTS];
uniform vec3 lightColor[MAX_LIGHTS];
uniform bool lightEnabled[MAX_LIGHTS];

// View position (reserved for future use)
uniform vec3 viewPos;
uniform float ambientStrength;

// Alpha test
uniform bool enableAlphaTest;
uniform float alphaRef;

// Base alpha multiplier (set based on blend mode)
uniform float baseAlpha;

// Override color for wireframe mode
uniform bool useOverrideColor;
uniform vec3 overrideColor;

out vec4 FragColor;

void main()
{
    // Override color mode (for wireframe rendering)
    if (useOverrideColor)
    {
        FragColor = vec4(overrideColor, 1.0);
        return;
    }

    // Sample texture or use white if no texture
    vec4 texColor = useTexture ? texture(texture0, TexCoord) : vec4(1.0);

    // Combine with vertex color
    vec4 baseColor = texColor * VertexColor;

    // Alpha test
    if (enableAlphaTest && baseColor.a <= alphaRef)
        discard;

    vec3 result;

    if (enableLighting)
    {
        vec3 norm = normalize(Normal);

        // Ambient base
        vec3 ambient = ambientStrength * vec3(1.0);
        vec3 totalDiffuse = vec3(0.0);

        // Accumulate lighting from all enabled lights
        for (int i = 0; i < MAX_LIGHTS; i++)
        {
            if (lightEnabled[i])
            {
                vec3 lightDir = normalize(lightPos[i] - FragPos);
                float NdotL = dot(norm, lightDir);

                // Standard Lambertian diffuse (matches legacy renderer)
                float diffuse = max(NdotL, 0.0);

                totalDiffuse += diffuse * lightColor[i];
            }
        }

        result = (ambient + totalDiffuse) * baseColor.rgb;
    }
    else
    {
        // No lighting - use raw color (matches legacy renderer)
        result = baseColor.rgb;
    }

    // Clamp to valid range
    result = clamp(result, 0.0, 1.0);

    // Apply base alpha (set based on blend mode - 0.5 for BLEND_AVG, 1.0 otherwise)
    FragColor = vec4(result, baseColor.a * baseAlpha);
}
