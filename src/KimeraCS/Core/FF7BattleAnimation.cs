using System.Diagnostics;
using OpenTK.Graphics.OpenGL.Compatibility;
using OpenTK.Mathematics;

namespace KimeraCS.Core
{

    using static FF7BattleSkeleton;
    using static Utils;


    public static class FF7BattleAnimation
    {

        public struct BattleFrameBone
        {
            public short accumAlphaS;
            public short accumBetaS;
            public short accumGammaS;

            public int accumAlpha;
            public int accumBeta;
            public int accumGamma;

            public float alpha;
            public float beta;
            public float gamma;            

            public BattleFrameBone(float alphaIn, float betaIn, float gammaIn)
            {
                accumAlphaS = 0;
                accumBetaS = 0;
                accumGammaS = 0;

                accumAlpha = 0;
                accumBeta = 0;
                accumGamma = 0;

                alpha = alphaIn;
                beta = betaIn;
                gamma = gammaIn;
            }
        }

        public struct BattleFrame
        {
            public int startX;
            public int startY;
            public int startZ;
            public List<BattleFrameBone> bones;

            //public BattleFrame(byte[] framesRawData, byte key, int blockSizeShort, int nBones, ref ushort numFramesShort)
            //{
            //    startX = 0;
            //    startY = 0;
            //    startZ = 0;

            //    bones = new List<BattleFrameBone>();
            //}
        }

        public struct BattleAnimation
        {

            //  ANIM HEADER
            public int nBones;                //  Number of bones for the model + 1 (root transformation). Unreliable.
            public int numFrames;             //  Number of frames (conservative). Usually wrong (smaller than the actual number).
            public int blockSize;             //  This is sizeOf(blockSizeShort + 5 bytes of ANIM HEADER SHORT + padding bytes (at 4 bytes)).

            //  ANIM HEADER SHORT(Array has Padding to 4 bytes)
            public ushort numFramesShort;     //  Number of frames. Usually wrong (higher than the actual number).
            public ushort blockSizeShort;     //  OLD COMMENT: 'Don't use this field EVER.It would be interpreted as a signed value.
                                              //  OLD VB6: int animationLengthLong;    //    AnimationLengthLong As Long     'This isn't part of the actual structure, it's used just to overcome the lack of unsigned shorts support
            public byte key;
            public byte[] framesRawData;
            public byte[] padding4bytes;

            //public bool missingNumFramesShort;    //  The animation has no secondary frames count. Only RSAA/RSDA seems to use it.
            public List<BattleFrame> frames;
            //public byte[] unknownData;

            //public BattleAnimation(BinaryReader memReader, byte[] fileBuffer, int iVectorBonesLen)
            public BattleAnimation(BinaryReader memReader, int nsSkeletonBones)
            {
                BattleFrame tmpbFrame;
                int offsetBit, fi;

                //  ANIM HEADER
                nBones = memReader.ReadInt32();

                // We will check the number of bones of Skeleton and the number of bones of the animation
                // The number of bones of the skeleton will have precedence if it is one '1'.
                if (nsSkeletonBones == 1) nBones = 1;

                numFrames = memReader.ReadInt32();
                blockSize = memReader.ReadInt32();

                //  ANIM HEADER SHORT(Array has Padding to 4 bytes) - This is partial init of vars. We will read data from fileBuffer.
                numFramesShort = 0;
                blockSizeShort = 0;
                key = 0;

                framesRawData = Array.Empty<byte>();
                padding4bytes = Array.Empty<byte>();

                //missingNumFramesShort = false;
                frames = new List<BattleFrame>();

                if (blockSize > 11)
                {
                    //  ANIM HEADER SHORT(Array has Padding to 4 bytes)
                    numFramesShort = memReader.ReadUInt16();

                    //  Let's use this to correct the missing numFramesShort in vanilla RSAA/Frog Enemy(frame 14) ushort value
                    if (blockSize - 5 == numFramesShort)
                    {
                        blockSizeShort = numFramesShort;
                        blockSize += 2;
                        numFramesShort = (ushort)numFrames;
                    }
                    else
                    {
                        blockSizeShort = memReader.ReadUInt16();
                    }

                    key = memReader.ReadByte();

                    framesRawData = new byte[blockSizeShort];
                    framesRawData = memReader.ReadBytes(blockSizeShort);

                    padding4bytes = new byte[(blockSize - blockSizeShort) - 5];
                    padding4bytes = memReader.ReadBytes((blockSize - blockSizeShort) - 5);

                    frames = new List<BattleFrame>();

                    // Now we need to work with the animRawDataBlock and get the frames
                    tmpbFrame = new BattleFrame();

                    offsetBit = 0;
                    //  Debug.Print "   -First frame at byte" + Str$(offset + 17)
                    //  Debug.Print "   Frame 0"
                    ProcessBattleUncompressedFrame(framesRawData, ref offsetBit, key, nBones, ref tmpbFrame);
                    frames.Add(tmpbFrame);

                    for (fi = 1; fi < numFramesShort; fi++)
                    {
                        //  If we ran out of data while reading the frame, it means this frame doesn't
                        //last_offsetBit = offsetBit;
                        tmpbFrame = new BattleFrame();
                        if (!ProcessBattleFrame(framesRawData, ref offsetBit, key, nBones, ref tmpbFrame, frames[fi - 1]))
                        {
                            numFramesShort = (ushort)fi;
                            break;
                        }
                        frames.Add(tmpbFrame);
                    }
                }
                else
                {
                    framesRawData = new byte[blockSize];
                    framesRawData = memReader.ReadBytes(blockSize);
                }
            }
        }


