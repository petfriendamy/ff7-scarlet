using Shojy.FF7.Elena.Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.KernelEditor
{
    public class MenuCommand
    {
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
    }
}
