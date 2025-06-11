using System;
using XiheFramework.Utility.Csv2Json;

namespace TableType {
    [Serializable]
    public class UnitInfo:ICsvInfo {
        public int id;
        public string name;
        public string description;
        public string attack;
    }
}