        //  ---------------------------------------------------------------------------------------------------
        //  =========================== READ COMPRESSED FRAME ANIMATION FUNCTIONS =============================
        //  ---------------------------------------------------------------------------------------------------
        public static int ProcessBattleFrameBoneRotationDelta(byte[] framesRawData, ref int offsetBit, byte key)
        {
            int dLen, iVal, itmpSignVal;
            int iProcessBattleFrameBoneRotationDeltaResult = 0;

            if ((short)GetBitBlockVUnsigned(framesRawData, 1, ref offsetBit) == 1)
            {
                dLen = (short)GetBitBlockVUnsigned(framesRawData, 3, ref offsetBit);

                switch (dLen)
                {
                    case 0:
                        //  Minimum bone rotation decrement
                        iVal = -1;
                        break;

                    case 7:
                        //  Just like the first frame
                        iVal = (short)GetBitBlockV(framesRawData, 12 - key, ref offsetBit);
                        break;

                    default:
                        iVal = (short)GetBitBlockV(framesRawData, dLen, ref offsetBit);

                        //  Invert the value of the last bit
                        itmpSignVal = (int)Math.Pow(2, dLen - 1);

                        if (iVal < 0) iVal -= itmpSignVal;
                        else iVal += itmpSignVal;
                        break;
                }

                //  Convert to 12-bits value
                iVal *= (int)Math.Pow(2, key);
                iProcessBattleFrameBoneRotationDeltaResult = iVal;
            }

            return iProcessBattleFrameBoneRotationDeltaResult;
        }

        //  For bone rotations of all the other frames
        public static void ProcessBattleFrameBone(byte[] framesRawData, ref int offsetBit, byte key, ref BattleFrameBone bBone, BattleFrameBone lastbBone)
        {
            bBone.accumAlphaS = (short)(lastbBone.accumAlphaS + ProcessBattleFrameBoneRotationDelta(framesRawData, ref offsetBit, key));
            bBone.accumBetaS = (short)(lastbBone.accumBetaS + ProcessBattleFrameBoneRotationDelta(framesRawData, ref offsetBit, key));
            bBone.accumGammaS = (short)(lastbBone.accumGammaS + ProcessBattleFrameBoneRotationDelta(framesRawData, ref offsetBit, key));

            bBone.accumAlpha = (bBone.accumAlphaS < 0 ? bBone.accumAlphaS + 0x1000 : bBone.accumAlphaS);
            bBone.accumBeta = (bBone.accumBetaS < 0 ? bBone.accumBetaS + 0x1000 : bBone.accumBetaS);
            bBone.accumGamma = (bBone.accumGammaS < 0 ? bBone.accumGammaS + 0x1000 : bBone.accumGammaS);

            bBone.alpha = GetDegreesFromRaw(bBone.accumAlpha, 0);
            bBone.beta = GetDegreesFromRaw(bBone.accumBeta, 0);
            bBone.gamma = GetDegreesFromRaw(bBone.accumGamma, 0);            
        }

