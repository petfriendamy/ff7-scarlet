#version 330 core

in vec4 VertexColor;
out vec4 FragColor;

void main()
{
    // Simple circular point with smooth edges
    vec2 circCoord = 2.0 * gl_PointCoord - 1.0;
    float dist = dot(circCoord, circCoord);

    // Discard fragments outside the circle
    if (dist > 1.0)
        discard;

    // Soft edge
    float alpha = 1.0 - smoothstep(0.8, 1.0, dist);
    FragColor = vec4(VertexColor.rgb, VertexColor.a * alpha);
}
