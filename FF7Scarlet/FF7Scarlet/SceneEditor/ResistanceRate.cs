using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
