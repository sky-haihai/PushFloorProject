using System;
using XiheFramework.Utility.Csv2Json;

namespace Buff {
    [Serializable]
    public class BuffInfo: ICsvInfo {
        public uint id;
        public string name;
        public string description;
    }
}