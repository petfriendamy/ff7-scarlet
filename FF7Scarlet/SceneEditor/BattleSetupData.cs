namespace FF7Scarlet.SceneEditor
{
    public class BattleSetupData
    {
        public const int BATTLE_ARENA_ID_COUNT = 4;
        private readonly ushort[] battleArenaIDs = new ushort[BATTLE_ARENA_ID_COUNT];

        public BattleLocations Location { get; set; }
        public ushort NextSceneID { get; set; }
        public ushort EscapeCounter { get; set; }
        public BattleFlags BattleFlags { get; set; }
        public BattleType BattleType { get; set; }
        public byte PreBattleCameraPosition { get; set; }
        public ushort[] BattleArenaIDs
        {
            get { return battleArenaIDs; }
        }

        public BattleSetupData(byte[] data)
        {
            using (var ms = new MemoryStream(data, false))
            using (var reader = new BinaryReader(ms))
            {
                Location = (BattleLocations)reader.ReadUInt16();
                NextSceneID = reader.ReadUInt16();
                EscapeCounter = reader.ReadUInt16();
                reader.ReadUInt16(); //padding
                for (int i = 0; i < BATTLE_ARENA_ID_COUNT; ++i)
                {
                    BattleArenaIDs[i] = reader.ReadUInt16();
                }
                BattleFlags = (BattleFlags)~reader.ReadUInt16();
                BattleType = (BattleType)reader.ReadByte();
                PreBattleCameraPosition = reader.ReadByte();
            }
        }
    }
}
