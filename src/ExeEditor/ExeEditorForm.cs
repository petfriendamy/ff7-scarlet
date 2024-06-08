using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Media;
using FF7Scarlet.KernelEditor;
using FF7Scarlet.Shared;
using FF7Scarlet.Shared.Controls;

namespace FF7Scarlet.ExeEditor
{
    public partial class ExeEditorForm : Form
    {
        #region Properties

        private const string WINDOW_TITLE = "Scarlet - EXE Editor";
        private ExeData editor;
        private List<StatusChangeType> statusChangeTypes = new();
        private TextBox[] nameTextBoxes;
        private ComboBox[] ShopItemList;
        private bool
            loading = true,
            unsavedChanges = false,
            limitNeedsSync = false;
        private int prevLimit;

        private Character? SelectedCharacter
        {
            get
            {
                if (comboBoxSelectedCharacter.SelectedIndex == 0)
                {
                    return editor.CaitSith;
                }
                else
                {
                    return editor.Vincent;
                }
            }
        }

        private Attack? SelectedLimit
        {
            get
            {
                if (SelectedLimitIndex >= 0 && SelectedLimitIndex < ExeData.NUM_LIMITS)
                {
                    return editor.Limits[SelectedLimitIndex];
                }
                return null;
            }
        }

        private int SelectedLimitIndex
        {
            get { return listBoxLimits.SelectedIndex; }
        }

        #endregion

        #region Constructor

        public ExeEditorForm()
        {
            InitializeComponent();

            editor = new ExeData(DataManager.ExePath);
            int i;

            //get name textboxes as array
            nameTextBoxes =
            [
                textBoxCloud, textBoxBarret, textBoxTifa, textBoxAeris, textBoxRedXIII, textBoxYuffie,
                textBoxCaitSith, textBoxVincent, textBoxCid, textBoxChocobo
            ];

            //get shop comboboxes as array
            ShopItemList =
            [
                comboBoxShopItem1, comboBoxShopItem2, comboBoxShopItem3, comboBoxShopItem4, comboBoxShopItem5,
                comboBoxShopItem6, comboBoxShopItem7, comboBoxShopItem8, comboBoxShopItem9, comboBoxShopItem10
            ];

            //set max values
            numericItemPrice.Maximum = uint.MaxValue;
            numericMateriaPrice.Maximum = uint.MaxValue;
            textBoxMainMenuText.MaxLength = ExeData.MENU_TEXT_LENGTH - 1;
            textBoxConfigMenuText.MaxLength = editor.GetConfigTextLength() - 1;
            textBoxStatusEffectText.MaxLength = editor.GetStatusEffectLength() - 1;
            textBoxL4Success.MaxLength = editor.GetLimitTextLength() - 1;
            textBoxL4Fail.MaxLength = editor.GetLimitTextLength() - 1;
            textBoxL4Wrong.MaxLength = editor.GetLimitTextLength() - 1;
            textBoxShopNameText.MaxLength = editor.GetShopNameLength() - 1;
            textBoxShopText.MaxLength = ExeData.SHOP_TEXT_LENGTH - 1;

            //add limit breaks
            listBoxLimits.BeginUpdate();
            for (i = 0; i < ExeData.NUM_LIMITS; ++i)
            {
                string name = $"(Limit break #{i + 1})";
                if (DataManager.BothKernelFilePathsExist && DataManager.Kernel != null)
                {
                    name = DataManager.Kernel.MagicNames.Strings[i + Kernel.ATTACK_COUNT];
                }
                listBoxLimits.Items.Add(name);
            }
            listBoxLimits.EndUpdate();

            //populate comboboxes
            SuspendOrResumeComboBoxes(tabControlMain, false);

            //character flags
            foreach (var f in Enum.GetNames<CharacterFlags>())
            {
                comboBoxCharacterFlags.Items.Add(f);
            }

            //limit status change
            comboBoxLimitStatusChange.Items.Add("None");
            foreach (var s in Enum.GetValues<StatusChangeType>())
            {
                if (s != StatusChangeType.None)
                {
                    comboBoxLimitStatusChange.Items.Add(s);
                    statusChangeTypes.Add(s);
                }
            }

            //limit condition submenu
            comboBoxLimitConditionSubMenu.Items.Add("None");
            foreach (var c in Enum.GetValues<AttackConditions>())
            {
                if (c != AttackConditions.None)
                {
                    comboBoxLimitConditionSubMenu.Items.Add(c);
                }
            }

            //add shop data
            for (i = 0; i < ExeData.NUM_SHOPS; ++i)
            {
                if (ShopData.SHOP_NAMES.ContainsKey(i))
                {
                    comboBoxShopIndex.Items.Add(ShopData.SHOP_NAMES[i]);
                }
                else
                {
                    comboBoxShopIndex.Items.Add($"[Shop ID {i}]");
                }
            }

            //kernel-synced data
            if (DataManager.Kernel != null)
            {
                //set materia slot selectors to equips
                materiaSlotSelectorCharacterWeapon.SlotSelectorType = SlotSelectorType.Materia;
                materiaSlotSelectorCharacterArmor.SlotSelectorType = SlotSelectorType.Materia;

                //items
                foreach (var item in DataManager.Kernel.ItemData.Items)
                {
                    foreach (var InventoryItem in ShopItemList)
                    {
                        InventoryItem.Items.Add(item.Name);
                        InventoryItem.SelectedIndex = 0;
                    }
                }

                //weapons
                foreach (var weapon in DataManager.Kernel.WeaponData.Weapons)
                {
                    comboBoxCharacterWeapon.Items.Add(weapon.Name);
                    foreach (var InventoryItem in ShopItemList)
                    {
                        InventoryItem.Items.Add(weapon.Name);
                    }
                }

                //armors
                foreach (var armor in DataManager.Kernel.ArmorData.Armors)
                {
                    comboBoxCharacterArmor.Items.Add(armor.Name);
                    foreach (var InventoryItem in ShopItemList)
                    {
                        InventoryItem.Items.Add(armor.Name);
                    }
                }

                //accessories
                comboBoxCharacterAccessory.Items.Add("None");
                foreach (var accessory in DataManager.Kernel.AccessoryData.Accessories)
                {
                    comboBoxCharacterAccessory.Items.Add(accessory.Name);
                    foreach (var InventoryItem in ShopItemList)
                    {
                        InventoryItem.Items.Add(accessory.Name);
                    }
                }

                //materia
                foreach (var materia in DataManager.Kernel.MateriaExt)
                {
                    //check if name is empty
                    string name = materia.Name;
                    if (string.IsNullOrEmpty(name))
                    {
                        name = $"(Materia ID {materia.Index})";
                    }

                    foreach (var InventoryItem in ShopItemList)
                    {
                        InventoryItem.Items.Add(name);
                    }
                }
            }
            else //no kernel loaded
            {
                //arrangedMateriaList = Array.Empty<Materia>().AsReadOnly();
                //arrangedAccessoryList = Array.Empty<Accessory>().AsReadOnly();
                groupBoxCharacterWeapon.Enabled = false;
                groupBoxCharacterArmor.Enabled = false;
                comboBoxCharacterAccessory.Enabled = false;
                foreach (Control c in tabPageShopData.Controls)
                {
                    c.Enabled = false;
                }
            }

            //resume combo boxes
            SuspendOrResumeComboBoxes(tabControlMain, true);

            UpdateFormData();
            loading = false;

            //select character
            comboBoxSelectedCharacter.SelectedIndex = 0;
            comboBoxL4Char.SelectedIndex = 0;

            //select shop
            if (DataManager.Kernel != null)
            {
                comboBoxShopIndex.SelectedIndex = 0;
            }
        }

