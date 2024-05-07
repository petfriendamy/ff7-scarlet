namespace FF7Scarlet.SceneEditor
{
    public partial class CoverFlagsControl : UserControl
    {
        private const int FLAG_COUNT = 16;
        private CheckBox[] checkboxes;
        public event EventHandler? FlagsChanged;

        public CoverFlagsControl()
        {
            InitializeComponent();

            checkboxes = new CheckBox[FLAG_COUNT]
            {
                checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8,
                checkBox9, checkBox10, checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16
            };
        }

        public void SetFlags(bool[] flags)
        {
            if (flags.Length < FLAG_COUNT)
            {
                throw new ArgumentException("Array is too short.");
            }

            for (int i = 0; i < FLAG_COUNT; ++i)
            {
                checkboxes[i].Checked = flags[i];
            }
        }

        public bool[] GetFlags()
        {
            var flags = new bool[FLAG_COUNT];
            for (int i = 0; i < FLAG_COUNT; ++i)
            {
                flags[i] = checkboxes[i].Checked;
            }
            return flags;
        }

        private void CheckBoxChanged(object? sender, EventArgs e)
        {
            FlagsChanged?.Invoke(this, e);
        }
    }
}
