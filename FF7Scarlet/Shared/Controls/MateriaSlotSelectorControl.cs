using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Materias;

namespace FF7Scarlet.Shared.Controls
{
    public enum SlotSelectorType { Slots, Equips }

    public partial class MateriaSlotSelectorControl : UserControl
    {
        private const int SLOT_COUNT = 8;
        private SlotSelectorType slotSelectorType;
        private readonly MateriaSlot[] slots = new MateriaSlot[SLOT_COUNT];
        private readonly Materia?[] equippedMateria = new Materia?[SLOT_COUNT];
        private GrowthRate growthRate;
        private PictureBox[] pictureBoxes;
        private ContextMenuStrip[] menuStrips = new ContextMenuStrip[SLOT_COUNT];
        private int selectedSlot = -1;

        public SlotSelectorType SlotSelectorType
        {
            get { return slotSelectorType; }
            set
            {
                slotSelectorType = value;
                if (value == SlotSelectorType.Slots)
                {
                    //create the context menu strips for each slot
                    for (int i = 0; i < SLOT_COUNT; ++i)
                    {
                        menuStrips[i] = new ContextMenuStrip();

                        var menuItem = new ToolStripMenuItem("No slot");
                        menuItem.Click += new EventHandler(EmptySlotMenu_Clicked);
                        menuStrips[i].Items.Add(menuItem);

                        menuItem = new ToolStripMenuItem("Unlinked slot");
                        menuItem.Click += new EventHandler(UnlinkedSlotMenu_Clicked);
                        menuStrips[i].Items.Add(menuItem);

                        menuItem = new ToolStripMenuItem("Left linked slot");
                        menuItem.Click += new EventHandler(LeftLinkedSlotMenu_Clicked);
                        if (i == SLOT_COUNT - 1) { menuItem.Enabled = false; }
                        menuStrips[i].Items.Add(menuItem);

                        menuItem = new ToolStripMenuItem("Right linked slot");
                        menuItem.Click += new EventHandler(RightLinkedSlotMenu_Clicked);
                        if (i == 0) { menuItem.Enabled = false; }
                        menuStrips[i].Items.Add(menuItem);

                        pictureBoxes[i].ContextMenuStrip = menuStrips[i];
                    }
                }
                else
                {
                    for (int i = 0; i < SLOT_COUNT; ++i)
                    {
                        pictureBoxes[i].ContextMenuStrip = null;
                        pictureBoxes[i].Click += new EventHandler(Slot_Clicked);
                    }
                }
            }
        }

        public GrowthRate GrowthRate
        {
            get { return growthRate; }
            set
            {
                for (int i = 0; i < SLOT_COUNT; ++i)
                {
                    SetSlotInner(i, GetMatchingSlot(slots[i]), value, true, true);
                }
                growthRate = value;
            }
        }

        public int SelectedSlot
        {
            get { return selectedSlot; }
            set
            {
                selectedSlot = value;
                for (int i = 0; i < SLOT_COUNT; ++i)
                {
                    if (i == value)
                    {
                        pictureBoxes[i].BackColor = Color.LightBlue;
                    }
                    else
                    {
                        pictureBoxes[i].BackColor = Color.Transparent;
                    }
                }
            }
        }

        public MateriaSlotSelectorControl()
        {
            InitializeComponent();
            pictureBoxes = new PictureBox[SLOT_COUNT]
            {
                pictureBoxSlot1, pictureBoxSlot2, pictureBoxSlot3, pictureBoxSlot4, pictureBoxSlot5,
                pictureBoxSlot6, pictureBoxSlot7, pictureBoxSlot8
            };
        }