        #endregion

        #region User Methods

        private void SetUnsaved(bool unsaved)
        {
            unsavedChanges = unsaved;
            Text = $"{(unsaved ? "*" : "")}{WINDOW_TITLE}";
        }

        //sync controls with EXE data
        private void UpdateFormData()
        {
            if (editor == null) { throw new ArgumentNullException(nameof(editor)); }
            loading = true;
            int i;

            //suspend layouts
            SuspendOrResumeExeTextListBoxes(false);
            listBoxItemPrices.SuspendLayout();
            listBoxMateriaPrices.SuspendLayout();
            comboBoxShopType.SuspendLayout();

            //clear items
            int shopType = comboBoxShopType.SelectedIndex;
            if (shopType < 0) { shopType = 0; }
            comboBoxShopType.Items.Clear();
            listBoxMainMenu.Items.Clear();
            listBoxConfigMenu.Items.Clear();
            listBoxStatusEffects.Items.Clear();
            listBoxItemPrices.Items.Clear();
            listBoxMateriaPrices.Items.Clear();
            listBoxShopNames.Items.Clear();
            listBoxShopText.Items.Clear();

            //set AP price multiplier
            numericMateriaAPPriceMultiplier.Value = editor.APPriceMultiplier;

            //set character names
            for (i = 0; i < 10; ++i)
            {
                nameTextBoxes[i].Text = editor.CharacterNames[i].ToString();
            }

            //set main menu text
            for (i = 0; i < ExeData.NUM_MENU_TEXTS; ++i)
            {
                listBoxMainMenu.Items.Add(editor.MainMenuTexts[i].ToString());
            }

            //set config menu text
            for (i = 0; i < ExeData.NUM_CONFIG_TEXTS; ++i)
            {
                listBoxConfigMenu.Items.Add(editor.ConfigMenuTexts[i].ToString());
            }

            //set status effects
            for (i = 0; i < ExeData.NUM_STATUS_EFFECTS; ++i)
            {
                listBoxStatusEffects.Items.Add(editor.StatusEffects[i].ToString());
            }

            //set item prices
            if (DataManager.KernelFilePathExists && DataManager.Kernel != null)
            {
                for (i = 0; i < InventoryItem.ITEM_COUNT; ++i)
                {
                    var name = DataManager.Kernel.ItemData.Items[i].Name;
                    if (string.IsNullOrEmpty(name))
                    {
                        name = $"(Item ID {i})";
                    }
                    listBoxItemPrices.Items.Add($"{name} - {editor.ItemPrices[i]}");
                }
                for (i = 0; i < InventoryItem.WEAPON_COUNT; ++i)
                {
                    var name = DataManager.Kernel.WeaponData.Weapons[i].Name;
                    if (string.IsNullOrEmpty(name))
                    {
                        name = $"(Weapon ID {i})";
                    }
                    listBoxItemPrices.Items.Add($"{name} - {editor.WeaponPrices[i]}");
                }
                for (i = 0; i < InventoryItem.ARMOR_COUNT; ++i)
                {
                    var name = DataManager.Kernel.ArmorData.Armors[i].Name;
                    if (string.IsNullOrEmpty(name))
                    {
                        name = $"(Armor ID {i})";
                    }
                    listBoxItemPrices.Items.Add($"{name} - {editor.ArmorPrices[i]}");
                }
                for (i = 0; i < InventoryItem.ACCESSORY_COUNT; ++i)
                {
                    var name = DataManager.Kernel.AccessoryData.Accessories[i].Name;
                    if (string.IsNullOrEmpty(name))
                    {
                        name = $"(Accessory ID {i})";
                    }
                    listBoxItemPrices.Items.Add($"{name} - {editor.AccessoryPrices[i]}");
                }

                //set materia prices
                for (i = 0; i < DataManager.Kernel.MateriaExt.Length; ++i)
                {
                    var name = DataManager.Kernel.MateriaExt[i].Name;
                    if (string.IsNullOrEmpty(name))
                    {
                        name = $"(Materia ID {i})";
                    }
                    listBoxMateriaPrices.Items.Add($"{name} - {editor.MateriaPrices[i]}");
                }
            }

            //set shop names
            foreach (var s in editor.ShopNames)
            {
                comboBoxShopType.Items.Add(s.ToString());
                listBoxShopNames.Items.Add(s.ToString());
            }
            comboBoxShopType.SelectedIndex = shopType;

            //set shop text
            foreach (var s in editor.ShopText)
            {
                listBoxShopText.Items.Add(s.ToString());
            }

            //set L4 text
            SetLimitText();

            //resume layouts
            SuspendOrResumeExeTextListBoxes(true);
            listBoxItemPrices.ResumeLayout();
            listBoxMateriaPrices.ResumeLayout();
            comboBoxShopType.ResumeLayout();
            loading = false;
        }

