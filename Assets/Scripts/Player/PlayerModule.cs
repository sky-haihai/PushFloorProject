using UnityEngine;
using XiheFramework.Runtime;
using XiheFramework.Runtime.Base;

namespace Player {
    public class PlayerModule : GameModuleBase {
        public override int Priority => (int)CoreModulePriority.CustomModuleDefault;

        public int CurrentPlayerMaxActionCount { get; set; } = 5;

        public PlayerBlackboard playerBlackboard;

        public void ResetPlayerActionPointToMax() {
            playerBlackboard.currentActionPoint = CurrentPlayerMaxActionCount;
        }

        protected override void OnInstantiated() {
            base.OnInstantiated();

            playerBlackboard= Game.Blackboard.CreateBlackboard<PlayerBlackboard>("PlayerModule_PlayerBlackboard");
            ThisGame.Player = this;
        }
    }
}