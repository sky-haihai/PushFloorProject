using System.Collections.Generic;
using GameConstant;
using UnityEngine;
using XiheFramework.Runtime;
using XiheFramework.Runtime.Blackboard;

namespace Card {
    public class CardBlackboard : IBlackboard {
        public Dictionary<uint, CardInfo> CardInfoList { get; set; }

        public void OnCreated() {
            CardInfoList = new Dictionary<uint, CardInfo>();
        }

        public void OnRelease() { }
    }
}