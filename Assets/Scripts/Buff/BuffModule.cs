using UnityEngine;
using XiheFramework.Runtime.Base;

namespace Buff {
    public class BuffModule : GameModuleBase {
        public override int Priority => (int)CoreModulePriority.CustomModuleDefault;
    }
}