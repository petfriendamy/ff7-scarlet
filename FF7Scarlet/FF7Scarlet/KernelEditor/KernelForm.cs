using Shojy.FF7.Elena;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Materias;
using FF7Scarlet.KernelEditor.Controls;
using FF7Scarlet.Shared;

namespace FF7Scarlet.KernelEditor
{
    public partial class KernelForm : Form
    {
        private const string WINDOW_TITLE = "Scarlet - Kernel Editor";
        private readonly Kernel kernel;
        private const int SUMMON_OFFSET = 56;
        private List<ushort> syncedAttackIDs = new();
        private bool unsavedChanges = false, loading = true;

        private readonly Dictionary<KernelSection, TabPage> tabPages = new();
        private readonly Dictionary<KernelSection, bool> tabPageIsEnabled = new();
        private readonly Dictionary<KernelSection, ListBox> listBoxes = new();
        private readonly Dictionary<KernelSection, TextBox> nameTextBoxes = new();
        private readonly Dictionary<KernelSection, TextBox> descriptionTextBoxes = new();
        private readonly Dictionary<KernelSection, ComboBox> cameraMovementSingle = new();
        private readonly Dictionary<KernelSection, ComboBox> cameraMovementMulti = new();
        private readonly Dictionary<KernelSection, StatIncreaseControl> statIncreases = new();
        private readonly Dictionary<KernelSection, TargetDataControl> targetData = new();
        private readonly Dictionary<KernelSection, DamageCalculationControl> damageCalculationControls = new();
        private readonly Dictionary<KernelSection, ItemRestrictionsControl> itemRestrictionLists = new();
        private readonly Dictionary<KernelSection, EquipableListControl> equipableLists = new();
        private readonly Dictionary<KernelSection, MateriaSlotSelectorControl> materiaSlots = new();
        private readonly Dictionary<KernelSection, ComboBox> materiaGrowthComboBoxes = new();
        private readonly Dictionary<KernelSection, ElementsControl> elementLists = new();
        private readonly Dictionary<KernelSection, ComboBox> elementDamageModifiers = new();
        private readonly Dictionary<KernelSection, StatusesControl> statusLists = new();
        private readonly Dictionary<KernelSection, ComboBox> equipmentStatus = new();

