using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Text;

#pragma warning disable CA1416
namespace FF7Scarlet.KernelEditor
{
    public partial class MagicOrderForm : Form
    {
        public List<SpellIndex> SpellIndices { get; }

        public MagicOrderForm(List<SpellIndex> spellIndices, SpellIndex selected, FFText[] spellNames)
        {
            InitializeComponent();
            SpellIndices = spellIndices;
            foreach (var spell in spellIndices)
            {
                listBoxSpellList.Items.Add(spellNames[spell.SpellID]);
            }
            listBoxSpellList.SelectedIndex = spellIndices.IndexOf(selected);
            groupBoxSpellList.Text = Enum.GetName(spellIndices[0].SpellType) + " spell list";
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            int selected = listBoxSpellList.SelectedIndex;
            if (selected > 0)
            {
                //swap positions in index list
                var temp = SpellIndices[selected - 1];
                SpellIndices[selected - 1] = SpellIndices[selected];
                SpellIndices[selected] = temp;

                //swap positions in listbox
                var temp2 = listBoxSpellList.Items[selected - 1];
                listBoxSpellList.Items[selected - 1] = listBoxSpellList.Items[selected];
                listBoxSpellList.Items[selected] = temp2;

                listBoxSpellList.SelectedIndex--;
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            int selected = listBoxSpellList.SelectedIndex;
            if (selected < SpellIndices.Count - 1)
            {
                //swap positions in index list
                var temp = SpellIndices[selected + 1];
                SpellIndices[selected + 1] = SpellIndices[selected];
                SpellIndices[selected] = temp;

                //swap positions in listbox
                var temp2 = listBoxSpellList.Items[selected + 1];
                listBoxSpellList.Items[selected + 1] = listBoxSpellList.Items[selected];
                listBoxSpellList.Items[selected] = temp2;

                listBoxSpellList.SelectedIndex++;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //sort the spell indices
            for (byte i = 0; i < SpellIndices.Count; ++i)
            {
                SpellIndices[i].SectionIndex = i;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
