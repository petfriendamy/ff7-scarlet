namespace FF7Scarlet.SceneEditor
{
    public enum Locations
    {
        Midgar, Junon, Corel, Nibelheim, Wutai, TempleOfTheAncients, NorthernCrater, Misc
    }

    public class LocationInfo
    {
        public static readonly LocationInfo[] LOCATION_LIST = new LocationInfo[]
        {
            new LocationInfo(0x00, "Debug Room", Locations.Misc),
            new LocationInfo(0x01, "Bizarro Sephiroth Battle (Center)", Locations.NorthernCrater),
            new LocationInfo(0x02, "Grassland", Locations.Misc),
            new LocationInfo(0x03, "Mt. Nibel", Locations.Nibelheim),
            new LocationInfo(0x04, "Forest", Locations.Misc),
            new LocationInfo(0x05, "Beach", Locations.Misc),
            new LocationInfo(0x06, "Desert", Locations.Misc),
            new LocationInfo(0x07, "Snow", Locations.Misc),
            new LocationInfo(0x08, "Swamp", Locations.Misc),
            new LocationInfo(0x09, "Sector 1 Train Station", Locations.Midgar),
            new LocationInfo(0x0A, "Reactor 1", Locations.Midgar),
            new LocationInfo(0x0B, "Reactor 1 Core", Locations.Midgar),
            new LocationInfo(0x0C, "Reactor 1 Entrance", Locations.Midgar),
            new LocationInfo(0x0D, "Sector 4 Subway", Locations.Midgar),
            new LocationInfo(0x0E, "Cave", Locations.Misc),
            new LocationInfo(0x0F, "Shinra HQ", Locations.Midgar),
            new LocationInfo(0x10, "Midgar Raid Subway", Locations.Midgar),
            new LocationInfo(0x11, "Hojo's Lab", Locations.Midgar),
            new LocationInfo(0x12, "Shinra HQ Elevator", Locations.Midgar),
            new LocationInfo(0x13, "Shinra HQ Roof",Locations.Midgar),
            new LocationInfo(0x14, "Highway", Locations.Midgar),
            new LocationInfo(0x15, "Wutai Pagoda", Locations.Wutai),
            new LocationInfo(0x16, "Church", Locations.Midgar),
            new LocationInfo(0x17, "Corel Valley", Locations.Corel),
            new LocationInfo(0x18, "Slums", Locations.Midgar),
            new LocationInfo(0x19, "Corridors", Locations.Misc),
            new LocationInfo(0x1A, "Underground", Locations.Midgar),
            new LocationInfo(0x1B, "Sector 7 Support Pillar Stairway", Locations.Midgar),
            new LocationInfo(0x1C, "Sector 7 Support Pillar Top", Locations.Midgar),
            new LocationInfo(0x1D, "Sector 8", Locations.Midgar),
            new LocationInfo(0x1E, "Sewers", Locations.Midgar),
            new LocationInfo(0x1F, "Mythril Mines", Locations.Misc),
            new LocationInfo(0x20, "Floating Platforms", Locations.NorthernCrater),
            new LocationInfo(0x21, "Corel Mountain Path", Locations.Corel),
            new LocationInfo(0x22, "Junon Beach", Locations.Junon),
            new LocationInfo(0x23, "Cargo Ship", Locations.Junon),
            new LocationInfo(0x24, "Corel Prison", Locations.Corel),
            new LocationInfo(0x25, "Battle Square", Locations.Misc),
            new LocationInfo(0x26, "Da Chao - Rapps Battle", Locations.Wutai),
            new LocationInfo(0x27, "Cid's Backyard", Locations.Misc),
            new LocationInfo(0x28, "Final Descent", Locations.NorthernCrater),
            new LocationInfo(0x29, "Reactor 5 Entrance", Locations.Midgar),
            new LocationInfo(0x2A, "Temple of the Ancients -- Escher Room", Locations.TempleOfTheAncients),
            new LocationInfo(0x2B, "Shinra Mansion", Locations.Nibelheim),
            new LocationInfo(0x2C, "Junon Airship Dock", Locations.Junon),
            new LocationInfo(0x2D, "Whirlwind Maze", Locations.Misc),
            new LocationInfo(0x2E, "Junon Underwater Reactor", Locations.Junon),
            new LocationInfo(0x2F, "Gongaga Reactor", Locations.Misc),
            new LocationInfo(0x30, "Gelnika", Locations.Misc),
            new LocationInfo(0x31, "Train Graveyard", Locations.Midgar),
            new LocationInfo(0x32, "Ice Caves", Locations.Misc),
            new LocationInfo(0x33, "Sister Ray", Locations.Midgar),
            new LocationInfo(0x34, "Sister Ray Base", Locations.Midgar),
            new LocationInfo(0x35, "Forgotten City Altar", Locations.Misc),
            new LocationInfo(0x36, "Initial Descent", Locations.NorthernCrater),
            new LocationInfo(0x37, "Hatchery", Locations.NorthernCrater),
            new LocationInfo(0x38, "Water Area", Locations.NorthernCrater),
            new LocationInfo(0x39, "Safer Sephiroth Battle", Locations.NorthernCrater),
            new LocationInfo(0x3A, "Kalm Flashback Dragon Battle", Locations.Misc),
            new LocationInfo(0x3B, "Junon Underwater Pipe", Locations.Junon),
            new LocationInfo(0x3C, "Corel Reactor, Cliff (unused)", Locations.Misc),
            new LocationInfo(0x3D, "Corel Railway Canyon", Locations.Corel),
            new LocationInfo(0x3E, "Whirlwind Maze Crater", Locations.Misc),
            new LocationInfo(0x3F, "Corel Railway Roller Coaster", Locations.Corel),
            new LocationInfo(0x40, "Wooden Bridge", Locations.Misc),
            new LocationInfo(0x41, "Da Chao", Locations.Wutai),
            new LocationInfo(0x42, "Fort Condor", Locations.Misc),
            new LocationInfo(0x43, "Dirt Wasteland", Locations.Misc),
            new LocationInfo(0x44, "Bizzaro Sephiroth Battle (Right)", Locations.NorthernCrater),
            new LocationInfo(0x45, "Bizzaro Sephiroth Battle (Left)", Locations.NorthernCrater),
            new LocationInfo(0x46, "Jenova•SYNTHESIS Battle", Locations.NorthernCrater),
            new LocationInfo(0x47, "Corel Train", Locations.Corel),
            new LocationInfo(0x48, "Cosmo Canyon", Locations.Misc),
            new LocationInfo(0x49, "Cave of the Gi", Locations.Misc),
            new LocationInfo(0x4A, "Shinra Mansion Basement", Locations.Nibelheim),
            new LocationInfo(0x4B, "Temple of the Ancients -- Boss Room", Locations.TempleOfTheAncients),
            new LocationInfo(0x4C, "Temple of the Ancients -- Mural Room", Locations.TempleOfTheAncients),
            new LocationInfo(0x4D, "Temple of the Ancients -- Clock Room", Locations.TempleOfTheAncients),
            new LocationInfo(0x4E, "Final Battle", Locations.NorthernCrater),
            new LocationInfo(0x4F, "Jungle", Locations.Misc),
            new LocationInfo(0x50, "Highwind Deck", Locations.Misc),
            new LocationInfo(0x51, "Corel Reactor", Locations.Corel),
            new LocationInfo(0x52, "Unused", Locations.Misc),
            new LocationInfo(0x53, "Don Corneo's Mansion", Locations.Midgar),
            new LocationInfo(0x54, "Underwater", Locations.Misc),
            new LocationInfo(0x55, "Reactor 5", Locations.Midgar),
            new LocationInfo(0x56, "Shinra HQ Escape", Locations.Midgar),
            new LocationInfo(0x57, "Gongaga Reactor (Ultimate Weapon)", Locations.Misc),
            new LocationInfo(0x58, "Corel Prison (Dyne Battle)", Locations.Corel),
            new LocationInfo(0x59, "Forest (Ultimate Weapon)", Locations.Misc)
        };
        public ushort LocationID { get; }
        public string Name { get; }
        public Locations Category { get; }

        public LocationInfo(ushort locationID, string name, Locations category)
        {
            LocationID = locationID;
            Name = name;
            Category = category;
        }

        public static LocationInfo? GetInfo(ushort id)
        {
            foreach (var l in LOCATION_LIST)
            {
                if (l.LocationID == id) { return l; }
            }
            return null;
        }

        public string GetModelID()
        {
            char c1 = 'o', c2 = 'g'; //first model ID is ogaa
            int i = 0;
            while (i < LocationID)
            {
                c1++;
                if (c1 > 'z')
                {
                    c2++;
                    c1 = 'a';
                }
            }
            return $"{c1}{c2}aa";
        }
    }
}
