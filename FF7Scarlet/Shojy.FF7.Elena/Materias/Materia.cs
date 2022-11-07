using Shojy.FF7.Elena.Battle;

namespace Shojy.FF7.Elena.Materias
{
    public class Materia
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level2AP { get; set; }
        public int Level3AP { get; set; }
        public int Level4AP { get; set; }
        public int Level5AP { get; set; }
        public Statuses Status { get; set; }
        public MateriaElements Element { get; set; }
        public MateriaType MateriaType { get; set; }
        public byte EquipEffect { get; set; }

        public static MateriaType GetMateriaType(byte data)
        {
            data = (byte)(data & 0x0F);

            switch (data)
            {
                case 0x2:
                case 0x3:
                case 0x6:
                case 0x7:
                case 0x8:
                    return MateriaType.Command;

                case 0x5:
                    return MateriaType.Support;

                case 0x9:
                case 0xA:
                    return MateriaType.Magic;

                case 0xB:
                case 0xC:
                    return MateriaType.Summon;

                case 0x0:
                case 0x1:
                case 0x4:
                case 0xD:
                case 0xE:
                case 0xF:
                default:
                    return MateriaType.Independent;
            }
        }
    }
}