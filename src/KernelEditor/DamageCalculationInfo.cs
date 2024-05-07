using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public enum DamageType { Physical, Magical }
    public enum AccuracyCalculation
    {
        NoMiss1, NoMiss2, Normal, HitChanceModTargetLevel, Manip
    }
    public enum DamageFormulas
    {
        NoDamage, Standard, Simple, CurrHPPercentage, MaxHPPercentage, SimpleStronger, StaticDamage, PowerDividedBy32, Recovery, Throw, Coin,
        UsersHP, UsersMaxMinusCurrHP, DiceRoll, NumOfEscapes, LeaveWith1HP, TimeOnClock,
        TargetKills, AireTamStorm, MasterFist, Powersoul, DeadAllies,
        TargetLevelAverage, CurrHPMultiplier, CurrMPMultiplier, MissingScore, DeathPenalty,
        PremiumHeart
    }

    public class DamageCalculationInfo
    {
        //private members
        private static readonly Dictionary<AccuracyCalculation, string> AccuracyDescriptions =
            new Dictionary<AccuracyCalculation, string>
            {
                { AccuracyCalculation.NoMiss1, "Never misses (type 1)" },
                { AccuracyCalculation.NoMiss2, "Never misses (type 2)" },
                { AccuracyCalculation.Normal, "Uses accuracy stat" },
                { AccuracyCalculation.HitChanceModTargetLevel, "Hit Chance % Target Level" },
                { AccuracyCalculation.Manip, "\"Manipulate\" formula" }
            };
        private static readonly Dictionary<DamageFormulas, string> FormulaDescriptions =
            new Dictionary<DamageFormulas, string>
            {
                { DamageFormulas.NoDamage, "No damage" },
                { DamageFormulas.Standard, "(Power / 16) * (Stat + ((Level + Stat) / 32) * ((Level + Stat) / 32)" },
                { DamageFormulas.Simple, "(Power / 16) * ((Level + Stat) * 6)" },
                { DamageFormulas.CurrHPPercentage, "Curr HP * (Power / 32)" },
                { DamageFormulas.MaxHPPercentage, "Max HP * (Power / 32)" },
                { DamageFormulas.SimpleStronger, "(Power * 22) + ((Level + Stat) * 6)" },
                { DamageFormulas.StaticDamage, "Power * 20 (static)" },
                { DamageFormulas.PowerDividedBy32, "Power / 32" },
                { DamageFormulas.Recovery, "Fully recovers HP and MP" },
                { DamageFormulas.Throw, "\"Throw\" formula" },
                { DamageFormulas.Coin, "\"Coin\" formula" },
                { DamageFormulas.UsersHP, "User's Current HP" },
                { DamageFormulas.UsersMaxMinusCurrHP, "User's Max HP - Curr HP" },
                { DamageFormulas.DiceRoll, "Dice Roll * 100" },
                { DamageFormulas.NumOfEscapes, "Number of escapes * 256" },
                { DamageFormulas.LeaveWith1HP, "Target's curr HP - 1" },
                { DamageFormulas.TimeOnClock, "(Hours * 100) + Minutes" },
                { DamageFormulas.TargetKills, "Target's kill count * 10" },
                { DamageFormulas.AireTamStorm, "Target's # of materia * 1111" },
                { DamageFormulas.MasterFist, "Increased damage with status effects on user" },
                { DamageFormulas.Powersoul, "Increased damage from Near Death and/or Death Sentence" },
                { DamageFormulas.DeadAllies, "Increased damage from deceased allies" },
                { DamageFormulas.TargetLevelAverage, "Attack power is average level of targets" },
                { DamageFormulas.CurrHPMultiplier, "Attack power based on current HP" },
                { DamageFormulas.CurrMPMultiplier, "Attack power based on current MP" },
                { DamageFormulas.MissingScore, "Attack power based on weapon AP" },
                { DamageFormulas.DeathPenalty, "Attack power based on user's kill count" },
                { DamageFormulas.PremiumHeart, "Attack power based on user's limit bar" }
            };

        private byte actualValue;
        private DamageType damageType;
        private AccuracyCalculation accuracyCalculation;
        private DamageFormulas damageFormula;
        private bool canCrit;

        //properties
        public byte ActualValue
        {
            get
            {
                if (IsNull) { return 0xFF; }
                else { return actualValue; }
            }
            set
            {
                actualValue = value;
                IsNull = (value == 0xFF);
                if (!IsNull)
                {
                    try
                    {
                        DamageType = GetDamageType(value);
                        CanCrit = GetIfCanCrit(value);
                        AccuracyCalculation = GetAccuracyCalculation(value);
                        DamageFormula = GetDamageFormula(value);
                    }
                    catch (ArgumentException)
                    {
                        IsValid = false;
                    }
                }
            }
        }
        public DamageType DamageType
        {
            get { return damageType; }
            set
            {
                byte newValue = GetNewActualValue(value);
                IsValid = (newValue != 0xFF);
                if (IsValid) { actualValue = newValue; }
                damageType = value;
            }
        }
        public AccuracyCalculation AccuracyCalculation
        {
            get { return accuracyCalculation; }
            set
            {
                byte newValue = GetNewActualValue(value);
                IsValid = (newValue != 0xFF);
                if (IsValid) { actualValue = newValue; }
                accuracyCalculation = value;
            }
        }
        public bool CanCrit
        {
            get { return canCrit; }
            set
            {
                byte newValue = GetNewActualValue(value);
                IsValid = (newValue != 0xFF);
                if (IsValid) { actualValue = newValue; }
                canCrit = value;
            }
        }
        public DamageFormulas DamageFormula
        {
            get { return damageFormula; }
            set
            {
                byte newValue = GetNewActualValue(value);
                IsValid = (newValue != 0xFF);
                if (IsValid) { actualValue = newValue; }
                damageFormula = value;
            }
        }
        public bool IsValid { get; private set; }
        public bool IsNull { get; set; }


        //constructor
        public DamageCalculationInfo(byte actualValue)
        {
            ActualValue = actualValue;
        }


        //functions
        public static string GetAccuracyCalcDesctiption(AccuracyCalculation calc)
        {
            return AccuracyDescriptions[calc];
        }

        public static string GetFormulaDescription(DamageFormulas form)
        {
            return FormulaDescriptions[form];
        }

        private byte GetLowerNybble(DamageFormulas form)
        {
            switch (form)
            {
                case DamageFormulas.NoDamage:
                case DamageFormulas.UsersHP:
                case DamageFormulas.MasterFist:
                    return 0x0;
                case DamageFormulas.Standard:
                case DamageFormulas.UsersMaxMinusCurrHP:
                case DamageFormulas.Powersoul:
                    return 0x1;
                case DamageFormulas.Simple:
                case DamageFormulas.DeadAllies:
                    return 0x2;
                case DamageFormulas.CurrHPPercentage:
                case DamageFormulas.TargetLevelAverage:
                    return 0x3;
                case DamageFormulas.MaxHPPercentage:
                case DamageFormulas.CurrHPMultiplier:
                    return 0x4;
                case DamageFormulas.SimpleStronger:
                case DamageFormulas.CurrMPMultiplier:
                    return 0x5;
                case DamageFormulas.StaticDamage:
                case DamageFormulas.MissingScore:
                    return 0x6;
                case DamageFormulas.PowerDividedBy32:
                case DamageFormulas.DeathPenalty:
                    return 0x7;
                case DamageFormulas.Recovery:
                case DamageFormulas.DiceRoll:
                case DamageFormulas.PremiumHeart:
                    return 0x8;
                case DamageFormulas.Throw:
                case DamageFormulas.NumOfEscapes:
                    return 0x9;
                case DamageFormulas.Coin:
                case DamageFormulas.LeaveWith1HP:
                    return 0xA;
                case DamageFormulas.TimeOnClock:
                    return 0xB;
                case DamageFormulas.TargetKills:
                    return 0xC;
                case DamageFormulas.AireTamStorm:
                    return 0xD;
                default:
                    return 0;
            }
        }

        private DamageType GetDamageType(byte actualValue)
        {
            byte upper = HexParser.GetUpperNybble(actualValue);
            if (upper > 0xB) { throw new ArgumentException("Invalid value."); }
            else
            {
                switch (upper)
                {
                    case 0x2:
                    case 0x4:
                    case 0x5:
                    case 0x7:
                    case 0x8:
                    case 0x9:
                        return DamageType.Magical;
                    default:
                        return DamageType.Physical;
                }
            }
        }

        private bool GetIfCanCrit(byte actualValue)
        {
            byte upper = HexParser.GetUpperNybble(actualValue);
            if (upper > 0xB) { throw new ArgumentException("Invalid value."); }
            else
            {
                switch (upper)
                {
                    case 0x1:
                    case 0x6:
                    case 0xA:
                        return true;
                    default:
                        return false;
                }
            }
        }

        private AccuracyCalculation GetAccuracyCalculation(byte actualValue)
        {
            byte upper = HexParser.GetUpperNybble(actualValue);
            if (upper > 0xB) { throw new ArgumentException("Invalid value."); }
            else
            {
                switch (upper)
                {
                    case 0x0:
                    case 0x4:
                        return AccuracyCalculation.NoMiss1;
                    case 0x3:
                    case 0x5:
                        return AccuracyCalculation.NoMiss2;
                    case 0x8:
                        return AccuracyCalculation.HitChanceModTargetLevel;
                    case 0x9:
                        return AccuracyCalculation.Manip;
                    default:
                        return AccuracyCalculation.Normal;
                }
            }
        }

        private DamageFormulas GetDamageFormula(byte actualValue)
        {
            byte upper = HexParser.GetUpperNybble(actualValue),
                lower = HexParser.GetLowerNybble(actualValue);

            if (upper > 0xB) { throw new ArgumentException("Invalid value."); }
            else
            {
                if (upper == 0x6 || upper == 0x7) //special formulas
                {
                    switch (lower)
                    {
                        case 0x0:
                            return DamageFormulas.UsersHP;
                        case 0x1:
                            return DamageFormulas.UsersMaxMinusCurrHP;
                        case 0x8:
                            return DamageFormulas.DiceRoll;
                        case 0x9:
                            return DamageFormulas.NumOfEscapes;
                        case 0xA:
                            return DamageFormulas.LeaveWith1HP;
                        case 0xB:
                            return DamageFormulas.TimeOnClock;
                        case 0xC:
                            return DamageFormulas.TargetKills;
                        case 0xD:
                            return DamageFormulas.AireTamStorm;
                    }
                }
                else if (upper == 0xA) //damage multipliers
                {
                    switch (lower)
                    {
                        case 0x0:
                            return DamageFormulas.MasterFist;
                        case 0x1:
                            return DamageFormulas.Powersoul;
                        case 0x2:
                            return DamageFormulas.DeadAllies;
                        case 0x3:
                            return DamageFormulas.TargetLevelAverage;
                        case 0x4:
                            return DamageFormulas.CurrHPMultiplier;
                        case 0x5:
                            return DamageFormulas.CurrMPMultiplier;
                        case 0x6:
                            return DamageFormulas.MissingScore;
                        case 0x7:
                            return DamageFormulas.DeathPenalty;
                        case 0x8:
                            return DamageFormulas.PremiumHeart;
                    }
                }
                else //normal formulas
                {
                    switch (lower)
                    {
                        case 0x0:
                            return DamageFormulas.NoDamage;
                        case 0x1:
                            return DamageFormulas.Standard;
                        case 0x2:
                            return DamageFormulas.Simple;
                        case 0x3:
                            return DamageFormulas.CurrHPPercentage;
                        case 0x4:
                            return DamageFormulas.MaxHPPercentage;
                        case 0x5:
                            return DamageFormulas.SimpleStronger;
                        case 0x6:
                            return DamageFormulas.StaticDamage;
                        case 0x7:
                            return DamageFormulas.PowerDividedBy32;
                        case 0x8:
                            return DamageFormulas.Recovery;
                        case 0x9:
                            return DamageFormulas.Throw;
                        case 0xA:
                            return DamageFormulas.Coin;
                    }
                }
            }
            throw new ArgumentException("Invalid value.");
        }

        private bool IsSpecialFormula(DamageFormulas form)
        {
            return form > DamageFormulas.Coin;
        }

        public bool IsSpecialFormula()
        {
            return IsSpecialFormula(DamageFormula);
        }

        public bool UsesModifier()
        {
            return UsesModifier(DamageFormula);
        }

        private bool UsesModifier(DamageFormulas form)
        {
            return form > DamageFormulas.AireTamStorm;
        }

        private byte GetNewActualValue(DamageType type, AccuracyCalculation calc, bool canCrit,
            DamageFormulas form)
        {
            //checks if the current combination is valid
            byte lower = GetLowerNybble(form);
            if (canCrit && (type == DamageType.Magical || AccuracyCalculation != AccuracyCalculation.Normal))
            {
                return 0xFF;
            }
            else if (type == DamageType.Physical && calc > AccuracyCalculation.Normal)
            {
                return 0xFF;
            }
            else if (UsesModifier(form))
            {
                if (DamageType == DamageType.Magical || !canCrit) { return 0xFF; }
                else { return HexParser.MergeNybbles(0xA, lower); }
            }
            else if (IsSpecialFormula(form))
            {
                if (DamageType == DamageType.Physical)
                {
                    if (!canCrit) { return 0xFF; }
                    else { return HexParser.MergeNybbles(0x6, lower); }
                }
                else { return HexParser.MergeNybbles(0x7, lower); }
            }
            else
            {
                switch (calc)
                {
                    case AccuracyCalculation.NoMiss1:
                        if (type == DamageType.Physical) { return HexParser.MergeNybbles(0x0, lower); }
                        else { return HexParser.MergeNybbles(0x4, lower); }
                    case AccuracyCalculation.NoMiss2:
                        if (type == DamageType.Physical) { return HexParser.MergeNybbles(0x3, lower); }
                        else { return HexParser.MergeNybbles(0x5, lower); }
                    case AccuracyCalculation.Normal:
                        if (type == DamageType.Physical)
                        {
                            if (canCrit) { return HexParser.MergeNybbles(0x1, lower); }
                            else { return HexParser.MergeNybbles(0xB, lower); }
                        }
                        else { return HexParser.MergeNybbles(0x2, lower); }
                    case AccuracyCalculation.HitChanceModTargetLevel:
                        return HexParser.MergeNybbles(0x8, lower);
                    case AccuracyCalculation.Manip:
                        return HexParser.MergeNybbles(0x9, lower);
                }
            }
            return 0;
        }

        private byte GetNewActualValue(DamageType type)
        {
            return GetNewActualValue(type, AccuracyCalculation, CanCrit, DamageFormula);
        }

        private byte GetNewActualValue(AccuracyCalculation calc)
        {
            return GetNewActualValue(DamageType, calc, CanCrit, DamageFormula);
        }

        private byte GetNewActualValue(bool canCrit)
        {
            return GetNewActualValue(DamageType, AccuracyCalculation, canCrit, DamageFormula);
        }

        private byte GetNewActualValue(DamageFormulas form)
        {
            return GetNewActualValue(DamageType, AccuracyCalculation, CanCrit, form);
        }
    }
}