        private Image GetMatchingImage(MateriaSlot slot, Materia? equipped)
        {
            if (equipped != null) //materia is equipped
            {
                var fixedSlot = GetMatchingSlot(GrowthRate.Normal, slot);
                switch (fixedSlot)
                {
                    case MateriaSlot.NormalUnlinkedSlot:
                        switch (equipped.MateriaType)
                        {
                            case MateriaType.Independent:
                                return Properties.Resources.materia_slot_independent1;
                            case MateriaType.Support:
                                return Properties.Resources.materia_slot_support1;
                            case MateriaType.Magic:
                                return Properties.Resources.materia_slot_magic1;
                            case MateriaType.Summon:
                                return Properties.Resources.materia_slot_summon1;
                            case MateriaType.Command:
                                return Properties.Resources.materia_slot_command1;
                        }
                        break;
                    case MateriaSlot.NormalLeftLinkedSlot:
                        switch (equipped.MateriaType)
                        {
                            case MateriaType.Independent:
                                return Properties.Resources.materia_slot_independent2;
                            case MateriaType.Support:
                                return Properties.Resources.materia_slot_support2;
                            case MateriaType.Magic:
                                return Properties.Resources.materia_slot_magic2;
                            case MateriaType.Summon:
                                return Properties.Resources.materia_slot_summon2;
                            case MateriaType.Command:
                                return Properties.Resources.materia_slot_command2;
                        }
                        break;
                    case MateriaSlot.NormalRightLinkedSlot:
                        switch (equipped.MateriaType)
                        {
                            case MateriaType.Independent:
                                return Properties.Resources.materia_slot_independent3;
                            case MateriaType.Support:
                                return Properties.Resources.materia_slot_support3;
                            case MateriaType.Magic:
                                return Properties.Resources.materia_slot_magic3;
                            case MateriaType.Summon:
                                return Properties.Resources.materia_slot_summon3;
                            case MateriaType.Command:
                                return Properties.Resources.materia_slot_command3;
                        }
                        break;
                }
            }
            else //no materia equipped
            {
                switch (slot)
                {
                    case MateriaSlot.NormalUnlinkedSlot:
                        return Properties.Resources.materia_slot1;
                    case MateriaSlot.NormalLeftLinkedSlot:
                        return Properties.Resources.materia_slot2;
                    case MateriaSlot.NormalRightLinkedSlot:
                        return Properties.Resources.materia_slot3;
                    case MateriaSlot.EmptyUnlinkedSlot:
                        return Properties.Resources.materia_slot4;
                    case MateriaSlot.EmptyLeftLinkedSlot:
                        return Properties.Resources.materia_slot5;
                    case MateriaSlot.EmptyRightLinkedSlot:
                        return Properties.Resources.materia_slot6;
                }
            }
            return Properties.Resources.materia_slot0;
        }

        public bool SetSlotsFromWeapon(Weapon weapon)
        {
            bool success = true;
            GrowthRate = weapon.GrowthRate;
            for (int i = 0; i < SLOT_COUNT; ++i)
            {
                if (!SetSlotInner(i, weapon.MateriaSlots[i], weapon.GrowthRate, true, true))
                {
                    success = false;
                }
            }
            return success;
        }

        public bool SetSlotsFromArmor(Armor armor)
        {
            bool success = true;
            GrowthRate = armor.GrowthRate;
            for (int i = 0; i < SLOT_COUNT; ++i)
            {
                if (!SetSlotInner(i, armor.MateriaSlots[i], armor.GrowthRate, true, true))
                {
                    success = false;
                }
            }
            return success;
        }

        public bool SetSlot(int slot, MateriaSlot value)
        {
            return SetSlotInner(slot, value, GrowthRate, false, false);
        }

