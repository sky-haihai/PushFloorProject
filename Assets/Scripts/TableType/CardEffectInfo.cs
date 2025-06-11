using System;
using XiheFramework.Utility.Csv2Json;

namespace TableType {
    [Serializable]
    public class CardEffectInfo : ICsvInfo {
        public int id;
        public string name;
        public string description;
    }
}