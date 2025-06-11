using UnityEngine;
using XiheFramework.Runtime.Base;

namespace Card {
    public class CardModule : GameModuleBase {
        public override int Priority => (int)CoreModulePriority.Default;
    }
}