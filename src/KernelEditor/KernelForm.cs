using System.Collections.ObjectModel;
using System.Globalization;
using System.Media;
using System.Windows.Forms.DataVisualization.Charting;

using Shojy.FF7.Elena;
using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Battle;
using Shojy.FF7.Elena.Characters;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Inventory;
using Shojy.FF7.Elena.Items;
using Shojy.FF7.Elena.Materias;

using FF7Scarlet.KernelEditor.Controls;
using FF7Scarlet.AIEditor;
using FF7Scarlet.Shared;
using FF7Scarlet.Shared.Controls;
using FF7Scarlet.ExeEditor;

namespace FF7Scarlet.KernelEditor
{
    public partial class KernelForm : Form
    {
        #region Properties

        private readonly string WINDOW_TITLE = $"{Application.ProductName} v{Application.ProductVersion} - Kernel Editor";
        private readonly string[] SCRIPT_LIST =
        [
            "Pre-Battle", "Main", "General Counter", "Death Counter", "Physical Counter",
            "Magic Counter", "Ally Death", "Post-Attack", "Custom Event 1",
            "Custom Event 2", "Custom Event 3", "Custom Event 4", "Custom Event 5",
            "Custom Event 6", "Custom Event 7", "Post-Battle"
        ];
        private readonly Kernel kernel;

        private List<ushort> syncedAttackIDs = new();
        private List<IndependentMateriaTypes> independentMateriaTypes = new();
        private List<SpellIndex>[] SpellIndexes = new List<SpellIndex>[(int)SpellType.Unlisted];
        private int prevCommand, prevCharacter, prevItem, prevWeapon, prevArmor, prevAccessory, prevMateria;
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
        private readonly Dictionary<KernelSection, Label> idLabels = new();
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
        private readonly Dictionary<KernelSection, ComboBox> statusChangeComboBoxes = new();
        private readonly Dictionary<KernelSection, SpecialAttackFlagsControl> specialAttackFlags = new();
        private readonly NumericUpDown[] curveBonuses;

