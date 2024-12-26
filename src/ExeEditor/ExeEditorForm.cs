using System.Globalization;
using System.Media;
using FF7Scarlet.KernelEditor;
using FF7Scarlet.Shared;
using FF7Scarlet.Shared.Controls;
using Shojy.FF7.Elena.Attacks;
using Shojy.FF7.Elena.Characters;
using Shojy.FF7.Elena.Inventory;
using Shojy.FF7.Elena.Materias;

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
            textBoxItemMenuText.MaxLength = ExeData.ITEM_MENU_TEXT_LENGTH - 1;
            textBoxMagicMenuText.MaxLength = ExeData.MENU_TEXT_LENGTH - 1;
            textBoxMateriaMenuText.MaxLength = ExeData.MENU_TEXT_LENGTH - 1;
            textBoxUnequipText.MaxLength = ExeData.UNEQUIP_TEXT_LENGTH - 1;
            textBoxEquipMenuText.MaxLength = ExeData.EQUIP_MENU_TEXT_LENGTH - 1;
            textBoxStatusMenuText.MaxLength = ExeData.STATUS_MENU_TEXT_LENGTH - 1;
            textBoxConfigMenuText.MaxLength = editor.GetConfigTextLength() - 1;

            textBoxElements.MaxLength = ExeData.ELEMENT_NAME_LENGTH - 1;
            textBoxStatusEffectTextBattle.MaxLength = editor.GetStatusEffectBattleLength() - 1;
            textBoxStatusEffectMenu.MaxLength = ExeData.STATUS_MENU_TEXT_LENGTH - 1;
            textBoxL4Success.MaxLength = editor.GetLimitTextLength() - 1;
            textBoxL4Fail.MaxLength = editor.GetLimitTextLength() - 1;
            textBoxL4Wrong.MaxLength = editor.GetLimitTextLength() - 1;
            textBoxShopNameText.MaxLength = editor.GetShopNameLength() - 1;
            textBoxShopText.MaxLength = ExeData.SHOP_TEXT_LENGTH - 1;
            textBoxChocoboName.MaxLength = ExeData.CHOCOBO_NAME_LENGTH - 1;

            //add limit breaks
            listBoxLimits.BeginUpdate();
            for (i = 0; i < ExeData.NUM_LIMITS; ++i)
            {
                string name = $"(Limit break #{i + 1})";
                if (DataManager.BothKernelFilePathsExist && DataManager.Kernel != null)
                {
                    name = DataManager.Kernel.GetLimitName(i);
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

            //English-only stuff
            if (editor.Language != Language.English)
            {
                foreach (Control c in tabPageItemMagicMenu.Controls)
                {
                    c.Enabled = false;
                }
                foreach (Control c in tabPageMateriaMenu.Controls)
                {
                    c.Enabled = false;
                }
                foreach (Control c in tabPageEquipMenu.Controls)
                {
                    c.Enabled = false;
                }
                foreach (Control c in tabPageStatusMenu.Controls)
                {
                    c.Enabled = false;
                }
                foreach (Control c in tabPageSortOrder.Controls)
                {
                    c.Enabled = false;
                }
                foreach (Control c in tabPageChocoboRacing.Controls)
                {
                    c.Enabled = false;
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
                    string name = DataManager.Kernel.GetInventoryItemName(DataParser.GetCombinedItemIndex(item));
                    foreach (var shop in ShopItemList)
                    {
                        shop.Items.Add(name);
                        shop.SelectedIndex = 0;
                    }
                    comboBoxChocoboRacePrizes.Items.Add(name);
                }

                //weapons
                foreach (var weapon in DataManager.Kernel.WeaponData.Weapons)
                {
                    string name = DataManager.Kernel.GetInventoryItemName(DataParser.GetCombinedItemIndex(weapon));
                    comboBoxCharacterWeapon.Items.Add(name);
                    foreach (var shop in ShopItemList)
                    {
                        shop.Items.Add(name);
                    }
                    comboBoxChocoboRacePrizes.Items.Add(name);
                }

                //armors
                foreach (var armor in DataManager.Kernel.ArmorData.Armors)
                {
                    string name = DataManager.Kernel.GetInventoryItemName(DataParser.GetCombinedItemIndex(armor));
                    comboBoxCharacterArmor.Items.Add(name);
                    foreach (var shop in ShopItemList)
                    {
                        shop.Items.Add(name);
                    }
                    comboBoxChocoboRacePrizes.Items.Add(name);
                }

                //accessories
                comboBoxCharacterAccessory.Items.Add("None");
                foreach (var accessory in DataManager.Kernel.AccessoryData.Accessories)
                {
                    string name = DataManager.Kernel.GetInventoryItemName(DataParser.GetCombinedItemIndex(accessory));
                    comboBoxCharacterAccessory.Items.Add(name);
                    foreach (var shop in ShopItemList)
                    {
                        shop.Items.Add(name);
                    }
                    comboBoxChocoboRacePrizes.Items.Add(name);
                }

                //materia
                foreach (var materia in DataManager.Kernel.MateriaData.Materias)
                {
                    string name = DataManager.Kernel.GetInventoryItemName(DataParser.GetCombinedItemIndex(materia));
                    foreach (var shop in ShopItemList)
                    {
                        shop.Items.Add(name);
                    }
                    comboBoxChocoboRacePrizes.Items.Add(name);
                }
            }
            else //no kernel loaded
            {
                groupBoxCharacterWeapon.Enabled = false;
                groupBoxCharacterArmor.Enabled = false;
                comboBoxCharacterAccessory.Enabled = false;
                foreach (Control c in tabPageShopData.Controls)
                {
                    c.Enabled = false;
                }
                foreach (Control c in tabPageSortOrder.Controls)
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
            loading = true;
            int i;

            //suspend layouts
            SuspendOrResumeExeTextListBoxes(false);
            listBoxItemPrices.SuspendLayout();
            listBoxMateriaPrices.SuspendLayout();
            comboBoxShopType.SuspendLayout();
            listBoxChocoboNames.SuspendLayout();
            listBoxSortItemName.SuspendLayout();

            //clear items
            int shopType = comboBoxShopType.SelectedIndex;
            if (shopType < 0) { shopType = 0; }
            comboBoxShopType.Items.Clear();
            foreach (TabPage p in tabControlMenus.TabPages)
            {
                foreach (var c in p.Controls)
                {
                    if (c is ListBox)
                    {
                        var lb = c as ListBox;
                        if (lb != null) { lb.Items.Clear(); }
                    }
                }
            }
            listBoxStatusEffects.Items.Clear();
            listBoxItemPrices.Items.Clear();
            listBoxMateriaPrices.Items.Clear();
            listBoxShopNames.Items.Clear();
            listBoxShopText.Items.Clear();
            listBoxSortItemName.Items.Clear();
            listBoxChocoboNames.Items.Clear();

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
            for (i = 0; i < ExeData.NUM_CONFIG_MENU_TEXTS; ++i)
            {
                listBoxConfigMenu.Items.Add(editor.ConfigMenuTexts[i].ToString());
            }

            //set status effects
            for (i = 0; i < ExeData.NUM_STATUS_EFFECTS; ++i)
            {
                string se = editor.StatusEffectsBattle[i].ToString();
                if (editor.Language == Language.English)
                {
                    string temp = editor.StatusEffectsMenu[i].ToString();
                    if (!string.IsNullOrEmpty(temp))
                    {
                        se = temp;
                    }
                }
                listBoxStatusEffects.Items.Add(se);
            }

            //kernel-synced data
            if (DataManager.Kernel != null)
            {
                //set item prices
                for (i = 0; i < DataParser.ITEM_COUNT; ++i)
                {
                    var item = DataManager.Kernel.ItemData.Items[i];
                    string name = DataManager.Kernel.GetInventoryItemName(DataParser.GetCombinedItemIndex(item));
                    listBoxItemPrices.Items.Add($"{name} - {editor.ItemPrices[i]}");
                }
                for (i = 0; i < DataParser.WEAPON_COUNT; ++i)
                {
                    var wpn = DataManager.Kernel.WeaponData.Weapons[i];
                    string name = DataManager.Kernel.GetInventoryItemName(DataParser.GetCombinedItemIndex(wpn));
                    listBoxItemPrices.Items.Add($"{name} - {editor.WeaponPrices[i]}");
                }
                for (i = 0; i < DataParser.ARMOR_COUNT; ++i)
                {
                    var armor = DataManager.Kernel.ArmorData.Armors[i];
                    string name = DataManager.Kernel.GetInventoryItemName(DataParser.GetCombinedItemIndex(armor));
                    listBoxItemPrices.Items.Add($"{name} - {editor.ArmorPrices[i]}");
                }
                for (i = 0; i < DataParser.ACCESSORY_COUNT; ++i)
                {
                    var acc = DataManager.Kernel.AccessoryData.Accessories[i];
                    string name = DataManager.Kernel.GetInventoryItemName(DataParser.GetCombinedItemIndex(acc));
                    listBoxItemPrices.Items.Add($"{name} - {editor.AccessoryPrices[i]}");
                }

                //set materia prices
                for (i = 0; i < DataManager.Kernel.MateriaData.Materias.Length; ++i)
                {
                    var mat = DataManager.Kernel.MateriaData.Materias[i];
                    string name = DataManager.Kernel.GetInventoryItemName(DataParser.GetCombinedItemIndex(mat));
                    listBoxMateriaPrices.Items.Add($"{name} - {editor.MateriaPrices[i]}");
                }

                //English-only stuff
                if (editor.Language == Language.English)
                {
                    //set item menu text
                    for (i = 0; i < ExeData.NUM_ITEM_MENU_TEXTS; ++i)
                    {
                        listBoxItemMenu.Items.Add(editor.ItemMenuTexts[i].ToString());
                    }

                    //set magic menu text
                    for (i = 0; i < ExeData.NUM_MAGIC_MENU_TEXTS; ++i)
                    {
                        listBoxMagicMenu.Items.Add(editor.MagicMenuTexts[i].ToString());
                    }

                    //set materia menu text
                    for (i = 0; i < ExeData.NUM_MATERIA_MENU_TEXTS; ++i)
                    {
                        listBoxMateriaMenu.Items.Add(editor.MateriaMenuTexts[i].ToString());
                    }

                    //set unequip text
                    for (i = 0; i < ExeData.NUM_UNEQUIP_TEXTS; ++i)
                    {
                        listBoxUnequipText.Items.Add(editor.UnequipTexts[i].ToString());
                    }

                    //set equip menu text
                    for (i = 0; i < ExeData.NUM_EQUIP_MENU_TEXTS; ++i)
                    {
                        listBoxEquipMenu.Items.Add(editor.EquipMenuTexts[i].ToString());
                    }

                    //set status menu text
                    for (i = 0; i < ExeData.NUM_STATUS_MENU_TEXTS; ++i)
                    {
                        listBoxStatusMenuText.Items.Add(editor.StatusMenuTexts[i].ToString());
                    }

                    //set element names
                    for (i = 0; i < ExeData.NUM_ELEMENTS; ++i)
                    {
                        listBoxElements.Items.Add(editor.ElementNames[i].ToString());
                    }

                    //set status menu text
                    for (i = 0; i < ExeData.NUM_LIMIT_MENU_TEXTS; ++i)
                    {
                        listBoxLimitMenu.Items.Add(editor.LimitMenuTexts[i].ToString());
                    }

                    //set save menu text
                    for (i = 0; i < ExeData.NUM_SAVE_MENU_TEXTS; ++i)
                    {
                        listBoxSaveMenu.Items.Add(editor.SaveMenuTexts[i].ToString());
                    }

                    //set chocobo names
                    for (i = 0; i <= ExeData.NUM_CHOCOBO_NAMES; ++i)
                    {
                        listBoxChocoboNames.Items.Add(editor.ChocoboNames[i].ToString());
                    }

                    //set chocobo race prizes
                    for (i = 0; i < ExeData.NUM_CHOCOBO_RACE_ITEMS; ++i)
                    {
                        listBoxChocoboRacePrizes.Items.Add(editor.ChocoboRacePrizes[i].ToString());
                    }

                    //sorted items
                    var sortedItems =
                        from item in editor.ItemsSortedByName
                        orderby item.Value
                        select item;
                    foreach (var item in sortedItems)
                    {
                        listBoxSortItemName.Items.Add(DataManager.Kernel.GetInventoryItemName(item.Key));
                    }

                    //materia priority list
                    LoadMateriaPriorityList();
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
            listBoxSortItemName.ResumeLayout();
            listBoxChocoboNames.ResumeLayout();
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
            foreach (TabPage t in tabControlMenus.TabPages)
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
                limit.ConditionSubmenu = ConditionSubmenu.None;
            }
            else
            {
                limit.ConditionSubmenu = (ConditionSubmenu)(comboBoxLimitConditionSubMenu.SelectedIndex - 1);
            }
            limit.Statuses = statusesControlLimit.GetStatuses();
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
                var type = DataParser.GetItemType(item.Item);
                if (type == ItemType.Materia)
                {
                    var mat = DataManager.Kernel.GetMateriaByID(DataParser.GetItemIndex(item.Item));
                    if (mat != null)
                    {
                        return mat.Index + DataParser.MATERIA_START;
                    }
                }
                else
                {
                    return item.Item;
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

            if (index <= DataParser.MAX_INDEX)
            {
                var item = new InventoryItem();
                item.Item = (ushort)index;
                return item;
            }
            else
            {
                var mat = new InventoryItem();
                DataParser.SetItem(mat, DataManager.Kernel.MateriaData.Materias[index - DataParser.MAX_INDEX - 1]);
                return mat;
            }
        }

        private int LoadMateriaPriorityList(byte currentMateriaID = 0xFF)
        {
            int pos = -1;
            listBoxMateriaPriority.SuspendLayout();
            listBoxMateriaPriority.Items.Clear();
            if (DataManager.Kernel != null)
            {
                var sortedMateria =
                    from mat in editor.MateriaPriority
                    orderby mat.Value descending
                    select mat;
                foreach (var mat in sortedMateria)
                {
                    var m = DataManager.Kernel.GetMateriaByID(mat.Key);
                    if (m != null)
                    {
                        string name = m.Name;
                        if (string.IsNullOrEmpty(name)) { name = $"(Materia ID {mat.Key})"; }
                        if (mat.Value == 0) { name = "[null] " + name; }
                        listBoxMateriaPriority.Items.Add(name);
                    }
                }
                if (currentMateriaID < DataParser.MATERIA_COUNT) //find index of materia
                {
                    pos = (from mat in sortedMateria select mat.Key).ToList().IndexOf(currentMateriaID);
                }
            }
            listBoxMateriaPriority.ResumeLayout();
            return pos;
        }

        private void SetLimitText()
        {
            bool wasAlreadyLoading = loading;
            loading = true;
            int i = comboBoxL4Char.SelectedIndex;
            if (i >= 0 && i < Kernel.PLAYABLE_CHARACTER_COUNT)
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
                    i < Kernel.PLAYABLE_CHARACTER_COUNT - 1;

                //disable success and fail for Cait Sith
                if (i == Kernel.PLAYABLE_CHARACTER_COUNT - 1)
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

        private void ListBoxIndexChanged(ListBox listBox, TextBox textBox, FFText[] strings, int length)
        {
            if (!loading)
            {
                loading = true;
                int i = listBox.SelectedIndex;
                if (i >= 0 && i < length)
                {
                    textBox.Enabled = true;
                    textBox.Text = strings[i].ToString();
                }
                loading = false;
            }
        }

        private void TextBoxTextChanged(ListBox listBox, TextBox textBox, FFText[] strings)
        {
            if (!loading)
            {
                loading = true;
                int i = listBox.SelectedIndex;
                strings[i] = new FFText(textBox.Text);
                listBox.Items[i] = textBox.Text;
                SetUnsaved(true);
                loading = false;
            }
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
                SelectedCharacter.Name = textBoxCharacterName.Text;
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
                    var mat = DataParser.CopyMateria(SelectedCharacter.WeaponMateria[slot]);
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
                    var mat = DataParser.CopyMateria(SelectedCharacter.ArmorMateria[slot]);
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
                    if (attack != null)
                    {
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
                        statusesControlLimit.SetStatuses(attack.Statuses);
                        if (attack.ConditionSubmenu == ConditionSubmenu.None)
                        {
                            comboBoxLimitConditionSubMenu.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBoxLimitConditionSubMenu.SelectedIndex = (int)attack.ConditionSubmenu + 1;
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
                var type = DataParser.GetItemType(item.Item);
                int index = DataParser.GetItemIndex(item.Item);
                if (type == ItemType.Weapon)
                {
                    numericItemPrice.Value = editor.WeaponPrices[index];
                }
                else if (type == ItemType.Armor)
                {
                    numericItemPrice.Value = editor.ArmorPrices[index];
                }
                else if (type == ItemType.Accessory)
                {
                    numericItemPrice.Value = editor.AccessoryPrices[index];
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
                var type = DataParser.GetItemType(item.Item);
                int index = DataParser.GetItemIndex(item.Item);
                if (type == ItemType.Weapon)
                {
                    editor.WeaponPrices[index] = (uint)numericItemPrice.Value;
                    listBoxItemPrices.Items[i] = $"{DataManager.Kernel.GetInventoryItemName(item)} - {editor.WeaponPrices[index]}";
                }
                else if (type == ItemType.Armor)
                {
                    editor.ArmorPrices[index] = (uint)numericItemPrice.Value;
                    listBoxItemPrices.Items[i] = $"{DataManager.Kernel.GetInventoryItemName(item)} - {editor.ArmorPrices[index]}";
                }
                else if (type == ItemType.Accessory)
                {
                    editor.AccessoryPrices[index] = (uint)numericItemPrice.Value;
                    listBoxItemPrices.Items[i] = $"{DataManager.Kernel.GetInventoryItemName(item)} - {editor.AccessoryPrices[index]}";
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
                listBoxMateriaPrices.Items[i] = $"{DataManager.Kernel.MateriaData.Materias[i].Name} - {editor.MateriaPrices[i]}";
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

        //change AP price multiplier
        private void numericMateriaAPPriceMultiplier_ValueChanged(object sender, EventArgs e)
        {
            if (!loading && editor != null)
            {
                editor.APPriceMultiplier = (byte)numericMateriaAPPriceMultiplier.Value;
                SetUnsaved(true);
            }
        }

        private void listBoxSortItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxSortItemName.SelectedIndex;
            buttonItemsMoveUp.Enabled = (i > 0 && i < DataParser.MATERIA_START);
            buttonItemsMoveDown.Enabled = (i >= 0 && i < DataParser.MATERIA_START - 1);
        }

        private void buttonItemsAutoSort_Click(object sender, EventArgs e)
        {
            if (DataManager.Kernel != null)
            {
                var sortedItems =
                    (from item in editor.ItemsSortedByName
                     let name = DataManager.Kernel.GetInventoryItemName(item.Key)
                     orderby name.StartsWith("(Item ID"), name
                     select item).ToArray();

                listBoxSortItemName.SuspendLayout();
                editor.ItemsSortedByName.Clear();
                listBoxSortItemName.Items.Clear();
                for (ushort i = 0; i < sortedItems.Length; ++i)
                {
                    editor.ItemsSortedByName.Add(sortedItems[i].Key, i);
                    listBoxSortItemName.Items.Add(DataManager.Kernel.GetInventoryItemName(sortedItems[i].Key));
                }
                listBoxSortItemName.ResumeLayout();
                buttonItemsMoveUp.Enabled = false;
                buttonItemsMoveDown.Enabled = false;
                SetUnsaved(true);
            }
        }

        private void buttonItemsMoveUp_Click(object sender, EventArgs e)
        {
            int i = listBoxSortItemName.SelectedIndex;
            if (i > 0 && i < DataParser.MATERIA_START)
            {
                //get the actual position of the item
                var itemList =
                    (from item in editor.ItemsSortedByName
                     orderby item.Value
                     select item.Key).ToArray();

                //swap items in the dictionary
                ushort curr = editor.ItemsSortedByName[itemList[i]],
                    prev = editor.ItemsSortedByName[itemList[i - 1]];
                editor.ItemsSortedByName[itemList[i]] = prev;
                editor.ItemsSortedByName[itemList[i - 1]] = curr;

                //swap items in the listbox
                var temp = listBoxSortItemName.Items[i];
                listBoxSortItemName.Items[i] = listBoxSortItemName.Items[i - 1];
                listBoxSortItemName.Items[i - 1] = temp;
                listBoxSortItemName.SelectedIndex = i - 1;

                SetUnsaved(true);
            }
        }

        private void buttonItemsMoveDown_Click(object sender, EventArgs e)
        {
            int i = listBoxSortItemName.SelectedIndex;
            if (i >= 0 && i < DataParser.MATERIA_START - 1)
            {
                //get the actual position of the item
                var itemList =
                    (from item in editor.ItemsSortedByName
                     orderby item.Value
                     select item.Key).ToArray();

                //swap items in the dictionary
                ushort curr = editor.ItemsSortedByName[itemList[i]],
                    next = editor.ItemsSortedByName[itemList[i + 1]];
                editor.ItemsSortedByName[itemList[i]] = next;
                editor.ItemsSortedByName[itemList[i + 1]] = curr;

                //swap items in the listbox
                var temp = listBoxSortItemName.Items[i];
                listBoxSortItemName.Items[i] = listBoxSortItemName.Items[i + 1];
                listBoxSortItemName.Items[i + 1] = temp;
                listBoxSortItemName.SelectedIndex = i + 1;

                SetUnsaved(true);
            }
        }

        private void listBoxMateriaPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxMateriaPriority.SelectedIndex;
            buttonMateriaMoveUp.Enabled = (i > 0 && i < DataParser.MATERIA_COUNT);
            buttonMateriaMoveDown.Enabled = (i >= 0 && i < DataParser.MATERIA_COUNT - 1
                && editor.MateriaPriority[(byte)i] > 0);
        }

        private void buttonMateriaMoveUp_Click(object sender, EventArgs e)
        {
            int i = listBoxMateriaPriority.SelectedIndex;
            if (i > 0 && i < DataParser.MATERIA_COUNT)
            {
                //get the actual position of the materia
                var matList =
                    (from mat in editor.MateriaPriority
                     orderby mat.Value descending
                     select mat.Key).ToArray();

                //special handling for 0 priority materia
                if (editor.MateriaPriority[matList[i]] == 0)
                {
                    //increase value of everything else
                    for (byte j = 0; j < DataParser.MATERIA_COUNT; ++j)
                    {
                        if (editor.MateriaPriority[j] > 0)
                        {
                            editor.MateriaPriority[j]++;
                        }
                    }
                    editor.MateriaPriority[matList[i]] = 1;
                    listBoxMateriaPriority.SelectedIndex = LoadMateriaPriorityList(matList[i]);
                    listBoxMateriaPriority.TopIndex = DataParser.MATERIA_COUNT - 1;

                }
                else
                {
                    //swap items in the dictionary
                    editor.MateriaPriority[matList[i]]++;
                    editor.MateriaPriority[matList[i - 1]]--;

                    //swap items in the listbox
                    var temp = listBoxMateriaPriority.Items[i];
                    listBoxMateriaPriority.Items[i] = listBoxMateriaPriority.Items[i - 1];
                    listBoxMateriaPriority.Items[i - 1] = temp;
                    listBoxMateriaPriority.SelectedIndex = i - 1;
                }
                SetUnsaved(true);
            }
        }

        private void buttonMateriaMoveDown_Click(object sender, EventArgs e)
        {
            int i = listBoxMateriaPriority.SelectedIndex;
            if (i >= 0 && i < DataParser.MATERIA_COUNT - 1)
            {
                //get the actual position of the materia
                var matList =
                    (from mat in editor.MateriaPriority
                     orderby mat.Value descending
                     select mat.Key).ToArray();

                //special handling for 0 priority materia
                if (editor.MateriaPriority[matList[i]] == 1)
                {
                    //decrease value of everything else
                    for (byte j = 0; j < DataParser.MATERIA_COUNT; ++j)
                    {
                        if (editor.MateriaPriority[j] > 0)
                        {
                            editor.MateriaPriority[j]--;
                        }
                    }
                    listBoxMateriaPriority.SelectedIndex = LoadMateriaPriorityList(matList[i]);
                    listBoxMateriaPriority.TopIndex = DataParser.MATERIA_COUNT - 1;

                }
                else
                {
                    //swap items in the dictionary
                    editor.MateriaPriority[matList[i]]--;
                    editor.MateriaPriority[matList[i + 1]]++;

                    //swap items in the listbox
                    var temp = listBoxMateriaPriority.Items[i];
                    listBoxMateriaPriority.Items[i] = listBoxMateriaPriority.Items[i + 1];
                    listBoxMateriaPriority.Items[i + 1] = temp;
                    listBoxMateriaPriority.SelectedIndex = i + 1;
                }
                SetUnsaved(true);
            }
        }

        //listboxes
        private void listBoxMainMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxMainMenu, textBoxMainMenuText, editor.MainMenuTexts,
                ExeData.NUM_MENU_TEXTS);
        }

        private void listBoxItemMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxItemMenu, textBoxItemMenuText, editor.ItemMenuTexts,
                ExeData.NUM_ITEM_MENU_TEXTS);
        }

        private void listBoxMagicMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxMagicMenu, textBoxMagicMenuText, editor.MagicMenuTexts,
                ExeData.NUM_MAGIC_MENU_TEXTS);
        }

        private void listBoxMateriaMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxMateriaMenu, textBoxMateriaMenuText, editor.MateriaMenuTexts,
                ExeData.NUM_MATERIA_MENU_TEXTS);
        }

        private void listBoxUnequipText_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxUnequipText, textBoxUnequipText, editor.UnequipTexts,
                ExeData.NUM_UNEQUIP_TEXTS);
        }

        private void listBoxEquipMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxEquipMenu, textBoxEquipMenuText, editor.EquipMenuTexts,
                ExeData.NUM_EQUIP_MENU_TEXTS);
        }

        private void listBoxStatusMenuText_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxStatusMenuText, textBoxStatusMenuText, editor.StatusMenuTexts,
                ExeData.NUM_STATUS_MENU_TEXTS);
        }

        private void listBoxElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxElements, textBoxElements, editor.ElementNames, ExeData.NUM_ELEMENTS);
        }

        private void listBoxLimitMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxLimitMenu, textBoxLimitMenuText, editor.LimitMenuTexts,
                ExeData.NUM_LIMIT_MENU_TEXTS);
        }

        private void listBoxConfigMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxConfigMenu, textBoxConfigMenuText, editor.ConfigMenuTexts,
                ExeData.NUM_CONFIG_MENU_TEXTS);
        }

        private void listBoxSaveMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxSaveMenu, textBoxSaveMenuText, editor.SaveMenuTexts,
                ExeData.NUM_SAVE_MENU_TEXTS);
        }

        private void listBoxStatusEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxStatusEffects.SelectedIndex;
                if (i >= 0 && i < ExeData.NUM_STATUS_EFFECTS)
                {
                    if (editor.Language == Language.English)
                    {
                        textBoxStatusEffectMenu.Enabled = true;
                        textBoxStatusEffectMenu.Text = editor.StatusEffectsMenu[i].ToString();
                    }
                    textBoxStatusEffectTextBattle.Enabled = true;
                    textBoxStatusEffectTextBattle.Text = editor.StatusEffectsBattle[i].ToString();
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
            ListBoxIndexChanged(listBoxShopNames, textBoxShopNameText, editor.ShopNames, ExeData.NUM_SHOP_NAMES);
        }

        private void listBoxShopText_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxShopText, textBoxShopText, editor.ShopText, ExeData.NUM_SHOP_TEXTS);
        }

        private void listBoxChocoboNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxIndexChanged(listBoxChocoboNames, textBoxChocoboName, editor.ChocoboNames,
                ExeData.NUM_CHOCOBO_NAMES + 1);
        }

        private void listBoxChocoboRacePrizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBoxChocoboRacePrizes.SelectedIndex;
            if (i >= 0 && i < ExeData.NUM_CHOCOBO_RACE_ITEMS)
            {
                loading = true;
                comboBoxChocoboRacePrizes.Enabled = true;
                comboBoxChocoboRacePrizes.Text = editor.ChocoboRacePrizes[i].ToString();
                loading = false;
            }
        }

        //textboxes
        private void textBoxMainMenuText_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged(listBoxMainMenu, textBoxMainMenuText, editor.MainMenuTexts);
        }

        private void textBoxItemMenuText_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged(listBoxItemMenu, textBoxItemMenuText, editor.ItemMenuTexts);
        }

        private void textBoxMagicMenuText_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged(listBoxMagicMenu, textBoxMagicMenuText, editor.MagicMenuTexts);
        }

        private void textBoxMateriaMenuText_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged(listBoxMateriaMenu, textBoxMateriaMenuText, editor.MateriaMenuTexts);
        }

        private void textBoxUnequipText_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged(listBoxUnequipText, textBoxUnequipText, editor.UnequipTexts);
        }

        private void textBoxEquipMenu_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged(listBoxEquipMenu, textBoxEquipMenuText, editor.EquipMenuTexts);
        }

        private void textBoxStatusMenuText_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged(listBoxStatusMenuText, textBoxStatusMenuText, editor.StatusMenuTexts);
        }

        private void textBoxElements_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged(listBoxElements, textBoxElements, editor.ElementNames);
        }

        private void textBoxLimitMenuText_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged(listBoxLimitMenu, textBoxLimitMenuText, editor.LimitMenuTexts);
        }

        private void textBoxConfigMenuText_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged(listBoxConfigMenu, textBoxConfigMenuText, editor.ConfigMenuTexts);
        }

        private void textBoxSaveMenuText_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged(listBoxSaveMenu, textBoxSaveMenuText, editor.SaveMenuTexts);
        }

        private void textBoxStatusEffectMenu_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxStatusEffects.SelectedIndex;
                editor.StatusEffectsMenu[i] = new FFText(textBoxStatusEffectMenu.Text);
                if (string.IsNullOrEmpty(textBoxStatusEffectMenu.Text))
                {
                    listBoxStatusEffects.Items[i] = textBoxStatusEffectTextBattle.Text;
                }
                else
                {
                    listBoxStatusEffects.Items[i] = textBoxStatusEffectMenu.Text;
                }
                SetUnsaved(true);
                loading = false;
            }
        }

        private void textBoxStatusEffectTextBattle_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxStatusEffects.SelectedIndex;
                editor.StatusEffectsBattle[i] = new FFText(textBoxStatusEffectTextBattle.Text);
                if (editor.Language != Language.English || editor.StatusEffectsMenu[i].IsEmpty())
                {
                    listBoxStatusEffects.Items[i] = textBoxStatusEffectTextBattle.Text;
                }
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
            TextBoxTextChanged(listBoxShopText, textBoxShopText, editor.ShopText);
        }

        private void textBoxChocoboName_TextChanged(object sender, EventArgs e)
        {
            TextBoxTextChanged(listBoxChocoboNames, textBoxChocoboName, editor.ChocoboNames);
        }

        private void comboBoxChocoboPrizes_TextChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                loading = true;
                int i = listBoxChocoboRacePrizes.SelectedIndex;
                editor.ChocoboRacePrizes[i] = new FFText(comboBoxChocoboRacePrizes.Text);
                listBoxChocoboRacePrizes.Items[i] = comboBoxChocoboRacePrizes.Text;
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
