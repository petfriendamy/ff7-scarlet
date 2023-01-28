using Shojy.FF7.Elena.Equipment;
using static System.Net.Mime.MediaTypeNames;

namespace FF7Scarlet
{
    public partial class MateriaSlotSelectorControl : UserControl
    {
        private const int SLOT_COUNT = 8;
        private readonly MateriaSlot[] slots = new MateriaSlot[SLOT_COUNT];
        private GrowthRate growthRate;
        private PictureBox[] pictureBoxes;
        private readonly Dictionary<MateriaSlot, Bitmap> ImageLookupTable = new Dictionary<MateriaSlot, Bitmap>
        {
            { MateriaSlot.None, Properties.Resources.materia_slot0 },
            { MateriaSlot.NormalUnlinkedSlot, Properties.Resources.materia_slot1 },
            { MateriaSlot.NormalLeftLinkedSlot, Properties.Resources.materia_slot2 },
            { MateriaSlot.NormalRightLinkedSlot, Properties.Resources.materia_slot3 },
            { MateriaSlot.EmptyUnlinkedSlot, Properties.Resources.materia_slot4 },
            { MateriaSlot.EmptyLeftLinkedSlot, Properties.Resources.materia_slot5 },
            { MateriaSlot.EmptyRightLinkedSlot, Properties.Resources.materia_slot6 }
        };
        private ContextMenuStrip[] menuStrips = new ContextMenuStrip[SLOT_COUNT];

        public GrowthRate GrowthRate
        {
            get { return growthRate; }
            set
            {
                for (int i = 0; i < SLOT_COUNT; ++i)
                {
                    SetSlotInner(i, GetMatchingSlot(value, slots[i]), true, true);
                }
                growthRate = value;
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

        public bool SetSlot(int slot, MateriaSlot value)
        {
            return SetSlotInner(slot, value, false, false);
        }

        private bool SetSlotInner(int slot, MateriaSlot value, bool ignoreLeft, bool ignoreRight)
        {
            if (slot >= 0 && slot < SLOT_COUNT)
            {
                if (slots[slot] != value)
                {
                    //update slot value
                    MateriaSlot currentValue = GetMatchingSlot(slots[slot]), newValue = GetMatchingSlot(value);
                    var pb = pictureBoxes[slot];
                    pb.Image = ImageLookupTable[newValue];
                    slots[slot] = newValue;
                    for (int i = 0; i < 4; ++i)
                    {
                        var mi = menuStrips[slot].Items[i] as ToolStripMenuItem;
                        if (mi != null)
                        {
                            mi.Checked = (newValue == GetMatchingSlot((MateriaSlot)i));
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
                                SetSlotInner(slot - 1, MateriaSlot.NormalLeftLinkedSlot, false, true);
                            }
                            else if (SlotIsRightLinked(currentValue) && SlotIsLeftLinked(prevValue))
                            {
                                SetSlotInner(slot - 1, MateriaSlot.NormalUnlinkedSlot, false, true);
                            }
                        }
                        if (!ignoreRight && slot < SLOT_COUNT - 1) //update slot to the right
                        {
                            var nextValue = GetMatchingSlot(slots[slot + 1]);
                            if (SlotIsLeftLinked(newValue) && !SlotIsRightLinked(nextValue))
                            {
                                SetSlotInner(slot + 1, MateriaSlot.NormalRightLinkedSlot, true, false);
                            }
                            else if (SlotIsLeftLinked(currentValue) && SlotIsRightLinked(nextValue))
                            {
                                SetSlotInner(slot + 1, MateriaSlot.NormalUnlinkedSlot, true, false);
                            }
                        }
                    }
                    return true;
                }
            }
            return false;
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
            var menuItem = sender as ToolStripMenuItem;
            var toolStrip = menuItem?.GetCurrentParent() as ContextMenuStrip;
            if (toolStrip == null) { return -1; }
            return menuStrips.ToList().IndexOf(toolStrip);
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
    }
}