        public static bool ProcessBattleFrame(byte[] framesRawData, ref int offsetBit, byte key, int nBones, ref BattleFrame bFrame, BattleFrame lastbFrame)
        {
            int bi, oi, offsetLen = 0;
            bool bProcessBattleFrameResult;
            BattleFrameBone tmpbFrameBone;

            try
            {
                for (oi = 0; oi < 3; oi++)
                {
                    switch ((short)GetBitBlockV(framesRawData, 1, ref offsetBit) & 1)
                    {
                        case 0:
                            offsetLen = 7;
                            break;

                        case 1:
                            offsetLen = 16;
                            break;

                        default:
                            //  Debug.Print "What?!"
                            break;
                    }

                    switch (oi)
                    {
                        case 0:
                            bFrame.startX = (short)GetBitBlockV(framesRawData, offsetLen, ref offsetBit) + lastbFrame.startX;
                            break;

                        case 1:
                            bFrame.startY = (short)GetBitBlockV(framesRawData, offsetLen, ref offsetBit) + lastbFrame.startY;
                            break;

                        case 2:
                            bFrame.startZ = (short)GetBitBlockV(framesRawData, offsetLen, ref offsetBit) + lastbFrame.startZ;
                            break;

                        default:
                            //  Debug.Print "What?!"
                            break;
                    }
                }

                //  Debug.Print "       Position delta "; Str$(.X_start); ", "; Str$(.Y_start); ", "; Str$(.Z_start)
                bFrame.bones = new List<BattleFrameBone>();
                for (bi = 0; bi < nBones; bi++)
                {
                    //  Debug.Print "       Bone "; Str$(bi)
                    tmpbFrameBone = new BattleFrameBone();
                    ProcessBattleFrameBone(framesRawData, ref offsetBit, key, ref tmpbFrameBone, lastbFrame.bones[bi]);
                    bFrame.bones.Add(tmpbFrameBone);
                }

                //  Debug.Print "diff: "; offsetBit - aux
                bProcessBattleFrameResult = true;
            }
            catch
            {
                bProcessBattleFrameResult = false;
            }

            return bProcessBattleFrameResult;
        }
    


        //  ---------------------------------------------------------------------------------------------------
        //  ========================== READ UNCOMPRESSED FRAME ANIMATION FUNCTIONS ============================
        //  ---------------------------------------------------------------------------------------------------
        //  For raw rotations
        public static short ProcessBattleUncompressedFrameBoneRotation(byte[] framesRawData, ref int offsetBit, byte key)
        {
            int iVal;

            iVal = (short)GetBitBlockV(framesRawData, 12 - key, ref offsetBit);

            //  Convert to 12-bit value
            iVal *= (short)Math.Pow(2, key);

            return (short)iVal;
        }

        //  For bone rotations of the first frame
        public static void ProcessBattleUncompressedFrameBone(byte[] framesRawData, ref int offsetBit, byte key, ref BattleFrameBone bBone)
        {
            bBone.accumAlphaS = ProcessBattleUncompressedFrameBoneRotation(framesRawData, ref offsetBit, key);
            bBone.accumBetaS = ProcessBattleUncompressedFrameBoneRotation(framesRawData, ref offsetBit, key);
            bBone.accumGammaS = ProcessBattleUncompressedFrameBoneRotation(framesRawData, ref offsetBit, key);

            bBone.accumAlpha = (bBone.accumAlphaS < 0 ? bBone.accumAlphaS + 0x1000 : bBone.accumAlphaS);
            bBone.accumBeta = (bBone.accumBetaS < 0 ? bBone.accumBetaS + 0x1000 : bBone.accumBetaS);
            bBone.accumGamma = (bBone.accumGammaS < 0 ? bBone.accumGammaS + 0x1000 : bBone.accumGammaS);

            bBone.alpha = GetDegreesFromRaw(bBone.accumAlpha, 0);
            bBone.beta = GetDegreesFromRaw(bBone.accumBeta, 0);
            bBone.gamma = GetDegreesFromRaw(bBone.accumGamma, 0);
        }

