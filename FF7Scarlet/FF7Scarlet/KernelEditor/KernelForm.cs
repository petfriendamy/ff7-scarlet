using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shojy.FF7.Elena;
using Shojy.FF7.Elena.Items;

namespace FF7Scarlet
{
    public partial class KernelForm : Form
    {
        private Kernel kernel;
        private const int SUMMON_OFFSET = 56;
        private bool unsavedChanges = false;

        private Dictionary<KernelSection, ListBox> listBoxes = new Dictionary<KernelSection, ListBox> { };
        private Dictionary<KernelSection, TextBox> nameTextBoxes = new Dictionary<KernelSection, TextBox> { };
        private Dictionary<KernelSection, TextBox> descriptionTextBoxes = new Dictionary<KernelSection, TextBox> { };

        public KernelForm()
        {
            InitializeComponent();
        }

        private void KernelForm_Load(object sender, EventArgs e)
        {
            //create private version of kernel data that can be edited freely
            kernel = new Kernel(DataManager.KernelPath);
            if (DataManager.BothKernelFilesLoaded)
            {
                kernel.MergeKernel2Data(DataManager.Kernel2Path);
            }

            //associate controls with kernel data
            listBoxes.Add(KernelSection.CommandData, listBoxCommands);
            nameTextBoxes.Add(KernelSection.CommandData, textBoxCommandName);
            descriptionTextBoxes.Add(KernelSection.CommandData, textBoxCommandDescription);

            listBoxes.Add(KernelSection.AttackData, listBoxAttacks);
            nameTextBoxes.Add(KernelSection.AttackData, textBoxAttackName);
            descriptionTextBoxes.Add(KernelSection.AttackData, textBoxAttackDescription);

            listBoxes.Add(KernelSection.ItemData, listBoxItems);
            nameTextBoxes.Add(KernelSection.ItemData, textBoxItemName);
            descriptionTextBoxes.Add(KernelSection.ItemData, textBoxItemDescription);

            listBoxes.Add(KernelSection.WeaponData, listBoxWeapons);
            nameTextBoxes.Add(KernelSection.WeaponData, textBoxWeaponName);
            descriptionTextBoxes.Add(KernelSection.WeaponData, textBoxWeaponDescription);

            listBoxes.Add(KernelSection.ArmorData, listBoxArmor);
            nameTextBoxes.Add(KernelSection.ArmorData, textBoxArmorName);
            descriptionTextBoxes.Add(KernelSection.ArmorData, textBoxArmorDescription);

            listBoxes.Add(KernelSection.AccessoryData, listBoxAccessories);
            nameTextBoxes.Add(KernelSection.AccessoryData, textBoxAccessoryName);
            descriptionTextBoxes.Add(KernelSection.AccessoryData, textBoxAccessoryDescription);

            listBoxes.Add(KernelSection.MateriaData, listBoxMateria);
            nameTextBoxes.Add(KernelSection.MateriaData, textBoxMateriaName);
            descriptionTextBoxes.Add(KernelSection.MateriaData, textBoxMateriaDescription);

            listBoxes.Add(KernelSection.KeyItemNames, listBoxKeyItems);
            nameTextBoxes.Add(KernelSection.KeyItemNames, textBoxKeyItemName);
            descriptionTextBoxes.Add(KernelSection.KeyItemNames, textBoxKeyItemDescription);

            //add names to listboxes
            foreach (var lb in listBoxes)
            {
                var names = kernel.GetAssociatedNames(lb.Key);
                if (names != null)
                {
                    foreach (var n in names)
                    {
                        lb.Value.Items.Add(n);
                    }
                }
            }
        }

        private void KernelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataManager.CloseForm(FormType.KernelEditor);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DataManager.CreateKernel(true);
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            using (var exportDialog = new KernelChunkExportForm(kernel))
            {
                exportDialog.ShowDialog();
            }
        }

        private int PopulateTabWithSelected(KernelSection section)
        {
            if (listBoxes.ContainsKey(section))
            {
                int i = listBoxes[section].SelectedIndex;
                if (i >= 0 && i < kernel.GetCount(section))
                {
                    nameTextBoxes[section].Text = kernel.GetAssociatedNames(section)[i];
                    descriptionTextBoxes[section].Text = kernel.GetAssociatedDescriptions(section)[i];
                }
                return i;
            }
            return -1;
        }

        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTabWithSelected(KernelSection.CommandData);
        }

        private void listBoxAttacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = PopulateTabWithSelected(KernelSection.AttackData) - SUMMON_OFFSET;
            if (i >= 0 && i < kernel.SummonAttackNames.Strings.Length)
            {
                textBoxSummonText.Enabled = true;
                textBoxSummonText.Text = kernel.SummonAttackNames.Strings[i];
            }
            else
            {
                textBoxSummonText.Enabled = false;
                textBoxSummonText.Clear();
            }
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = PopulateTabWithSelected(KernelSection.ItemData);
            if (i != -1) //valid item selected
            {
                var item = kernel.ItemData.Items[i];
                checkBoxItemIsSellable.Checked = item.Restrictions.HasFlag(Restrictions.CanBeSold);
                checkBoxItemUsableInBattle.Checked = item.Restrictions.HasFlag(Restrictions.CanBeUsedInBattle);
                checkBoxItemUsableInMenu.Checked = item.Restrictions.HasFlag(Restrictions.CanBeUsedInMenu);
            }
            
        }

        private void listBoxWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTabWithSelected(KernelSection.WeaponData);
        }

        private void listBoxArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTabWithSelected(KernelSection.ArmorData);
        }

        private void listBoxAccessories_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTabWithSelected(KernelSection.AccessoryData);
        }

        private void listBoxMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTabWithSelected(KernelSection.MateriaData);
        }

        private void listBoxKeyItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTabWithSelected(KernelSection.KeyItemNames);
        }
    }
}
