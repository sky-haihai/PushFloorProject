using UnityEngine;
using XiheFramework.Runtime.Base;

namespace Player {
    public class PlayerModule : GameModuleBase {
        public override int Priority => (int)CoreModulePriority.CustomModuleDefault;

        protected override void OnInstantiated() {
            base.OnInstantiated();
        }
    }
}
