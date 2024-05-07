using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.ExeEditor
{
    public static class ShopData
    {
        public static int SHOP_NAME_LENGTH = 20;

        public static ReadOnlyDictionary<int, string> SHOP_NAMES = new Dictionary<int, string>
        {
            { 0, "Sector 7 Weapon Shop" },
            { 1, "Sector 7 Item Shop" },
            { 2, "Sector 7 Drug Store" },
            { 3, "Sector 8 Weapon Shop" },
            { 4, "Sector 8 Item Shop" },
            { 5, "Sector 8 Materia Shop" },
            { 6, "Wall Market Weapon Shop" },
            { 7, "Wall Market Materia Shop" },
            { 8, "Wall Market Item Shop" },
            { 9, "Sector 7 Pillar Shop" },
            { 10, "Shinra HQ Shop" },
            { 11, "Kalm Weapon Shop" },
            { 12, "Kalm Item Shop" },
            { 13, "Kalm Materia Shop" },
            { 14, "Choco Billy's Greens Store (Disc 1)" },
            { 15, "Choco Billy's Greens Store (Disc 2)" },
            { 16, "Fort Condor Item Shop (Disc 1)" },
            { 17, "Fort Condor Materia Shop (Disc 1)" },
            { 18, "Lower Junon Weapon Shop" },
            { 19, "Upper Junon Weapon Shop #1 (Disc 1)" },
            { 20, "Upper Junon Item Shop (Disc 1)" },
            { 21, "Upper Junon Materia Shop #1" },
            { 22, "Upper Junon Weapon Shop #2 (Disc 1)" },
            { 23, "Upper Junon Accessory Shop (Disc 1)" },
            { 24, "Upper Junon Materia Shop #2 (Disc 1)" },
            { 25, "Cargo Ship Item Shop" },
            { 26, "Costa Del Sol Weapon Shop (Disc 1)" },
            { 27, "Costa Del Sol Materia Shop (Disc 1)" },
            { 28, "Costa Del Sol Item Shop (Disc 1)" },
            { 29, "North Corel Weapons Shop" },
            { 30, "North Corel Item Shop" },
            { 31, "North Corel General Store" },
            { 32, "Gold Saucer Hotel Shop" },
            { 33, "Corel Prison General Store" },
            { 34, "Gongaga Weapon Shop" },
            { 35, "Gongaga Item Shop" },
            { 36, "Gongaga Accessory Shop" },
            { 37, "Cosmo Canyon Weapon Shop" },
            { 38, "Cosmo Canyon Item Shop" },
            { 39, "Cosmo Canyon Materia Shop" },
            { 40, "Nibelheim General Store" },
            { 41, "Rocket Town Weapon Shop (Disc 1)" },
            { 42, "Rocket Town Item Shop (Disc 1)" },
            { 43, "Wutai Weapon Shop" },
            { 44, "Wutai Item Shop" },
            { 45, "Temple of the Ancients Shop" },
            { 46, "Icicle Inn Weapon Shop" },
            { 47, "Mideel Weapon Shop" },
            { 48, "Mideel Accessory Shop" },
            { 49, "Mideel Item Shop" },
            { 50, "Mideel Materia Shop" },
            { 51, "Fort Condor Item Shop (Disc 2)" },
            { 52, "Fort Condor Materia Shop (Disc 2)" },
            { 53, "Chocobo Sage's Greens Store" },
            { 54, "Upper Junon Weapon Shop #1 (Disc 2)" },
            { 55, "Upper Junon Item Shop (Disc 2)" },
            { 57, "Upper Junon Weapon Shop #2 (Disc 2)" },
            { 58, "Upper Junon Accessory Shop (Disc 2)" },
            { 59, "Upper Junon Materia Shop #2 (Disc 2)" },
            { 60, "Costa Del Sol Weapon Shop (Disc 2)" },
            { 61, "Costa Del Sol Materia Shop (Disc 2)" },
            { 62, "Costa Del Sol Item Shop (Disc 2)" },
            { 63, "Rocket Town Weapon Shop (Disc 2)" },
            { 64, "Rocket Town Item Shop (Disc 2)" },
            { 65, "Bone Village Shop" }
        }.AsReadOnly();
    }
}
