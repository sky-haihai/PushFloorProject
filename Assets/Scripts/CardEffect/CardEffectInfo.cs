using System;
using XiheFramework.Utility.Csv2Json;

namespace CardEffect {
    [Serializable]
    public class CardEffectInfo : ICsvInfo {
        public uint id;
        public string name;
        public string description;
    }
}