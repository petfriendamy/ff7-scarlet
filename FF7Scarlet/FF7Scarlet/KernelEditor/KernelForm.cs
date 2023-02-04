using Shojy.FF7.Elena;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Materias;
using FF7Scarlet.KernelEditor.Controls;

namespace FF7Scarlet.KernelEditor
{
    public partial class KernelForm : Form
    {
        private Kernel kernel;
        private const int SUMMON_OFFSET = 56;
        private bool unsavedChanges = false, loading = true;

        private Dictionary<KernelSection, TabPage> tabPages = new Dictionary<KernelSection, TabPage> { };
        private Dictionary<KernelSection, ListBox> listBoxes = new Dictionary<KernelSection, ListBox> { };
        private Dictionary<KernelSection, TextBox> nameTextBoxes = new Dictionary<KernelSection, TextBox> { };
        private Dictionary<KernelSection, TextBox> descriptionTextBoxes = new Dictionary<KernelSection, TextBox> { };
        private Dictionary<KernelSection, StatIncreaseControl> statIncreases = new Dictionary<KernelSection, StatIncreaseControl> { };
        private Dictionary<KernelSection, TargetDataControl> targetData = new Dictionary<KernelSection, TargetDataControl> { };
        private Dictionary<KernelSection, DamageCalculationControl> damageCalculationControls = new Dictionary<KernelSection, DamageCalculationControl> { };
        private Dictionary<KernelSection, ItemRestrictionsControl> itemRestrictionLists = new Dictionary<KernelSection, ItemRestrictionsControl> { };
        private Dictionary<KernelSection, EquipableListControl> equipableLists = new Dictionary<KernelSection, EquipableListControl> { };
        private Dictionary<KernelSection, MateriaSlotSelectorControl> materiaSlots = new Dictionary<KernelSection, MateriaSlotSelectorControl> { };
        private Dictionary<KernelSection, ComboBox> materiaGrowthComboBoxes = new Dictionary<KernelSection, ComboBox> { };
        private Dictionary<KernelSection, ElementsControl> elementLists = new Dictionary<KernelSection, ElementsControl> { };
        private Dictionary<KernelSection, ComboBox> elementDamageModifiers = new Dictionary<KernelSection, ComboBox> { };
        private Dictionary<KernelSection, StatusesControl> statusLists = new Dictionary<KernelSection, StatusesControl> { };
        private Dictionary<KernelSection, ComboBox> equipmentStatus = new Dictionary<KernelSection, ComboBox> { };