        public KernelForm()
        {
            InitializeComponent();
            kernel = DataManager.CopyKernel();
            foreach (var a in kernel.Attacks)
            {
                if (DataManager.AttackIsSynced(a.ID)) { syncedAttackIDs.Add(a.ID); }
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
            cameraMovementSingle.Add(KernelSection.CommandData, comboBoxCommandCameraMovementIDSingle);
            cameraMovementMulti.Add(KernelSection.CommandData, comboBoxCommandCamMovementIDMulti);
            targetData.Add(KernelSection.CommandData, targetDataControlCommand);

            //attack data
            tabPages.Add(KernelSection.AttackData, tabPageAttackData);
            listBoxes.Add(KernelSection.AttackData, listBoxAttacks);
            nameTextBoxes.Add(KernelSection.AttackData, textBoxAttackName);
            descriptionTextBoxes.Add(KernelSection.AttackData, textBoxAttackDescription);
            cameraMovementSingle.Add(KernelSection.AttackData, comboBoxAttackCamMovementIDSingle);
            cameraMovementMulti.Add(KernelSection.AttackData, comboBoxAttackCamMovementIDMulti);
            damageCalculationControls.Add(KernelSection.AttackData, damageCalculationControlAttack);
            elementLists.Add(KernelSection.AttackData, elementsControlAttack);
            statusLists.Add(KernelSection.AttackData, statusesControlAttack);

            //item data
            tabPages.Add(KernelSection.ItemData, tabPageItemData);
            listBoxes.Add(KernelSection.ItemData, listBoxItems);
            nameTextBoxes.Add(KernelSection.ItemData, textBoxItemName);
            descriptionTextBoxes.Add(KernelSection.ItemData, textBoxItemDescription);
            cameraMovementSingle.Add(KernelSection.ItemData, comboBoxItemCamMovementID);
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

            //initial cursor command
            foreach (var c in InitialCursorActionInfo.ACTION_LIST)
            {
                comboBoxCommandInitialCursorAction.Items.Add(c.Description);
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
            comboBoxAttackStatusChange.Items.Add("None");
            foreach (var s in Enum.GetNames<StatusChange>())
            {
                comboBoxAttackStatusChange.Items.Add(s);
            }

            //materia info
            foreach (var g in Enum.GetNames<GrowthRate>())
            {
                foreach (var cb in materiaGrowthComboBoxes.Values)
                {
                    cb.Items.Add(g);
                }
            }
            foreach (var el in Enum.GetValues<MateriaElements>())
            {
                if (el == MateriaElements.Bolt) { comboBoxMateriaElement.Items.Add("Lightning"); }
                else { comboBoxMateriaElement.Items.Add(el); }
            }
            foreach (var mt in Enum.GetNames<MateriaType>())
            {
                comboBoxMateriaType.Items.Add(mt);
            }

            //condition sub-menu
            comboBoxAttackConditionSubMenu.Items.Add("None");
            foreach (var c in Enum.GetValues<AttackConditions>())
            {
                if (c != AttackConditions.None)
                {
                    comboBoxAttackConditionSubMenu.Items.Add(c);
                }
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

        private void SetUnsaved(bool unsaved)
        {
            unsavedChanges = unsaved;
            Text = $"{(unsaved ? "*" : "")}{WINDOW_TITLE}";
        }

        private void EnableOrDisableTabPageControls(KernelSection section, bool enabled)
        {
            if (!tabPageIsEnabled.ContainsKey(section))
            {
                tabPageIsEnabled.Add(section, !enabled);
            }
            if (tabPages.ContainsKey(section) && tabPageIsEnabled[section] != enabled)
            {
                EnableOrDisableInner(section, tabPages[section], enabled);
                tabPageIsEnabled[section] = enabled;
            }
        }

        private void EnableOrDisableInner(KernelSection section, Control group, bool enabled)
        {
            for (int i = 0; i < group.Controls.Count; ++i)
            {
                var c = group.Controls[i];
                if (c != null)
                {
                    if (ShouldIgnoreControl(section, c))
                    {
                        if (c != listBoxes[section]) { c.Enabled = false; }
                    }
                    else
                    {
                        if (c is TabControl)
                        {
                            var innerTab = c as TabControl;
                            if (innerTab != null)
                            {
                                for (int j = 0; j < innerTab.TabCount; ++j)
                                {
                                    EnableOrDisableInner(section, innerTab.TabPages[j], enabled);
                                }
                            }
                        }
                        else if (c is GroupBox)
                        {
                            var groupBox = c as GroupBox;
                            if (groupBox != null)
                            {
                                EnableOrDisableInner(section, groupBox, enabled);
                            }
                        }
                        else { c.Enabled = enabled; }
                    }
                }
            }
        }

        private bool ShouldIgnoreControl(KernelSection section, Control c)
        {
            if (c == listBoxes[section]) { return true; }
            if (!DataManager.BothKernelFilesLoaded &&
                (c == nameTextBoxes[section] || c == descriptionTextBoxes[section])) { return true; }
            if (!DataManager.SceneFileIsLoaded && c == checkBoxAttackSyncWithSceneBin) { return true; }
            return false;
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

                    //check for camera movement ID(s)
                    if (cameraMovementSingle.ContainsKey(section))
                    {
                        cameraMovementSingle[section].Text = kernel.GetCameraMovementIDSingle(section, i).ToString("X4");
                    }
                    if (cameraMovementMulti.ContainsKey(section))
                    {
                        cameraMovementMulti[section].Text = kernel.GetCameraMovementIDMulti(section, i).ToString("X4");
                    }

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
                        elementLists[section].SetElements(kernel.GetElement(section, i));
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
                            var attack = kernel.Attacks[i];
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
                            numericAttackMPCost.Value = attack.MPCost;
                            comboBoxAttackAttackEffectID.Text = attack.AttackEffectID.ToString("X2");
                            comboBoxAttackImpactEffectID.Text = attack.ImpactEffectID.ToString("X2");
                            comboBoxAttackHurtActionIndex.Text = attack.TargetHurtActionIndex.ToString("X2");
                            if (attack.AttackConditions == AttackConditions.None)
                            {
                                comboBoxAttackConditionSubMenu.SelectedIndex = 0;
                            }
                            else
                            {
                                comboBoxAttackConditionSubMenu.SelectedIndex = (int)attack.AttackConditions + 1;
                            }
                            specialAttackFlagsControlAttack.SetFlags(attack.SpecialAttackFlags);
                            numericAttackStatusChangeChance.Value = attack.StatusChangeChance;
                            if (attack.StatusChange == StatusChange.None)
                            {
                                comboBoxAttackStatusChange.SelectedIndex = 0;
                                numericAttackStatusChangeChance.Enabled = false;
                                statusesControlAttack.Enabled = false;
                            }
                            else
                            {
                                var s = Enum.GetValues<StatusChange>().ToList();
                                comboBoxAttackStatusChange.SelectedIndex = s.IndexOf(attack.StatusChange) + 1;
                                numericAttackStatusChangeChance.Enabled = true;
                                statusesControlAttack.Enabled = true;
                            }
                            checkBoxAttackSyncWithSceneBin.Checked = syncedAttackIDs.Contains(attack.ID);
                            break;

                        //item data
                        case KernelSection.ItemData:
                            var item = kernel.ItemData.Items[i];
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
                else
                {
                    EnableOrDisableTabPageControls(section, false);
                    if (section == KernelSection.AttackData && i > 0)
                    {
                        var names = kernel.GetAssociatedNames(section);
                        var descs = kernel.GetAssociatedDescriptions(section);
                        if (i < names.Length && i < descs.Length)
                        {
                            textBoxAttackName.Text = names[i];
                            textBoxAttackDescription.Text = descs[i];
                            textBoxAttackName.Enabled = textBoxAttackDescription.Enabled = true;
                        }
                    }
                }
            }
            loading = false;
        }

        private void checkBoxAttackSyncWithSceneBin_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                bool isChecked = checkBoxAttackSyncWithSceneBin.Checked;
                var selected = listBoxAttacks.SelectedIndex;
                if (selected >= 0 && selected < kernel.GetCount(KernelSection.AttackData))
                {
                    var atk = kernel.Attacks[selected];
                    loading = true;
                    if (isChecked)
                    {
                        bool result = MessageBox.Show("All instances of this attack in scene.bin will be synced with this one. Is that okay?",
                            "Sync Attack?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                        if (result)
                        {
                            SyncAttack(atk.ID);
                            SetUnsaved(true);
                        }
                        checkBoxAttackSyncWithSceneBin.Checked = result;
                    }
                    else
                    {
                        if (DataManager.AttackIsSynced(atk.ID))
                        {
                            bool result = MessageBox.Show("This will desync this attack from every instance of this attack in scene.bin. Are you sure you want to do this?",
                                "Desync Attack?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                            if (result)
                            {
                                syncedAttackIDs.Remove(atk.ID);
                                DataManager.UnsyncAttack(atk.ID);
                                kernel.Attacks[selected] = new Attack(atk.ID, atk.Name, atk.GetRawData());
                                SetUnsaved(true);
                            }
                            checkBoxAttackSyncWithSceneBin.Checked = result;
                        }
                    }
                    loading = false;
                }
            }
        }

        private void buttonAttackSyncAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("This will sync EVERY attack shared between kernel.bin and scene.bin. Are you sure you want to do this?",
                "Sync All?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                loading = true;
                foreach (var a in kernel.Attacks)
                {
                    SyncAttack(a.ID);
                }
                checkBoxAttackSyncWithSceneBin.Checked = true;
                loading = false;
            }
        }

        private void SyncAttack(ushort id)
        {
            if (!syncedAttackIDs.Contains(id))
            {
                syncedAttackIDs.Add(id);
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

        private void comboBoxWeaponMateriaGrowth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                var rate = (GrowthRate)comboBoxWeaponMateriaGrowth.SelectedIndex;
                if (Enum.IsDefined(rate))
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
                if (Enum.IsDefined(rate))
                {
                    materiaSlotSelectorArmor.GrowthRate = rate;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false,
                    saveSceneBin = false,
                    otherFormsOpen = (DataManager.FormIsOpen(FormType.BattleDataEditor) ||
                        DataManager.FormIsOpen(FormType.BattleAIEditor));

                //check if there are any attacks that need to be synced
                if (syncedAttackIDs.Count > 0)
                {
                    //if no other forms are open, offer to save scene.bin as well
                    if (!otherFormsOpen)
                    {
                        var dialogResult = MessageBox.Show("Update scene.bin also?", "Update scene.bin?", MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Cancel) { return; }
                        else if (dialogResult == DialogResult.No)
                        {
                            result = true;
                        }
                        else
                        {
                            saveSceneBin = true;
                        }
                    }

                    //sync the attack data
                    int count = 0;
                    foreach (var i in syncedAttackIDs)
                    {
                        var atk = kernel.GetAttackByID(i);
                        if (atk != null)
                        {
                            count += DataManager.SyncAttack(atk, saveSceneBin);
                        }
                    }

                    //display a message
                    if (saveSceneBin)
                    {
                        MessageBox.Show($"{count} attack(s) updated.", "Attacks synced", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        if (count > 0) { DataManager.CreateSceneBin(); }
                    }
                }
                DataManager.CreateKernel(true);
                SetUnsaved(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            using (var exportDialog = new KernelChunkExportForm(kernel))
            {
                exportDialog.ShowDialog();
            }
        }

        private void KernelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unsavedChanges)
            {
                var result = MessageBox.Show("Unsaved changes will be lost. Are you sure?", "Unsaved changes",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                e.Cancel = result == DialogResult.No;
            }
        }

        private void KernelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataManager.CloseForm(FormType.KernelEditor);
        }
    }
}
