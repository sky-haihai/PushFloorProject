using System;
using XiheFramework.Utility.Csv2Json;

namespace Card {
    [Serializable]
    public class CardInfo: ICsvInfo {
        public uint id;
        public string name;
        public string description;
        public string cardCommand;
    }
}