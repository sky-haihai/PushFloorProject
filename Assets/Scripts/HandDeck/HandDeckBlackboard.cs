using System.Collections.Generic;
using XiheFramework.Runtime.Blackboard;

namespace HandDeck {
    public class HandDeckBlackboard : IBlackboard {
        public List<uint> currentCardList = new List<uint>();
        public void OnCreated() { }

        public void OnRelease() { }
    }
}