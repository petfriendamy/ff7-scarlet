namespace KimeraCS.Core
{
    public enum ModelType
    {
        // This will tell to all the tool which type of skeleton/model we have loaded
        // Possible values:
        // -1: Error (file not exists, error opening file...)
        //  0: Field P Model
        //  1: Battle P Model
        //  2: Magic P Model
        //  3: Field Skeleton
        //  4: Battle Skeleton
        //  5: Magic Skeleton
        //  6: 3DS Model
        K_NONE = -1,
        K_P_FIELD_MODEL = 0,
        K_P_BATTLE_MODEL = 1,
        K_P_MAGIC_MODEL = 2,
        K_HRC_SKELETON = 3,
        K_AA_SKELETON = 4,
        K_MAGIC_SKELETON = 5,
        K_3DS_MODEL = 6
    }
}
