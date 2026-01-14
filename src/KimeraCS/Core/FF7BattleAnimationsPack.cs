//  STRUCT BATTLE ANIMATION ??DA
//
//  MAIN ??DA HEADER
//  4 bytes                 NumAnims
//  NumAnims*               ANIM HEADER
//  
//  ANIM HEADER
//  4 bytes                 NumBones + 1
//  4 bytes                 numFrames
//  4 bytes                 blockSize;
//  ANIM HEADER SHORT (Array has Padding to 4 bytes)
//  2 bytes                 numFramesShort
//  2 bytes                 blockSizeShort
//  1 byte                  key
//  blockSizeShort* byte    framesRawData;
//  n * bytes               padding at 4 bytes      padding calculation = (4 - (blockSizeShort + 5) % 4)) % 4    - the padding is of 4 bytes
//                                                  padding reading = (blockSize - blockSizeShort) - 5

using System.Runtime.InteropServices;

namespace KimeraCS.Core
{
    using static FF7BattleSkeleton;
    using static FF7BattleAnimation;

    public static class FF7BattleAnimationsPack
    {
        //  Battle animations notes by L.Spiro and Qhimm:
        //  http://wiki.qhimm.com/FF7/Battle/Battle_Animation_(PC)
        //  Weapon animations notes by seb:
        //  http://forums.qhimm.com/index.php?topic=7185.0

        public const int MAX_BATTLEANIMATION_SIZE = 0xFFFFF;

        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct BattleAnimationsPack
        {

            public int nAnimations;
            public int nbSkeletonAnims;
            public int nbWeaponAnims;
            public List<BattleAnimation> SkeletonAnimations;
            public List<BattleAnimation> WeaponAnimations;
            public bool IsLimit;
            public readonly bool WrongAnimationCount;

            public BattleAnimationsPack(BattleSkeleton bSkeleton, ModelType modelType, byte[] data, string strFileName)
            {
                string strBattleAnimPackFileName;
                string strAnimsPackFullFileName;                             

                nAnimations = 0;
                nbSkeletonAnims = 0;
                nbWeaponAnims = 0;
                IsLimit = false;

                SkeletonAnimations = new List<BattleAnimation>();
                WeaponAnimations = new List<BattleAnimation>();

                if (bSkeleton.IsBattleLocation)
                {
                    CreateEmptyBattleAnimationsPack(ref this, bSkeleton.nBones + 1);
                }
                else
                {
                    switch (modelType)
                    {
                        case ModelType.K_AA_SKELETON:
                            if (Path.GetExtension(strFileName).Length == 4)
                                strBattleAnimPackFileName = Path.GetFileName(strFileName).ToUpper();
                            else
                            {
                                // Let's check if we are opening all the model or only loading an animation
                                if (Path.GetFileName(strFileName).ToUpper().EndsWith("AA"))
                                    strBattleAnimPackFileName = Path.GetFileNameWithoutExtension(strFileName).Substring(0, 2).ToUpper() + "DA";
                                else
                                    strBattleAnimPackFileName = Path.GetFileNameWithoutExtension(strFileName).ToUpper();
                            }
                            break;

                        default:
                            strBattleAnimPackFileName = Path.GetFileNameWithoutExtension(strFileName).ToUpper() + ".A00";
                            break;
                    }


                    strAnimsPackFullFileName = Path.GetDirectoryName(strFileName) + "\\" + strBattleAnimPackFileName;

                    if (data.Length > 0)
                    {
                        int result = LoadBattleAnimationsPack(data, strAnimsPackFullFileName,
                                bSkeleton.nBones, bSkeleton.nsSkeletonAnims, bSkeleton.nsWeaponsAnims,
                                bSkeleton, ref this);
                        WrongAnimationCount = result == 1;
                    }
                }
            }
        }

