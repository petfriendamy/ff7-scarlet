using FF7Scarlet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.AIEditor
{
    public enum ParameterTypes
    {
        None, OneByte, TwoByte, ThreeByte, String, Debug, ReadWrite, Label, Other
    }

    public enum ParameterValidData
    {
        None, Hex, String
    }

    public class ParameterInfo
    {
        public static readonly ParameterInfo[] PARAMETER_LIST = new ParameterInfo[]
        {
            new ParameterInfo(ParameterTypes.None, ParameterValidData.None, 0),
            new ParameterInfo(ParameterTypes.OneByte, ParameterValidData.Hex, 1),
            new ParameterInfo(ParameterTypes.TwoByte, ParameterValidData.Hex, 2),
            new ParameterInfo(ParameterTypes.ThreeByte, ParameterValidData.Hex, 3),
            new ParameterInfo(ParameterTypes.String, ParameterValidData.String, 0),
            new ParameterInfo(ParameterTypes.Debug, ParameterValidData.String, 0),
            new ParameterInfo(ParameterTypes.ReadWrite, ParameterValidData.Hex, 2),
            new ParameterInfo(ParameterTypes.Label, ParameterValidData.Hex, 2),
            new ParameterInfo(ParameterTypes.Other, ParameterValidData.Hex, 0)
        };

        public ParameterTypes Type { get; }
        public ParameterValidData ValidData { get; }
        public int MaxLength { get; }

        public ParameterInfo(ParameterTypes type, ParameterValidData validData, int maxLength)
        {
            Type = type;
            ValidData = validData;
            MaxLength = maxLength;
        }

        public static ParameterInfo? GetInfo(ParameterTypes type)
        {
            foreach (var p in PARAMETER_LIST)
            {
                if (p.Type == type) { return p; }
            }
            return null;
        }

        public bool IsValid(byte[] data)
        {
            switch (ValidData)
            {
                case ParameterValidData.None:
                    return false;
                case ParameterValidData.Hex:
                    if (data.Length == 0)
                    {
                        return false;
                    }
                    break;
            }
            int? temp = data.Length;
            if (MaxLength > 0 && data.Length > ((MaxLength * 2) + 1)) { return false; }
            return true;
        }

        public static bool IsValid(ParameterTypes type, byte[] data)
        {
            var info = GetInfo(type);
            if (info == null) { return false; }
            return info.IsValid(data);
        }
    }
}
