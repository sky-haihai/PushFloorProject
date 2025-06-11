using System;
using XiheFramework.Utility.Csv2Json;

namespace TableType {
    [Serializable]
    public class CardInfo: ICsvInfo {
        public int id;
        public string name;
        public string description;
        public string cardCommand;
    }
}