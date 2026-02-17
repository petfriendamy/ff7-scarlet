using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.AIEditor
{
    public static class CommonVars
    {
        public enum Globals : ushort
        {
            CommandIndex = 0x2000, ActionIndex = 0x2008, TempGlobal = 0x2010, Dummy = 0x2018,
            BattleFormation = 0x2020, LimitLevel = 0x2038, ActiveActors = 0x2050, Self = 0x2060,
            Target = 0x2070, Allies = 0x2080, ActiveAllies = 0x2090, Enemies = 0x20A0,
            ActiveEnemies = 0x20B0, ActiveCharacters = 0x20C0, Actors = 0x20E0,
            BattleRewards = 0x2110, Elements = 0x2120, FormationIndex = 0x2140,
            ActionIndex2 = 0x2150, SpecialFlags = 0x2170, Gil = 0x21C0
        }

        public enum ActorGlobals : ushort
        {
            StatusEffects = 0x4000, ActorIndex = 0x4040, Level = 0x4048,
            ElementalDamageModifier = 0x4058, CharacterID = 0x4060, PhysicalAttackPower = 0x4068,
            MagicAttackPower = 0x4070, PhysicalEvade = 0x4078, IdleAnimation = 0x4080,
            DamagedAnimation = 0x4088, BackDamageModifier = 0x4090, ModelSize = 0x4098,
            Dexterity = 0x40A0, Luck = 0x40A8, CoveredCharacter = 0x40B8, Target = 0x40C0,
            PreviousAttacker = 0x40D0, PreviousPhysicalAttacker = 0x40E0,
            PreviousMagicalAttacker = 0x40F0, PhysicalDefense = 0x4100, MagicalDefense = 0x4110,
            ActorIndex2 = 0x4120, AbsorbedElements = 0x4130, CurrentMP = 0x4140, MaxMP = 0x4150,
            CurrentHP = 0x4160, MaxHP = 0x4180, InitialStatus = 0x4220, MagicEvade = 0x4268,
            Row = 0x4270, GilStolen = 0x4280, ItemStolen = 0x4290, NullifiedElements = 0x42A0,
            APReward = 0x42B0, GilReward = 0x42C0, EXPReward = 0x42E0
        }
    }
}
