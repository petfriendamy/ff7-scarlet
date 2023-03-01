using Shojy.FF7.Elena.Battle;

namespace FF7Scarlet.SceneEditor
{
    public enum ResistRates : byte
    {
        Death, Double = 2, Half = 4, Null, Absorb, FullCure
    }

    public abstract class ResistanceRate
    {
        public ResistRates Rate { get; protected set; }

        public abstract byte GetID();
        public virtual string GetText()
        {
            switch (Rate)
            {
                case ResistRates.Death:
                    return "Killed by";
                case ResistRates.Double:
                    return "2x damage from";
                case ResistRates.Half:
                    return "Half damage from";
                case ResistRates.Null:
                    return "Nullifies damage from";
                case ResistRates.Absorb:
                    return "Absorbs damage from";
                case ResistRates.FullCure:
                    return "Fully cured by";
                default:
                    return "(none)";
            }
        }
    }

    public class ElementResistanceRate : ResistanceRate
    {
        public MateriaElements Element { get; }

        public ElementResistanceRate(MateriaElements element, ResistRates rate)
        {
            Element = element;
            Rate = rate;
        }

        public override byte GetID()
        {
            return (byte)Element;
        }

        public override string GetText()
        {
            return base.GetText() + ' ' + Element.ToString();
        }
    }

    public class StatusResistanceRate : ResistanceRate
    {
        public EquipmentStatus Status { get; }

        public StatusResistanceRate(EquipmentStatus status, ResistRates rate)
        {
            Status = status;
            Rate = rate;
        }

        public override byte GetID()
        {
            return (byte)(Status + 0x20);
        }

        public override string GetText()
        {
            return base.GetText() + ' ' + Status.ToString() + " (status attack)";
        }
    }
}
