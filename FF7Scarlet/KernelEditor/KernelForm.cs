﻿using System.Collections.ObjectModel;
using System.Globalization;
using System.Media;

using Shojy.FF7.Elena;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Materias;

using FF7Scarlet.SceneEditor;
using FF7Scarlet.KernelEditor.Controls;
using FF7Scarlet.AIEditor;
using FF7Scarlet.Shared;
using FF7Scarlet.Shared.Controls;

namespace FF7Scarlet.KernelEditor
{
    public partial class KernelForm : Form
    {
        #region Properties

        private const string WINDOW_TITLE = "Scarlet - Kernel Editor";
        private readonly string[] SCRIPT_LIST = new string[Script.SCRIPT_COUNT]
        {
            "Pre-Battle", "Main", "General Counter", "Death Counter", "Physical Counter",
            "Magic Counter", "Ally Death", "Post-Attack", "Custom Event 1",
            "Custom Event 2", "Custom Event 3", "Custom Event 4", "Custom Event 5",
            "Custom Event 6", "Custom Event 7", "Post-Battle"
        };
        private readonly Kernel kernel;
        private const int SUMMON_OFFSET = 56;
        private List<ushort> syncedAttackIDs = new();
        private List<StatusChange> statusChanges = new();
        private int prevAttack;
        private bool
            attackNeedsSync = false,
            itemsNeedSync = false,
            unsavedChanges = false,
            loading = true;

        private readonly Dictionary<KernelSection, TabPage> tabPages = new();
        private readonly Dictionary<TabPage, bool> tabPageIsEnabled = new();
        private readonly Dictionary<KernelSection, ToolStripMenuItem> toolStrips = new();
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
        private readonly Dictionary<KernelSection, SpecialAttackFlagsControl> specialAttackFlags = new();

        private KernelSection CurrentSection
        {
            get
            {
                foreach (var p in tabPages)
                {
                    if (p.Value == tabControlMain.SelectedTab)
                    {
                        return p.Key;
                    }
                }
                throw new ArgumentNullException();
            }
        }

        private Attack? SelectedAttack
        {
            get
            {
                if (SelectedAttackIndex >= 0 && SelectedAttackIndex < Kernel.ATTACK_COUNT)
                {
                    return kernel.Attacks[SelectedAttackIndex];
                }
                return null;
            }
        }
        private int SelectedAttackIndex
        {
            get { return listBoxAttacks.SelectedIndex; }
        }

        #endregion

        #region Constructor