        //suspend comboboxes so we can add stuff to them (or resume when done)
        private void SuspendOrResumeComboBoxes(Control control, bool resume)
        {
            if (control is TabControl)
            {
                var tc = control as TabControl;
                if (tc != null)
                {
                    for (int i = 0; i < tc.TabCount; ++i)
                    {
                        SuspendOrResumeComboBoxes(tc.TabPages[i], resume);
                    }
                }
            }
            else if (control is GroupBox)
            {
                for (int i = 0; i < control.Controls.Count; ++i)
                {
                    SuspendOrResumeComboBoxes(control.Controls[i], resume);
                }
            }
            else if (control is ComboBox)
            {
                var cb = control as ComboBox;
                if (resume) { cb?.ResumeLayout(); }
                else { cb?.SuspendLayout(); }
            }
        }

        private void SuspendOrResumeExeTextListBoxes(bool resume)
        {
            foreach (TabPage t in tabControlOtherText.TabPages)
            {
                foreach (Control c in t.Controls)
                {
                    if (c is ListBox)
                    {
                        if (resume) { c.ResumeLayout(); }
                        else { c.SuspendLayout(); }
                    }
                }
            }
        }
        private void SyncLimitData(Attack limit)
        {
            limit.AccuracyRate = (byte)numericLimitAttackPercent.Value;
            limit.MPCost = (ushort)numericLimitMPCost.Value;
            limit.TargetFlags = targetDataControlLimit.GetTargetData();
            limit.DamageCalculationID = damageCalculationControlLimit.ActualValue;
            limit.AttackStrength = damageCalculationControlLimit.AttackPower;
            if (comboBoxLimitConditionSubMenu.SelectedIndex == 0)
            {
                limit.AttackConditions = AttackConditions.None;
            }
            else
            {
                limit.AttackConditions = (AttackConditions)(comboBoxLimitConditionSubMenu.SelectedIndex - 1);
            }
            limit.StatusEffects = statusesControlLimit.GetStatuses();
            limit.Elements = elementsControlLimit.GetElements();
            limit.SpecialAttackFlags = specialAttackFlagsControlLimit.GetFlags();

            limitNeedsSync = false;
        }

        //update a character's name
        private void ChangeName(TextBox textBox, int charID)
        {
            if (editor == null) { throw new ArgumentNullException(nameof(editor)); }
            if (!loading)
            {
                try
                {
                    editor.CharacterNames[charID] = new FFText(textBox.Text);
                    SetUnsaved(true);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loading = true;
                    textBox.Text = editor.CharacterNames[charID].ToString();
                    loading = false;
                }
            }
        }

        private int GetItemIndex(InventoryItem item)
        {
            if (DataManager.Kernel != null)
            {
                if (item.Type == ItemType.Materia)
                {
                    var mat = DataManager.Kernel.GetMateriaByID(item.Index);
                    if (mat != null)
                    {
                        return mat.Index + InventoryItem.MATERIA_START;
                    }
                }
                else
                {
                    return item.GetCombinedIndex();
                }
            }
            return 0;
        }

        private InventoryItem GetShopItem(int index)
        {
            if (DataManager.Kernel == null)
            {
                throw new ArgumentNullException(nameof(DataManager.Kernel));
            }

            if (index <= InventoryItem.MAX_INDEX)
            {
                return new InventoryItem((ushort)index);
            }
            else
            {
                return new InventoryItem(DataManager.Kernel.MateriaExt[index - InventoryItem.MAX_INDEX - 1]);
            }
        }

