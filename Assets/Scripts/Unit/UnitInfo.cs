using System;
using XiheFramework.Utility.Csv2Json;

namespace Unit {
    [Serializable]
    public class UnitInfo : ICsvInfo {
        public uint id;
        public string name;
        public string description;
        public string attack;
    }
}