using UnityEngine;
using XiheFramework.Runtime.Base;

namespace Player {
    public class PlayerModule : GameModuleBase {
        public override int Priority => (int)CoreModulePriority.CustomModuleDefault;

        public int CurrentPlayerMaxActionCount { get; set; } = 5;

        protected override void OnInstantiated() {
            base.OnInstantiated();

            ThisGame.Player = this;
        }
    }
}