        public KernelForm()
        {
            InitializeComponent();

            //create private version of kernel data that can be edited freely
            if (DataManager.KernelPath == null) { throw new ArgumentNullException(); }
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
            targetData.Add(KernelSection.ItemData, targetDataControlItem);
            damageCalculationControls.Add(KernelSection.ItemData, damageCalculationControlItem);
            itemRestrictionLists.Add(KernelSection.ItemData, itemRestrictionsItem);
            elementLists.Add(KernelSection.ItemData, elementsControlItem);
            statusLists.Add(KernelSection.ItemData, statusesControlItem);

            //weapon data
            tabPages.Add(KernelSection.WeaponData, tabPageWeaponData);
            listBoxes.Add(KernelSection.WeaponData, listBoxWeapons);
            nameTextBoxes.Add(KernelSection.WeaponData, textBoxWeaponName);
            descriptionTextBoxes.Add(KernelSection.WeaponData, textBoxWeaponDescription);
            statIncreases.Add(KernelSection.WeaponData, statIncreaseControlWeapon);
            targetData.Add(KernelSection.WeaponData, targetDataControlWeapon);
            damageCalculationControls.Add(KernelSection.WeaponData, damageCalculationControlWeapon);
            itemRestrictionLists.Add(KernelSection.WeaponData, itemRestrictionsWeapon);
            equipableLists.Add(KernelSection.WeaponData, equipableListWeapon);
            materiaSlots.Add(KernelSection.WeaponData, materiaSlotSelectorWeapon);
            materiaGrowthComboBoxes.Add(KernelSection.WeaponData, comboBoxWeaponMateriaGrowth);
            elementLists.Add(KernelSection.WeaponData, elementsControlWeapon);
            equipmentStatus.Add(KernelSection.WeaponData, comboBoxWeaponStatus);

            //armor data
            tabPages.Add(KernelSection.ArmorData, tabPageArmorData);
            listBoxes.Add(KernelSection.ArmorData, listBoxArmor);
            nameTextBoxes.Add(KernelSection.ArmorData, textBoxArmorName);
            descriptionTextBoxes.Add(KernelSection.ArmorData, textBoxArmorDescription);
            statIncreases.Add(KernelSection.ArmorData, statIncreaseControlArmor);
            itemRestrictionLists.Add(KernelSection.ArmorData, itemRestrictionsArmor);
            equipableLists.Add(KernelSection.ArmorData, equipableListArmor);
            materiaSlots.Add(KernelSection.ArmorData, materiaSlotSelectorArmor);
            materiaGrowthComboBoxes.Add(KernelSection.ArmorData, comboBoxArmorMateriaGrowth);
            elementLists.Add(KernelSection.ArmorData, elementsControlArmor);
            elementDamageModifiers.Add(KernelSection.ArmorData, comboBoxArmorElementModifier);
            equipmentStatus.Add(KernelSection.ArmorData, comboBoxArmorStatus);

            //accessory data
            tabPages.Add(KernelSection.AccessoryData, tabPageAccessoryData);
            listBoxes.Add(KernelSection.AccessoryData, listBoxAccessories);
            nameTextBoxes.Add(KernelSection.AccessoryData, textBoxAccessoryName);
            descriptionTextBoxes.Add(KernelSection.AccessoryData, textBoxAccessoryDescription);
            statIncreases.Add(KernelSection.AccessoryData, statIncreaseControlAccessory);
            itemRestrictionLists.Add(KernelSection.AccessoryData, itemRestrictionsAccessory);
            equipableLists.Add(KernelSection.AccessoryData, equipableListAccessory);
            elementLists.Add(KernelSection.AccessoryData, elementsControlAccessory);
            elementDamageModifiers.Add(KernelSection.AccessoryData, comboBoxAccessoryElementModifier);
            statusLists.Add(KernelSection.AccessoryData, statusesControlAccessory);

            //materia data
            tabPages.Add(KernelSection.MateriaData, tabPageMateriaData);
            listBoxes.Add(KernelSection.MateriaData, listBoxMateria);
            nameTextBoxes.Add(KernelSection.MateriaData, textBoxMateriaName);
            descriptionTextBoxes.Add(KernelSection.MateriaData, textBoxMateriaDescription);
            statusLists.Add(KernelSection.MateriaData, statusesControlMateria);

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

            //element modifiers
            foreach (var cb in elementDamageModifiers.Values)
            {
                cb.Items.Add("None");
                foreach (var m in Enum.GetValues<DamageModifier>())
                {
                    if (m != DamageModifier.Normal) { cb.Items.Add(m); }
                }
            }

            //status effects
            foreach (var cb in equipmentStatus.Values)
            {
                cb.Items.Add("None");
                foreach (var s in Enum.GetValues<EquipmentStatus>())
                {
                    if (s == EquipmentStatus.MBarrier)
                    {
                        cb.Items.Add("M.Barrier");
                    }
                    else if (s != EquipmentStatus.None)
                    {
                        string final = s.ToString();
                        for (int i = 1; i < final.Length; ++i)
                        {
                            if (char.IsUpper(final[i]))
                            {
                                final = final.Substring(0, i) + ' ' + final.Substring(i);
                                break;
                            }
                        }
                        cb.Items.Add(final);
                    }
                }
            }

            //materia info
            foreach (var g in Enum.GetNames<GrowthRate>())
            {
                foreach (var cb in materiaGrowthComboBoxes.Values)
                {
                    cb.Items.Add(g);
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

            //show/hide controls that are invalid
            itemRestrictionsWeapon.ShowThrowable = true;
            statIncreaseControlAccessory.Count = 2;
            statusesControlMateria.FullList = false;

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
                var page = tabPages[section];
                EnableOrDisableInner(page, enabled, listBoxes[section]);
            }
        }

        private void EnableOrDisableInner(TabPage page, bool enabled, Control? ignore)
        {
            for (int i = 0; i < page.Controls.Count; ++i)
            {
                var c = page.Controls[i];
                if (c != ignore)
                {
                    if (c is TabControl)
                    {
                        var innerTab = c as TabControl;
                        if (innerTab != null)
                        {
                            for (int j = 0; j < innerTab.TabCount; ++j)
                            {
                                EnableOrDisableInner(innerTab.TabPages[j], enabled, null);
                            }
                        }
                    }
                    else { c.Enabled = enabled; }
                }
            }
        }

        //fills the current tab with data from the selected item
        private void PopulateTabWithSelected(KernelSection section)
        {
            loading = true;
            if (listBoxes.ContainsKey(section))
            {
                int i = listBoxes[section].SelectedIndex, j;
                if (i >= 0 && i < kernel.GetCount(section))
                {
                    EnableOrDisableTabPageControls(section, true);
                    nameTextBoxes[section].Text = kernel.GetAssociatedNames(section)[i];
                    descriptionTextBoxes[section].Text = kernel.GetAssociatedDescriptions(section)[i];

                    //check for stat increases
                    if (statIncreases.ContainsKey(section))
                    {
                        statIncreases[section].SetStatIncreases(kernel.GetStatIncreases(section, i));
                    }

                    //check for target data
                    if (targetData.ContainsKey(section))
                    {
                        targetData[section].SetTargetData(kernel.GetTargetData(section, i));
                    }

                    //check for damage calculation data
                    if (damageCalculationControls.ContainsKey(section))
                    {
                        damageCalculationControls[section].Reload(kernel.GetDamageCalculationID(section, i),
                            kernel.GetAttackPower(section, i));
                    }

                    //check for item restrictions
                    if (itemRestrictionLists.ContainsKey(section))
                    {
                        itemRestrictionLists[section].SetItemRestrictions(kernel.GetItemRestrictions(section, i));
                    }

                    //check for equip lists
                    if (equipableLists.ContainsKey(section))
                    {
                        equipableLists[section].SetEquipableFlags(kernel.GetEquipableFlags(section, i));
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

                    //check for elements
                    if (elementLists.ContainsKey(section))
                    {
                        elementLists[section].SetElements(kernel.GetElements(section, i));
                    }
                    if (elementDamageModifiers.ContainsKey(section))
                    {
                        int modifier = (int)kernel.GetDamageModifier(section, i);
                        if (modifier == 0xFF)
                        {
                            elementDamageModifiers[section].SelectedIndex = 0;
                        }
                        else
                        {
                            elementDamageModifiers[section].SelectedIndex = modifier + 1;
                        }
                    }

                    //check for status effects
                    if (statusLists.ContainsKey(section))
                    {
                        statusLists[section].SetStatuses(kernel.GetStatuses(section, i));
                    }
                    if (equipmentStatus.ContainsKey(section))
                    {
                        int status = (int)kernel.GetEquipmentStatus(section, i);
                        if (status == 0xFF)
                        {
                            equipmentStatus[section].SelectedIndex = 0;
                        }
                        else
                        {
                            equipmentStatus[section].SelectedIndex = status + 1;
                        }
                    }

                    //get data specific to this section
                    switch (section)
                    {
                        //attack data
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

                        //item data
                        case KernelSection.ItemData:
                            var item = kernel.ItemData.Items[i];
                            comboBoxItemCamMovementID.Text = item.CameraMovementId.ToString("X4");
                            comboBoxItemAttackEffectID.Text = item.AttackEffectId.ToString("X2");
                            break;

                        //weapon data
                        case KernelSection.WeaponData:
                            var weapon = kernel.WeaponData.Weapons[i];
                            numericWeaponHitChance.Value = weapon.AccuracyRate;
                            numericWeaponCritChance.Value = weapon.CriticalRate;
                            numericWeaponModelIndex.Value = HexParser.GetLowerNybble(weapon.WeaponModelId);
                            numericWeaponAnimationIndex.Value = HexParser.GetUpperNybble(weapon.WeaponModelId);
                            break;

                        //armor data
                        case KernelSection.ArmorData:
                            var armor = kernel.ArmorData.Armors[i];
                            numericArmorDefense.Value = armor.Defense;
                            numericArmorDefensePercent.Value = armor.Evade;
                            numericArmorMagicDefense.Value = armor.MagicDefense;
                            numericArmorMagicDefensePercent.Value = armor.MagicEvade;
                            break;

                        //accessory data
                        case KernelSection.AccessoryData:
                            var acc = kernel.AccessoryData.Accessories[i];
                            if (acc.SpecialEffect == AccessoryEffect.None)
                            {
                                comboBoxAccessorySpecialEffects.SelectedIndex = 0;
                            }
                            else
                            {
                                comboBoxAccessorySpecialEffects.SelectedIndex = (int)acc.SpecialEffect + 1;
                            }
                            break;

                        //materia data
                        case KernelSection.MateriaData:
                            var materia = kernel.MateriaData.Materias[i];
                            if (Enum.IsDefined(materia.Element)){
                                comboBoxMateriaElement.SelectedIndex = (int)materia.Element;
                            }
                            else
                            {
                                comboBoxMateriaElement.SelectedIndex = -1;
                            }
                            comboBoxMateriaType.SelectedIndex = (int)materia.MateriaType;
                            materiaLevelControl.SetAPLevels(materia.Level2AP, materia.Level3AP, materia.Level4AP,
                                materia.Level5AP);
                            comboBoxMateriaEquipAttributes.Text = materia.EquipEffect.ToString("X2");
                            break;
                    }
                }
            }
            loading = false;
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

        private void comboBoxWeaponMateriaGrowth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                var rate = (GrowthRate)comboBoxWeaponMateriaGrowth.SelectedIndex;
                if (Enum.IsDefined<GrowthRate>(rate))
                {
                    materiaSlotSelectorWeapon.GrowthRate = rate;
                }
            }
        }

        private void comboBoxArmorMateriaGrowth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                var rate = (GrowthRate)comboBoxArmorMateriaGrowth.SelectedIndex;
                if (Enum.IsDefined<GrowthRate>(rate))
                {
                    materiaSlotSelectorArmor.GrowthRate = rate;
                }
            }
        }
    }
}
