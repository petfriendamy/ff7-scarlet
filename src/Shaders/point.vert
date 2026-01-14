#version 330 core

layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec4 aColor;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform float pointSize;

out vec4 VertexColor;

void main()
{
    gl_Position = projection * view * model * vec4(aPosition, 1.0);
    gl_PointSize = pointSize;
    VertexColor = aColor;
}