        public KernelForm()
        {
            InitializeComponent();
            kernel = DataManager.CopyKernel();
            foreach (var a in kernel.Attacks)
            {
                if (DataManager.AttackIsSynced(a.ID)) { syncedAttackIDs.Add(a.ID); }
            }
            selectedAttackToolStripMenuItem.Enabled = false;

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
            toolStrips.Add(KernelSection.AttackData, selectedAttackToolStripMenuItem);
            listBoxes.Add(KernelSection.AttackData, listBoxAttacks);
            nameTextBoxes.Add(KernelSection.AttackData, textBoxAttackName);
            descriptionTextBoxes.Add(KernelSection.AttackData, textBoxAttackDescription);
            cameraMovementSingle.Add(KernelSection.AttackData, comboBoxAttackCamMovementIDSingle);
            cameraMovementMulti.Add(KernelSection.AttackData, comboBoxAttackCamMovementIDMulti);
            targetData.Add(KernelSection.AttackData, targetDataControlAttack);
            damageCalculationControls.Add(KernelSection.AttackData, damageCalculationControlAttack);
            elementLists.Add(KernelSection.AttackData, elementsControlAttack);
            statusLists.Add(KernelSection.AttackData, statusesControlAttack);
            specialAttackFlags.Add(KernelSection.AttackData, specialAttackFlagsControlAttack);

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
            specialAttackFlags.Add(KernelSection.ItemData, specialAttackFlagsControlItem);

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
            foreach (var t in kernel.BattleText.Strings)
            {
                listBoxBattleText.Items.Add(t);
            }

            //initial cursor command
            comboBoxCommandInitialCursorAction.Items.Add("None");
            foreach (var c in InitialCursorActionInfo.ACTION_LIST)
            {
                comboBoxCommandInitialCursorAction.Items.Add(c.Description);
            }

            //character data
            for (int i = 0; i < Character.CHARACTER_COUNT; ++i)
            {
                var name = Enum.GetName((CharacterNames)i);
                if (name != null)
                {
                    var parsedName = StringParser.AddSpace(name);
                    listBoxCharacterAI.Items.Add(parsedName);

                    //playable characters
                    if (i < Character.PLAYABLE_CHARACTER_COUNT)
                    {
                        listBoxCharacterGrowth.Items.Add(parsedName);

                        if (i == 6 || i == 7) //Cait/Vincent
                        {
                            var name2 = Enum.GetName((CharacterNames)(i + 3));
                            if (name2 != null)
                            {
                                parsedName = StringParser.AddSpace(name2); //+= $"/{StringParser.AddSpace(name2)}";
                            }
                        }
                        listBoxInitCharacters.Items.Add(parsedName);
                    }
                }
            }
            listBoxCharacterAI.Items.Add("(unknown)");
            LoadItemLists();
            foreach (var f in Enum.GetNames<CharacterFlags>())
            {
                comboBoxCharacterFlags.Items.Add(f);
            }

            //battle data
            rngTableControl.SetValues(kernel.BattleAndGrowthData.RNGTable);

            //inventory
            PopulateInventoryListBoxes();

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
                        cb.Items.Add(StringParser.AddSpace(s.ToString()));
                    }
                }
            }
            comboBoxAttackStatusChange.Items.Add("None");
            foreach (var s in Enum.GetValues<StatusChange>())
            {
                if (s != StatusChange.None)
                {
                    comboBoxAttackStatusChange.Items.Add(s);
                    statusChanges.Add(s);
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

            //set max values for various controls
            textBoxAttackName.MaxLength = Scene.NAME_LENGTH - 1;
            numericCharacterCurrentEXP.Maximum = uint.MaxValue;
            numericCharacterEXPtoNext.Maximum = uint.MaxValue;

            //show/hide controls that are invalid
            itemRestrictionsWeapon.ShowThrowable = true;
            materiaSlotSelectorCharacterWeapon.SlotSelectorType = SlotSelectorType.Materia;
            materiaSlotSelectorCharacterArmor.SlotSelectorType = SlotSelectorType.Materia;
            materiaSlotSelectorWeapon.SlotSelectorType = SlotSelectorType.Slots;
            materiaSlotSelectorArmor.SlotSelectorType = SlotSelectorType.Slots;
            statIncreaseControlAccessory.Count = 2;
            statusesControlMateria.FullList = false;

            //disable all the controls while there's no data in them
            foreach (var tab in tabPages)
            {
                EnableOrDisableTabPageControls(tab.Key, false);
            }
            EnableOrDisableSingleIgnore(tabPageInitCharacterStats, false, listBoxInitCharacters);
            loading = false;
        }

        #endregion

        #region User Methods

        private void SetUnsaved(bool unsaved)
        {
            unsavedChanges = unsaved;
            Text = $"{(unsaved ? "*" : "")}{WINDOW_TITLE}";
        }

        private void EnableOrDisableTabPageControls(KernelSection section, bool enabled)
        {
            if (!tabPageIsEnabled.ContainsKey(tabPages[section]))
            {
                tabPageIsEnabled.Add(tabPages[section], !enabled);
            }
            if (tabPages.ContainsKey(section) && tabPageIsEnabled[tabPages[section]] != enabled)
            {
                EnableOrDisableInner(tabPages[section], enabled, GetIgnoreListForSection(section));
                tabPageIsEnabled[tabPages[section]] = enabled;
            }
        }

        private void EnableOrDisableInner(Control group, bool enabled, ReadOnlyCollection<Control>? ignoreList)
        {
            for (int i = 0; i < group.Controls.Count; ++i)
            {
                var c = group.Controls[i];
                if (c != null)
                {
                    if (ignoreList != null && ignoreList.Contains(c))
                    {
                        if (!(c is ListBox)) { c.Enabled = false; }
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
                                    EnableOrDisableInner(innerTab.TabPages[j], enabled, ignoreList);
                                }
                            }
                        }
                        else if (c is GroupBox)
                        {
                            var groupBox = c as GroupBox;
                            if (groupBox != null)
                            {
                                EnableOrDisableInner(groupBox, enabled, ignoreList);
                            }
                        }
                        else { c.Enabled = enabled; }
                    }
                }
            }
        }

        private void EnableOrDisableSingleIgnore(Control group, bool enable, Control ignore)
        {
            var list = new List<Control> { ignore };
            EnableOrDisableInner(group, enable, list.AsReadOnly());
        }

        private ReadOnlyCollection<Control> GetIgnoreListForSection(KernelSection section)
        {
            var list = new List<Control>();
            if (tabPages.ContainsKey(section))
            {
                list.Add(listBoxes[section]);
                if (!DataManager.BothKernelFilePathsExist)
                {
                    list.Add(nameTextBoxes[section]);
                    list.Add(descriptionTextBoxes[section]);
                }
                if (!DataManager.SceneFilePathExists)
                {
                    list.Add(checkBoxAttackSyncWithSceneBin);
                }
            }
            return list.AsReadOnly();
        }

        private void LoadItemLists()
        {
            loading = true;

            //items
            comboBoxInitItem.Items.Clear();
            comboBoxInitItem.Items.Add("None");
            foreach (var item in kernel.ItemData.Items)
            {
                comboBoxInitItem.Items.Add(item.Name);
            }

            //weapons
            comboBoxCharacterWeapon.Items.Clear();
            foreach (var wpn in kernel.WeaponData.Weapons)
            {
                comboBoxCharacterWeapon.Items.Add(wpn.Name);
                comboBoxInitItem.Items.Add(wpn.Name);
            }

            //armor
            comboBoxCharacterArmor.Items.Clear();
            foreach (var armor in kernel.ArmorData.Armors)
            {
                comboBoxCharacterArmor.Items.Add(armor.Name);
                comboBoxInitItem.Items.Add(armor.Name);
            }

            //accessories
            comboBoxCharacterAccessory.Items.Clear();
            comboBoxCharacterAccessory.Items.Add("None");
            foreach (var acc in kernel.AccessoryData.Accessories)
            {
                comboBoxCharacterAccessory.Items.Add(acc.Name);
                comboBoxInitItem.Items.Add(acc.Name);
            }

            //materia
            comboBoxInitMateria.Items.Clear();
            comboBoxInitMateria.Items.Add("None");
            comboBoxInitMateriaStolen.Items.Add("None");
            foreach (var mat in kernel.MateriaData.Materias)
            {
                comboBoxInitMateria.Items.Add(mat.Name);
                comboBoxInitMateriaStolen.Items.Add(mat.Name);
            }

            loading = false;
        }

        private void PopulateInventoryListBoxes()
        {
            listBoxInitInventory.SuspendLayout();
            listBoxInitMateria.SuspendLayout();
            listBoxInitMateriaStolen.SuspendLayout();

            listBoxInitInventory.Items.Clear();
            foreach (var inv in kernel.InitialData.InventoryItems)
            {
                if (inv.Item.Type == ItemType.None)
                {
                    listBoxInitInventory.Items.Add("(empty)");
                }
                else
                {
                    listBoxInitInventory.Items.Add($"{kernel.GetInventoryItemName(inv.Item)} x{inv.Amount}");
                }
            }
            listBoxInitMateria.Items.Clear();
            foreach (var invm in kernel.InitialData.InventoryMateria)
            {
                var m = kernel.GetMateriaByID(invm.Index);
                if (m == null)
                {
                    listBoxInitMateria.Items.Add("(empty)");
                }
                else
                {
                    listBoxInitMateria.Items.Add(m.Name);
                }
            }
            listBoxInitMateriaStolen.Items.Clear();
            foreach (var sm in kernel.InitialData.StolenMateria)
            {
                var m = kernel.GetMateriaByID(sm.Index);
                if (m == null)
                {
                    listBoxInitMateriaStolen.Items.Add("(empty)");
                }
                else
                {
                    listBoxInitMateriaStolen.Items.Add(m.Name);
                }
            }
            listBoxInitInventory.ResumeLayout();
            listBoxInitMateria.ResumeLayout();
            listBoxInitMateriaStolen.ResumeLayout();
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

                    //check for toolstrips
                    if (toolStrips.ContainsKey(section))
                    {
                        toolStrips[section].Enabled = true;
                    }

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
                        materiaSlots[section].SetSlots(slots, rate);
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

                    //special attack flags
                    if (specialAttackFlags.ContainsKey(section))
                    {
                        specialAttackFlags[section].SetFlags(kernel.GetSpecialEffects(section, i));
                    }

                    //get data specific to this section
                    switch (section)
                    {
                        //command data
                        case KernelSection.CommandData:
                            var command = kernel.Commands[i];
                            if (command.InitialCursorAction == 0xFF)
                            {
                                comboBoxCommandInitialCursorAction.SelectedIndex = 0;
                            }
                            else
                            {
                                comboBoxCommandInitialCursorAction.SelectedIndex = command.InitialCursorAction + 1;
                            }
                            break;

                        //attack data
                        case KernelSection.AttackData:
                            attackPasteToolStripMenuItem.Enabled = DataManager.CopiedAttack != null;
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
                            numericAttackAttackPercent.Value = attack.AccuracyRate;
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
                            if (Enum.IsDefined(materia.Element))
                            {
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

        private void PopulateInitCharacterDataTab(int charIndex)
        {
            if (charIndex >= 0 && charIndex < 9)
            {
                if (!tabPageIsEnabled.ContainsKey(tabPageInitCharacterStats))
                {
                    EnableOrDisableInner(tabPageInitCharacterStats, true, null);
                    tabPageIsEnabled.Add(tabPageInitCharacterStats, true);
                }

                var character = kernel.InitialData.Characters[charIndex];

                textBoxCharacterName.Text = character.Name.ToString();
                numericCharacterID.Value = character.ID;
                numericCharacterLevel.Value = character.Level;
                numericCharacterCurrentEXP.Value = character.CurrentEXP;
                numericCharacterEXPtoNext.Value = character.EXPtoNextLevel;

                numericCharacterCurrHP.Value = character.CurrentHP;
                numericCharacterBaseHP.Value = character.BaseHP;
                numericCharacterMaxHP.Value = character.MaxHP;
                numericCharacterCurrMP.Value = character.CurrentMP;
                numericCharacterBaseMP.Value = character.BaseMP;
                numericCharacterMaxMP.Value = character.MaxMP;

                var temp = Enum.GetValues<CharacterFlags>().ToList();
                comboBoxCharacterFlags.SelectedIndex = temp.IndexOf(character.CharacterFlags);
                checkBoxCharacterBackRow.Checked = character.IsBackRow;
                characterLimitControl.LimitLevel = character.LimitLevel;
                characterLimitControl.LearnedLimits = character.LearnedLimits;
                characterLimitControl.LimitBar = character.CurrentLimitBar;

                var wpn = kernel.GetWeaponByID(character.WeaponID);
                if (wpn != null)
                {
                    comboBoxCharacterWeapon.SelectedIndex = character.WeaponID;
                    materiaSlotSelectorCharacterWeapon.SetSlots(wpn);
                    for (int i = 0; i < 8; ++i)
                    {
                        var mat = kernel.GetMateriaByID(character.WeaponMateria[i].Index);
                        materiaSlotSelectorCharacterWeapon.SetMateria(i, mat);
                        materiaSlotSelectorCharacterWeapon.SelectedSlot = -1;
                    }
                }
                buttonCharacterWeaponChangeMateria.Enabled = false;
                var armor = kernel.GetArmorByID(character.ArmorID);
                if (armor != null)
                {
                    comboBoxCharacterArmor.SelectedIndex = character.ArmorID;
                    materiaSlotSelectorCharacterArmor.SetSlots(armor);
                    for (int i = 0; i < 8; ++i)
                    {
                        var mat = kernel.GetMateriaByID(character.ArmorMateria[i].Index);
                        materiaSlotSelectorCharacterArmor.SetMateria(i, mat);
                        materiaSlotSelectorCharacterArmor.SelectedSlot = -1;
                    }
                }
                buttonCharacterArmorChangeMateria.Enabled = false;
                var acc = kernel.GetAccessoryByID(character.AccessoryID);
                if (acc == null)
                {
                    comboBoxCharacterAccessory.SelectedIndex = 0;
                }
                else
                {
                    comboBoxCharacterAccessory.SelectedIndex = character.AccessoryID + 1;
                }
                characterStatsControl.SetStats(character);
            }
        }

        private void PopulateInitInventoryBox(int i)
        {
            if (i >= 0 && i < InitialData.INVENTORY_SIZE)
            {
                var item = kernel.InitialData.InventoryItems[i];
                loading = true;
                comboBoxInitItem.Enabled = true;
                switch (item.Item.Type)
                {
                    case ItemType.Item:
                        comboBoxInitItem.SelectedIndex = item.Item.Index + 1;
                        break;
                    case ItemType.Weapon:
                        comboBoxInitItem.SelectedIndex = item.Item.Index + InventoryItem.WEAPON_START + 1;
                        break;
                    case ItemType.Armor:
                        comboBoxInitItem.SelectedIndex = item.Item.Index + InventoryItem.ARMOR_START + 1;
                        break;
                    case ItemType.Accessory:
                        comboBoxInitItem.SelectedIndex = item.Item.Index + InventoryItem.ACCESSORY_START + 1;
                        break;
                    default:
                        comboBoxInitItem.SelectedIndex = 0;
                        break;
                }

                if (item.Item.Type == ItemType.None)
                {
                    numericInitItemAmount.Value = 0;
                    numericInitItemAmount.Enabled = false;
                }
                else
                {
                    numericInitItemAmount.Value = item.Amount;
                    numericInitItemAmount.Enabled = true;
                }
                loading = false;
            }
        }

        private void PopulateInitMateriaBox(bool isStolen)
        {
            //get index + max
            int i, max;
            if (isStolen)
            {
                i = listBoxInitMateriaStolen.SelectedIndex;
                max = InitialData.STOLEN_MATERIA_COUNT;
            }
            else
            {
                i = listBoxInitMateria.SelectedIndex;
                max = InitialData.MATERIA_INVENTORY_SIZE;
            }

            if (i >= 0 && i < max)
            {
                loading = true;

                //get data to edit
                InventoryMateria materia;
                ComboBox comboBox;
                Button editButton;

                if (isStolen)
                {
                    materia = kernel.InitialData.StolenMateria[i];
                    comboBox = comboBoxInitMateriaStolen;
                    editButton = buttonInitMateriaStolenEdit;
                }
                else
                {
                    materia = kernel.InitialData.InventoryMateria[i];
                    comboBox = comboBoxInitMateria;
                    editButton = buttonInitMateriaEdit;
                }

                comboBox.Enabled = true;
                if (materia.Index == 0xFF)
                {
                    comboBox.SelectedIndex = 0;
                    editButton.Enabled = false;
                }
                else
                {
                    comboBox.SelectedIndex = materia.Index + 1;
                    editButton.Enabled = true;
                }
                loading = false;
            }
        }

        private void UpdateCharacterAIScripts(int selectedChar)
        {
            if (selectedChar >= 0 && selectedChar < BattleAndGrowthData.AI_BLOCK_COUNT)
            {
                try
                {
                    if (!kernel.BattleAndGrowthData.ScriptsLoaded)
                    {
                        kernel.BattleAndGrowthData.ParseAIScripts();
                        groupBoxCharacterScripts.Enabled = true;
                        scriptControlCharacterAI.Enabled = true;
                    }
                    var chara = kernel.BattleAndGrowthData.CharacterAI[selectedChar];
                    for (int i = 0; i < Script.SCRIPT_COUNT; ++i)
                    {
                        listBoxCharacterScripts.Items[i] = SCRIPT_LIST[i];
                        if (chara != null)
                        {
                            var script = chara.Scripts[i];
                            if (script != null && !script.IsEmpty)
                            {
                                listBoxCharacterScripts.Items[i] += "*";
                            }
                        }
                    }
                    //select first script
                    if (listBoxCharacterScripts.SelectedIndex == -1)
                    {
                        listBoxCharacterScripts.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error in A.I. data: {ex.Message}", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void DisplayScript(int charID, int scriptID)
        {
            var chara = kernel.BattleAndGrowthData.CharacterAI[charID];
            scriptControlCharacterAI.AIContainer = chara;
            scriptControlCharacterAI.SelectedScriptIndex = scriptID;
        }

        private void SetInventoryItem()
        {
            int selectedItem = listBoxInitInventory.SelectedIndex,
                newItemIndex = comboBoxInitItem.SelectedIndex,
                amount = (int)numericInitItemAmount.Value;

            if (selectedItem >= 0 && selectedItem < InitialData.INVENTORY_SIZE)
            {
                loading = true;
                var item = kernel.InitialData.InventoryItems[selectedItem];
                if (newItemIndex == 0) //none
                {
                    item.Item.SetItem(ItemType.None, 0);
                    listBoxInitInventory.Items[selectedItem] = "(empty)";
                    numericInitItemAmount.Value = 0;
                    numericInitItemAmount.Enabled = false;
                }
                else //get selected item
                {
                    if (amount == 0)
                    {
                        amount = 1;
                        numericInitItemAmount.Value = amount;
                    }
                    numericInitItemAmount.Enabled = true;

                    var type = InventoryItem.GetType((ushort)(newItemIndex - 1));
                    byte index = InventoryItem.GetIndex((ushort)(newItemIndex - 1));

                    item.Item.SetItem(type, index);
                    item.Amount = amount;
                    var name = kernel.GetInventoryItemName(item.Item);
                    listBoxInitInventory.Items[selectedItem] = $"{name} x{amount}";
                }
                loading = false;
                SetUnsaved(true);
            }
        }

        private void SetInitMateria(bool isStolen)
        {
            //get data to check/edit
            int selectedMateria, newMateriaIndex, max;
            ListBox listBox;
            ComboBox comboBox;
            Button editButton;

            if (isStolen)
            {
                max = InitialData.STOLEN_MATERIA_COUNT;
                listBox = listBoxInitMateriaStolen;
                comboBox = comboBoxInitMateriaStolen;
                editButton = buttonInitMateriaStolenEdit;
            }
            else
            {
                max = InitialData.MATERIA_INVENTORY_SIZE;
                listBox = listBoxInitMateria;
                comboBox = comboBoxInitMateria;
                editButton = buttonInitMateriaEdit;
            }
            selectedMateria = listBox.SelectedIndex;
            newMateriaIndex = comboBox.SelectedIndex;

            if (selectedMateria >= 0 && selectedMateria < max)
            {
                loading = true;

                InventoryMateria materia;
                if (isStolen) { materia = kernel.InitialData.StolenMateria[selectedMateria]; }
                else { materia = kernel.InitialData.InventoryMateria[selectedMateria]; }

                if (newMateriaIndex == 0) //no materia
                {
                    materia.Index = 0xFF;
                    listBox.Items[selectedMateria] = "(empty)";
                    editButton.Enabled = false;
                }
                else //get materia index
                {
                    materia.Index = (byte)(newMateriaIndex - 1);
                    var md = kernel.GetMateriaByID(materia.Index);
                    if (md == null)
                    {
                        listBox.Items[selectedMateria] = "(unknown)";
                    }
                    else
                    {
                        listBox.Items[selectedMateria] = md.Name;
                    }
                    editButton.Enabled = true;
                }
                loading = false;
                SetUnsaved(true);
            }
        }

        private void SyncAttack(ushort id)
        {
            if (!syncedAttackIDs.Contains(id))
            {
                syncedAttackIDs.Add(id);
            }
        }

        private void SyncAttackData(Attack attack)
        {
            attack.AccuracyRate = (byte)numericAttackAttackPercent.Value;
            attack.MPCost = (ushort)numericAttackMPCost.Value;
            attack.TargetFlags = targetDataControlAttack.GetTargetData();
            attack.DamageCalculationID = damageCalculationControlAttack.ActualValue;
            attack.AttackStrength = damageCalculationControlAttack.AttackPower;
            if (comboBoxAttackConditionSubMenu.SelectedIndex == 0)
            {
                attack.AttackConditions = AttackConditions.None;
            }
            else
            {
                attack.AttackConditions = (AttackConditions)(comboBoxAttackConditionSubMenu.SelectedIndex - 1);
            }
            attack.StatusEffects = statusesControlAttack.GetStatuses();
            attack.Elements = elementsControlAttack.GetElements();
            attack.SpecialAttackFlags = specialAttackFlagsControlAttack.GetFlags();

            attackNeedsSync = false;
        }

        public void UpdateLookupTable(byte[] table)
        {
            kernel.UpdateLookupTable(table);
        }

        #endregion

        #region Event Methods

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemsNeedSync) //sync item names
            {
                var tab = tabControlMain.SelectedTab;
                if (tab == tabPageInitInventory || tab == tabPageCharacters)
                {
                    LoadItemLists();
                    PopulateInitCharacterDataTab(listBoxInitCharacters.SelectedIndex);
                    PopulateInventoryListBoxes();
                    itemsNeedSync = false;
                }
            }
        }

        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                PopulateTabWithSelected(KernelSection.CommandData);
            }
        }

        private void listBoxAttacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (attackNeedsSync) //sync unsaved attack data
                {
                    var attack = kernel.Attacks[prevAttack];
                    if (attack != null)
                    {
                        SyncAttackData(attack);
                    }
                }
                prevAttack = SelectedAttackIndex;
                PopulateTabWithSelected(KernelSection.AttackData);
            }
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                PopulateTabWithSelected(KernelSection.ItemData);
            }

        }

        private void listBoxWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                PopulateTabWithSelected(KernelSection.WeaponData);
            }
        }

        private void listBoxArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                PopulateTabWithSelected(KernelSection.ArmorData);
            }
        }

        private void listBoxAccessories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                PopulateTabWithSelected(KernelSection.AccessoryData);
            }
        }

        private void listBoxMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                PopulateTabWithSelected(KernelSection.MateriaData);
            }
        }

        private void listBoxKeyItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                PopulateTabWithSelected(KernelSection.KeyItemNames);
            }
        }

        private void listBoxBattleText_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = listBoxBattleText.SelectedIndex;
                if (i >= 0 && i < kernel.GetCount(KernelSection.BattleText))
                {
                    labelBattleText.Enabled = true;
                    textBoxBattleText.Enabled = true;
                    textBoxBattleText.Text = kernel.BattleText.Strings[i];
                }
            }
        }

        private void listBoxInitCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                PopulateInitCharacterDataTab(listBoxInitCharacters.SelectedIndex);
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                var curr = CurrentSection;
                int selected = listBoxes[curr].SelectedIndex;
                if (selected >= 0 && selected < listBoxes[curr].Items.Count)
                {
                    loading = true;
                    kernel.UpdateName(curr, nameTextBoxes[curr].Text, selected);
                    listBoxes[curr].Items[selected] = nameTextBoxes[curr].Text;
                    if (curr == KernelSection.ItemData || curr == KernelSection.WeaponData
                        || curr == KernelSection.ArmorData || curr == KernelSection.AccessoryData
                        || curr == KernelSection.MateriaData)
                    {
                        itemsNeedSync = true;
                    }
                    SetUnsaved(true);
                    loading = false;
                }
            }
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                var curr = CurrentSection;
                int selected = listBoxes[curr].SelectedIndex;
                if (selected >= 0 && selected < listBoxes[curr].Items.Count)
                {
                    kernel.GetAssociatedDescriptions(curr)[selected] = descriptionTextBoxes[curr].Text;
                    SetUnsaved(true);
                }
            }
        }

        private void materiaSlotSelector_MultiLinkEnabled(object sender, EventArgs e)
        {
            foreach (var s in materiaSlots.Values)
            {
                s?.EnableMultiLinkSlots();
            }
            materiaSlotSelectorCharacterWeapon.EnableMultiLinkSlots();
            materiaSlotSelectorCharacterArmor.EnableMultiLinkSlots();
        }

        private void materiaSlotSelectorCharacterWeapon_SelectedSlotChanged(object sender, EventArgs e)
        {
            buttonCharacterWeaponChangeMateria.Enabled = materiaSlotSelectorCharacterWeapon.SelectedSlot != -1;
        }

        private void materiaSlotSelectorCharacterArmor_SelectedSlotChanged(object sender, EventArgs e)
        {
            buttonCharacterArmorChangeMateria.Enabled = materiaSlotSelectorCharacterArmor.SelectedSlot != -1;
        }

        private void buttonCharacterWeaponChangeMateria_Click(object sender, EventArgs e)
        {
            int chara = listBoxInitCharacters.SelectedIndex,
                slot = materiaSlotSelectorCharacterWeapon.SelectedSlot;
            if (slot != -1)
            {
                var mat = kernel.InitialData.Characters[chara].WeaponMateria[slot].Copy();
                using (var edit = new MateriaAPEditForm(mat, kernel.MateriaData))
                {
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                        kernel.InitialData.Characters[chara].WeaponMateria[slot] = mat;
                        materiaSlotSelectorCharacterWeapon.SetMateria(slot, mat, kernel);
                        SetUnsaved(true);
                    }
                }
            }
        }

        private void buttonCharacterArmorChangeMateria_Click(object sender, EventArgs e)
        {
            int chara = listBoxInitCharacters.SelectedIndex,
                slot = materiaSlotSelectorCharacterArmor.SelectedSlot;
            if (slot != -1)
            {
                var mat = kernel.InitialData.Characters[chara].ArmorMateria[slot].Copy();
                using (var edit = new MateriaAPEditForm(mat, kernel.MateriaData))
                {
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                        kernel.InitialData.Characters[chara].ArmorMateria[slot] = mat;
                        materiaSlotSelectorCharacterArmor.SetMateria(slot, mat, kernel);
                        SetUnsaved(true);
                    }
                }
            }
        }

        private void listBoxCharacterAI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                UpdateCharacterAIScripts(listBoxCharacterAI.SelectedIndex);
            }
        }

        private void listBoxCharacterScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedChar = listBoxCharacterAI.SelectedIndex;
            if (!loading && selectedChar >= 0 && selectedChar < BattleAndGrowthData.AI_BLOCK_COUNT)
            {
                DisplayScript(selectedChar, listBoxCharacterScripts.SelectedIndex);
            }
        }

        private void scriptControlCharacterAI_DataChanged(object? sender, EventArgs e)
        {
            SetUnsaved(true);
        }

        private void scriptControlCharacterAI_ScriptAddedOrRemoved(object? sender, EventArgs e)
        {
            UpdateCharacterAIScripts(listBoxCharacterAI.SelectedIndex);
        }

        private void listBoxInitInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                PopulateInitInventoryBox(listBoxInitInventory.SelectedIndex);
            }
        }

        private void comboBoxInitItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                SetInventoryItem();
            }
        }

        private void numericInitItemAmount_ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                SetInventoryItem();
            }
        }

        private void listBoxInitMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                PopulateInitMateriaBox(false);
            }
        }

        private void comboBoxInitMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                SetInitMateria(false);
            }
        }

        private void buttonInitMateriaEdit_Click(object sender, EventArgs e)
        {
            int slot = listBoxInitMateria.SelectedIndex;
            if (slot != -1)
            {
                var mat = kernel.InitialData.InventoryMateria[slot].Copy();
                using (var edit = new MateriaAPEditForm(mat, kernel.MateriaData))
                {
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                        kernel.InitialData.InventoryMateria[slot] = mat;
                    }
                }
            }
        }

        private void listBoxInitMateriaStolen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                PopulateInitMateriaBox(true);
            }
        }

        private void comboBoxInitMateriaStolen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                SetInitMateria(true);
            }
        }

        private void buttonInitMateriaStolenEdit_Click(object sender, EventArgs e)
        {
            int slot = listBoxInitMateriaStolen.SelectedIndex;
            if (slot != -1)
            {
                var mat = kernel.InitialData.StolenMateria[slot].Copy();
                using (var edit = new MateriaAPEditForm(mat, kernel.MateriaData))
                {
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                        kernel.InitialData.StolenMateria[slot] = mat;
                    }
                }
            }
        }

        private void textBoxAttackName_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                loading = true;
                string name = textBoxAttackName.Text;
                SelectedAttack.Name = new FFText(name);
                kernel.MagicNames.Strings[SelectedAttackIndex] = name;
                listBoxAttacks.Items[SelectedAttackIndex] = name;
                SetUnsaved(true);
                loading = false;
            }
        }

        private void textBoxAttackDescription_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                string desc = textBoxAttackDescription.Text;
                SelectedAttack.Description = new FFText(desc);
                kernel.MagicDescriptions.Strings[SelectedAttackIndex] = desc;
                SetUnsaved(true);
            }
        }

        private void textBoxSummonText_TextChanged(object sender, EventArgs e)
        {
            int i = SelectedAttackIndex - SUMMON_OFFSET;
            if (!loading && i >= 0 && i < kernel.SummonAttackNames.Strings.Length)
            {
                kernel.SummonAttackNames.Strings[i] = textBoxSummonText.Text;
                SetUnsaved(true);
            }
        }

        private void comboBoxAttackAttackEffectID_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                var text = comboBoxAttackAttackEffectID.Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedAttack.AttackEffectID = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxAttackImpactEffectID_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                var text = comboBoxAttackImpactEffectID.Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedAttack.ImpactEffectID = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxAttackCamMovementIDSingle_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                var text = comboBoxAttackCamMovementIDSingle.Text;
                if (text.Length == 4)
                {
                    ushort newID;
                    if (ushort.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedAttack.CameraMovementIDSingle = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxAttackCamMovementIDMulti_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                var text = comboBoxAttackCamMovementIDMulti.Text;
                if (text.Length == 4)
                {
                    ushort newID;
                    if (ushort.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedAttack.CameraMovementIDMulti = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxAttackHurtActionIndex_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                var text = comboBoxAttackHurtActionIndex.Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedAttack.TargetHurtActionIndex = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxAttackStatusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBoxAttackStatusChange.SelectedIndex;
            numericAttackStatusChangeChance.Enabled = (i > 0);
            statusesControlAttack.Enabled = (i > 0);
            if (!loading && SelectedAttack != null)
            {
                if (i == 0)
                {
                    SelectedAttack.StatusChange = StatusChange.None;
                }
                else
                {
                    SelectedAttack.StatusChange = statusChanges[i - 1];
                }
                SetUnsaved(true);
            }
        }

        private void numericAttackStatusChangeChance_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                SelectedAttack.StatusChangeChance = (byte)numericAttackStatusChangeChance.Value;
                SetUnsaved(true);
            }
        }

        private void AttackDataChanged(object? sender, EventArgs e)
        {
            if (!loading)
            {
                attackNeedsSync = true;
                SetUnsaved(true);
            }
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
            if (DataManager.Kernel != null)
            {
                if (attackNeedsSync && SelectedAttack != null) //sync unsaved attack data
                {
                    SyncAttackData(SelectedAttack);
                }
                try
                {
                    bool result = false, saveSceneBin = false;

                    //check if there are any attacks that need to be synced
                    if (syncedAttackIDs.Count > 0)
                    {
                        //if the scene editor is not open, offer to save scene.bin as well
                        if (!DataManager.FormIsOpen(FormType.SceneEditor))
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
                            if (count > 0)
                            {
                                DataManager.CreateSceneBin();
                            }
                        }
                    }
                    DataManager.CreateKernel(true, kernel);
                    SetUnsaved(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            //stuff
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (attackNeedsSync && SelectedAttack != null) //sync unsaved attack data
            {
                SyncAttackData(SelectedAttack);
            }
            using (var exportDialog = new KernelChunkExportForm(kernel))
            {
                exportDialog.ShowDialog();
            }
        }

        private void attackCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAttack != null)
            {
                DataManager.CopiedAttack = new Attack(SelectedAttack);
                attackPasteToolStripMenuItem.Enabled = true;
            }
        }

        private void attackPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAttackIndex != -1 && DataManager.CopiedAttack != null)
            {
                kernel.Attacks[SelectedAttackIndex] = new Attack((ushort)SelectedAttackIndex,
                    DataManager.CopiedAttack);
                SetUnsaved(true);
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

        #endregion
    }
}
