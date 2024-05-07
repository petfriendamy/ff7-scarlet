using Shojy.FF7.Elena.Battle;

namespace FF7Scarlet.KernelEditor
{
    public class MenuCommand
    {
        public const int DATA_LENGTH = 8;

        public byte InitialCursorAction { get; set; }
        public TargetData TargetFlags { get; set; }
        public ushort CameraMovementIDSingle { get; set; }
        public ushort CameraMovementIDMulti { get; set; }

        public MenuCommand(byte[] data)
        {
            InitialCursorAction = data[0];
            TargetFlags = (TargetData)data[1];
            CameraMovementIDSingle = BitConverter.ToUInt16(data, 4);
            CameraMovementIDMulti = BitConverter.ToUInt16(data, 6);
        }

        public byte[] GetBytes()
        {
            var bytes = new byte[DATA_LENGTH];
            using (var ms = new MemoryStream(bytes))
            using (var writer = new BinaryWriter(ms))
            {
                writer.Write(InitialCursorAction);
                writer.Write((byte)TargetFlags);
                writer.Write(HexParser.NULL_OFFSET_16_BIT); //unknown
                writer.Write(CameraMovementIDSingle);
                writer.Write(CameraMovementIDMulti);
            }
            return bytes;
        }
    }
}