        /// <summary>
        /// The section associated with the currently associated tab page
        /// </summary>
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
                throw new ArgumentNullException(); //fix this?
            }
        }

        /// <summary>
        /// The currently selected command. Returns null if none is selected.
        /// </summary>
        private Command? SelectedCommand
        {
            get
            {
                if (SelectedCommandIndex >= 0 && SelectedCommandIndex < kernel.CommandData.Commands.Length)
                {
                    return kernel.CommandData.Commands[SelectedCommandIndex];
                }
                return null;
            }
        }

        /// <summary>
        /// The index of the currently selected command. Returns -1 if none is selected.
        /// </summary>
        private int SelectedCommandIndex
        {
            get { return listBoxCommands.SelectedIndex; }
        }

        /// <summary>
        /// Gets the current attack type.
        /// </summary>
        private AttackTypes SelectedAttackType
        {
            get { return (AttackTypes)comboBoxAttackType.SelectedIndex; }
        }

        /// <summary>
        /// Gets the attack offset, relative to attack type.
        /// </summary>
        private int AttackOffset
        {
            get
            {
                switch (SelectedAttackType)
                {
                    case AttackTypes.Summon:
                        return Kernel.SUMMON_OFFSET;
                    case AttackTypes.ESkill:
                        return Kernel.ESKILL_OFFSET;
                    case AttackTypes.Limit:
                        return Kernel.LIMIT_OFFSET;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// Gets the attack count, relative to attack type.
        /// </summary>
        private int AttackCount
        {
            get
            {
                switch (SelectedAttackType)
                {
                    case AttackTypes.Magic:
                        return Kernel.SUMMON_OFFSET;
                    case AttackTypes.Summon:
                        return Kernel.ESKILL_OFFSET - Kernel.SUMMON_OFFSET + 2;
                    case AttackTypes.ESkill:
                        return Kernel.SPECIAL_SUMMON_OFFSET - Kernel.ESKILL_OFFSET;
                    case AttackTypes.Limit:
                        return Kernel.ATTACK_COUNT - Kernel.LIMIT_OFFSET;
                    default:
                        return Kernel.ATTACK_COUNT;
                }
            }
        }

        /// <summary>
        /// The currently selected attack. Returns null if none is selected.
        /// </summary>
        private Attack? SelectedAttack
        {
            get
            {
                if (SelectedAttackIndex >= 0 && SelectedAttackIndex < Kernel.ATTACK_COUNT)
                {
                    return kernel.AttackData.Attacks[SelectedAttackIndex];
                }
                return null;
            }
        }

        /// <summary>
        /// The index of the currently selected attack. Returns -1 if none is selected.
        /// </summary>
        private int SelectedAttackIndex
        {
            get
            {
                if (SelectedAttackType == AttackTypes.Summon)
                {
                    int special = AttackCount - 2;
                    if (listBoxAttacks.SelectedIndex >= special)
                    {
                        return listBoxAttacks.SelectedIndex - special + Kernel.SPECIAL_SUMMON_OFFSET;
                    }
                }
                return listBoxAttacks.SelectedIndex + AttackOffset;
            }
        }

        /// <summary>
        /// The currently selected character. Returns null if none is selected.
        /// </summary>
        private Character? SelectedCharacter
        {
            get
            {
                if (SelectedCharacterIndex >= 0 &&
                    SelectedCharacterIndex < Kernel.CHARACTER_COUNT)
                {
                    return kernel.CharacterList[SelectedCharacterIndex];
                }
                return null;
            }
        }

        /// <summary>
        /// The index of the currently selected character. Returns -1 if none is selected.
        /// </summary>
        private int SelectedCharacterIndex
        {
            get { return listBoxInitCharacters.SelectedIndex; }
        }

        private Series MainCurveMin
        {
            get { return chartMainCurve.Series[0]; }
        }

        private Series MainCurveMax
        {
            get { return chartMainCurve.Series[1]; }
        }

        /// <summary>
        /// The currently selected item. Returns null if none is selected.
        /// </summary>
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

        /// <summary>
        /// The index of the currently selected item. Returns -1 if none is selected.
        /// </summary>
        private int SelectedItemIndex
        {
            get { return listBoxItems.SelectedIndex; }
        }

        /// <summary>
        /// The currently selected weapon. Returns null if none is selected.
        /// </summary>
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

        /// <summary>
        /// The index of the currently selected weapon. Returns -1 if none is selected.
        /// </summary>
        private int SelectedWeaponIndex
        {
            get { return listBoxWeapons.SelectedIndex; }
        }

        /// <summary>
        /// The currently selected armor. Returns null if none is selected.
        /// </summary>
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

        /// <summary>
        /// The index of the currently selected armor. Returns -1 if none is selected.
        /// </summary>
        private int SelectedArmorIndex
        {
            get { return listBoxArmor.SelectedIndex; }
        }

        /// <summary>
        /// The currently selected accessory. Returns null if none is selected.
        /// </summary>
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

        /// <summary>
        /// The index of the currently selected accessory. Returns -1 if none is selected.
        /// </summary>
        private int SelectedAccessoryIndex
        {
            get { return listBoxAccessories.SelectedIndex; }
        }

        /// <summary>
        /// The currently selected materia. Returns null if none is selected.
        /// </summary>
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

        /// <summary>
        /// The index of the currently selected materia. Returns -1 if none is selected.
        /// </summary>
        private int SelectedMateriaIndex
        {
            get { return listBoxMateria.SelectedIndex; }
        }

        #endregion

        #region Constructor

        public KernelForm()
        {
            InitializeComponent();
            Text = WINDOW_TITLE;

            kernel = DataManager.CopyKernel();
            DataManager.MergeCharacterData(kernel);
            foreach (var a in kernel.AttackData.Attacks)
            {
                if (DataManager.AttackIsSynced((ushort)a.Index)) { syncedAttackIDs.Add((ushort)a.Index); }
            }
            selectedAttackToolStripMenuItem.Enabled = false;
            useKernel2StringsToolStripMenuItem.Enabled = DataManager.BothKernelFilePathsExist;
            useKernel2StringsToolStripMenuItem.Checked = DataManager.BothKernelFilePathsExist;

            //get curve controls
            curveBonuses = [
                numericCurveBonus1, numericCurveBonus2, numericCurveBonus3, numericCurveBonus4,
                numericCurveBonus5, numericCurveBonus6, numericCurveBonus7, numericCurveBonus8,
                numericCurveBonus9, numericCurveBonus10, numericCurveBonus11, numericCurveBonus12
            ];

            //associate controls with kernel data
            //command data
            tabPages.Add(KernelSection.CommandData, tabPageCommandData);
            listBoxes.Add(KernelSection.CommandData, listBoxCommands);
            nameTextBoxes.Add(KernelSection.CommandData, textBoxCommandName);
            descriptionTextBoxes.Add(KernelSection.CommandData, textBoxCommandDescription);
            idLabels.Add(KernelSection.CommandData, labelCommandID);
            cameraMovementSingle.Add(KernelSection.CommandData, comboBoxCommandCameraMovementIDSingle);
            cameraMovementMulti.Add(KernelSection.CommandData, comboBoxCommandCamMovementIDMulti);
            targetData.Add(KernelSection.CommandData, targetDataControlCommand);

            //attack data
            tabPages.Add(KernelSection.AttackData, tabPageAttackData);
            toolStrips.Add(KernelSection.AttackData, selectedAttackToolStripMenuItem);
            listBoxes.Add(KernelSection.AttackData, listBoxAttacks);

            //item data
            tabPages.Add(KernelSection.ItemData, tabPageItemData);
            listBoxes.Add(KernelSection.ItemData, listBoxItems);
            nameTextBoxes.Add(KernelSection.ItemData, textBoxItemName);
            descriptionTextBoxes.Add(KernelSection.ItemData, textBoxItemDescription);
            idLabels.Add(KernelSection.ItemData, labelItemID);
            cameraMovementSingle.Add(KernelSection.ItemData, comboBoxItemCamMovementID);
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
            idLabels.Add(KernelSection.WeaponData, labelWeaponID);
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
            idLabels.Add(KernelSection.ArmorData, labelArmorID);
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
            idLabels.Add(KernelSection.AccessoryData, labelAccessoryID);
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
            idLabels.Add(KernelSection.MateriaData, labelMateriaID);
            statusLists.Add(KernelSection.MateriaData, statusesControlMateria);

            //key items
            tabPages.Add(KernelSection.KeyItemNames, tabPageKeyItemText);
            listBoxes.Add(KernelSection.KeyItemNames, listBoxKeyItems);
            nameTextBoxes.Add(KernelSection.KeyItemNames, textBoxKeyItemName);
            descriptionTextBoxes.Add(KernelSection.KeyItemNames, textBoxKeyItemDescription);

            //set max values for various controls
            numericCharacterCurrentEXP.Maximum = uint.MaxValue;
            numericCharacterEXPtoNext.Maximum = uint.MaxValue;
            numericStartingGil.Maximum = uint.MaxValue;

            //add relevant data to controls
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
            for (int i = 0; i < Kernel.CHARACTER_COUNT; ++i)
            {
                var name = Enum.GetName((CharacterNames)i);
                if (name != null)
                {
                    var parsedName = StringParser.AddSpaces(name);
                    listBoxCharacterAI.Items.Add(parsedName);
                    comboBoxParty1.Items.Add(parsedName);
                    comboBoxParty2.Items.Add(parsedName);
                    comboBoxParty3.Items.Add(parsedName);

                    //playable characters
                    if (i < Kernel.PLAYABLE_CHARACTER_COUNT)
                    {
                        listBoxCharacterLimits.Items.Add(parsedName);
                        listBoxCharacterGrowth.Items.Add(parsedName);

                        if (i == 6 || i == 7) //Cait/Vincent
                        {
                            var name2 = Enum.GetName((CharacterNames)(i + 3));
                            if (name2 != null)
                            {
                                parsedName = StringParser.AddSpaces(name2);
                            }
                        }
                        listBoxInitCharacters.Items.Add(parsedName);
                    }
                }
            }

            limitRequirementControl1.SetData(kernel.GetLimitNames(), 1);
            limitRequirementControl2.SetData(kernel.GetLimitNames(), 2);
            limitRequirementControl3.SetData(kernel.GetLimitNames(), 3);
            limitRequirementControl4.SetData(kernel.GetLimitNames(), 4);

            listBoxCharacterAI.Items.Add("(unknown)");
            LoadItemLists();
            foreach (var f in Enum.GetNames<CharacterFlags>())
            {
                comboBoxCharacterFlags.Items.Add(f);
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
                        cb.Items.Add(StringParser.AddSpaces(s.ToString()));
                    }
                }
            }
            comboBoxItemStatusChange.Items.Add("None");
            foreach (var s in DataManager.StatusChangeTypes)
            {
                if (s != StatusChangeType.None)
                {
                    comboBoxItemStatusChange.Items.Add(s);
                }
            }

            //spell type
            for (int i = 0; i < (int)SpellType.Unlisted; ++i)
            {
                SpellIndexes[i] =
                    (from s in kernel.BattleAndGrowthData.SpellIndexes
                     where (int)s.SpellType == i
                     orderby s.SectionIndex
                     select s).ToList();
            }

            //materia info
            foreach (var g in Enum.GetNames<GrowthRate>())
            {
                foreach (var cb in materiaGrowthComboBoxes.Values)
                {
                    cb.Items.Add(g);
                }
            }
            comboBoxMateriaElement.Items.Add("None");
            foreach (var el in Enum.GetValues<MateriaElements>())
            {
                if (el == MateriaElements.Bolt) { comboBoxMateriaElement.Items.Add("Lightning"); }
                else { comboBoxMateriaElement.Items.Add(el); }
            }
            foreach (var mt in Enum.GetNames<MateriaType>())
            {
                comboBoxMateriaType.Items.Add(mt);
            }
            for (int i = 0; i < MateriaEquipEffect.COUNT; ++i) // (var e in MateriaExt.EQUIP_EFFECTS)
            {
                string name = $"Effect ID {i:X2}";
                if (DataManager.ExeData != null)
                {
                    name = DataManager.ExeData.MateriaEquipEffects[i].ToString();
                }
                comboBoxMateriaEquipAttributes.Items.Add(name);
            }
            independentMateriaTypes = Enum.GetValues<IndependentMateriaTypes>().ToList();

            //section-specific data
            comboBoxAttackType.SelectedIndex = 0;
            foreach (var lb in listBoxes)
            {
                UpdateNames(lb.Key);
            }
            UpdateInitialData();
            UpdateBattleAndGrowthData();
            UpdateBattleText();
            UpdateLimitNames();

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
            FormFunctions.EnableOrDisableInner(tabPageInitCharacterStats, false,
                new List<Control> { listBoxInitCharacters }.AsReadOnly());
            FormFunctions.EnableOrDisableInner(groupBoxSelectedCurve, false, Array.Empty<Control>().AsReadOnly());
            loading = false;
        }

        #endregion

        #region User Methods

        /// <summary>
        /// Marks whether or not there is unsaved data
        /// </summary>
        /// <param name="unsaved">If data is unsaved or not</param>
        private void SetUnsaved(bool unsaved)
        {
            unsavedChanges = unsaved;
            Text = $"{(unsaved ? "*" : "")}{WINDOW_TITLE}";
        }

        #region Load Data

        /// <summary>
        /// Enables or disables controls for a tab page
        /// </summary>
        /// <param name="section">The section for the associated tab page</param>
        /// <param name="enabled">Whether to enable or disable controls</param>
        private void EnableOrDisableTabPageControls(KernelSection section, bool enabled)
        {
            //mark whether or not the page is enabled
            if (!tabPageIsEnabled.ContainsKey(tabPages[section]))
            {
                tabPageIsEnabled.Add(tabPages[section], !enabled);
            }

            //enable or disable the controls
            if (tabPages.ContainsKey(section) && tabPageIsEnabled[tabPages[section]] != enabled)
            {
                FormFunctions.EnableOrDisableInner(tabPages[section], enabled, GetIgnoreListForSection(section));
                tabPageIsEnabled[tabPages[section]] = enabled;
            }
        }

        /// <summary>
        /// Gets a list of controls to ignore for EnableOrDisableInner
        /// </summary>
        /// <param name="section">The section for the associated controls</param>
        /// <returns></returns>
        private ReadOnlyCollection<Control> GetIgnoreListForSection(KernelSection section)
        {
            var list = new List<Control>();
            if (tabPages.ContainsKey(section))
            {
                list.Add(listBoxes[section]); //ignore main listbox

                if (section == KernelSection.AttackData) //ignore selection combo box
                {
                    list.Add(comboBoxAttackType);
                }

                //if scene.bin isn't loaded, disable synced attacks
                //if (!DataManager.SceneFilePathExists)
                //{
                //list.Add(groupBoxAttackSpecialActions);
                //}
            }
            return list.AsReadOnly();
        }

        /// <summary>
        /// Get item names and put them into relevant combo boxes
        /// </summary>
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
            int i = comboBoxInitItem.SelectedIndex;
            comboBoxInitItem.Items.Clear();
            comboBoxInitItem.Items.Add("None");
            foreach (var item in kernel.ItemData.Items)
            {
                comboBoxInitItem.Items.Add(item.Name);
            }
            comboBoxInitItem.SelectedIndex = i;

            //weapons
            i = comboBoxCharacterWeapon.SelectedIndex;
            comboBoxCharacterWeapon.Items.Clear();
            foreach (var wpn in kernel.WeaponData.Weapons)
            {
                comboBoxCharacterWeapon.Items.Add(wpn.Name);
                comboBoxInitItem.Items.Add(wpn.Name);
            }
            comboBoxCharacterWeapon.SelectedIndex = i;

            //armor
            i = comboBoxCharacterArmor.SelectedIndex;
            comboBoxCharacterArmor.Items.Clear();
            foreach (var armor in kernel.ArmorData.Armors)
            {
                comboBoxCharacterArmor.Items.Add(armor.Name);
                comboBoxInitItem.Items.Add(armor.Name);
            }
            comboBoxCharacterArmor.SelectedIndex = i;

            //accessories
            i = comboBoxCharacterAccessory.SelectedIndex;
            comboBoxCharacterAccessory.Items.Clear();
            comboBoxCharacterAccessory.Items.Add("None");
            foreach (var acc in kernel.AccessoryData.Accessories)
            {
                comboBoxCharacterAccessory.Items.Add(acc.Name);
                comboBoxInitItem.Items.Add(acc.Name);
            }
            comboBoxCharacterAccessory.SelectedIndex = i;

            //materia
            i = comboBoxInitMateria.SelectedIndex;
            int j = comboBoxInitMateriaStolen.SelectedIndex;
            comboBoxInitMateria.Items.Clear();
            comboBoxInitMateriaStolen.Items.Clear();
            comboBoxInitMateria.Items.Add("None");
            comboBoxInitMateriaStolen.Items.Add("None");
            foreach (var mat in kernel.MateriaData.Materias)
            {
                comboBoxInitMateria.Items.Add(mat.Name);
                comboBoxInitMateriaStolen.Items.Add(mat.Name);
            }
            comboBoxInitMateria.SelectedIndex = i;
            comboBoxInitMateriaStolen.SelectedIndex = j;

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

        /// <summary>
        /// Fill out the initial data tab with inventory items
        /// </summary>
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

            //inventory
            int i = listBoxInitInventory.SelectedIndex;
            listBoxInitInventory.Items.Clear();
            foreach (var inv in kernel.InitialData.Inventory)
            {
                if (DataParser.GetItemType(inv.Item) == ItemType.None)
                {
                    listBoxInitInventory.Items.Add("(empty)");
                }
                else
                {
                    listBoxInitInventory.Items.Add($"{kernel.GetInventoryItemName(inv)} x{inv.Amount}");
                }
            }
            listBoxInitInventory.SelectedIndex = i;


            //materia
            i = listBoxInitMateria.SelectedIndex;
            listBoxInitMateria.Items.Clear();
            foreach (var invm in kernel.InitialData.Materia)
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
            listBoxInitMateria.SelectedIndex = i;
            SetInitMateria(false);

            //stolen materia
            i = listBoxInitMateriaStolen.SelectedIndex;
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
            listBoxInitMateriaStolen.SelectedIndex = i;

            if (!wasAlreadyLoading)
            {
                listBoxInitInventory.ResumeLayout();
                listBoxInitMateria.ResumeLayout();
                listBoxInitMateriaStolen.ResumeLayout();
                loading = false;
            }
        }

        /// <summary>
        /// Fill out a section's tab with associated data
        /// </summary>
        /// <param name="section">The section to load data from</param>
        private void PopulateTabWithSelected(KernelSection section)
        {
            loading = true;
            if (listBoxes.ContainsKey(section))
            {
                int i = listBoxes[section].SelectedIndex, j;
                if (i >= 0 && i < kernel.GetCount(section))
                {
                    if (section == KernelSection.AttackData)
                    {
                        if (SelectedAttackType == AttackTypes.Summon && i > AttackCount - 3)
                        {
                            i = Kernel.SPECIAL_SUMMON_OFFSET + (i - AttackCount) + 2;
                        }
                        else
                        {
                            i += AttackOffset;
                        }
                    }
                    EnableOrDisableTabPageControls(section, true);

                    //check for name
                    if (nameTextBoxes.ContainsKey(section))
                    {
                        nameTextBoxes[section].Text = kernel.GetAssociatedNames(section)[i];
                    }

                    //check for description
                    if (descriptionTextBoxes.ContainsKey(section))
                    {
                        descriptionTextBoxes[section].Text = kernel.GetAssociatedDescriptions(section)[i];
                    }

                    //check for ID
                    if (idLabels.ContainsKey(section))
                    {
                        idLabels[section].Text = $"ID: {i:X2}";
                    }

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
                    if (statusChangeComboBoxes.ContainsKey(section))
                    {
                        var change = kernel.GetStatusChange(section, i);
                        if (change.Type == StatusChangeType.None)
                        {
                            statusChangeComboBoxes[section].SelectedIndex = 0;
                            statusLists[section].Enabled = false;
                        }
                        else
                        {
                            var temp = DataManager.StatusChangeTypes.ToList();
                            statusChangeComboBoxes[section].SelectedIndex = temp.IndexOf(change.Type) + 1;
                            statusLists[section].Enabled = true;
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
                            var command = kernel.CommandData.Commands[i];
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
                            var attack = kernel.AttackData.Attacks[i];
                            j = i - Kernel.SUMMON_OFFSET;
                            string? summon = null;
                            if (j >= 0 && j < kernel.SummonAttackNames.Strings.Length)
                            {
                                summon = kernel.SummonAttackNames.Strings[j];
                            }
                            SpellType type = SpellType.Unlisted;
                            if (i < Kernel.INDEXED_SPELL_COUNT)
                            {
                                type = kernel.BattleAndGrowthData.SpellIndexes[i].SpellType;
                            }
                            attackFormControl.UpdateForm(attack, i, kernel.AttackIsLimit[i], summon, type);

                            //checkBoxAttackSyncWithSceneBin.Checked = syncedAttackIDs.Contains((ushort)attack.Index);
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
                                comboBoxMateriaElement.SelectedIndex = (int)materia.Element + 1;
                            }
                            else
                            {
                                comboBoxMateriaElement.SelectedIndex = 0;
                            }
                            comboBoxMateriaType.SelectedIndex = (int)Materia.GetMateriaType(materia.MateriaTypeByte);
                            UpdateMateriaSubtype(materia);
                            materiaLevelControl.SetAPLevels(materia.Level2AP, materia.Level3AP, materia.Level4AP,
                                materia.Level5AP);
                            if (materia.EquipEffect > MateriaEquipEffect.COUNT)
                            {
                                comboBoxMateriaEquipAttributes.SelectedIndex = 0;
                            }
                            else
                            {
                                comboBoxMateriaEquipAttributes.SelectedIndex = materia.EquipEffect;
                            }
                            break;
                    }
                }
                else //nothing selected, so disable tab
                {
                    if (section == KernelSection.AttackData && i > 0)
                    {
                        var names = kernel.GetAssociatedNames(section);
                        var descs = kernel.GetAssociatedDescriptions(section);
                        if (i < names.Length && i < descs.Length)
                        {
                            attackFormControl.UpdateForm(i, names[i], descs[i]);
                        }
                    }
                    else
                    {
                        EnableOrDisableTabPageControls(section, false);
                    }
                }
            }
            loading = false;
        }

        /// <summary>
        /// Fill out the character data tab with selected character's info
        /// </summary>
        /// <param name="charIndex">The index of the selected character</param>
        private void PopulateInitCharacterDataTab(int charIndex)
        {
            if (charIndex >= 0 && charIndex < 9)
            {
                loading = true;
                if (!tabPageIsEnabled.ContainsKey(tabPageInitCharacterStats))
                {
                    FormFunctions.EnableOrDisableInner(tabPageInitCharacterStats, true, (ReadOnlyCollection<Control>?)null);
                    tabPageIsEnabled.Add(tabPageInitCharacterStats, true);
                }

                var character = kernel.CharacterList[charIndex];

                textBoxCharacterName.Text = character.Name.ToString();
                numericCharacterID.Value = character.ID;
                numericCharacterLevel.Value = character.Level;
                numericCharacterCurrentEXP.Value = character.CurrentEXP;
                numericCharacterEXPtoNext.Value = character.EXPtoNextLevel;
                numericCharacterLevelOffset.Value = character.RecruitLevelOffset;
                numericCharacterLevelOffset.Enabled = character.ID != (byte)CharacterNames.Yuffie;

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
                    materiaSlotSelectorCharacterWeapon.SetMateria(character.WeaponMateria, kernel);
                }
                var armor = kernel.GetArmorByID(character.ArmorID);
                if (armor != null)
                {
                    comboBoxCharacterArmor.SelectedIndex = character.ArmorID;
                    materiaSlotSelectorCharacterArmor.SetMateria(character.ArmorMateria, kernel);
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

                limitRequirementControl1.Enabled = true;
                limitRequirementControl2.Enabled = true;
                limitRequirementControl3.Enabled = true;
                limitRequirementControl4.Enabled = true;

                limitRequirementControl1.SetCharacter(character);
                limitRequirementControl2.SetCharacter(character);
                limitRequirementControl3.SetCharacter(character);
                limitRequirementControl4.SetCharacter(character);

                loading = false;
            }
        }

        /// <summary>
        /// Updates the stat growth chart with relevant data.
        /// </summary>
        /// <param name="chara">The index of the currently selected character.</param>
        /// <param name="stat">The index of the currently selected stat.</param>
        private void UpdateStatCurves(int chara, int stat)
        {
            if (chara >= 0 && chara < Kernel.PLAYABLE_CHARACTER_COUNT && stat >= 0 && stat < 9)
            {
                loading = true;
                var c = kernel.CharacterList[chara];

                //enable the controls
                FormFunctions.EnableOrDisableInner(groupBoxSelectedCurve, true, null);

                //check if selected character is Cait Sith or Vincent
                bool inaccurate = false;
                if (chara == (int)CharacterNames.CaitSith || chara == (int)CharacterNames.Vincent)
                {
                    if (DataManager.ExeData == null)
                    {
                        inaccurate = stat != (int)CurveStats.EXP;
                    }
                    else if (chara == (int)CharacterNames.CaitSith)
                    {
                        c = DataManager.ExeData.CaitSith;
                    }
                    else
                    {
                        c = DataManager.ExeData.Vincent;
                    }
                }
                labelInaccurateCurve.Visible = inaccurate;

                //fill out the charts
                chartMainCurve.SuspendLayout();
                MainCurveMin.Points.Clear();
                MainCurveMax.Points.Clear();
                var minStats = kernel.BattleAndGrowthData.CalculateMinStats(c, (CurveStats)stat);
                var maxStats = kernel.BattleAndGrowthData.CalculateMaxStats(c, (CurveStats)stat);
                for (int i = 1; i <= 99; ++i)
                {
                    if (stat != (int)CurveStats.EXP)
                    {
                        MainCurveMin.Points.AddXY(i, minStats[i - 1]);
                    }
                    MainCurveMax.Points.AddXY(i, maxStats[i - 1]);
                }
                chartMainCurve.ResumeLayout();

                //set numerics
                numericCurveIndex.Value = kernel.GetCurveIndex(chara, stat);
                bool isEXP = (stat == (int)CurveStats.EXP);
                groupBoxCurveBonuses.Enabled = !isEXP;
                FormFunctions.EnableOrDisableInner(groupBoxCurveBonuses, !isEXP, null);
                if (isEXP)
                {
                    labelCurveMin.Text = "Value: ??";
                    labelCurveMax.Visible = false;
                }
                else
                {
                    labelCurveMin.Text = "Min: ??";
                    labelCurveMax.Visible = true;

                    for (int i = 0; i < 12; ++i)
                    {
                        if (stat == (int)CurveStats.HP)
                        {
                            curveBonuses[i].Value = kernel.BattleAndGrowthData.RandomBonusToHP[i];
                        }
                        else if (stat == (int)CurveStats.MP)
                        {
                            curveBonuses[i].Value = kernel.BattleAndGrowthData.RandomBonusToMP[i];
                        }
                        else
                        {
                            curveBonuses[i].Value = kernel.BattleAndGrowthData.RandomBonusToPrimaryStats[i];
                        }
                    }
                }

                loading = false;
            }
        }

        /// <summary>
        /// Display info for currently selected inventory item
        /// </summary>
        /// <param name="selected">The selected item</param>
        private void PopulateInitInventoryBox(int selected)
        {
            if (selected >= 0 && selected < Kernel.INVENTORY_SIZE)
            {
                var item = kernel.InitialData.Inventory[selected];
                loading = true;
                comboBoxInitItem.Enabled = true;
                var type = DataParser.GetItemType(item.Item);
                switch (DataParser.GetItemType(item.Item))
                {
                    case ItemType.None:
                        comboBoxInitItem.SelectedIndex = 0;
                        break;
                    default:
                        comboBoxInitItem.SelectedIndex = item.Item + 1;
                        break;
                }

                if (type == ItemType.None)
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

        /// <summary>
        /// Display info for the currently selected materia
        /// </summary>
        /// <param name="isStolen">Whether this materia was stolen by Yuffie</param>
        private void PopulateInitMateriaBox(bool isStolen)
        {
            //get index + max
            int i, max;
            if (isStolen)
            {
                i = listBoxInitMateriaStolen.SelectedIndex;
                max = Kernel.STOLEN_MATERIA_COUNT;
            }
            else
            {
                i = listBoxInitMateria.SelectedIndex;
                max = Kernel.MATERIA_INVENTORY_SIZE;
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
                    materia = kernel.InitialData.Materia[i];
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

        /// <summary>
        /// Reload the script list for the selected character
        /// </summary>
        /// <param name="selectedChar">The index of the selected character</param>
        private void UpdateCharacterAIScripts(int selectedChar)
        {
            if (selectedChar >= 0 && selectedChar < Kernel.AI_BLOCK_COUNT)
            {
                try
                {
                    //load the scripts if they aren't
                    if (!kernel.ScriptsLoaded)
                    {
                        kernel.ParseAIScripts();
                        groupBoxCharacterScripts.Enabled = true;
                        scriptControlCharacterAI.Enabled = true;
                    }
                    var chara = kernel.CharacterAI[selectedChar];
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

        /// <summary>
        /// Show the currently selected script
        /// </summary>
        /// <param name="charID">The index of the selected character</param>
        /// <param name="scriptID">The index of the selected script</param>
        private void DisplayScript(int charID, int scriptID)
        {
            var chara = kernel.CharacterAI[charID];
            scriptControlCharacterAI.AIContainer = chara;
            scriptControlCharacterAI.SelectedScriptIndex = scriptID;
        }

        /// <summary>
        /// Load names from selected section into associated listbox
        /// </summary>
        /// <param name="section">The section to load names for</param>
        private void UpdateNames(KernelSection section)
        {
            bool wasAlreadyLoading = loading;
            loading = true;
            var s = Kernel.GetDataSection(section);
            if (listBoxes.ContainsKey(s))
            {
                int i = listBoxes[s].SelectedIndex;
                listBoxes[s].SuspendLayout();
                listBoxes[s].Items.Clear();
                var names = kernel.GetAssociatedNames(s);
                if (names != null)
                {
                    int top = 0, bottom = names.Length, j;
                    bool summons = false;
                    if (section == KernelSection.AttackData) //offset for attacks
                    {
                        top = AttackOffset;
                        bottom = AttackOffset + AttackCount;
                        summons = SelectedAttackType == AttackTypes.Summon;
                        if (summons) { bottom -= 2; }
                    }

                    for (j = top; j < bottom; ++j)
                    {
                        listBoxes[s].Items.Add(names[j]);
                    }
                    if (summons) //add extra limits
                    {
                        for (j = Kernel.SPECIAL_SUMMON_OFFSET; j < Kernel.SPECIAL_SUMMON_OFFSET + 2; ++j)
                        {
                            listBoxes[s].Items.Add(names[j]);
                        }
                    }

                    //re-set previously selected item
                    listBoxes[s].SelectedIndex = i;
                    if (i >= 0 && i < listBoxes[s].Items.Count)
                    {
                        nameTextBoxes[s].Text = names[i + top];
                    }
                }
                listBoxes[s].ResumeLayout();
            }
            if (!wasAlreadyLoading) { loading = false; }
        }

        /// <summary>
        /// Reload description for selected section (if one is selected)
        /// </summary>
        /// <param name="section">The section to update the description for</param>
        private void UpdateSelectedDescription(KernelSection section)
        {
            bool wasAlreadyLoading = loading;
            loading = true;
            var s = Kernel.GetDataSection(section);
            if (listBoxes.ContainsKey(s))
            {
                int i = listBoxes[s].SelectedIndex;
                if (i >= 0 && i < kernel.GetCount(s))
                {
                    descriptionTextBoxes[s].Text = kernel.GetAssociatedDescriptions(s)[i];
                }
            }
            if (!wasAlreadyLoading) { loading = false; }
        }

        /// <summary>
        /// Load everything from the initial data section into associated controls
        /// </summary>
        private void UpdateInitialData()
        {
            bool wasAlreadyLoading = loading;
            loading = true;

            PopulateInventoryListBoxes();
            if (kernel.InitialData.Party1 == 0xFF) { comboBoxParty1.SelectedIndex = 0; }
            else { comboBoxParty1.SelectedIndex = kernel.InitialData.Party1 + 1; }
            if (kernel.InitialData.Party2 == 0xFF) { comboBoxParty2.SelectedIndex = 0; }
            else { comboBoxParty2.SelectedIndex = kernel.InitialData.Party2 + 1; }
            if (kernel.InitialData.Party3 == 0xFF) { comboBoxParty3.SelectedIndex = 0; }
            else { comboBoxParty3.SelectedIndex = kernel.InitialData.Party3 + 1; }
            numericStartingGil.Value = kernel.InitialData.Gil;


            if (!wasAlreadyLoading) { loading = false; }
        }

        /// <summary>
        /// Load everything from the battle and growth data section into associated controls
        /// </summary>
        private void UpdateBattleAndGrowthData()
        {
            UpdateCharacterAIScripts(SelectedCharacterIndex);
            rngTableControl.SetValues(kernel.BattleAndGrowthData.RNGTable);

            //other stuff
        }

        /// <summary>
        /// Add battle text to the list box
        /// </summary>
        private void UpdateBattleText()
        {
            bool wasAlreadyLoading = loading;
            loading = true;
            int i = listBoxBattleText.SelectedIndex;

            listBoxBattleText.SuspendLayout();
            listBoxBattleText.Items.Clear();

            foreach (var t in kernel.BattleTextFF)
            {
                listBoxBattleText.Items.Add(t);
            }

            listBoxBattleText.SelectedIndex = i;
            if (i >= 0 && i < kernel.BattleTextFF.Length)
            {
                textBoxBattleText.Text = kernel.BattleTextFF[i].ToString();
            }

            if (!wasAlreadyLoading) { loading = false; }
        }

        /// <summary>
        /// Reload the limit names
        /// </summary>
        private void UpdateLimitNames()
        {
            bool wasAlreadyLoading = loading;
            loading = true;
            int i = listBoxLimitBreaks.SelectedIndex;

            listBoxLimitBreaks.SuspendLayout();
            listBoxLimitBreaks.Items.Clear();

            for (int j = Kernel.ATTACK_COUNT; j < kernel.MagicNames.Strings.Length; ++j)
            {
                listBoxLimitBreaks.Items.Add(kernel.MagicNames.Strings[j]);
            }

            listBoxLimitBreaks.SelectedIndex = i;
            if (i >= Kernel.ATTACK_COUNT && i < kernel.MagicNames.Strings.Length)
            {
                textBoxLimitName.Text = kernel.MagicNames.Strings[i + Kernel.ATTACK_COUNT];
            }

            if (!wasAlreadyLoading) { loading = false; }
        }

        private void ReloadAllText()
        {
            for (int i = 0; i < Kernel.KERNEL1_END; ++i)
            {
                var s = (KernelSection)i;
                UpdateNames(s);
                UpdateSelectedDescription(s);
            }
            UpdateNames(KernelSection.KeyItemNames);
            UpdateSelectedDescription(KernelSection.KeyItemNames);
            UpdateBattleText();
            UpdateLimitNames();
        }

        /// <summary>
        /// Get list of subtypes for the selected materia type
        /// </summary>
        /// <param name="mat">The selected materia</param>
        private void UpdateMateriaSubtype(Materia mat)
        {
            comboBoxMateriaSubtype.SelectedIndex = MateriaExt.GetSubtypeIndex(mat);
            buttonMateriaAttributes.Enabled = MateriaExt.MateriaHasEditableAttribules(mat);
        }

        #endregion

        #region Sync Unsaved Data

        /// <summary>
        /// Update the selected command with info from controls
        /// </summary>
        /// <param name="command">The selected command</param>
        private void SyncCommandData(Command command)
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

        /// <summary>
        /// Update the selected character with info from controls
        /// </summary>
        /// <param name="chara">The selected character</param>
        private void SyncInitialStats(Character chara)
        {
            chara.Name = textBoxCharacterName.Text;
            chara.Level = (byte)numericCharacterLevel.Value;
            chara.CurrentEXP = (uint)numericCharacterCurrentEXP.Value;
            chara.EXPtoNextLevel = (uint)numericCharacterEXPtoNext.Value;
            chara.CurrentHP = (ushort)numericCharacterCurrHP.Value;
            chara.BaseHP = (ushort)numericCharacterBaseHP.Value;
            chara.MaxHP = (ushort)numericCharacterMaxHP.Value;
            chara.CurrentMP = (ushort)numericCharacterCurrMP.Value;
            chara.BaseMP = (ushort)numericCharacterBaseMP.Value;
            chara.MaxMP = (ushort)numericCharacterMaxMP.Value;
            if (chara.ID != (byte)CharacterNames.Yuffie)
            {
                chara.RecruitLevelOffset = (sbyte)(numericCharacterLevelOffset.Value);
            }
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

        /// <summary>
        /// Update the selected item with info from controls
        /// </summary>
        /// <param name="item">The selected item</param>
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

        /// <summary>
        /// Update the selected weapon with info from controls
        /// </summary>
        /// <param name="weapon">The selected weapon</param>
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
            weapon.AttackStrength = damageCalculationControlWeapon.AttackPower;
            weapon.Targets = targetDataControlWeapon.GetTargetData();
            weapon.EquipableBy = equipableListWeapon.GetEquipableFlags();
            weapon.Restrictions = itemRestrictionsWeapon.GetItemRestrictions();

            weaponNeedsSync = false;
        }

        /// <summary>
        /// Update the selected armor with info from controls
        /// </summary>
        /// <param name="armor">The selected armor</param>
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

        /// <summary>
        /// Update the selected accessory with info from controls
        /// </summary>
        /// <param name="acc">The selected accessory</param>
        private void SyncAccessoryData(Accessory acc)
        {
            acc.ElementalDefense = elementsControlAccessory.GetElements();
            int temp = comboBoxAccessoryElementModifier.SelectedIndex;
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

        /// <summary>
        /// Update the selected materia with info from controls
        /// </summary>
        /// <param name="materia">The selected materia</param>
        private void SyncMateriaData(Materia materia)
        {
            var elem = Enum.GetValues<MateriaElements>();
            if (comboBoxMateriaElement.SelectedIndex == 0)
            {
                materia.Element = (MateriaElements)0xFF;
            }
            else
            {
                materia.Element = elem[comboBoxMateriaElement.SelectedIndex - 1];
            }
            materia.EquipEffect = (byte)comboBoxMateriaEquipAttributes.SelectedIndex;
            materia.Status = statusesControlMateria.GetStatuses();
            materia.Level2AP = materiaLevelControl.Lvl2APValue;
            materia.Level3AP = materiaLevelControl.Lvl3APValue;
            materia.Level4AP = materiaLevelControl.Lvl4APValue;
            materia.Level5AP = materiaLevelControl.Lvl5APValue;

            materiaNeedsSync = false;
        }

        /// <summary>
        /// Update item names across all controls
        /// </summary>
        private void SyncItemNames()
        {
            LoadItemLists();
            PopulateInitCharacterDataTab(SelectedCharacterIndex);
            PopulateInventoryListBoxes();
            itemNamesNeedSync = false;
        }

        /// <summary>
        /// Make sure all data from controls is properly reflected in kernel
        /// </summary>
        private void SyncAllUnsaved()
        {
            if (commandNeedsSync && SelectedCommand != null)
            {
                SyncCommandData(SelectedCommand);
            }
            if (attackNeedsSync && SelectedAttack != null)
            {
                attackFormControl.SyncAttackData(SelectedAttack);
            }
            if (initialStatsNeedSync && SelectedCharacter != null)
            {
                SyncInitialStats(SelectedCharacter);
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

        /// <summary>
        /// Set the currently selected inventory item with data from controls
        /// </summary>
        private void SetInventoryItem()
        {
            int selectedItem = listBoxInitInventory.SelectedIndex,
                newItemIndex = comboBoxInitItem.SelectedIndex,
                amount = (int)numericInitItemAmount.Value;

            if (selectedItem >= 0 && selectedItem < Kernel.INVENTORY_SIZE)
            {
                loading = true;
                var item = kernel.InitialData.Inventory[selectedItem];
                if (newItemIndex == 0) //none
                {
                    DataParser.SetItem(item, ItemType.None, 0);
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

                    var type = DataParser.GetItemType((ushort)(newItemIndex - 1));
                    byte index = DataParser.GetItemIndex((ushort)(newItemIndex - 1));

                    DataParser.SetItem(item, type, index);
                    item.Amount = amount;
                    var name = kernel.GetInventoryItemName(item);
                    listBoxInitInventory.Items[selectedItem] = $"{name} x{amount}";
                }
                loading = false;
                SetUnsaved(true);
            }
        }

        /// <summary>
        /// Set the currently selected inventory materia with data from controls
        /// </summary>
        /// <param name="isStolen">Whether this materia was stolen by Yuffie</param>
        private void SetInitMateria(bool isStolen)
        {
            //get data to check/edit
            int selectedMateria, newMateriaIndex, max;
            ListBox listBox;
            ComboBox comboBox;
            Button editButton;

            if (isStolen)
            {
                max = Kernel.STOLEN_MATERIA_COUNT;
                listBox = listBoxInitMateriaStolen;
                comboBox = comboBoxInitMateriaStolen;
                editButton = buttonInitMateriaStolenEdit;
            }
            else
            {
                max = Kernel.MATERIA_INVENTORY_SIZE;
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
                else { materia = kernel.InitialData.Materia[selectedMateria]; }

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

        /// <summary>
        /// Add selected attack to synced attacks list (syncs with scene.bin)
        /// </summary>
        /// <param name="id">The index of the selected attack</param>
        private void SyncAttack(ushort id)
        {
            if (!syncedAttackIDs.Contains(id))
            {
                syncedAttackIDs.Add(id);
            }
        }

        /// <summary>
        /// Update the scene lookup table
        /// </summary>
        /// <param name="table">The new table</param>
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
                    SyncItemNames();
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
                    var command = kernel.CommandData.Commands[prevCommand];
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
                PopulateTabWithSelected(KernelSection.AttackData);
            }
        }

        private void listBoxCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                //load both init data and limit data
                int i = SelectedCharacterIndex;
                if (sender == listBoxCharacterLimits)
                {
                    i = listBoxCharacterLimits.SelectedIndex;
                }
                loading = true;
                listBoxInitCharacters.SelectedIndex = i;
                listBoxCharacterLimits.SelectedIndex = i;

                if (initialStatsNeedSync) //sync unsaved stat data
                {
                    var chara = kernel.CharacterList[prevCharacter];
                    if (chara != null)
                    {
                        SyncInitialStats(chara);
                    }
                }
                prevCharacter = i;
                PopulateInitCharacterDataTab(i);
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
                    textBoxBattleText.Text = kernel.BattleTextFF[i].ToString();
                    loading = false;
                }
            }
        }

        private void listBoxLimitBreaks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = listBoxLimitBreaks.SelectedIndex + Kernel.ATTACK_COUNT;
                if (i >= Kernel.ATTACK_COUNT && i < kernel.MagicNames.Strings.Length)
                {
                    loading = true;
                    labelLimitName.Enabled = true;
                    labelLimitDescription.Enabled = true;
                    textBoxLimitName.Enabled = true;
                    textBoxLimitDescription.Enabled = true;
                    textBoxLimitName.Text = kernel.MagicNames.Strings[i];
                    textBoxLimitDescription.Text = kernel.MagicDescriptions.Strings[i];
                    loading = false;
                }
            }
        }

        #endregion

        #region Data Changed (Common)

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
                    if (Kernel.SectionIsItems(curr))
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

        private void comboBoxStatusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statusChangeComboBoxes.ContainsKey(CurrentSection))
            {
                int i = statusChangeComboBoxes[CurrentSection].SelectedIndex;
                var status = StatusChangeType.None;
                bool hasStatus = i > 0;
                if (hasStatus)
                {
                    status = DataManager.StatusChangeTypes[i - 1];
                }
                statusLists[CurrentSection].Enabled = hasStatus;
                if (CurrentSection == KernelSection.ItemData && SelectedItem != null)
                {
                    SelectedItem.StatusChange.Type = status;
                }
                if (!loading) { SetUnsaved(true); }
            }
        }

        #endregion

        #region Data Changed (Section-Specific)

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

        private void StatCurveChanged(object sender, EventArgs e)
        {
            UpdateStatCurves(listBoxCharacterGrowth.SelectedIndex,
                listBoxStatCurves.SelectedIndex);
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

        private void comboBoxAttackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                listBoxAttacks.SelectedIndex = -1;
                UpdateNames(KernelSection.AttackData);
            }
        }

        private void textBoxAttackName_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                loading = true;
                string name = attackFormControl.AttackName;
                kernel.MagicNames.Strings[SelectedAttackIndex] = name;
                listBoxAttacks.Items[listBoxAttacks.SelectedIndex] = name;
                SetUnsaved(true);
                loading = false;
            }
        }

        private void textBoxAttackDescription_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                kernel.MagicDescriptions.Strings[SelectedAttackIndex] = attackFormControl.AttackDescription;
                SetUnsaved(true);
            }
        }

        private void textBoxSummonText_TextChanged(object sender, EventArgs e)
        {
            int i = SelectedAttackIndex - Kernel.SUMMON_OFFSET;
            if (!loading && i >= 0 && i < kernel.SummonAttackNames.Strings.Length)
            {
                kernel.SummonAttackNames.Strings[i] = attackFormControl.SummonText;
                SetUnsaved(true);
            }
        }

        private void checkBoxAttackIsLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null)
            {
                kernel.AttackIsLimit[SelectedAttackIndex] = attackFormControl.IsLimit;
                SetUnsaved(true);
            }
        }

        private void comboBoxMagicType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedAttack != null && SelectedAttackIndex < Kernel.INDEXED_SPELL_COUNT)
            {
                //get spell index
                var index = kernel.BattleAndGrowthData.SpellIndexes[SelectedAttackIndex];
                SpellType oldType = index.SpellType, newType = attackFormControl.SpellType;

                if (oldType != newType)
                {
                    byte i, type;

                    //remove spell from the old list
                    if (oldType != SpellType.Unlisted)
                    {
                        type = (byte)oldType;
                        SpellIndexes[type].Remove(index);
                        for (i = 0; i < SpellIndexes[type].Count; ++i)
                        {
                            SpellIndexes[type][i].SectionIndex = i;
                        }
                    }

                    //add spell to the new list
                    if (newType != SpellType.Unlisted)
                    {
                        type = (byte)newType;
                        SpellIndexes[type].Add(index);
                        for (i = 0; i < SpellIndexes[type].Count; ++i)
                        {
                            SpellIndexes[type][i].SectionIndex = i;
                        }
                    }
                    index.SpellType = newType;
                    SetUnsaved(true);
                }
            }
        }

        private void buttonSpellPosition_Click(object sender, EventArgs e)
        {
            if (SelectedAttack != null && SelectedAttackIndex < Kernel.INDEXED_SPELL_COUNT)
            {
                var index = kernel.BattleAndGrowthData.SpellIndexes[SelectedAttackIndex];
                using (var form = new MagicOrderForm(SpellIndexes[(int)index.SpellType],
                    index, kernel.GetAssociatedNames(KernelSection.AttackData)))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        SpellIndexes[(int)index.SpellType] = form.SpellIndices;
                        SetUnsaved(true);
                    }
                }
            }
        }

        /*private void checkBoxAttackSyncWithSceneBin_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                bool isChecked = checkBoxAttackSyncWithSceneBin.Checked;
                var selected = listBoxAttacks.SelectedIndex;
                if (selected >= 0 && selected < kernel.GetCount(KernelSection.AttackData))
                {
                    var atk = kernel.AttackData.Attacks[selected];
                    loading = true;
                    if (isChecked)
                    {
                        bool result = MessageBox.Show("All instances of this attack in scene.bin will be synced with this one. Is that okay?",
                            "Sync Attack?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                        if (result)
                        {
                            SyncAttack((ushort)atk.Index);
                            SetUnsaved(true);
                        }
                        checkBoxAttackSyncWithSceneBin.Checked = result;
                    }
                    else
                    {
                        if (DataManager.AttackIsSynced((ushort)atk.Index))
                        {
                            bool result = MessageBox.Show("This will desync this attack from every instance of this attack in scene.bin. Are you sure you want to do this?",
                                "Desync Attack?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                            if (result)
                            {
                                syncedAttackIDs.Remove((ushort)atk.Index);
                                DataManager.UnsyncAttack((ushort)atk.Index);
                                kernel.AttackData.Attacks[selected] = DataParser.CopyAttack(atk);
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
                foreach (var a in kernel.AttackData.Attacks)
                {
                    SyncAttack((ushort)a.Index);
                }
                checkBoxAttackSyncWithSceneBin.Checked = true;
                loading = false;
            }
        }*/

        #endregion

        #region Character Controls

        private void numericCharacterID_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedCharacter != null && !loading)
            {
                SelectedCharacter.ID = (byte)numericCharacterID.Value;
                numericCharacterLevelOffset.Enabled = SelectedCharacter.ID != (byte)CharacterNames.Yuffie;
                SetUnsaved(true);
            }
        }

        private void comboBoxCharacterWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedCharacter != null)
            {
                if (!loading)
                {
                    SelectedCharacter.WeaponID = (byte)comboBoxCharacterWeapon.SelectedIndex;
                    SetUnsaved(true);
                }
                var wpn = kernel.GetWeaponByID(SelectedCharacter.WeaponID);
                if (wpn != null)
                {
                    materiaSlotSelectorCharacterWeapon.SetSlots(wpn);
                    materiaSlotSelectorCharacterWeapon.SetMateria(SelectedCharacter.WeaponMateria, kernel);
                }
                buttonCharacterWeaponChangeMateria.Enabled = false;
            }
        }

        private void comboBoxCharacterArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedCharacter != null)
            {
                if (!loading)
                {
                    SelectedCharacter.ArmorID = (byte)comboBoxCharacterArmor.SelectedIndex;
                    SetUnsaved(true);
                }
                var arm = kernel.GetArmorByID(SelectedCharacter.ArmorID);
                if (arm != null)
                {
                    materiaSlotSelectorCharacterArmor.SetSlots(arm);
                    materiaSlotSelectorCharacterArmor.SetMateria(SelectedCharacter.ArmorMateria, kernel);
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
            if (slot != -1 && SelectedCharacter != null)
            {
                var mat = DataParser.CopyMateria(SelectedCharacter.WeaponMateria[slot]);
                using (var edit = new MateriaAPEditForm(mat, kernel.MateriaData, kernel.GetEnemySkillNames()))
                {
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                        SelectedCharacter.WeaponMateria[slot] = mat;
                        materiaSlotSelectorCharacterWeapon.SetMateria(slot, mat, kernel);
                        SetUnsaved(true);
                    }
                }
            }
        }

        private void buttonCharacterArmorChangeMateria_Click(object sender, EventArgs e)
        {
            int slot = materiaSlotSelectorCharacterArmor.SelectedSlot;
            if (slot != -1 && SelectedCharacter != null)
            {
                var mat = DataParser.CopyMateria(SelectedCharacter.ArmorMateria[slot]);
                using (var edit = new MateriaAPEditForm(mat, kernel.MateriaData, kernel.GetEnemySkillNames()))
                {
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                        SelectedCharacter.ArmorMateria[slot] = mat;
                        materiaSlotSelectorCharacterArmor.SetMateria(slot, mat, kernel);
                        SetUnsaved(true);
                    }
                }
            }
        }

        private void limitRequirementControl_DataChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                SetUnsaved(true);
            }
        }

        private void numericCurveIndex_ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int chara = listBoxCharacterGrowth.SelectedIndex,
                    stat = listBoxStatCurves.SelectedIndex;

                kernel.SetCurveIndex(chara, stat, (byte)numericCurveIndex.Value);
                if (stat != (int)CurveStats.EXP && (chara == (int)CharacterNames.CaitSith || chara == (int)CharacterNames.Vincent))
                {
                    DataManager.MergeCharacterData(kernel);
                }
                UpdateStatCurves(chara, stat);
                SetUnsaved(true);
            }
        }

        private void buttonEditBaseCurve_Click(object sender, EventArgs e)
        {
            DialogResult result;
            byte curveIndex = (byte)numericCurveIndex.Value;
            bool unsaved;

            using (var editForm = new CurveEditForm(kernel, curveIndex))
            {
                result = editForm.ShowDialog();
                unsaved = editForm.Unsaved;
            }

            if (result == DialogResult.OK && unsaved)
            {
                int chara = listBoxCharacterGrowth.SelectedIndex,
                    stat = listBoxStatCurves.SelectedIndex;
                UpdateStatCurves(chara, stat);
                SetUnsaved(true);
            }
        }

        private void numericCurveBonus_ValueChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                var numeric = sender as NumericUpDown;
                if (numeric != null)
                {
                    int i = curveBonuses.ToList().IndexOf(numeric),
                        chara = listBoxCharacterGrowth.SelectedIndex,
                        stat = listBoxStatCurves.SelectedIndex;
                    if (i >= 0 && i < 12)
                    {
                        if (stat == (int)CurveStats.HP)
                        {
                            kernel.BattleAndGrowthData.RandomBonusToHP[i] = (byte)numeric.Value;
                        }
                        else if (stat == (int)CurveStats.MP)
                        {
                            kernel.BattleAndGrowthData.RandomBonusToMP[i] = (byte)numeric.Value;
                        }
                        else
                        {
                            kernel.BattleAndGrowthData.RandomBonusToPrimaryStats[i] = (byte)numeric.Value;
                        }
                        UpdateStatCurves(chara, stat);
                        SetUnsaved(true);
                    }
                }
            }
        }

        private void chartMainCurve_MouseMove(object sender, MouseEventArgs e)
        {
            int p = FindNearestPoint(e.X);
            if (p >= 0)
            {
                labelCurveLevel.Text = $"Level: {p + 1}";
                if (listBoxStatCurves.SelectedIndex == (int)CurveStats.EXP)
                {
                    int val = (int)MainCurveMax.Points[p].YValues[0];

                    labelCurveMin.Text = $"Value: {val}";
                }
                else
                {
                    int min = (int)MainCurveMin.Points[p].YValues[0],
                        max = (int)MainCurveMax.Points[p].YValues[0];

                    labelCurveMin.Text = $"Min: {min}";
                    labelCurveMax.Text = $"Max: {max}";
                }
            }
        }

        private int FindNearestPoint(double x)
        {
            var area = chartMainCurve.ChartAreas[0];
            int nearestPoint = -1;
            double nearestDistance = double.MaxValue;

            for (int i = 0; i < 99; ++i)
            {
                var distance = Math.Abs(area.AxisX.ValueToPixelPosition(MainCurveMax.Points[i].XValue) - x);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestPoint = i;
                }
            }
            return nearestPoint;
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
            if (!loading && selectedChar >= 0 && selectedChar < Kernel.AI_BLOCK_COUNT)
            {
                DisplayScript(selectedChar, listBoxCharacterScripts.SelectedIndex);
            }
        }

        private void listBoxCharacterAI_KeyDown(object sender, KeyEventArgs e)
        {
            if (!scriptControlCharacterAI.CodeIsSelected)
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    e.SuppressKeyPress = true;
                    scriptControlCharacterAI.PasteFromClipboard();
                }
            }
        }

        private void scriptControlCharacterAI_DataChanged(object? sender, EventArgs e)
        {
            UpdateCharacterAIScripts(listBoxCharacterAI.SelectedIndex);
            SetUnsaved(true);
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
                kernel.InitialData.Gil = (uint)numericStartingGil.Value;
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
                var mat = DataParser.CopyMateria(kernel.InitialData.Materia[slot]);
                using (var edit = new MateriaAPEditForm(mat, kernel.MateriaData, kernel.GetEnemySkillNames()))
                {
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                        kernel.InitialData.Materia[slot] = mat;
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
                var mat = DataParser.CopyMateria(kernel.InitialData.StolenMateria[slot]);
                using (var edit = new MateriaAPEditForm(mat, kernel.MateriaData, kernel.GetEnemySkillNames()))
                {
                    if (edit.ShowDialog() == DialogResult.OK)
                    {
                        kernel.InitialData.StolenMateria[slot] = mat;
                    }
                }
            }
        }

        #endregion

        #region Materia Controls

        private void comboBoxMateriaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedMateria != null)
            {
                //update materia type
                var newType = (MateriaType)comboBoxMateriaType.SelectedIndex;
                if (!loading)
                {
                    MateriaExt.SetMateriaType(SelectedMateria, newType);
                }

                //update subtypes list
                comboBoxMateriaSubtype.Items.Clear();
                comboBoxMateriaSubtype.Enabled = true;

                //var types = Enum.GetValues<MateriaType>();
                switch (newType)
                {
                    case MateriaType.Independent:
                        foreach (var t in independentMateriaTypes)
                        {
                            if (t == IndependentMateriaTypes.HPtoMP)
                            {
                                comboBoxMateriaSubtype.Items.Add("HP<->MP");
                            }
                            else
                            {
                                var temp = Enum.GetName(t);
                                if (temp == null)
                                {
                                    comboBoxMateriaSubtype.Items.Add("");
                                }
                                else
                                {
                                    comboBoxMateriaSubtype.Items.Add(StringParser.AddSpaces(temp));
                                }
                            }
                        }
                        break;

                    case MateriaType.Support:
                        comboBoxMateriaSubtype.Items.Add("None");
                        comboBoxMateriaSubtype.SelectedIndex = 0;
                        comboBoxMateriaSubtype.Enabled = false;
                        break;

                    case MateriaType.Command:
                        foreach (var t in MateriaExt.COMMAND_TYPES.Values)
                        {
                            comboBoxMateriaSubtype.Items.Add(t);
                        }
                        break;

                    default:
                        comboBoxMateriaSubtype.Items.Add("Normal");
                        comboBoxMateriaSubtype.Items.Add("Master");
                        break;
                }
                if (!loading)
                {
                    UpdateMateriaSubtype(SelectedMateria);
                    SetUnsaved(true);
                }
            }
        }

        private void comboBoxMateriaSubtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedMateria != null)
            {
                int i = comboBoxMateriaSubtype.SelectedIndex;
                switch (Materia.GetMateriaType(SelectedMateria.MateriaTypeByte))
                {
                    case MateriaType.Independent:
                        MateriaExt.SetMateriaSubtype(SelectedMateria, independentMateriaTypes[i]);
                        break;

                    case MateriaType.Support:
                        break;

                    case MateriaType.Command:
                        var temp = MateriaExt.COMMAND_TYPES.ToList();
                        MateriaExt.SetMateriaSubtype(SelectedMateria, temp[i].Key);
                        break;

                    default:
                        MateriaExt.SetMaster(SelectedMateria, i == 1);
                        break;
                }
            }
        }

        private void buttonMateriaAttributes_Click(object sender, EventArgs e)
        {
            if (SelectedMateria != null && MateriaExt.MateriaHasEditableAttribules(SelectedMateria))
            {
                var result = DialogResult.None;
                bool changed = false;
                var type = Materia.GetMateriaType(SelectedMateria.MateriaTypeByte);
                if (type == MateriaType.Magic || type == MateriaType.Summon)
                {
                    using (var aForm = new MateriaSpellsForm(SelectedMateria, kernel.MagicNames.Strings))
                    {
                        result = aForm.ShowDialog();
                        changed = aForm.UnsavedChanges;
                    }
                }
                else if (type == MateriaType.Command)
                {
                    using (var aForm = new MateriaSpellsForm(SelectedMateria, kernel.CommandNames.Strings))
                    {
                        result = aForm.ShowDialog();
                        changed = aForm.UnsavedChanges;
                    }
                }
                else
                {
                    using (var aForm = new MateriaEffectScaleForm(SelectedMateria))
                    {
                        result = aForm.ShowDialog();
                        changed = aForm.UnsavedChanges;
                    }
                }
                if (result == DialogResult.OK)
                {
                    if (changed) { SetUnsaved(true); }
                }
            }
        }

        #endregion

        #region Other Controls

        private void comboBoxItemAttackEffectID_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                var text = comboBoxItemAttackEffectID.Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        if (SelectedItem != null)
                        {
                            SelectedItem.AttackEffectId = newID;
                        }
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
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
                    if (SelectedWeapon != null)
                    {
                        SelectedWeapon.GrowthRate = rate;
                    }

                    //check if currently selected character is using this weapon
                    //and if so, update the growth rate
                    if (SelectedCharacter != null && SelectedCharacter.WeaponID == SelectedWeaponIndex)
                    {
                        materiaSlotSelectorCharacterWeapon.GrowthRate = rate;
                    }
                }
            }
        }

        private void materiaSlotSelectorWeapon_DataChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedWeapon != null)
            {
                var slots = materiaSlotSelectorWeapon.GetSlots();
                for (int i = 0; i < 8; ++i)
                {
                    SelectedWeapon.MateriaSlots[i] = slots[i];
                }

                //check if currently selected character is using this weapon
                //and if so, update the slots
                if (SelectedCharacter != null && SelectedCharacter.WeaponID == SelectedWeaponIndex)
                {
                    materiaSlotSelectorCharacterWeapon.SetSlots(SelectedWeapon);
                }

                SetUnsaved(true);
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

                    //check if currently selected character is using this armor
                    //and if so, update the growth rate
                    if (SelectedCharacter != null && SelectedCharacter.ArmorID == SelectedArmorIndex)
                    {
                        materiaSlotSelectorCharacterArmor.GrowthRate = rate;
                    }
                }
            }
        }

        private void materiaSlotSelectorArmor_DataChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedArmor != null)
            {
                var slots = materiaSlotSelectorArmor.GetSlots();
                for (int i = 0; i < 8; ++i)
                {
                    SelectedArmor.MateriaSlots[i] = slots[i];
                }

                //check if currently selected character is using this armor
                //and if so, update the slots
                if (SelectedCharacter != null && SelectedCharacter.ArmorID == SelectedArmorIndex)
                {
                    materiaSlotSelectorCharacterArmor.SetSlots(SelectedArmor);
                }
                SetUnsaved(true);
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

        private void textBoxLimitName_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = listBoxLimitBreaks.SelectedIndex,
                    j = i + Kernel.ATTACK_COUNT;
                if (j >= Kernel.ATTACK_COUNT && j < kernel.MagicNames.Strings.Length)
                {
                    kernel.MagicNames.Strings[j] = textBoxLimitName.Text;
                    listBoxLimitBreaks.Items[i] = textBoxLimitName.Text;
                    SetUnsaved(true);
                }
            }
        }

        private void textBoxLimitDescription_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = listBoxLimitBreaks.SelectedIndex + Kernel.ATTACK_COUNT;
                if (i >= Kernel.ATTACK_COUNT && i < kernel.MagicNames.Strings.Length)
                {
                    kernel.MagicDescriptions.Strings[i] = textBoxLimitDescription.Text;
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
            DialogResult result;
            string[] paths;
            bool imported = false, syncItemNames = false;

            using (var importDialogue = new OpenFileDialog())
            {
                importDialogue.Filter = "Kernel chunks|kernel.bin.chunk.*";
                importDialogue.Multiselect = true;
                result = importDialogue.ShowDialog();
                paths = importDialogue.FileNames;
            }

            if (result == DialogResult.OK)
            {
                //check if the selected files are valid
                foreach (var path in paths)
                {
                    if (File.Exists(path))
                    {
                        string temp = path.Substring(path.LastIndexOf('.') + 1);
                        int chunk;
                        if (!int.TryParse(temp, out chunk) || chunk < 1 || chunk > Kernel.SECTION_COUNT)
                        {
                            MessageBox.Show($"Invalid file path: {path}", "Invalid File",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else //update form data with new info
                        {
                            if (kernel.ImportChunk((KernelSection)chunk, path))
                            {
                                if (chunk == (int)KernelSection.BattleAndGrowthData)
                                {
                                    UpdateBattleAndGrowthData();
                                }
                                else if (chunk == (int)KernelSection.InitData)
                                {
                                    UpdateInitialData();
                                }
                                else if (chunk == (int)KernelSection.BattleText)
                                {
                                    UpdateBattleText();
                                }
                                else if (chunk == (int)KernelSection.SummonAttackNames)
                                {
                                    int i = SelectedAttackIndex - Kernel.SUMMON_OFFSET;
                                    if (i >= 0 && i < kernel.SummonAttackNames.Strings.Length)
                                    {
                                        attackFormControl.UpdateSummonText(kernel.SummonAttackNames.Strings[i]);
                                    }
                                }
                                else if (chunk < Kernel.KERNEL1_END) //data sections
                                {
                                    PopulateTabWithSelected((KernelSection)chunk);
                                }
                                else if (chunk < Kernel.DESCRIPTIONS_END) //descriptions
                                {
                                    UpdateSelectedDescription((KernelSection)chunk);
                                }
                                else //names
                                {
                                    UpdateNames((KernelSection)chunk);
                                    if (Kernel.SectionIsItems((KernelSection)chunk))
                                    {
                                        syncItemNames = true;
                                    }
                                }
                                imported = true;
                            }
                            else
                            {
                                MessageBox.Show($"An error occurred with chunk {chunk}, and it was not imported.",
                                    "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                if (syncItemNames) { SyncItemNames(); }
                if (imported) { SetUnsaved(true); }
            }
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
                DataManager.CopiedAttack = DataParser.CopyAttack(SelectedAttack);
                attackPasteToolStripMenuItem.Enabled = true;
            }
        }

        private void attackPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedAttackIndex != -1 && DataManager.CopiedAttack != null)
            {
                DataManager.CopiedAttack.Index = SelectedAttackIndex;
                kernel.AttackData.Attacks[SelectedAttackIndex] = DataParser.CopyAttack(DataManager.CopiedAttack);
                SetUnsaved(true);
            }
        }

        private void useKernel2StringsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = DialogResult.Yes;
            if (unsavedChanges) //alert of unsaved data
            {
                result = MessageBox.Show("This action may result in unsaved data being lost. Are you sure?",
                    "Unsaved changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (result == DialogResult.Yes)
            {
                bool flip = !useKernel2StringsToolStripMenuItem.Checked;

                //reload the strings
                var temp = new Kernel(DataManager.KernelPath);
                if (flip)
                {
                    temp.MergeKernel2Data(DataManager.Kernel2Path);
                }

                kernel.CopyAllText(temp);
                ReloadAllText();
                useKernel2StringsToolStripMenuItem.Checked = flip;
                SetUnsaved(true);
            }
        }

        #endregion

        #endregion
    }
}