        public static int LoadBattleAnimationsPack(byte[] data, string strAnimsPackFullFileName,
                                                   int nsSkeletonBones, int nsSkeletonAnims,
                                                   int nsWeaponsAnims,
                                                   BattleSkeleton bSkeleton,
                                                   ref BattleAnimationsPack bAnimationsPack)
        {
            int ai, result = 0;
            //  Debug.Print "Loadng animations pack " + fileName
            //  Debug.Print "Reading pack "; fileName

            try
            {
                // Work with memory file
                using (var fileMemory = new MemoryStream(data))
                {
                    using (var memReader = new BinaryReader(fileMemory))
                    {
                        bAnimationsPack.nAnimations = memReader.ReadInt32();

                        if (nsSkeletonAnims > bAnimationsPack.nAnimations)
                        {
                            // Auto-fix: Animation pack has fewer animations than skeleton header expects
                            nsSkeletonAnims = bAnimationsPack.nAnimations;
                            result = 1;

                            if (!bAnimationsPack.IsLimit) bSkeleton.nsSkeletonAnims = nsSkeletonAnims;
                        }


                        bAnimationsPack.nbSkeletonAnims = nsSkeletonAnims;
                        bAnimationsPack.nbWeaponAnims = nsWeaponsAnims;

                        bAnimationsPack.SkeletonAnimations = new List<BattleAnimation>();
                        bAnimationsPack.WeaponAnimations = new List<BattleAnimation>();
                        //  Debug.Print "Loading "; .NumAnimations; " animations."

                        for (ai = 0; ai < bAnimationsPack.nbSkeletonAnims; ai++)
                        {
                            //  Debug.Print "anim "; ai
                            //  Debug.Print "Body Animation "; Str$(ai)
                            //iVectorBones = 1;
                            //if (nBones > 1) iVectorBones = nBones + 1;
                            //bAnimationsPack.SkeletonAnimations.Add(new BattleAnimation(memReader, fileBuffer, iVectorBones));
                            bAnimationsPack.SkeletonAnimations.Add(new BattleAnimation(memReader, nsSkeletonBones));
                        }

                        for (ai = 0; ai < bAnimationsPack.nbWeaponAnims; ai++)
                        {
                            //  Debug.Print "anim "; ai
                            //  Debug.Print "Weapon Animation "; Str$(ai)
                            //iVectorBones = 1;
                            //if (nBones > 1) iVectorBones = nBones + 1;
                            //bAnimationsPack.WeaponAnimations.Add(new BattleAnimation(memReader, fileBuffer, 1));
                            bAnimationsPack.WeaponAnimations.Add(new BattleAnimation(memReader, 1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Error reading Battle Animation Pack file " + Path.GetFileName(strAnimsPackFullFileName) + ".",
                                            strAnimsPackFullFileName, ex);
            }
            return result;
        }



        //  ---------------------------------------------------------------------------------------------------
        //  ================================== CREATE EMPTY BATTLE ANIMATION ==================================
        //  ---------------------------------------------------------------------------------------------------
        public static void CreateEmptyBattleAnimationsPack(ref BattleAnimationsPack bAnimationsPack, int nBones)
        {
            BattleAnimation tmpbAnimation;

            bAnimationsPack.nAnimations = 1;
            bAnimationsPack.nbSkeletonAnims = 1;
            bAnimationsPack.nbWeaponAnims = 1;

            tmpbAnimation = new BattleAnimation();
            CreateEmptyBattleAnimation(ref tmpbAnimation, nBones);

            bAnimationsPack.SkeletonAnimations.Add(tmpbAnimation);
            bAnimationsPack.WeaponAnimations.Add(tmpbAnimation);
        }



        //  ---------------------------------------------------------------------------------------------------
        //  =============================== CREATE COMPATIBLE BATTLE ANIMATION ================================
        //  ---------------------------------------------------------------------------------------------------
        public static void CreateCompatibleBattleAnimationsPack(BattleSkeleton bSkeleton, ref BattleAnimationsPack bAnimationsPack)
        {
            BattleAnimation tmpbAnimation;

            bAnimationsPack.nAnimations = 1;
            bAnimationsPack.nbSkeletonAnims = 1;
            bAnimationsPack.nbWeaponAnims = 1;

            tmpbAnimation = new BattleAnimation();
            CreateCompatibleBattleAnimation(bSkeleton, ref tmpbAnimation);
            bAnimationsPack.SkeletonAnimations.Add(tmpbAnimation);

            tmpbAnimation = new BattleAnimation();
            CreateCompatibleBattleAnimation(bSkeleton, ref tmpbAnimation);
            bAnimationsPack.WeaponAnimations.Add(tmpbAnimation);
        }
    }
}
