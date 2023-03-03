using Shojy.FF7.Elena;

namespace FF7Scarlet.SceneEditor
{
    public class BattleLgp
    {
        private LgpReader reader;
        private string[] models;
        public const string CONFIG_KEY = "BattleLgpPath";

        public string[] Models
        {
            get { return models; }
        }

        public BattleLgp(string path)
        {
            if (Path.GetFileName(path) != "battle.lgp")
            {
                throw new ArgumentException("Invalid file.");
            }
            reader = new LgpReader(path);
            models = //there's probably a better way to get models
                (from file in reader.ListFiles()
                 where file.EndsWith("aa")
                 select file).ToArray();
        }
    }
}