        private void SetLimitText()
        {
            bool wasAlreadyLoading = loading;
            loading = true;
            int i = comboBoxL4Char.SelectedIndex;
            if (i >= 0 && i < Character.PLAYABLE_CHARACTER_COUNT)
            {
                //set character portrait
                switch (i)
                {
                    case 0:
                        pictureBoxL4Char.Image = Properties.Resources.Cloud;
                        break;
                    case 1:
                        pictureBoxL4Char.Image = Properties.Resources.Barret;
                        break;
                    case 2:
                        pictureBoxL4Char.Image = Properties.Resources.Tifa;
                        break;
                    case 3:
                        pictureBoxL4Char.Image = Properties.Resources.Aeris;
                        break;
                    case 4:
                        pictureBoxL4Char.Image = Properties.Resources.RedXIII;
                        break;
                    case 5:
                        pictureBoxL4Char.Image = Properties.Resources.Yuffie;
                        break;
                    case 6:
                        pictureBoxL4Char.Image = Properties.Resources.Vincent;
                        break;
                    case 7:
                        pictureBoxL4Char.Image = Properties.Resources.Cid;
                        break;
                    case 8:
                        pictureBoxL4Char.Image = Properties.Resources.CaitSith;
                        break;
                }

                //set text
                textBoxL4Success.Enabled = textBoxL4Fail.Enabled =
                    i < Character.PLAYABLE_CHARACTER_COUNT - 1;

                //disable success and fail for Cait Sith
                if (i == Character.PLAYABLE_CHARACTER_COUNT - 1)
                {
                    textBoxL4Success.Clear();
                    textBoxL4Fail.Clear();
                }
                else
                {
                    textBoxL4Success.Text = editor.LimitSuccess[i].ToString();
                    textBoxL4Fail.Text = editor.LimitFail[i].ToString();
                }
                textBoxL4Wrong.Text = editor.LimitWrong[i].ToString();
            }
            if (!wasAlreadyLoading) { loading = false; }
        }

        #endregion

        #region Event Methods

        //populate controls with character data
        private void comboBoxSelectedCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBoxSelectedCharacter.SelectedIndex;
            if (!loading && i >= 0 && i < 2)
            {
                loading = true;
                Character? character;
                if (i == 0) { character = editor.CaitSith; }
                else { character = editor.Vincent; }

                if (character != null)
                {
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
                    characterStatsControl.SetStatsFromCharacter(character);

                    //check if kernel is loaded
                    if (DataManager.Kernel != null)
                    {
                        var wpn = DataManager.Kernel.GetWeaponByID(character.WeaponID);
                        if (wpn != null)
                        {
                            comboBoxCharacterWeapon.SelectedIndex = character.WeaponID;
                            materiaSlotSelectorCharacterWeapon.SetSlots(wpn);
                            for (int j = 0; j < 8; ++j)
                            {
                                var mat = DataManager.Kernel.GetMateriaByID(character.WeaponMateria[j].Index);
                                materiaSlotSelectorCharacterWeapon.SetMateria(j, mat);
                                materiaSlotSelectorCharacterWeapon.SelectedSlot = -1;
                            }
                        }
                        var armor = DataManager.Kernel.GetArmorByID(character.ArmorID);
                        if (armor != null)
                        {
                            comboBoxCharacterArmor.SelectedIndex = character.ArmorID;
                            materiaSlotSelectorCharacterArmor.SetSlots(armor);
                            for (int j = 0; j < 8; ++j)
                            {
                                var mat = DataManager.Kernel.GetMateriaByID(character.ArmorMateria[j].Index);
                                materiaSlotSelectorCharacterArmor.SetMateria(j, mat);
                                materiaSlotSelectorCharacterArmor.SelectedSlot = -1;
                            }
                        }
                        var acc = DataManager.Kernel.GetAccessoryByID(character.AccessoryID);
                        if (acc == null)
                        {
                            comboBoxCharacterAccessory.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBoxCharacterAccessory.SelectedIndex = character.AccessoryID + 1;
                        }
                    }
                }
                loading = false;
            }
        }

