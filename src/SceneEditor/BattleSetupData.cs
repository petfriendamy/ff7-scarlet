namespace FF7Scarlet.SceneEditor
{
    public class BattleSetupData
    {
        public const int BATTLE_ARENA_ID_COUNT = 4, BLOCK_SIZE = 20;
        private readonly ushort[] battleArenaIDs = new ushort[BATTLE_ARENA_ID_COUNT];

        public LocationInfo? Location { get; set; } = null;
        public ushort NextSceneID { get; set; } = HexParser.NULL_OFFSET_16_BIT;
        public ushort EscapeCounter { get; set; }
        public BattleFlags BattleFlags { get; set; }
        public BattleType BattleType { get; set; }
        public byte PreBattleCameraPosition { get; set; }
        public ushort[] BattleArenaIDs
        {
            get { return battleArenaIDs; }
        }

        public BattleSetupData()
        {
            for (int i = 0; i <  BATTLE_ARENA_ID_COUNT; ++i)
            {
                BattleArenaIDs[i] = HexParser.NULL_OFFSET_16_BIT;
            }
        }

        public BattleSetupData(byte[] data)
        {
            using (var ms = new MemoryStream(data, false))
            using (var reader = new BinaryReader(ms))
            {
                Location = LocationInfo.GetInfo(reader.ReadUInt16());
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

        public byte[] GetRawData()
        {
            var data = new byte[BLOCK_SIZE];
            using (var ms = new MemoryStream(data, true))
            using (var writer = new BinaryWriter(ms))
            {
                if (Location == null) { writer.Write(HexParser.NULL_OFFSET_16_BIT); }
                else { writer.Write(Location.LocationID); }
                writer.Write(NextSceneID);
                writer.Write(EscapeCounter);
                writer.Write(HexParser.NULL_OFFSET_16_BIT); //padding
                for (int i = 0; i < BATTLE_ARENA_ID_COUNT; ++i)
                {
                    writer.Write(BattleArenaIDs[i]);
                }
                writer.Write((ushort)~BattleFlags);
                writer.Write((byte)BattleType);
                writer.Write(PreBattleCameraPosition);
            }
            return data;
        }
    }
}