        private bool SetSlotInner(int slot, MateriaSlot value, GrowthRate rate, bool ignoreLeft, bool ignoreRight)
        {
            if (slot >= 0 && slot < SLOT_COUNT)
            {
                var newValue = GetMatchingSlot(rate, value);
                if (slots[slot] != newValue)
                {
                    //update slot value
                    var currentValue = GetMatchingSlot(rate, slots[slot]);
                    var pb = pictureBoxes[slot];
                    pb.Image = GetMatchingImage(newValue, equippedMateria[slot]);
                    slots[slot] = newValue;
                    for (int i = 0; i < 4; ++i)
                    {
                        var mi = menuStrips[slot].Items[i] as ToolStripMenuItem;
                        if (mi != null)
                        {
                            mi.Checked = (newValue == GetMatchingSlot(rate, (MateriaSlot)i));
                        }
                    }

                    //attempt to update neighboring slot(s) as well
                    if (!ignoreLeft || !ignoreRight)
                    {
                        if (!ignoreLeft && slot > 0) //update slot to the left
                        {
                            var prevValue = GetMatchingSlot(slots[slot - 1]);
                            if (SlotIsRightLinked(newValue) && !SlotIsLeftLinked(prevValue))
                            {
                                SetSlotInner(slot - 1, MateriaSlot.NormalLeftLinkedSlot, rate, false, true);
                            }
                            else if (SlotIsRightLinked(currentValue) && SlotIsLeftLinked(prevValue))
                            {
                                SetSlotInner(slot - 1, MateriaSlot.NormalUnlinkedSlot, rate, false, true);
                            }
                        }
                        if (!ignoreRight && slot < SLOT_COUNT - 1) //update slot to the right
                        {
                            var nextValue = GetMatchingSlot(slots[slot + 1]);
                            if (SlotIsLeftLinked(newValue) && !SlotIsRightLinked(nextValue))
                            {
                                SetSlotInner(slot + 1, MateriaSlot.NormalRightLinkedSlot, rate, true, false);
                            }
                            else if (SlotIsLeftLinked(currentValue) && SlotIsRightLinked(nextValue))
                            {
                                SetSlotInner(slot + 1, MateriaSlot.NormalUnlinkedSlot, rate, true, false);
                            }
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public void SetMateria(int slot, Materia? materia)
        {
            equippedMateria[slot] = materia;
            pictureBoxes[slot].Image = GetMatchingImage(slots[slot], materia);
        }

        private bool SlotIsUnlinked (MateriaSlot slot)
        {
            return (slot == MateriaSlot.NormalUnlinkedSlot || slot == MateriaSlot.EmptyUnlinkedSlot);
        }

        private bool SlotIsLeftLinked (MateriaSlot slot)
        {
            return (slot == MateriaSlot.NormalLeftLinkedSlot || slot == MateriaSlot.EmptyLeftLinkedSlot);
        }

        private bool SlotIsRightLinked(MateriaSlot slot)
        {
            return (slot == MateriaSlot.NormalRightLinkedSlot || slot == MateriaSlot.EmptyRightLinkedSlot);
        }

        private MateriaSlot GetMatchingSlot(MateriaSlot slot)
        {
            return GetMatchingSlot(GrowthRate, slot);
        }

        private MateriaSlot GetMatchingSlot(GrowthRate rate, MateriaSlot slot)
        {
            if (SlotIsUnlinked(slot))
            {
                if (rate == GrowthRate.None) { return MateriaSlot.EmptyUnlinkedSlot; }
                else { return MateriaSlot.NormalUnlinkedSlot; }
            }
            else if (SlotIsLeftLinked(slot))
            {
                if (rate == GrowthRate.None) { return MateriaSlot.EmptyLeftLinkedSlot; }
                else { return MateriaSlot.NormalLeftLinkedSlot; }
            }
            else if (SlotIsRightLinked(slot))
            {
                if (rate == GrowthRate.None) { return MateriaSlot.EmptyRightLinkedSlot; }
                else { return MateriaSlot.NormalRightLinkedSlot; }
            }
            else
            {
                return slot;
            }
        }

        private int GetSlotFromSender(object sender)
        {
            if (sender is ToolStripMenuItem)
            {
                var menuItem = sender as ToolStripMenuItem;
                var toolStrip = menuItem?.GetCurrentParent() as ContextMenuStrip;
                if (toolStrip == null) { return -1; }
                return menuStrips.ToList().IndexOf(toolStrip);
            }
            else if (sender is PictureBox)
            {
                var picture = sender as PictureBox;
                if (picture == null) { return -1; }
                return pictureBoxes.ToList().IndexOf(picture);
            }
            else { return -1; }
        }

        private void EmptySlotMenu_Clicked(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                int slot = GetSlotFromSender(sender);
                SetSlot(slot, MateriaSlot.None);
            }
        }

        private void UnlinkedSlotMenu_Clicked(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                int slot = GetSlotFromSender(sender);
                SetSlot(slot, GetMatchingSlot(MateriaSlot.NormalUnlinkedSlot));
            }
        }

        private void LeftLinkedSlotMenu_Clicked(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                int slot = GetSlotFromSender(sender);
                SetSlot(slot, GetMatchingSlot(MateriaSlot.NormalLeftLinkedSlot));
            }
        }

        private void RightLinkedSlotMenu_Clicked(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                int slot = GetSlotFromSender(sender);
                SetSlot(slot, GetMatchingSlot(MateriaSlot.NormalRightLinkedSlot));
            }
        }

        private void Slot_Clicked(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                SelectedSlot = GetSlotFromSender(sender);
            }
        }
    }
}