        private void numericCharacterID_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.ID = (byte)numericCharacterID.Value;
                SetUnsaved(true);
            }
        }

        private void textBoxCharacterName_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.Name = new FFText(textBoxCharacterName.Text);
                SetUnsaved(true);
            }
        }

        private void numericCharacterLevel_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.Level = (byte)numericCharacterLevel.Value;
                SetUnsaved(true);
            }
        }

        private void numericCharacterCurrentEXP_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.CurrentEXP = (uint)numericCharacterCurrentEXP.Value;
                SetUnsaved(true);
            }
        }

        private void numericCharacterEXPtoNext_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.EXPtoNextLevel = (uint)numericCharacterEXPtoNext.Value;
                SetUnsaved(true);
            }
        }

        private void characterStatsControl_CharacterStatsChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                characterStatsControl.CopyStatsToCharacter(SelectedCharacter);
                SetUnsaved(true);
            }
        }

        private void numericCharacterCurrHP_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.CurrentHP = (ushort)numericCharacterCurrHP.Value;
                SetUnsaved(true);
            }
        }

        private void numericCharacterBaseHP_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.BaseHP = (ushort)numericCharacterBaseHP.Value;
                SetUnsaved(true);
            }
        }

        private void numericCharacterMaxHP_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.MaxHP = (ushort)numericCharacterMaxHP.Value;
                SetUnsaved(true);
            }
        }

        private void numericCharacterCurrMP_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.CurrentMP = (ushort)numericCharacterCurrMP.Value;
                SetUnsaved(true);
            }
        }

        private void numericCharacterBaseMP_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.BaseMP = (ushort)numericCharacterBaseMP.Value;
                SetUnsaved(true);
            }
        }

        private void numericCharacterMaxMP_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.MaxMP = (ushort)numericCharacterMaxMP.Value;
                SetUnsaved(true);
            }
        }

        private void comboBoxCharacterWeapon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null && DataManager.Kernel != null)
            {
                var wpn = DataManager.Kernel.WeaponData.Weapons[comboBoxCharacterWeapon.SelectedIndex];
                SelectedCharacter.WeaponID = (byte)wpn.Index;
                SetUnsaved(true);
            }
        }

        private void comboBoxCharacterArmor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null && DataManager.Kernel != null)
            {
                var armor = DataManager.Kernel.ArmorData.Armors[comboBoxCharacterArmor.SelectedIndex];
                SelectedCharacter.ArmorID = (byte)armor.Index;
                SetUnsaved(true);
            }
        }

        private void comboBoxCharacterAccessory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null && DataManager.Kernel != null)
            {
                int i = comboBoxCharacterAccessory.SelectedIndex;
                if (i == 0)
                {
                    SelectedCharacter.AccessoryID = 0xFF;
                }
                else
                {
                    var acc = DataManager.Kernel.AccessoryData.Accessories[i - 1];
                    SelectedCharacter.AccessoryID = (byte)acc.Index;
                }
                SetUnsaved(true);
            }
        }

        private void materiaSlotSelectorCharacter_MultiLinkEnabled(object sender, EventArgs e)
        {
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
            if (SelectedCharacter != null && DataManager.Kernel != null)
            {
                int slot = materiaSlotSelectorCharacterWeapon.SelectedSlot;
                if (slot != -1)
                {
                    var mat = SelectedCharacter.WeaponMateria[slot].Copy();
                    using (var edit = new MateriaAPEditForm(mat, DataManager.Kernel.MateriaData))
                    {
                        if (edit.ShowDialog() == DialogResult.OK)
                        {
                            SelectedCharacter.WeaponMateria[slot] = mat;
                            materiaSlotSelectorCharacterWeapon.SetMateria(slot, mat, DataManager.Kernel);
                            SetUnsaved(true);
                        }
                    }
                }
            }
        }

        private void buttonCharacterArmorChangeMateria_Click(object sender, EventArgs e)
        {
            if (SelectedCharacter != null && DataManager.Kernel != null)
            {
                int slot = materiaSlotSelectorCharacterArmor.SelectedSlot;
                if (slot != -1)
                {
                    var mat = SelectedCharacter.ArmorMateria[slot].Copy();
                    using (var edit = new MateriaAPEditForm(mat, DataManager.Kernel.MateriaData))
                    {
                        if (edit.ShowDialog() == DialogResult.OK)
                        {
                            SelectedCharacter.ArmorMateria[slot] = mat;
                            materiaSlotSelectorCharacterArmor.SetMateria(slot, mat, DataManager.Kernel);
                            SetUnsaved(true);
                        }
                    }
                }
            }
        }

        private void comboBoxCharacterFlags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                var flags = Enum.GetValues<CharacterFlags>();
                SelectedCharacter.CharacterFlags = flags[comboBoxCharacterFlags.SelectedIndex];
                SetUnsaved(true);
            }
        }

        private void checkBoxCharacterBackRow_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.IsBackRow = checkBoxCharacterBackRow.Checked;
                SetUnsaved(true);
            }
        }

        private void numericCharacterKillCount_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedCharacter != null)
            {
                SelectedCharacter.KillCount = (ushort)numericCharacterKillCount.Value;
                SetUnsaved(true);
            }
        }

        //populate controls with limit data
        private void listBoxLimits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                if (limitNeedsSync) //sync unsaved limit data
                {
                    var limit = editor.Limits[prevLimit];
                    if (limit != null)
                    {
                        SyncLimitData(limit);
                    }
                }

                int i = SelectedLimitIndex;

                if (i >= 0 && i < ExeData.NUM_LIMITS)
                {
                    var attack = editor.Limits[i];
                    tabControlLimits.Enabled = true;

                    //page 1
                    numericLimitAttackPercent.Value = attack.AccuracyRate;
                    numericLimitMPCost.Value = attack.MPCost;
                    comboBoxLimitAttackEffectID.Text = attack.AttackEffectID.ToString("X2");
                    comboBoxLimitImpactEffectID.Text = attack.ImpactEffectID.ToString("X2");
                    elementsControlLimit.SetElements(attack.Elements);
                    comboBoxLimitCamMovementIDSingle.Text = attack.CameraMovementIDSingle.ToString("X4");
                    comboBoxLimitCamMovementIDMulti.Text = attack.CameraMovementIDMulti.ToString("X4");
                    comboBoxLimitHurtActionIndex.Text = attack.TargetHurtActionIndex.ToString("X2");
                    damageCalculationControlLimit.AttackPower = attack.AttackStrength;
                    damageCalculationControlLimit.ActualValue = attack.DamageCalculationID;

                    //page 2
                    specialAttackFlagsControlLimit.SetFlags(attack.SpecialAttackFlags);
                    statusesControlLimit.SetStatuses(attack.StatusEffects);
                    if (attack.AttackConditions == AttackConditions.None)
                    {
                        comboBoxLimitConditionSubMenu.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBoxLimitConditionSubMenu.SelectedIndex = (int)attack.AttackConditions + 1;
                    }
                    numericLimitStatusChangeChance.Value = attack.StatusChange.Amount;
                    if (attack.StatusChange.Type == StatusChangeType.None)
                    {
                        comboBoxLimitStatusChange.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBoxLimitStatusChange.SelectedIndex = statusChangeTypes.IndexOf(attack.StatusChange.Type) + 1;
                    }

                    //page 3
                    targetDataControlLimit.SetTargetData(attack.TargetFlags);
                }
                prevLimit = i;
                loading = false;
            }
        }

        //limit data changed
        private void LimitDataChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                limitNeedsSync = true;
                SetUnsaved(true);
            }
        }

        private void comboBoxLimitAttackEffectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedLimit != null)
            {
                var text = comboBoxLimitAttackEffectID.Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedLimit.AttackEffectID = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxLimitImpactEffectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedLimit != null)
            {
                var text = comboBoxLimitImpactEffectID.Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedLimit.ImpactEffectID = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxLimitCamMovementIDSingle_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedLimit != null)
            {
                var text = comboBoxLimitCamMovementIDSingle.Text;
                if (text.Length == 4)
                {
                    ushort newID;
                    if (ushort.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedLimit.CameraMovementIDSingle = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxLimitCamMovementIDMulti_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedLimit != null)
            {
                var text = comboBoxLimitCamMovementIDMulti.Text;
                if (text.Length == 4)
                {
                    ushort newID;
                    if (ushort.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedLimit.CameraMovementIDMulti = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxLimitHurtActionIndex_TextChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedLimit != null)
            {
                var text = comboBoxLimitHurtActionIndex.Text;
                if (text.Length == 2)
                {
                    byte newID;
                    if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                    {
                        SelectedLimit.TargetHurtActionIndex = newID;
                        SetUnsaved(true);
                    }
                    else { SystemSounds.Exclamation.Play(); }
                }
            }
        }

        private void comboBoxLimitStatusChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBoxLimitStatusChange.SelectedIndex;
            numericLimitStatusChangeChance.Enabled = (i > 0);
            statusesControlLimit.Enabled = (i > 0);
            if (!loading && SelectedLimit != null)
            {
                if (i == 0)
                {
                    SelectedLimit.StatusChange.Type = StatusChangeType.None;
                }
                else
                {
                    SelectedLimit.StatusChange.Type = statusChangeTypes[i - 1];
                }
                SetUnsaved(true);
            }
        }

        private void numericLimitStatusChangeChance_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && SelectedLimit != null)
            {
                SelectedLimit.StatusChange.Amount = (byte)numericLimitStatusChangeChance.Value;
                SetUnsaved(true);
            }
        }

        //update character names
        private void textBoxCloud_TextChanged(object sender, EventArgs e)
        {
            ChangeName(textBoxCloud, 0);
        }

        private void textBoxBarret_TextChanged(object sender, EventArgs e)
        {
            ChangeName(textBoxBarret, 1);
        }

        private void textBoxTifa_TextChanged(object sender, EventArgs e)
        {
            ChangeName(textBoxTifa, 2);
        }

        private void textBoxAeris_TextChanged(object sender, EventArgs e)
        {
            ChangeName(textBoxAeris, 3);
        }

        private void textBoxRedXIII_TextChanged(object sender, EventArgs e)
        {
            ChangeName(textBoxRedXIII, 4);
        }

        private void textBoxYuffie_TextChanged(object sender, EventArgs e)
        {
            ChangeName(textBoxYuffie, 5);
        }

        private void textBoxCaitSith_TextChanged(object sender, EventArgs e)
        {
            ChangeName(textBoxCaitSith, 6);
        }

        private void textBoxVincent_TextChanged(object sender, EventArgs e)
        {
            ChangeName(textBoxVincent, 7);
        }

        private void textBoxCid_TextChanged(object sender, EventArgs e)
        {
            ChangeName(textBoxCid, 8);
        }

        private void textBoxChocobo_TextChanged(object sender, EventArgs e)
        {
            ChangeName(textBoxChocobo, 9);
        }

        private void listBoxItemPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxItemPrices.SelectedIndex;
            if (i != -1 && editor != null)
            {
                loading = true;
                numericItemPrice.Enabled = true;
                var item = GetShopItem(i);
                if (item.Type == ItemType.Weapon)
                {
                    numericItemPrice.Value = editor.WeaponPrices[item.Index];
                }
                else if (item.Type == ItemType.Armor)
                {
                    numericItemPrice.Value = editor.ArmorPrices[item.Index];
                }
                else if (item.Type == ItemType.Accessory)
                {
                    numericItemPrice.Value = editor.AccessoryPrices[item.Index];
                }
                else
                {
                    numericItemPrice.Value = editor.ItemPrices[i];
                }
                loading = false;
            }
        }

        private void numericItemPrice_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && editor != null && DataManager.Kernel != null)
            {
                int i = listBoxItemPrices.SelectedIndex;
                var item = GetShopItem(i);
                if (item.Type == ItemType.Weapon)
                {
                    editor.WeaponPrices[item.Index] = (uint)numericItemPrice.Value;
                    listBoxItemPrices.Items[i] = $"{DataManager.Kernel.GetInventoryItemName(item)} - {editor.WeaponPrices[item.Index]}";
                }
                else if (item.Type == ItemType.Armor)
                {
                    editor.ArmorPrices[item.Index] = (uint)numericItemPrice.Value;
                    listBoxItemPrices.Items[i] = $"{DataManager.Kernel.GetInventoryItemName(item)} - {editor.ArmorPrices[item.Index]}";
                }
                else if (item.Type == ItemType.Accessory)
                {
                    editor.AccessoryPrices[item.Index] = (uint)numericItemPrice.Value;
                    listBoxItemPrices.Items[i] = $"{DataManager.Kernel.GetInventoryItemName(item)} - {editor.AccessoryPrices[item.Index]}";
                }
                else
                {
                    editor.ItemPrices[i] = (uint)numericItemPrice.Value;
                    listBoxItemPrices.Items[i] = $"{DataManager.Kernel.GetInventoryItemName(item)} - {editor.ItemPrices[i]}";
                }
                SetUnsaved(true);
            }
        }

        private void listBoxMateriaPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxMateriaPrices.SelectedIndex;
            if (i != -1 && editor != null && DataManager.Kernel != null)
            {
                loading = true;
                numericMateriaPrice.Enabled = true;
                numericMateriaPrice.Value = editor.MateriaPrices[i];
                loading = false;
            }
        }

        private void numericMateriaPrice_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && editor != null && DataManager.Kernel != null)
            {
                int i = listBoxMateriaPrices.SelectedIndex;
                editor.MateriaPrices[i] = (uint)numericMateriaPrice.Value;
                listBoxMateriaPrices.Items[i] = $"{DataManager.Kernel.MateriaExt[i].Name} - {editor.MateriaPrices[i]}";
                SetUnsaved(true);
            }
        }

        //select shop
        private void comboBoxShopIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBoxShopIndex.SelectedIndex;
            if (i != -1 && editor != null)
            {
                loading = true;
                comboBoxShopType.SelectedIndex = (int)editor.Shops[i].ShopType;
                numericShopItemCount.Value = editor.Shops[i].ItemCount;

                for (int j = 0; j < ShopInventory.SHOP_ITEM_MAX; ++j)
                {
                    if (j < editor.Shops[i].ItemCount)
                    {
                        var item = editor.Shops[i].Inventory[j];
                        if (item != null)
                        {
                            ShopItemList[j].Enabled = true;
                            ShopItemList[j].SelectedIndex = GetItemIndex(item);
                        }
                        else
                        {
                            ShopItemList[j].Enabled = false;
                        }
                    }
                    else
                    {
                        ShopItemList[j].Enabled = false;
                    }
                }
                loading = false;
            }
        }

        //change shop item count
        private void numericShopItemCount_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && editor != null)
            {
                //enable/disable comboboxes
                for (int i = 0; i < ShopInventory.SHOP_ITEM_MAX; ++i)
                {
                    ShopItemList[i].Enabled = i < numericShopItemCount.Value;
                }

                //change shop inventory
                var shop = editor.Shops[comboBoxShopIndex.SelectedIndex];
                if (numericShopItemCount.Value > shop.ItemCount)
                {
                    var item = GetShopItem(ShopItemList[shop.ItemCount].SelectedIndex);
                    shop.AddItem(item);
                }
                else
                {
                    shop.RemoveItem();
                }
                SetUnsaved(true);
            }
        }

        //change shop item
        private void comboBoxShopItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading && editor != null)
            {
                for (int i = 0; i < ShopInventory.SHOP_ITEM_MAX; ++i)
                {
                    if (sender == ShopItemList[i]) //check which combobox sent the command
                    {
                        var shop = editor.Shops[comboBoxShopIndex.SelectedIndex];
                        var item = GetShopItem(ShopItemList[i].SelectedIndex);
                        shop.Inventory[i] = item;
                        SetUnsaved(true);
                        break;
                    }
                }
            }
        }

        private void listBoxMainMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxMainMenu.SelectedIndex;
                if (i >= 0 && i < ExeData.NUM_MENU_TEXTS)
                {
                    textBoxMainMenuText.Enabled = true;
                    textBoxMainMenuText.Text = editor.MainMenuTexts[i].ToString();
                }
                loading = false;
            }
        }

        private void listBoxConfigMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxConfigMenu.SelectedIndex;
                if (i >= 0 && i < ExeData.NUM_CONFIG_TEXTS)
                {
                    textBoxConfigMenuText.Enabled = true;
                    textBoxConfigMenuText.Text = editor.ConfigMenuTexts[i].ToString();
                }
                loading = false;
            }
        }

        private void listBoxStatusEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxStatusEffects.SelectedIndex;
                if (i >= 0 && i < ExeData.NUM_STATUS_EFFECTS)
                {
                    textBoxStatusEffectText.Enabled = true;
                    textBoxStatusEffectText.Text = editor.StatusEffects[i].ToString();
                }
                loading = false;
            }
        }

        private void comboBoxL4Char_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLimitText();
        }

        private void listBoxShopNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxShopNames.SelectedIndex;
                if (i >= 0 && i < ExeData.NUM_SHOP_NAMES)
                {
                    textBoxShopNameText.Enabled = true;
                    textBoxShopNameText.Text = editor.ShopNames[i].ToString();
                }
                loading = false;
            }
        }

        private void listBoxShopText_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxShopText.SelectedIndex;
                if (i >= 0 && i < ExeData.NUM_SHOP_TEXTS)
                {
                    textBoxShopText.Enabled = true;
                    textBoxShopText.Text = editor.ShopText[i].ToString();
                }
                loading = false;
            }
        }

        private void textBoxMainMenuText_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxMainMenu.SelectedIndex;
                editor.MainMenuTexts[i] = new FFText(textBoxMainMenuText.Text);
                listBoxMainMenu.Items[i] = textBoxMainMenuText.Text;
                SetUnsaved(true);
                loading = false;
            }
        }

        private void textBoxConfigMenuText_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxConfigMenu.SelectedIndex;
                editor.ConfigMenuTexts[i] = new FFText(textBoxConfigMenuText.Text);
                listBoxConfigMenu.Items[i] = textBoxConfigMenuText.Text;
                SetUnsaved(true);
                loading = false;
            }
        }

        private void textBoxStatusEffectText_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxStatusEffects.SelectedIndex;
                editor.StatusEffects[i] = new FFText(textBoxStatusEffectText.Text);
                listBoxStatusEffects.Items[i] = textBoxStatusEffectText.Text;
                SetUnsaved(true);
                loading = false;
            }
        }

        private void textBoxL4Success_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = comboBoxL4Char.SelectedIndex;
                editor.LimitSuccess[i] = new FFText(textBoxL4Success.Text);
                SetUnsaved(true);
            }
        }

        private void textBoxL4Fail_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = comboBoxL4Char.SelectedIndex;
                editor.LimitFail[i] = new FFText(textBoxL4Fail.Text);
                SetUnsaved(true);
            }
        }

        private void textBoxL4Wrong_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                int i = comboBoxL4Char.SelectedIndex;
                editor.LimitWrong[i] = new FFText(textBoxL4Wrong.Text);
                SetUnsaved(true);
            }
        }

        private void textBoxShopNameText_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxShopNames.SelectedIndex;
                editor.ShopNames[i] = new FFText(textBoxShopNameText.Text);
                listBoxShopNames.Items[i] = textBoxShopNameText.Text;
                comboBoxShopType.Items[i] = textBoxShopNameText.Text;
                SetUnsaved(true);
                loading = false;
            }
        }

        private void textBoxShopText_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxShopText.SelectedIndex;
                editor.ShopText[i] = new FFText(textBoxShopText.Text);
                listBoxShopText.Items[i] = textBoxShopText.Text;
                SetUnsaved(true);
                loading = false;
            }
        }

        //load data from a file
        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            if (editor == null) { throw new ArgumentNullException(nameof(editor)); }

            DialogResult result;
            string path;
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "DAT file|*.dat";
                result = openDialog.ShowDialog();
                path = openDialog.FileName;
            }

            if (result == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        try
                        {
                            editor.ReadFile(path);
                        }
                        catch (EndOfStreamException ex)
                        {
                            MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        UpdateFormData();
                        SetUnsaved(true);
                    }
                    else
                    {
                        MessageBox.Show($"File could not be found.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"{ex.Message} ({ex.InnerException?.Message})", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //save data to a file
        private void buttonSaveFile_Click(object sender, EventArgs e)
        {
            if (editor == null) { throw new ArgumentNullException(nameof(editor)); }
            if (limitNeedsSync && SelectedLimit != null)
            {
                SyncLimitData(SelectedLimit);
            }

            DialogResult result;
            string path;
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "DAT file|*.dat";
                result = saveDialog.ShowDialog();
                path = saveDialog.FileName;
            }

            if (result == DialogResult.OK)
            {
                try
                {
                    editor.WriteFile(path);
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"{ex.Message} ({ex.InnerException?.Message})", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //create a Hext file
        private void buttonHext_Click(object sender, EventArgs e)
        {
            try
            {
                if (editor == null) { throw new ArgumentNullException(nameof(editor)); }
                if (limitNeedsSync && SelectedLimit != null)
                {
                    SyncLimitData(SelectedLimit);
                }

                DialogResult result;
                string path;
                if (DataManager.VanillaExe == null)
                {
                    if (DataManager.VanillaExePathExists) //load EXE from settings
                    {
                        DataManager.LoadVanillaEXE();
                    }
                    else if (editor.IsUnedited)
                    {
                        DataManager.SetFilePath(FileClass.EXE, editor.FilePath, true);
                    }
                    else
                    {
                        MessageBox.Show("You will need to provide an unmodified English EXE for the Hext comparison.",
                        "EXE Needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (var openDialog = new OpenFileDialog())
                        {
                            openDialog.Filter = "Final Fantasy VII executable|ff7_en.exe;ff7.exe";
                            result = openDialog.ShowDialog();
                            path = openDialog.FileName;
                        }

                        if (result != DialogResult.OK)
                        {
                            return;
                        }
                        else
                        {
                            try
                            {
                                DataManager.SetFilePath(FileClass.EXE, path, true);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                }

                if (DataManager.VanillaExe != null)
                {
                    using (var saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "Text file|*.txt";
                        result = saveDialog.ShowDialog();
                        path = saveDialog.FileName;
                    }

                    if (result == DialogResult.OK)
                    {
                        try
                        {
                            editor.CreateHextFile(path, DataManager.VanillaExe);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show($"{ex.Message} ({ex.InnerException?.Message})", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //update EXE
        private void buttonSaveEXE_Click(object sender, EventArgs e)
        {
            if (editor == null) { throw new ArgumentNullException(nameof(editor)); }
            if (limitNeedsSync && SelectedLimit != null)
            {
                SyncLimitData(SelectedLimit);
            }

            try
            {
                string backupPath = editor.FilePath + ".bak";
                if (editor.IsUnedited && !File.Exists(backupPath)) //ask to make a backup
                {
                    var result = MessageBox.Show("Make a backup of the EXE before saving?", "Make backup?",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Cancel) { return; }
                    else if (result == DialogResult.Yes)
                    {
                        File.Copy(editor.FilePath, backupPath);
                        DataManager.SetFilePath(FileClass.EXE, backupPath, true);
                    }
                }
                editor.WriteEXE();
                if (DataManager.ExeData != null) //sync with DataManager
                {
                    DataManager.ExeData.ReadBytes(editor.GetBytes());
                }
                SetUnsaved(false);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"{ex.Message} ({ex.InnerException?.Message})", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExeEditorForm_FormClosing(object sender, FormClosingEventArgs e)
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
