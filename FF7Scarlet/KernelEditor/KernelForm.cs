using System.Collections.ObjectModel;
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
using Shojy.FF7.Elena.Items;

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
        
        private List<ushort> syncedAttackIDs = new();
        private List<StatusChangeType> statusChangeTypes = new();
        private int prevCommand, prevAttack, prevCharacter, prevItem,
            prevWeapon, prevArmor, prevAccessory, prevMateria;
        private bool
            commandNeedsSync = false,
            attackNeedsSync = false,
            initialStatsNeedSync = false,
            itemDataNeedsSync = false,
            weaponNeedsSync = false,
            armorNeedsSync = false,
            accessoryNeedsSync = false,
            materiaNeedsSync = false,
            itemNamesNeedSync = false,
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
        private readonly Dictionary<KernelSection, ComboBox> attackEffectIDs = new();
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
        private readonly Dictionary<KernelSection, ComboBox> statusChangeComboBoxes = new();
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

        private MenuCommand? SelectedCommand
        {
            get
            {
                if (SelectedCommandIndex >= 0 && SelectedCommandIndex < kernel.Commands.Length)
                {
                    return kernel.Commands[SelectedCommandIndex];
                }
                return null;
            }
        }

        private int SelectedCommandIndex
        {
            get { return listBoxCommands.SelectedIndex; }
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

        private Character? SelectedInitCharacter
        {
            get
            {
                if (SelectedInitCharacterIndex >= 0 &&
                    SelectedInitCharacterIndex < Character.CHARACTER_COUNT)
                {
                    return kernel.InitialData.Characters[SelectedInitCharacterIndex];
                }
                return null;
            }
        }

        private int SelectedInitCharacterIndex
        {
            get { return listBoxInitCharacters.SelectedIndex; }
        }

        private Item? SelectedItem
        {
            get
            {
                if (SelectedItemIndex >= 0 && SelectedItemIndex < kernel.ItemData.Items.Length)
                {
                    return kernel.ItemData.Items[SelectedItemIndex];
                }
                return null;
            }
        }

        private int SelectedItemIndex
        {
            get { return listBoxItems.SelectedIndex; }
        }

        private Weapon? SelectedWeapon
        {
            get
            {
                if (SelectedWeaponIndex >= 0 && SelectedWeaponIndex < kernel.WeaponData.Weapons.Length)
                {
                    return kernel.WeaponData.Weapons[SelectedWeaponIndex];
                }
                return null;
            }
        }

        private int SelectedWeaponIndex
        {
            get { return listBoxWeapons.SelectedIndex; }
        }

        private Armor? SelectedArmor
        {
            get
            {
                if (SelectedArmorIndex >= 0 && SelectedArmorIndex < kernel.ArmorData.Armors.Length)
                {
                    return kernel.ArmorData.Armors[SelectedArmorIndex];
                }
                return null;
            }
        }

        private int SelectedArmorIndex
        {
            get { return listBoxArmor.SelectedIndex; }
        }

        private Accessory? SelectedAccessory
        {
            get
            {
                if (SelectedAccessoryIndex >= 0
                    && SelectedAccessoryIndex < kernel.AccessoryData.Accessories.Length)
                {
                    return kernel.AccessoryData.Accessories[SelectedAccessoryIndex];
                }
                return null;
            }
        }

        private int SelectedAccessoryIndex
        {
            get { return listBoxAccessories.SelectedIndex; }
        }

        private Materia? SelectedMateria
        {
            get
            {
                if (SelectedMateriaIndex >= 0
                    && SelectedMateriaIndex < kernel.MateriaData.Materias.Length)
                {
                    return kernel.MateriaData.Materias[SelectedMateriaIndex];
                }
                return null;
            }
        }

        private int SelectedMateriaIndex
        {
            get { return listBoxMateria.SelectedIndex; }
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
            attackEffectIDs.Add(KernelSection.AttackData, comboBoxAttackAttackEffectID);
            targetData.Add(KernelSection.AttackData, targetDataControlAttack);
            damageCalculationControls.Add(KernelSection.AttackData, damageCalculationControlAttack);
            elementLists.Add(KernelSection.AttackData, elementsControlAttack);
            statusLists.Add(KernelSection.AttackData, statusesControlAttack);
            statusChangeComboBoxes.Add(KernelSection.AttackData, comboBoxAttackStatusChange);
            specialAttackFlags.Add(KernelSection.AttackData, specialAttackFlagsControlAttack);

            //item data
            tabPages.Add(KernelSection.ItemData, tabPageItemData);
            listBoxes.Add(KernelSection.ItemData, listBoxItems);
            nameTextBoxes.Add(KernelSection.ItemData, textBoxItemName);
            descriptionTextBoxes.Add(KernelSection.ItemData, textBoxItemDescription);
            cameraMovementSingle.Add(KernelSection.ItemData, comboBoxItemCamMovementID);
            attackEffectIDs.Add(KernelSection.ItemData, comboBoxItemAttackEffectID);
            targetData.Add(KernelSection.ItemData, targetDataControlItem);
            damageCalculationControls.Add(KernelSection.ItemData, damageCalculationControlItem);
            itemRestrictionLists.Add(KernelSection.ItemData, itemRestrictionsItem);
            elementLists.Add(KernelSection.ItemData, elementsControlItem);
            statusLists.Add(KernelSection.ItemData, statusesControlItem);
            statusChangeComboBoxes.Add(KernelSection.ItemData, comboBoxItemStatusChange);
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

            //set max values for various controls
            textBoxAttackName.MaxLength = Scene.NAME_LENGTH - 1;
            numericCharacterCurrentEXP.Maximum = uint.MaxValue;
            numericCharacterEXPtoNext.Maximum = uint.MaxValue;
            numericStartingGil.Maximum = uint.MaxValue;

            //initial cursor command
            comboBoxCommandInitialCursorAction.Items.Add("None");
            foreach (var c in InitialCursorActionInfo.ACTION_LIST)
            {
                comboBoxCommandInitialCursorAction.Items.Add(c.Description);
            }

            //character data
            comboBoxParty1.Items.Add("None");
            comboBoxParty2.Items.Add("None");
            comboBoxParty3.Items.Add("None");
            for (int i = 0; i < Character.CHARACTER_COUNT; ++i)
            {
                var name = Enum.GetName((CharacterNames)i);
                if (name != null)
                {
                    var parsedName = StringParser.AddSpace(name);
                    listBoxCharacterAI.Items.Add(parsedName);
                    comboBoxParty1.Items.Add(parsedName);
                    comboBoxParty2.Items.Add(parsedName);
                    comboBoxParty3.Items.Add(parsedName);

                    //playable characters
                    if (i < Character.PLAYABLE_CHARACTER_COUNT)
                    {
                        listBoxCharacterGrowth.Items.Add(parsedName);

                        if (i == 6 || i == 7) //Cait/Vincent
                        {
                            var name2 = Enum.GetName((CharacterNames)(i + 3));
                            if (name2 != null)
                            {
                                parsedName = StringParser.AddSpace(name2);
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
            if (kernel.InitialData.Party1 == 0xFF) { comboBoxParty1.SelectedIndex = 0; }
            else { comboBoxParty1.SelectedIndex = kernel.InitialData.Party1 + 1; }
            if (kernel.InitialData.Party2 == 0xFF) { comboBoxParty2.SelectedIndex = 0; }
            else { comboBoxParty2.SelectedIndex = kernel.InitialData.Party2 + 1; }
            if (kernel.InitialData.Party3 == 0xFF) { comboBoxParty3.SelectedIndex = 0; }
            else { comboBoxParty3.SelectedIndex = kernel.InitialData.Party3 + 1; }

            //battle data
            rngTableControl.SetValues(kernel.BattleAndGrowthData.RNGTable);

            //inventory
            PopulateInventoryListBoxes();
            numericStartingGil.Value = kernel.InitialData.StartingGil;

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
            comboBoxItemStatusChange.Items.Add("None");
            foreach (var s in Enum.GetValues<StatusChangeType>())
            {
                if (s != StatusChangeType.None)
                {
                    comboBoxAttackStatusChange.Items.Add(s);
                    comboBoxItemStatusChange.Items.Add(s);
                    statusChangeTypes.Add(s);
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

        #region Load Data

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
                    list.Add(groupBoxAttackSpecialActions);
                }
            }
            return list.AsReadOnly();
        }

        private void LoadItemLists()
        {
            bool wasAlreadyLoading = loading;
            loading = true;
            if (!wasAlreadyLoading)
            {
                comboBoxInitItem.SuspendLayout();
                comboBoxCharacterWeapon.SuspendLayout();
                comboBoxCharacterArmor.SuspendLayout();
                comboBoxCharacterAccessory.SuspendLayout();
                comboBoxInitMateria.SuspendLayout();
            }

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

            if (!wasAlreadyLoading)
            {
                comboBoxInitItem.ResumeLayout();
                comboBoxCharacterWeapon.ResumeLayout();
                comboBoxCharacterArmor.ResumeLayout();
                comboBoxCharacterAccessory.ResumeLayout();
                comboBoxInitMateria.ResumeLayout();
                loading = false;
            }
        }

        private void PopulateInventoryListBoxes()
        {
            bool wasAlreadyLoading = loading;
            loading = true;
            if (!wasAlreadyLoading)
            {
                listBoxInitInventory.SuspendLayout();
                listBoxInitMateria.SuspendLayout();
                listBoxInitMateriaStolen.SuspendLayout();
            }

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
            if (!wasAlreadyLoading)
            {
                listBoxInitInventory.ResumeLayout();
                listBoxInitMateria.ResumeLayout();
                listBoxInitMateriaStolen.ResumeLayout();
                loading = false;
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
                        var modifier = kernel.GetDamageModifier(section, i);
                        if (modifier == DamageModifier.Normal)
                        {
                            elementDamageModifiers[section].SelectedIndex = 0;
                        }
                        else
                        {
                            elementDamageModifiers[section].SelectedIndex = (int)modifier + 1;
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
                            j = i - Kernel.SUMMON_OFFSET;
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
                            checkBoxAttackIsLimit.Checked = attack.IsLimit;
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
                            numericAttackStatusChangeChance.Value = attack.StatusChange.Amount;
                            if (attack.StatusChange.Type == StatusChangeType.None)
                            {
                                comboBoxAttackStatusChange.SelectedIndex = 0;
                                numericAttackStatusChangeChance.Enabled = false;
                                statusesControlAttack.Enabled = false;
                            }
                            else
                            {
                                comboBoxAttackStatusChange.SelectedIndex = statusChangeTypes.IndexOf(attack.StatusChange.Type) + 1;
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
                loading = true;
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
                }
                var armor = kernel.GetArmorByID(character.ArmorID);
                if (armor != null)
                {
                    comboBoxCharacterArmor.SelectedIndex = character.ArmorID;
                }
                var acc = kernel.GetAccessoryByID(character.AccessoryID);
                if (acc == null)
                {
                    comboBoxCharacterAccessory.SelectedIndex = 0;
                }
                else
                {
                    comboBoxCharacterAccessory.SelectedIndex = character.AccessoryID + 1;
                }
                characterStatsControl.SetStatsFromCharacter(character);
                loading = false;
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

        #endregion

        #region Sync Unsaved Data

        private void SyncCommandData(MenuCommand command)
        {
            int i = comboBoxCommandInitialCursorAction.SelectedIndex;
            if (i <= 0)
            {
                command.InitialCursorAction = 0xFF;
            }
            else
            {
                command.InitialCursorAction = (byte)(i - 1);
            }
            command.TargetFlags = targetDataControlCommand.GetTargetData();
            commandNeedsSync = true;
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

        private void SyncInitialStats(Character chara)
        {
            chara.ID = (byte)numericCharacterID.Value;
            chara.Name = new FFText(textBoxCharacterName.Text);
            chara.Level = (byte)numericCharacterLevel.Value;
            chara.CurrentEXP = (uint)numericCharacterCurrentEXP.Value;
            chara.EXPtoNextLevel = (uint)numericCharacterEXPtoNext.Value;
            chara.CurrentHP = (ushort)numericCharacterCurrHP.Value;
            chara.BaseHP = (ushort)numericCharacterBaseHP.Value;
            chara.MaxHP = (ushort)numericCharacterMaxHP.Value;
            chara.CurrentMP = (ushort)numericCharacterCurrMP.Value;
            chara.BaseMP = (ushort)numericCharacterBaseMP.Value;
            chara.MaxMP = (ushort)numericCharacterMaxMP.Value;
            characterStatsControl.CopyStatsToCharacter(chara);
            var flags = Enum.GetValues<CharacterFlags>();
            chara.CharacterFlags = flags[comboBoxCharacterFlags.SelectedIndex];
            chara.IsBackRow = checkBoxCharacterBackRow.Checked;
            chara.KillCount = (ushort)numericCharacterKillCount.Value;
            chara.LimitLevel = characterLimitControl.LimitLevel;
            chara.CurrentLimitBar = characterLimitControl.LimitBar;
            chara.LearnedLimits = characterLimitControl.LearnedLimits;
            if (comboBoxCharacterAccessory.SelectedIndex == 0)
            {
                chara.AccessoryID = 0xFF;
            }
            else
            {
                chara.AccessoryID = (byte)(comboBoxCharacterAccessory.SelectedIndex - 1);
            }

            initialStatsNeedSync = false;
        }

        private void SyncItemData(Item item)
        {
            item.DamageCalculationId = damageCalculationControlItem.ActualValue;
            item.AttackPower = damageCalculationControlItem.AttackPower;
            item.TargetData = targetDataControlItem.GetTargetData();
            item.Restrictions = itemRestrictionsItem.GetItemRestrictions();
            item.Element = elementsControlItem.GetElements();
            item.Status = statusesControlItem.GetStatuses();
            item.Special = specialAttackFlagsControlItem.GetFlags();

            itemDataNeedsSync = false;
        }

        private void SyncWeaponData(Weapon weapon)
        {
            weapon.AccuracyRate = (byte)numericWeaponHitChance.Value;
            weapon.CriticalRate = (byte)numericWeaponCritChance.Value;
            byte modelIndex = HexParser.MergeNybbles((byte)numericWeaponAnimationIndex.Value,
                (byte)numericWeaponModelIndex.Value);
            weapon.WeaponModelId = modelIndex;

            var increases = statIncreaseControlWeapon.GetStatIncreases();
            weapon.BoostedStat1 = increases[0].Stat;
            weapon.BoostedStat1Bonus = increases[0].Amount;
            weapon.BoostedStat2 = increases[1].Stat;
            weapon.BoostedStat2Bonus = increases[1].Amount;
            weapon.BoostedStat3 = increases[2].Stat;
            weapon.BoostedStat3Bonus = increases[2].Amount;
            weapon.BoostedStat4 = increases[3].Stat;
            weapon.BoostedStat4Bonus = increases[3].Amount;

            var slots = materiaSlotSelectorWeapon.GetSlots();
            for (int i = 0; i < 8; ++i)
            {
                weapon.MateriaSlots[i] = slots[i];
            }

            weapon.AttackElements = elementsControlWeapon.GetElements();
            int s = comboBoxWeaponStatus.SelectedIndex;
            if (s == 0)
            {
                weapon.Status = EquipmentStatus.None;
            }
            else
            {
                weapon.Status = (EquipmentStatus)(s - 1);
            }
            weapon.DamageCalculationId = damageCalculationControlWeapon.ActualValue;
            weapon.Targets = targetDataControlWeapon.GetTargetData();
            weapon.EquipableBy = equipableListWeapon.GetEquipableFlags();
            weapon.Restrictions = itemRestrictionsWeapon.GetItemRestrictions();

            weaponNeedsSync = false;
        }

        private void SyncArmorData(Armor armor)
        {
            armor.Defense = (byte)numericArmorDefense.Value;
            armor.Evade = (byte)numericArmorDefensePercent.Value;
            armor.MagicDefense = (byte)numericArmorMagicDefense.Value;
            armor.MagicEvade = (byte)numericArmorMagicDefensePercent.Value;

            var increases = statIncreaseControlArmor.GetStatIncreases();
            armor.BoostedStat1 = increases[0].Stat;
            armor.BoostedStat1Bonus = increases[0].Amount;
            armor.BoostedStat2 = increases[1].Stat;
            armor.BoostedStat2Bonus = increases[1].Amount;
            armor.BoostedStat3 = increases[2].Stat;
            armor.BoostedStat3Bonus = increases[2].Amount;
            armor.BoostedStat4 = increases[3].Stat;
            armor.BoostedStat4Bonus = increases[3].Amount;

            var slots = materiaSlotSelectorWeapon.GetSlots();
            for (int i = 0; i < 8; ++i)
            {
                armor.MateriaSlots[i] = slots[i];
            }

            int temp;
            armor.ElementalDefense = elementsControlArmor.GetElements();
            temp = comboBoxArmorElementModifier.SelectedIndex;
            if (temp == 0)
            {
                armor.ElementDamageModifier = DamageModifier.Normal;
            }
            else
            {
                armor.ElementDamageModifier = (DamageModifier)(temp - 1);
            }
            temp = comboBoxArmorStatus.SelectedIndex;
            if (temp == 0)
            {
                armor.Status = EquipmentStatus.None;
            }
            else
            {
                armor.Status = (EquipmentStatus)(temp - 1);
            }
            armor.EquipableBy = equipableListArmor.GetEquipableFlags();
            armor.Restrictions = itemRestrictionsArmor.GetItemRestrictions();

            armorNeedsSync = false;
        }

        private void SyncAccessoryData(Accessory acc)
        {
            acc.ElementalDefense = elementsControlAccessory.GetElements();
            int temp = temp = comboBoxArmorElementModifier.SelectedIndex;
            if (temp == 0)
            {
                acc.ElementalDamageModifier = DamageModifier.Normal;
            }
            else
            {
                acc.ElementalDamageModifier = (DamageModifier)(temp - 1);
            }

            var increases = statIncreaseControlAccessory.GetStatIncreases();
            acc.BoostedStat1 = increases[0].Stat;
            acc.BoostedStat1Bonus = increases[0].Amount;
            acc.BoostedStat2 = increases[1].Stat;
            acc.BoostedStat2Bonus = increases[1].Amount;

            acc.StatusDefense = statusesControlAccessory.GetStatuses();
            temp = comboBoxAccessorySpecialEffects.SelectedIndex;
            if (temp == 0)
            {
                acc.SpecialEffect = AccessoryEffect.None;
            }
            else
            {
                acc.SpecialEffect = (AccessoryEffect)(temp - 1);
            }
            acc.EquipableBy = equipableListAccessory.GetEquipableFlags();
            acc.Restrictions = itemRestrictionsAccessory.GetItemRestrictions();

            accessoryNeedsSync = false;
        }

        private void SyncMateriaData(Materia materia)
        {
            var elem = Enum.GetValues<MateriaElements>();
            materia.Element = elem[comboBoxMateriaElement.SelectedIndex];
            //type, subtype, equip attribules
            materia.Status = statusesControlMateria.GetStatuses();
            materia.Level2AP = materiaLevelControl.Lvl2APValue;
            materia.Level3AP = materiaLevelControl.Lvl3APValue;
            materia.Level4AP = materiaLevelControl.Lvl4APValue;
            materia.Level5AP = materiaLevelControl.Lvl5APValue;

            materiaNeedsSync = false;
        }

        private void SyncAllUnsaved()
        {
            if (commandNeedsSync && SelectedCommand != null)
            {
                SyncCommandData(SelectedCommand);
            }
            if (attackNeedsSync && SelectedAttack != null)
            {
                SyncAttackData(SelectedAttack);
            }
            if (initialStatsNeedSync && SelectedInitCharacter != null)
            {
                SyncInitialStats(SelectedInitCharacter);
            }
            if (itemDataNeedsSync && SelectedItem != null)
            {
                SyncItemData(SelectedItem);
            }
            if (weaponNeedsSync && SelectedWeapon != null)
            {
                SyncWeaponData(SelectedWeapon);
            }
            if (armorNeedsSync && SelectedArmor != null)
            {
                SyncArmorData(SelectedArmor);
            }
            if (accessoryNeedsSync && SelectedAccessory != null)
            {
                SyncAccessoryData(SelectedAccessory);
            }
            if (materiaNeedsSync && SelectedMateria != null)
            {
                SyncMateriaData(SelectedMateria);
            }
        }

        #endregion

        #region Manual Data Updates

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

        public void UpdateLookupTable(byte[] table)
        {
            kernel.UpdateLookupTable(table);
        }

        #endregion

        #endregion

        #region Event Methods

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemNamesNeedSync) //sync item names
            {
                var tab = tabControlMain.SelectedTab;
                if (tab == tabPageInitData || tab == tabPageCharacters)
                {
                    LoadItemLists();
                    PopulateInitCharacterDataTab(SelectedInitCharacterIndex);
                    PopulateInventoryListBoxes();
                    itemNamesNeedSync = false;
                }
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

        #region ListBox Index Changed

        private void listBoxCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (commandNeedsSync) //sync unsaved command data
                {
                    var command = kernel.Commands[prevCommand];
                    if (command != null)
                    {
                        SyncCommandData(command);
                    }
                }
                prevCommand = SelectedCommandIndex;
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

        private void listBoxInitCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (initialStatsNeedSync) //sync unsaved stat data
                {
                    var chara = kernel.InitialData.Characters[prevCharacter];
                    if (chara != null)
                    {
                        SyncInitialStats(chara);
                    }
                }
                prevCharacter = SelectedInitCharacterIndex;
                PopulateInitCharacterDataTab(SelectedInitCharacterIndex);
            }
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (itemDataNeedsSync) //sync unsaved item data
                {
                    var item = kernel.ItemData.Items[prevItem];
                    if (item != null)
                    {
                        SyncItemData(item);
                    }
                }
                prevItem = SelectedItemIndex;
                PopulateTabWithSelected(KernelSection.ItemData);
            }

        }

        private void listBoxWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (weaponNeedsSync) //sync unsaved weapon data
                {
                    var wpn = kernel.WeaponData.Weapons[prevWeapon];
                    if (wpn != null)
                    {
                        SyncWeaponData(wpn);
                    }
                }
                prevWeapon = SelectedWeaponIndex;
                PopulateTabWithSelected(KernelSection.WeaponData);
            }
        }

        private void listBoxArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (armorNeedsSync) //sync unsaved armor data
                {
                    var armor = kernel.ArmorData.Armors[prevArmor];
                    if (armor != null)
                    {
                        SyncArmorData(armor);
                    }
                }
                prevArmor = SelectedArmorIndex;
                PopulateTabWithSelected(KernelSection.ArmorData);
            }
        }

        private void listBoxAccessories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (accessoryNeedsSync) //sync unsaved accessory data
                {
                    var acc = kernel.AccessoryData.Accessories[prevAccessory];
                    if (acc != null)
                    {
                        SyncAccessoryData(acc);
                    }
                }
                prevAccessory = SelectedAccessoryIndex;
                PopulateTabWithSelected(KernelSection.AccessoryData);
            }
        }

        private void listBoxMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (materiaNeedsSync) //sync unsaved materia data
                {
                    var mat = kernel.MateriaData.Materias[prevMateria];
                    if (mat != null)
                    {
                        SyncMateriaData(mat);
                    }
                }
                prevMateria = SelectedMateriaIndex;
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
                    loading = true;
                    labelBattleText.Enabled = true;
                    textBoxBattleText.Enabled = true;
                    textBoxBattleText.Text = kernel.BattleText.Strings[i];
                    loading = false;
                }
            }
        }

        #endregion

        #region Common Controls

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
                        itemNamesNeedSync = true;
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

        private void comboBoxCamMovementIDSingle_TextChanged(object sender, EventArgs e)
        {
            if (!loading && cameraMovementSingle.ContainsKey(CurrentSection))
            {
                var text = cameraMovementSingle[CurrentSection].Text;
                if (text.Length == 4)
                {
                    ushort newID;
                    if (ushort.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        switch (CurrentSection)
                        {
                            case KernelSection.CommandData:
                                if (SelectedCommand != null)
                                {
                                    SelectedCommand.CameraMovementIDSingle = newID;
                                }
                                break;
                            case KernelSection.AttackData:
                                if (SelectedAttack != null)
                                {
                                    SelectedAttack.CameraMovementIDSingle = newID;
                                }
                                break;
                            case KernelSection.ItemData:
                                if (SelectedItem != null)
                                {
                                    SelectedItem.CameraMovementId = newID;
                                }
                                break;
                        }
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxCamMovementIDMulti_TextChanged(object sender, EventArgs e)
        {
            if (!loading && cameraMovementMulti.ContainsKey(CurrentSection))
            {
                var text = cameraMovementMulti[CurrentSection].Text;
                if (text.Length == 4)
                {
                    ushort newID;
                    if (ushort.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        switch (CurrentSection)
                        {
                            case KernelSection.CommandData:
                                if (SelectedCommand != null)
                                {
                                    SelectedCommand.CameraMovementIDMulti = newID;
                                }
                                break;
                            case KernelSection.AttackData:
                                if (SelectedAttack != null)
                                {
                                    SelectedAttack.CameraMovementIDMulti = newID;
                                }
                                break;
                        }
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxAttackEffectID_TextChanged(object sender, EventArgs e)
        {
            if (!loading && attackEffectIDs.ContainsKey(CurrentSection))
            {
                var text = attackEffectIDs[CurrentSection].Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        switch (CurrentSection)
                        {
                            case KernelSection.AttackData:
                                if (SelectedAttack != null)
                                {
                                    SelectedAttack.AttackEffectID = newID;
                                }
                                break;
                            case KernelSection.ItemData:
                                if (SelectedItem != null)
                                {
                                    SelectedItem.AttackEffectId = newID;
                                }
                                break;
                        }
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxStatusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statusChangeComboBoxes.ContainsKey(CurrentSection))
            {
                int i = statusChangeComboBoxes[CurrentSection].SelectedIndex;
                var status = StatusChangeType.None;
                bool hasStatus = i > 0;
                if (hasStatus)
                {
                    status = statusChangeTypes[i - 1];
                }
                statusLists[CurrentSection].Enabled = hasStatus;
                switch (CurrentSection)
                {
                    case KernelSection.AttackData:
                        if (SelectedAttack != null)
                        {
                            numericAttackStatusChangeChance.Enabled = hasStatus;
                            statusesControlAttack.Enabled = hasStatus;
                            SelectedAttack.StatusChange.Type = status;
                        }
                        break;
                    case KernelSection.ItemData:
                        if (SelectedItem != null)
                        {
                            //SelectedItem.StatusChange.Type = status;
                        }
                        break;
                }
                if (!loading) { SetUnsaved(true); }
            }
        }

        #endregion

        #region Data Changed

        private void CommandDataChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                commandNeedsSync = true;
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

        private void InitCharacterDataChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                initialStatsNeedSync = true;
                SetUnsaved(true);
            }
        }

        private void ItemDataChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                itemDataNeedsSync = true;
                SetUnsaved(true);
            }
        }

        private void WeaponDataChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                weaponNeedsSync = true;
                SetUnsaved(true);
            }
        }

        private void ArmorDataChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                armorNeedsSync = true;
                SetUnsaved(true);
            }
        }

        private void AccessoryDataChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                accessoryNeedsSync = true;
                SetUnsaved(true);
            }
        }

        private void MateriaDataChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                materiaNeedsSync = true;
                SetUnsaved(true);
            }
        }

        #endregion

        #region Attack Controls

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
            int i = SelectedAttackIndex - Kernel.SUMMON_OFFSET;
            if (!loading && i >= 0 && i < kernel.SummonAttackNames.Strings.Length)
            {
                kernel.SummonAttackNames.Strings[i] = textBoxSummonText.Text;
                SetUnsaved(true);
            }
        }

        private void checkBoxAttackIsLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                SelectedAttack.IsLimit = checkBoxAttackIsLimit.Checked;
                SetUnsaved(true);
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

        private void numericAttackStatusChangeChance_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                SelectedAttack.StatusChange.Amount = (byte)numericAttackStatusChangeChance.Value;
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

        #endregion

        #region Character Controls

        private void comboBoxCharacterWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedInitCharacter != null)
            {
                if (!loading)
                {
                    SelectedInitCharacter.WeaponID = (byte)comboBoxCharacterWeapon.SelectedIndex;
                    SetUnsaved(true);
                }
                var wpn = kernel.GetWeaponByID(SelectedInitCharacter.WeaponID);
                if (wpn != null)
                {
                    materiaSlotSelectorCharacterWeapon.SetSlots(wpn);
                    for (int i = 0; i < 8; ++i)
                    {
                        var mat = kernel.GetMateriaByID(SelectedInitCharacter.WeaponMateria[i].Index);
                        materiaSlotSelectorCharacterWeapon.SetMateria(i, mat);
                        materiaSlotSelectorCharacterWeapon.SelectedSlot = -1;
                    }
                }
                buttonCharacterWeaponChangeMateria.Enabled = false;
            }
        }

        private void comboBoxCharacterArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedInitCharacter != null)
            {
                if (!loading)
                {
                    SelectedInitCharacter.ArmorID = (byte)comboBoxCharacterArmor.SelectedIndex;
                    SetUnsaved(true);
                }
                var arm = kernel.GetArmorByID(SelectedInitCharacter.ArmorID);
                if (arm != null)
                {
                    materiaSlotSelectorCharacterArmor.SetSlots(arm);
                    for (int i = 0; i < 8; ++i)
                    {
                        var mat = kernel.GetMateriaByID(SelectedInitCharacter.ArmorMateria[i].Index);
                        materiaSlotSelectorCharacterArmor.SetMateria(i, mat);
                        materiaSlotSelectorCharacterArmor.SelectedSlot = -1;
                    }
                }
                buttonCharacterArmorChangeMateria.Enabled = false;
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
            buttonCharacterWeaponChangeMateria.Enabled =
                materiaSlotSelectorCharacterWeapon.SelectedSlot != -1;
        }

        private void materiaSlotSelectorCharacterArmor_SelectedSlotChanged(object sender, EventArgs e)
        {
            buttonCharacterArmorChangeMateria.Enabled =
                materiaSlotSelectorCharacterArmor.SelectedSlot != -1;
        }

        private void buttonCharacterWeaponChangeMateria_Click(object sender, EventArgs e)
        {
            int slot = materiaSlotSelectorCharacterWeapon.SelectedSlot;
            if (slot != -1 && SelectedInitCharacter != null)
            {
                var mat = SelectedInitCharacter.WeaponMateria[slot].Copy();
                using (var edit = new MateriaAPEditForm(mat, kernel.MateriaData))
                {
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                        SelectedInitCharacter.WeaponMateria[slot] = mat;
                        materiaSlotSelectorCharacterWeapon.SetMateria(slot, mat, kernel);
                        SetUnsaved(true);
                    }
                }
            }
        }

        private void buttonCharacterArmorChangeMateria_Click(object sender, EventArgs e)
        {
            int slot = materiaSlotSelectorCharacterArmor.SelectedSlot;
            if (slot != -1 && SelectedInitCharacter != null)
            {
                var mat = SelectedInitCharacter.ArmorMateria[slot].Copy();
                using (var edit = new MateriaAPEditForm(mat, kernel.MateriaData))
                {
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                        SelectedInitCharacter.ArmorMateria[slot] = mat;
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

        private void comboBoxParty1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = comboBoxParty1.SelectedIndex;
                if (i == 0)
                {
                    kernel.InitialData.Party1 = 0xFF;
                }
                else
                {
                    kernel.InitialData.Party1 = (byte)(i - 1);
                }
                SetUnsaved(true);
            }
        }

        private void comboBoxParty2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = comboBoxParty2.SelectedIndex;
                if (i == 0)
                {
                    kernel.InitialData.Party2 = 0xFF;
                }
                else
                {
                    kernel.InitialData.Party2 = (byte)(i - 1);
                }
                SetUnsaved(true);
            }
        }

        private void comboBoxParty3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = comboBoxParty3.SelectedIndex;
                if (i == 0)
                {
                    kernel.InitialData.Party3 = 0xFF;
                }
                else
                {
                    kernel.InitialData.Party3 = (byte)(i - 1);
                }
                SetUnsaved(true);
            }
        }

        #endregion

        #region Inventory Controls

        private void numericStartingGil_ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                kernel.InitialData.StartingGil = (uint)numericStartingGil.Value;
                SetUnsaved(true);
            }
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

        #endregion

        #region Other Controls

        private void comboBoxWeaponMateriaGrowth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                var rate = (GrowthRate)comboBoxWeaponMateriaGrowth.SelectedIndex;
                if (Enum.IsDefined(rate))
                {
                    materiaSlotSelectorWeapon.GrowthRate = rate;
                    if (SelectedWeapon != null)
                    {
                        SelectedWeapon.GrowthRate = rate;
                    }
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
                    if (SelectedArmor != null)
                    {
                        SelectedArmor.GrowthRate = rate;
                    }
                }
            }
        }

        private void textBoxBattleText_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = listBoxBattleText.SelectedIndex;
                if (i >= 0 && i < listBoxBattleText.Items.Count)
                {
                    kernel.BattleText.Strings[i] = textBoxBattleText.Text;
                    listBoxBattleText.Items[i] = textBoxBattleText.Text;
                    SetUnsaved(true);
                }
            }
        }

        #endregion

        #region Loading and Saving

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (DataManager.Kernel != null)
            {
                SyncAllUnsaved();
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
            SyncAllUnsaved();
            using (var exportDialog = new KernelChunkExportForm(kernel))
            {
                exportDialog.ShowDialog();
            }
        }

        #endregion

        #region Tool Strip

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

        #endregion

        #endregion
    }
}
