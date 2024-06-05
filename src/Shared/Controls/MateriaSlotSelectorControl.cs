using FF7Scarlet.KernelEditor;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Materias;

namespace FF7Scarlet.Shared.Controls
{
    public enum SlotSelectorType { Slots, Materia }

    public partial class MateriaSlotSelectorControl : UserControl
    {
        private const int SLOT_COUNT = 8;
        private const MateriaSlot
            DOUBLE_LINKED_EMPTY = (MateriaSlot)8,
            DOUBLE_LINKED_NORMAL = (MateriaSlot)9;

        private SlotSelectorType slotSelectorType;
        private readonly MateriaSlot[] slots = new MateriaSlot[SLOT_COUNT];
        private readonly MateriaExt?[] equippedMateria = new MateriaExt?[SLOT_COUNT];
        private GrowthRate growthRate;
        private PictureBox[] pictureBoxes;
        private ContextMenuStrip[] menuStrips = new ContextMenuStrip[SLOT_COUNT];
        private int selectedSlot = -1;
        private bool multiLinkEnabled;

        public event EventHandler? SelectedSlotChanged;
        public event EventHandler? DataChanged;
        public event EventHandler? MultiLinkEnabled;

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

                        if (multiLinkEnabled)
                        {
                            menuItem = new ToolStripMenuItem("Double linked slot");
                            menuItem.Click += new EventHandler(DoubleLinkedSlotMenu_Clicked);
                            if (i == 0 || i == SLOT_COUNT - 1) { menuItem.Enabled = false; }
                            menuStrips[i].Items.Add(menuItem);
                        }

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
                InvokeDataChanged(this, EventArgs.Empty);
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
                SelectedSlotChanged?.Invoke(this, EventArgs.Empty);
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
            multiLinkEnabled = DataManager.PS3TweaksEnabled;
        }