        public static void ProcessBattleUncompressedFrame(byte[] framesRawData, ref int offsetBit, byte key, int nBones, ref BattleFrame bFrame)
        {
            //int bi, tmpOffsetBit;
            int bi;
            BattleFrameBone bBone;

            //tmpOffsetBit = offsetBit;

            //  .BonesVectorLength = BonesVectorLength ' + IIf(NumBones = 1, 0, 1)
            //  NumBones = IIf(NumBones = 2, 1, NumBones)  'Some single bone models have bones counter of 2 instead of 1, so adjust the value for convenience.

            bFrame.startX = (short)GetBitBlockV(framesRawData, 16, ref offsetBit);
            bFrame.startY = (short)GetBitBlockV(framesRawData, 16, ref offsetBit);
            bFrame.startZ = (short)GetBitBlockV(framesRawData, 16, ref offsetBit);

            bFrame.bones = new List<BattleFrameBone>();

            for (bi = 0; bi < nBones; bi++)
            {
                bBone = new BattleFrameBone();
                //  Debug.Print "       Bone "; Str$(bi)
                ProcessBattleUncompressedFrameBone(framesRawData, ref offsetBit, key, ref bBone);
                bFrame.bones.Add(bBone);
            }
            //  Debug.Print "diff: "; offsetBit - aux
        }



        //  ---------------------------------------------------------------------------------------------------
        //  ============================= CREATE EMPTY BATTLE/WEAPON/MAGIC ANIMATION ==========================
        //  ---------------------------------------------------------------------------------------------------
        public static void CreateEmptyBattleAnimation(ref BattleAnimation bAnimation, int nBones)
        {
            BattleFrame tmpbFrame;
            BattleFrameBone tmpbFrameBone;
            int bi;

            bAnimation.nBones = nBones;
            bAnimation.numFrames = 1;
            bAnimation.numFramesShort = 1;
            bAnimation.blockSize = 0;
            bAnimation.blockSizeShort = 0;

            bAnimation.key = 0;

            tmpbFrameBone = new BattleFrameBone()
            {
                accumAlpha = 0,
                accumBeta = 0,
                accumGamma = 0,

                alpha = 0,
                beta = 0,
                gamma = 0,
            };

            tmpbFrame = new BattleFrame()
            {
                startX = 0,
                startY = 0,
                startZ = 0,

                bones = new List<BattleFrameBone>(),
            };

            for (bi = 0; bi < nBones; bi++)
                tmpbFrame.bones.Add(tmpbFrameBone);
            
            bAnimation.frames = new List<BattleFrame>() { tmpbFrame };           
            //bAnimation.frames.Add(tmpbFrame);
        }



