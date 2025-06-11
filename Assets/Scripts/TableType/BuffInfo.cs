using System;
using XiheFramework.Utility.Csv2Json;

namespace TableType {
    [Serializable]
    public class BuffInfo: ICsvInfo {
        public int id;
        public string name;
        public string description;
    }
}