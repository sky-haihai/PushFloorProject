using XiheFramework.Runtime;
using XiheFramework.Runtime.FSM;

namespace GameLoop.PushFloor {
    public class PrepareDataState : State<MainGameState> {
        public PrepareDataState(StateMachine parentStateMachine, string stateName, MainGameState owner) : base(parentStateMachine, stateName, owner) { }

        protected override void OnEnterCallback() {
            var pushFloorBlackboard = Game.Blackboard.CreateBlackboard<PushFloorBlackboard>("PushFloorBlackboard");
            pushFloorBlackboard.PlayerTurnRemainingActionCount = ThisGame.Player.CurrentPlayerMaxActionCount;
        }

        protected override void OnUpdateCallback() { }

        protected override void OnExitCallback() { }
    }
}