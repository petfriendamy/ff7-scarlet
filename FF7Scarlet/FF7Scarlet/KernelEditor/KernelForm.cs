using Shojy.FF7.Elena;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Items;
using Shojy.FF7.Elena.Materias;

namespace FF7Scarlet
{
    public partial class KernelForm : Form
    {
        private Kernel kernel;
        private const int SUMMON_OFFSET = 56;
        private bool unsavedChanges = false;

        private Dictionary<KernelSection, TabPage> tabPages = new Dictionary<KernelSection, TabPage> { };
        private Dictionary<KernelSection, ListBox> listBoxes = new Dictionary<KernelSection, ListBox> { };
        private Dictionary<KernelSection, TextBox> nameTextBoxes = new Dictionary<KernelSection, TextBox> { };
        private Dictionary<KernelSection, TextBox> descriptionTextBoxes = new Dictionary<KernelSection, TextBox> { };
        private Dictionary<KernelSection, CheckBox[]> itemRestrictionLists = new Dictionary<KernelSection, CheckBox[]> { };
        private Dictionary<KernelSection, CheckBox[]> equipableLists = new Dictionary<KernelSection, CheckBox[]> { };
        private Dictionary<KernelSection, MateriaSlotSelectorControl> materiaSlots = new Dictionary<KernelSection, MateriaSlotSelectorControl> { };
        private Dictionary<KernelSection, ComboBox> materiaGrowthComboBoxes = new Dictionary<KernelSection, ComboBox> { };

        public KernelForm()
        {
            InitializeComponent();

            //create private version of kernel data that can be edited freely
            kernel = new Kernel(DataManager.KernelPath);
            if (DataManager.BothKernelFilesLoaded)
            {
                kernel.MergeKernel2Data(DataManager.Kernel2Path);
            }
        }