        private Image GetMatchingImage(MateriaSlot slot, MateriaExt? equipped)
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
                    case DOUBLE_LINKED_NORMAL:
                        switch (equipped.MateriaType)
                        {
                            case MateriaType.Independent:
                                return Properties.Resources.materia_slot_independent_dl;
                            case MateriaType.Support:
                                return Properties.Resources.materia_slot_support_dl;
                            case MateriaType.Magic:
                                return Properties.Resources.materia_slot_magic_dl;
                            case MateriaType.Summon:
                                return Properties.Resources.materia_slot_summon_dl;
                            case MateriaType.Command:
                                return Properties.Resources.materia_slot_command_dl;
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
                    case DOUBLE_LINKED_NORMAL:
                        return Properties.Resources.materia_slot_dl1;
                    case DOUBLE_LINKED_EMPTY:
                        return Properties.Resources.materia_slot_dl2;
                }
            }
            return Properties.Resources.materia_slot0;
        }

        public void EnableMultiLinkSlots()
        {
            if (!multiLinkEnabled)
            {
                for (int i = 0; i < SLOT_COUNT; ++i)
                {
                    var menuItem = new ToolStripMenuItem("Double linked slot");
                    menuItem.Click += new EventHandler(DoubleLinkedSlotMenu_Clicked);
                    if (i == 0 || i == SLOT_COUNT - 1) { menuItem.Enabled = false; }
                    menuStrips[i].Items.Add(menuItem);
                }
                multiLinkEnabled = true;
            }
        }

        public bool SetSlots(Weapon weapon)
        {
            return SetSlots(weapon.MateriaSlots, weapon.GrowthRate);
        }

        public bool SetSlots(Armor armor)
        {
            return SetSlots(armor.MateriaSlots, armor.GrowthRate);
        }

        public bool SetSlots(MateriaSlot[] slots, GrowthRate rate)
        {
            bool success = true;
            int right = 0; //internally, multi-link slots are right links
            GrowthRate = rate;
            for (int i = 0; i < SLOT_COUNT; ++i)
            {
                if (SetSlotInner(i, slots[i], rate, true, true, true))
                {
                    //checks for multi-linked slots
                    if (SlotIsRightLinked(slots[i])) { right++; }
                    else { right = 0; }
                    if (right > 1)
                    {
                        //if multi-linked slots are not enabled, ask to enable them
                        if (!multiLinkEnabled)
                        {
                            var result = MessageBox.Show("This kernel file appears to use multi-linked materia slots! Would you like to enable Postscriptthree Tweaks?",
                                "Enable Postscriptthree Tweaks?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                DataManager.PS3TweaksEnabled = true;
                                EnableMultiLinkSlots();
                                MultiLinkEnabled?.Invoke(this, EventArgs.Empty);
                            }
                        }

                        //if multi-linked slots are enabled, correct the previous slot
                        if (multiLinkEnabled)
                        {
                            SetSlotInner(i - 1, DOUBLE_LINKED_NORMAL, rate, true, true);
                        }
                    }
                    InvokeDataChanged(this, EventArgs.Empty);
                }
                else
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

        private bool SetSlotInner(int slot, MateriaSlot value, GrowthRate rate, bool ignoreLeft, bool ignoreRight,
            bool forceUpdate = false)
        {
            if (slot >= 0 && slot < SLOT_COUNT)
            {
                var newValue = GetMatchingSlot(rate, value);
                if (slots[slot] != newValue || forceUpdate)
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
                                if (DataManager.PS3TweaksEnabled && SlotIsRightLinked(prevValue))
                                {
                                    SetSlotInner(slot - 1, DOUBLE_LINKED_NORMAL, rate, true, true);
                                }
                                else
                                {
                                    SetSlotInner(slot - 1, MateriaSlot.NormalLeftLinkedSlot, rate, false, true);
                                }
                            }
                            else if (!SlotIsRightLinked(newValue) && SlotIsRightLinked(currentValue)
                                && SlotIsLeftLinked(prevValue))
                            {
                                if (DataManager.PS3TweaksEnabled && SlotIsDoubleLinked(prevValue))
                                {
                                    SetSlotInner(slot - 1, MateriaSlot.NormalRightLinkedSlot, rate, true, true);
                                }
                                else
                                {
                                    SetSlotInner(slot - 1, MateriaSlot.NormalUnlinkedSlot, rate, false, true);
                                }
                            }
                        }
                        if (!ignoreRight && slot < SLOT_COUNT - 1) //update slot to the right
                        {
                            var nextValue = GetMatchingSlot(slots[slot + 1]);
                            if (SlotIsLeftLinked(newValue) && !SlotIsRightLinked(nextValue))
                            {
                                if (DataManager.PS3TweaksEnabled && SlotIsLeftLinked(nextValue))
                                {
                                    SetSlotInner(slot + 1, DOUBLE_LINKED_NORMAL, rate, true, true);
                                }
                                else
                                {
                                    SetSlotInner(slot + 1, MateriaSlot.NormalRightLinkedSlot, rate, true, false);
                                }
                            }
                            else if (!SlotIsLeftLinked(newValue) && SlotIsLeftLinked(currentValue)
                                && SlotIsRightLinked(nextValue))
                            {
                                if (DataManager.PS3TweaksEnabled && SlotIsDoubleLinked(nextValue))
                                {
                                    SetSlotInner(slot - 1, MateriaSlot.NormalLeftLinkedSlot, rate, true, true);
                                }
                                else
                                {
                                    SetSlotInner(slot + 1, MateriaSlot.NormalUnlinkedSlot, rate, true, false);
                                }
                            }
                        }
                    }
                    InvokeDataChanged(this, EventArgs.Empty);
                    return true;
                }
            }
            return false;
        }

        public void SetMateria(InventoryMateria[] materia, Kernel kernel)
        {
            for (int i = 0; i < 8; ++i)
            {
                SetMateria(i, materia[i], kernel);
                SelectedSlot = -1;
            }
        }

        public void SetMateria(int slot, MateriaExt? materia)
        {
            equippedMateria[slot] = materia;
            pictureBoxes[slot].Image = GetMatchingImage(slots[slot], materia);
            InvokeDataChanged(this, EventArgs.Empty);
        }

        public void SetMateria(int slot, InventoryMateria materia, Kernel kernel)
        {
            var mat = kernel.GetMateriaByID(materia.Index);
            SetMateria(slot, mat);
        }

        public MateriaSlot[] GetSlots()
        {
            var s = new MateriaSlot[SLOT_COUNT];
            Array.Copy(slots, s, SLOT_COUNT);
            return s;
        }

        public InventoryMateria[] GetMateria()
        {
            var m = new InventoryMateria[SLOT_COUNT];
            Array.Copy(equippedMateria, m, SLOT_COUNT);
            return m;
        }

        private bool SlotIsUnlinked(MateriaSlot slot)
        {
            return (slot == MateriaSlot.NormalUnlinkedSlot || slot == MateriaSlot.EmptyUnlinkedSlot);
        }

        private bool SlotIsLeftLinked(MateriaSlot slot)
        {
            return (slot == MateriaSlot.NormalLeftLinkedSlot || slot == MateriaSlot.EmptyLeftLinkedSlot
                || SlotIsDoubleLinked(slot));
        }

        private bool SlotIsRightLinked(MateriaSlot slot)
        {
            return (slot == MateriaSlot.NormalRightLinkedSlot || slot == MateriaSlot.EmptyRightLinkedSlot
                || SlotIsDoubleLinked(slot));
        }

        private bool SlotIsDoubleLinked(MateriaSlot slot)
        {
            return (slot == DOUBLE_LINKED_NORMAL || slot == DOUBLE_LINKED_EMPTY);
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
            else if (SlotIsDoubleLinked(slot))
            {
                if (rate == GrowthRate.None) { return DOUBLE_LINKED_EMPTY; }
                else { return DOUBLE_LINKED_NORMAL; }
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

        private void DoubleLinkedSlotMenu_Clicked(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                int slot = GetSlotFromSender(sender);
                SetSlot(slot, GetMatchingSlot(DOUBLE_LINKED_NORMAL));
            }
        }

        private void Slot_Clicked(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                var slot = GetSlotFromSender(sender);
                if (slots[slot] != MateriaSlot.None)
                {
                    SelectedSlot = slot;
                }
            }
        }

        private void InvokeDataChanged(object? sender, EventArgs e)
        {
            DataChanged?.Invoke(sender, e);
        }
    }
}
