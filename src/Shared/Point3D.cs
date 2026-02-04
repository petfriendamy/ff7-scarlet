using OpenTK.Mathematics;

namespace FF7Scarlet.Shared
{
    public struct Point3D
    {
        public short X { get; }
        public short Y { get; }
        public short Z { get; }

        public Point3D(short x, short y, short z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3 ToOpenTK()
        {
            return new Vector3(X, Y, Z);
        }
    }
}