        private void KernelForm_Load(object sender, EventArgs e)
        {
            //associate controls with kernel data
            //command data
            tabPages.Add(KernelSection.CommandData, tabPageCommandData);
            listBoxes.Add(KernelSection.CommandData, listBoxCommands);
            nameTextBoxes.Add(KernelSection.CommandData, textBoxCommandName);
            descriptionTextBoxes.Add(KernelSection.CommandData, textBoxCommandDescription);

            //attack data
            tabPages.Add(KernelSection.AttackData, tabPageAttackData);
            listBoxes.Add(KernelSection.AttackData, listBoxAttacks);
            nameTextBoxes.Add(KernelSection.AttackData, textBoxAttackName);
            descriptionTextBoxes.Add(KernelSection.AttackData, textBoxAttackDescription);

            //item data
            tabPages.Add(KernelSection.ItemData, tabPageItemData);
            listBoxes.Add(KernelSection.ItemData, listBoxItems);
            nameTextBoxes.Add(KernelSection.ItemData, textBoxItemName);
            descriptionTextBoxes.Add(KernelSection.ItemData, textBoxItemDescription);
            itemRestrictionLists.Add(KernelSection.ItemData, new CheckBox[3]
            {
                checkBoxItemIsSellable, checkBoxItemUsableInBattle, checkBoxItemUsableInMenu
            });

            //weapon data
            tabPages.Add(KernelSection.WeaponData, tabPageWeaponData);
            listBoxes.Add(KernelSection.WeaponData, listBoxWeapons);
            nameTextBoxes.Add(KernelSection.WeaponData, textBoxWeaponName);
            descriptionTextBoxes.Add(KernelSection.WeaponData, textBoxWeaponDescription);
            itemRestrictionLists.Add(KernelSection.WeaponData, new CheckBox[3]
            {
                checkBoxWeaponIsSellable, checkBoxWeaponUsableInBattle, checkBoxWeaponUsableInMenu
            });
            equipableLists.Add(KernelSection.WeaponData, new CheckBox[11]
            {
                checkBoxWeaponCloud, checkBoxWeaponBarret, checkBoxWeaponTifa,
                checkBoxWeaponAerith, checkBoxWeaponRed, checkBoxWeaponYuffie,
                checkBoxWeaponCaitSith, checkBoxWeaponVincent, checkBoxWeaponCid,
                checkBoxWeaponYCloud, checkBoxWeaponSephiroth
            });
            materiaSlots.Add(KernelSection.WeaponData, materiaSlotSelectorWeapon);
            materiaGrowthComboBoxes.Add(KernelSection.WeaponData, comboBoxWeaponMateriaGrowth);

            //armor data
            tabPages.Add(KernelSection.ArmorData, tabPageArmorData);
            listBoxes.Add(KernelSection.ArmorData, listBoxArmor);
            nameTextBoxes.Add(KernelSection.ArmorData, textBoxArmorName);
            descriptionTextBoxes.Add(KernelSection.ArmorData, textBoxArmorDescription);
            itemRestrictionLists.Add(KernelSection.ArmorData, new CheckBox[3]
            {
                checkBoxArmorIsSellable, checkBoxArmorUsableInBattle, checkBoxArmorUsableInMenu
            });
            equipableLists.Add(KernelSection.ArmorData, new CheckBox[11]
            {
                checkBoxArmorCloud, checkBoxArmorBarret, checkBoxArmorTifa,
                checkBoxArmorAerith, checkBoxArmorRed, checkBoxArmorYuffie,
                checkBoxArmorCaitSith, checkBoxArmorVincent, checkBoxArmorCid,
                checkBoxArmorYCloud, checkBoxArmorSephiroth
            });
            materiaSlots.Add(KernelSection.ArmorData, materiaSlotSelectorArmor);
            materiaGrowthComboBoxes.Add(KernelSection.ArmorData, comboBoxArmorMateriaGrowth);

            //accessory data
            tabPages.Add(KernelSection.AccessoryData, tabPageAccessoryData);
            listBoxes.Add(KernelSection.AccessoryData, listBoxAccessories);
            nameTextBoxes.Add(KernelSection.AccessoryData, textBoxAccessoryName);
            descriptionTextBoxes.Add(KernelSection.AccessoryData, textBoxAccessoryDescription);
            itemRestrictionLists.Add(KernelSection.AccessoryData, new CheckBox[3]
            {
                checkBoxAccessoryIsSellable, checkBoxAccessoryUsableInBattle, checkBoxAccessoryUsableInMenu
            });
            equipableLists.Add(KernelSection.AccessoryData, new CheckBox[11]
            {
                checkBoxAccessoryCloud, checkBoxAccessoryBarret, checkBoxAccessoryTifa,
                checkBoxAccessoryAerith, checkBoxAccessoryRed, checkBoxAccessoryYuffie,
                checkBoxAccessoryCaitSith, checkBoxAccessoryVincent, checkBoxAccessoryCid,
                checkBoxAccessoryYCloud, checkBoxAccessorySephiroth
            });

            //materia data
            tabPages.Add(KernelSection.MateriaData, tabPageMateriaData);
            listBoxes.Add(KernelSection.MateriaData, listBoxMateria);
            nameTextBoxes.Add(KernelSection.MateriaData, textBoxMateriaName);
            descriptionTextBoxes.Add(KernelSection.MateriaData, textBoxMateriaDescription);

            //key items
            tabPages.Add(KernelSection.KeyItemNames, tabPageKeyItemText);
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

            //materia info
            foreach (var g in Enum.GetNames<GrowthRate>())
            {
                foreach (var cb in materiaGrowthComboBoxes)
                {
                    cb.Value.Items.Add(g);
                }
            }
            foreach (var el in Enum.GetNames<MateriaElements>())
            {
                comboBoxMateriaElement.Items.Add(el);
            }
            foreach (var mt in Enum.GetNames<MateriaType>())
            {
                comboBoxMateriaType.Items.Add(mt);
            }

            //disable all the controls while there's no data in them
            foreach (var tab in tabPages)
            {
                EnableOrDisableTabPageControls(tab.Key, false);
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

        private void EnableOrDisableTabPageControls(KernelSection section, bool enabled)
        {
            if (tabPages.ContainsKey(section))
            {
                var tab = tabPages[section];
                for (int i = 0; i < tab.Controls.Count; ++i)
                {
                    var c = tab.Controls[i];
                    if (c != listBoxes[section])
                    {
                        c.Enabled = enabled;
                    }
                }
            }
        }

        private void PopulateTabWithSelected(KernelSection section)
        {
            if (listBoxes.ContainsKey(section))
            {
                int i = listBoxes[section].SelectedIndex, j;
                if (i >= 0 && i < kernel.GetCount(section))
                {
                    EnableOrDisableTabPageControls(section, true);
                    nameTextBoxes[section].Text = kernel.GetAssociatedNames(section)[i];
                    descriptionTextBoxes[section].Text = kernel.GetAssociatedDescriptions(section)[i];

                    //check for item restrictions
                    if (itemRestrictionLists.ContainsKey(section))
                    {
                        var restrictions = kernel.GetItemRestrictions(section, i);
                        itemRestrictionLists[section][0].Checked = restrictions.HasFlag(Restrictions.CanBeSold);
                        itemRestrictionLists[section][1].Checked = restrictions.HasFlag(Restrictions.CanBeUsedInBattle);
                        itemRestrictionLists[section][2].Checked = restrictions.HasFlag(Restrictions.CanBeUsedInMenu);
                    }

                    //check for equip lists
                    if (equipableLists.ContainsKey(section))
                    {
                        var equip = kernel.GetEquipableFlags(section, i);
                        equipableLists[section][0].Checked = equip.HasFlag(EquipableBy.Cloud);
                        equipableLists[section][1].Checked = equip.HasFlag(EquipableBy.Barret);
                        equipableLists[section][2].Checked = equip.HasFlag(EquipableBy.Tifa);
                        equipableLists[section][3].Checked = equip.HasFlag(EquipableBy.Aeris);
                        equipableLists[section][4].Checked = equip.HasFlag(EquipableBy.RedXIII);
                        equipableLists[section][5].Checked = equip.HasFlag(EquipableBy.Yuffie);
                        equipableLists[section][6].Checked = equip.HasFlag(EquipableBy.CaitSith);
                        equipableLists[section][7].Checked = equip.HasFlag(EquipableBy.Vincent);
                        equipableLists[section][8].Checked = equip.HasFlag(EquipableBy.Cid);
                        equipableLists[section][9].Checked = equip.HasFlag(EquipableBy.YoungCloud);
                        equipableLists[section][10].Checked = equip.HasFlag(EquipableBy.Sephiroth);
                    }

                    //check for materia slots
                    if (materiaSlots.ContainsKey(section) && materiaGrowthComboBoxes.ContainsKey(section))
                    {
                        var slots = kernel.GetMateriaSlots(section, i);
                        var rate = kernel.GetGrowthRate(section, i);
                        materiaSlots[section].GrowthRate = rate;
                        for (j = 0; j < slots.Length; j++)
                        {
                            materiaSlots[section].SetSlot(j, slots[j]);
                        }
                        materiaGrowthComboBoxes[section].SelectedIndex = (int)rate;
                    }

                    //get data specific to this section
                    switch (section)
                    {
                        case KernelSection.AttackData:
                            j = i - SUMMON_OFFSET;
                            if (j >= 0 && j < kernel.SummonAttackNames.Strings.Length)
                            {
                                textBoxSummonText.Enabled = true;
                                textBoxSummonText.Text = kernel.SummonAttackNames.Strings[j];
                            }
                            else
                            {
                                textBoxSummonText.Enabled = false;
                                textBoxSummonText.Clear();
                            }
                            break;

                        case KernelSection.WeaponData:
                            var weapon = kernel.WeaponData.Weapons[i];
                            checkBoxWeaponIsThrowable.Checked = ((int)weapon.Restrictions & 0x08) != 0;
                            break;

                        case KernelSection.MateriaData:
                            var materia = kernel.MateriaData.Materias[i];
                            if (Enum.IsDefined<MateriaElements>(materia.Element)){
                                comboBoxMateriaElement.SelectedIndex = (int)materia.Element;
                            }
                            else
                            {
                                comboBoxMateriaElement.SelectedIndex = -1;
                            }
                            comboBoxMateriaType.SelectedIndex = (int)materia.MateriaType;
                            break;
                    }
                }
            }
        }

        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTabWithSelected(KernelSection.CommandData);
        }

        private void listBoxAttacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTabWithSelected(KernelSection.AttackData);
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTabWithSelected(KernelSection.ItemData);
            
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
