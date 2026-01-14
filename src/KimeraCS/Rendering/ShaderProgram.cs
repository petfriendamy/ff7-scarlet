using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

namespace KimeraCS.Rendering
{
    public class ShaderProgram : IDisposable
    {
        public int Handle { get; private set; }
        private bool _disposed;

        public ShaderProgram(string vertexSource, string fragmentSource)
        {
            int vertexShader = CompileShader(ShaderType.VertexShader, vertexSource);
            int fragmentShader = CompileShader(ShaderType.FragmentShader, fragmentSource);

            Handle = GL.CreateProgram();
            GL.AttachShader(Handle, vertexShader);
            GL.AttachShader(Handle, fragmentShader);
            GL.LinkProgram(Handle);

            int success = GL.GetProgrami(Handle, ProgramProperty.LinkStatus);
            if (success == 0)
            {
                GL.GetProgramInfoLog(Handle, out string infoLog);
                throw new Exception($"Shader program linking failed: {infoLog}");
            }

            GL.DetachShader(Handle, vertexShader);
            GL.DetachShader(Handle, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
        }

        private static int CompileShader(ShaderType type, string source)
        {
            int shader = GL.CreateShader(type);
            GL.ShaderSource(shader, source);
            GL.CompileShader(shader);

            int success = GL.GetShaderi(shader, ShaderParameterName.CompileStatus);
            if (success == 0)
            {
                GL.GetShaderInfoLog(shader, out string infoLog);
                throw new Exception($"{type} compilation failed: {infoLog}");
            }

            return shader;
        }

        public void Use()
        {
            GL.UseProgram(Handle);
        }

        public int GetUniformLocation(string name)
        {
            return GL.GetUniformLocation(Handle, name);
        }

        public void SetBool(string name, bool value)
        {
            GL.Uniform1i(GetUniformLocation(name), value ? 1 : 0);
        }

        public void SetInt(string name, int value)
        {
            GL.Uniform1i(GetUniformLocation(name), value);
        }

        public void SetFloat(string name, float value)
        {
            GL.Uniform1f(GetUniformLocation(name), value);
        }

        public void SetVector3(string name, Vector3 value)
        {
            GL.Uniform3f(GetUniformLocation(name), value.X, value.Y, value.Z);
        }

        public void SetMatrix4(string name, Matrix4 value)
        {
            GL.UniformMatrix4f(GetUniformLocation(name), 1, false, ref value);
        }

        public void SetVector3Array(string baseName, Vector3[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                GL.Uniform3f(GetUniformLocation($"{baseName}[{i}]"), values[i].X, values[i].Y, values[i].Z);
            }
        }

        public void SetBoolArray(string baseName, bool[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                GL.Uniform1i(GetUniformLocation($"{baseName}[{i}]"), values[i] ? 1 : 0);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (Handle != 0)
                {
                    GL.DeleteProgram(Handle);
                    Handle = 0;
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ShaderProgram()
        {
            Dispose(false);
        }
    }
}