        //  ---------------------------------------------------------------------------------------------------
        //  =============================== CREATE COMPATIBLE BATTLE ANIMATION ================================
        //  ---------------------------------------------------------------------------------------------------
        public static void CreateCompatibleBattleAnimationFrame(BattleSkeleton bSkeleton, ref BattleFrame bFrame)
        {
            int bi, jsp, jsp0, stageIndex;
            //string[] joint_stack = new string[bSkeleton.nBones];
            int[] joint_stack = new int[bSkeleton.nBones + 1];
            float hipArmAngle = 0, c1, c2;
            BattleFrameBone tmpbFrameBone;

            jsp = 0;
            jsp0 = 0;

            joint_stack[jsp] = -1;

            stageIndex = 1;

            // 1st Bone Frame
            tmpbFrameBone = new BattleFrameBone()
            {
                alpha = 90,
                beta = 0,
                gamma = 0,

                accumAlpha = 0,
                accumBeta = 0,
                accumGamma = 0,
            };

            bFrame.bones.Add(tmpbFrameBone);

            for (bi = 0; bi < bSkeleton.nBones; bi++)
            {
                tmpbFrameBone = new BattleFrameBone();

                //while (!(bSkeleton.bones[bi].parentBone.ToString() == joint_stack[jsp]) && jsp > 0)
                while (!(bSkeleton.bones[bi].parentBone == joint_stack[jsp]) && jsp > 0)
                {
                    GL.PopMatrix();
                    jsp--;
                }

                if (jsp0 > jsp) stageIndex++;
                //  Debug.Print obj.Bones(bi + 1).ParentBone, bi, jsp, StageIndex

                switch (stageIndex)
                {
                    case 1:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        if (bi == 1) stageIndex = 2;
                        break;
                    case 2:
                        tmpbFrameBone.alpha = -145;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 3;
                        break;
                    case 3:
                        if (jsp > jsp0)
                        {
                            tmpbFrameBone.alpha = 0;
                            tmpbFrameBone.beta = 0;
                            tmpbFrameBone.gamma = 0;
                        }
                        else
                        {
                            tmpbFrameBone.alpha = -180;
                            tmpbFrameBone.beta = 0;
                            tmpbFrameBone.gamma = 180;
                            stageIndex = 5;

                        }
                        break;
                    case 4:
                        tmpbFrameBone.alpha = -180;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 180;
                        stageIndex = 5;
                        break;
                    case 5:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = 90;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 6;
                        break;
                    case 6:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = -60;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 7;
                        break;
                    case 7:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 8;
                        break;
                    case 8:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 9;
                        break;
                    case 9:
                        tmpbFrameBone.alpha = -90;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 10;
                        break;
                    case 10:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        break;
                    case 11:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = -90;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 12;
                        break;
                    case 12:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = 60;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 13;
                        break;
                    case 13:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 14;
                        break;
                    case 14:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 15;
                        break;
                    case 15:
                        tmpbFrameBone.alpha = -90;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 16;
                        break;
                    case 16:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        break;
                    case 17:
                        c1 = (float)(bSkeleton.bones[bi + 1].len - (bSkeleton.bones[bi].len * 0.01));
                        c2 = (float)(Math.Sqrt(Math.Pow(bSkeleton.bones[bi + 1].len, 2) - Math.Pow(c1, 2)));
                        hipArmAngle = (float)(Math.Atan(c2 / c1) / PI_180);

                        if (float.IsNaN(hipArmAngle) || float.IsInfinity(hipArmAngle)) hipArmAngle = 0;

                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = hipArmAngle;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 18;
                        break;
                    case 18:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = -hipArmAngle - 90;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 19;
                        break;
                    case 19:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        break;
                    case 20:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = -hipArmAngle;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 21;
                        break;
                    case 21:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = hipArmAngle + 90;
                        tmpbFrameBone.gamma = 0;
                        stageIndex = 22;
                        break;
                    case 22:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        break;
                    case 23:
                        tmpbFrameBone.alpha = 90;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        break;

                    default:
                        tmpbFrameBone.alpha = 0;
                        tmpbFrameBone.beta = 0;
                        tmpbFrameBone.gamma = 0;
                        break;
                }

                if (bi == 0) tmpbFrameBone.gamma = 180;
                bFrame.bones.Add(tmpbFrameBone);

                jsp0 = jsp;
                jsp++;

                //joint_stack[jsp] = bi.ToString();
                joint_stack[jsp] = bi;
            }
        }

        public static void CreateCompatibleBattleAnimation(BattleSkeleton bSkeleton, ref BattleAnimation bAnimation)
        {
            BattleFrame tmpbFrame;

            bAnimation.nBones = bSkeleton.nBones;
            bAnimation.numFrames = 1;
            bAnimation.blockSize = 0;
            bAnimation.numFramesShort = 1;
            bAnimation.blockSizeShort = 0;
            bAnimation.key = 0;
            //bAnimation.missingNumFramesShort = false;
            bAnimation.frames = new List<BattleFrame>();

            tmpbFrame = new BattleFrame()
            {
                startX = 0,
                startY = 0,
                startZ = 0,

                bones = new List<BattleFrameBone>(),
            };

            CreateCompatibleBattleAnimationFrame(bSkeleton, ref tmpbFrame);
            bAnimation.frames.Add(tmpbFrame);
        }
    }
}
