using System.Dynamic;

namespace FF7Scarlet.Shared
{
    public class AdditionalEffects
    {
        public byte Value { get; }
        public string Description { get; }
        public bool HasModifier { get; }

        public AdditionalEffects(byte value, string description, bool hasModifier = false)
        {
            Value = value;
            Description = description;
            HasModifier = hasModifier;
        }

        public static readonly AdditionalEffects[] Effects = [
            new AdditionalEffects(0xFF, "None"),
            new AdditionalEffects(0x00, "Multiple hits (# of modifier)", true),
            new AdditionalEffects(0x01, "Performs Gunge Lance if enemies are immune to status"),
            new AdditionalEffects(0x02, "Summon Fat Chocobo if random 0-255 > modifier", true),
            new AdditionalEffects(0x03, "Caster becomes ID of modifier (Vincent limit break)", true),
            new AdditionalEffects(0x04, "If target row is modifier, do back attack damage", true),
            new AdditionalEffects(0x05, "End battle with no reward"),
            new AdditionalEffects(0x06, "Steal (Level * 20) gil from target"),
            new AdditionalEffects(0x07, "Steal an item from the target"),
            new AdditionalEffects(0x08, "Randomly select one of the next six animation indices to play"),
            new AdditionalEffects(0x09, "If attacker level = target level, multiply damage by 8"),
            new AdditionalEffects(0x0A, "Master Fist damage multiplier"),
            new AdditionalEffects(0x0B, "Powersoul damage multiplier"),
            new AdditionalEffects(0x0C, "Damage = 1 * # of KO'd allies"),
            new AdditionalEffects(0x0D, "Attack power = average target level"),
            new AdditionalEffects(0x0E, "Resurrect dead allies"),
            new AdditionalEffects(0x0F, "Cait Sith's Slots"),
            new AdditionalEffects(0x10, "Cait Sith's Transform"),
            new AdditionalEffects(0x11, "Remove target from battle (flag as dead)"),
            new AdditionalEffects(0x12, "Remove target from battle (flag as escaped)"),
            new AdditionalEffects(0x13, "Damage based on slot result (Tifa limit breaks)"),
            new AdditionalEffects(0x14, "Fill allies' limit gauges"),
            new AdditionalEffects(0x15, "Alter target's attack/defense by (modifier - 100)%", true),
            new AdditionalEffects(0x16, "Alter target's evasion by (modifier - 100)%", true),
            new AdditionalEffects(0x17, "Alter target's attack by (modifier - 100)%", true),
            new AdditionalEffects(0x18, "Perform attack ID of modifier upon completion", true),
            new AdditionalEffects(0x19, "Change target row"),
            new AdditionalEffects(0x1A, "Perform attack ID of modifier on other row members", true),
            new AdditionalEffects(0x1B, "Remove caster from battle"),
            new AdditionalEffects(0x1C, "Alter target's defense by (modifer - 100)%", true),
            new AdditionalEffects(0x1D, "Returns target from escaped status"),
            new AdditionalEffects(0x1E, "Attack power based on current HP"),
            new AdditionalEffects(0x1F, "Attack power based on current MP"),
            new AdditionalEffects(0x20, "Attack power based on current AP"),
            new AdditionalEffects(0x21, "Attack power based on character kills"),
            new AdditionalEffects(0x22, "Attack power based on limit level"),
            new AdditionalEffects(0x23, "Receive no rewards from target")
        ];

        public static int GetIndex(byte value)
        {
            var values =
                (from e in Effects
                 select e.Value).ToList();

            if (values.Contains(value))
            {
                return values.IndexOf(value);
            }
            return 0;
        }
    }
}
