namespace FF7Scarlet
{
    public class Point3D
    {
        public ushort X { get; }
        public ushort Y { get; }
        public ushort Z { get; }

        public Point3D(ushort x, ushort y, ushort z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
