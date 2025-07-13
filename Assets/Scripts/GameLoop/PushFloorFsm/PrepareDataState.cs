using GameConstant;
using XiheFramework.Runtime;
using XiheFramework.Runtime.FSM;

namespace GameLoop.PushFloorFsm {
    public class PrepareDataState : State<MainGameState> {
        public PrepareDataState(StateMachine parentStateMachine, string stateName, MainGameState owner) : base(parentStateMachine, stateName, owner) { }

        protected override void OnEnterCallback() {
            var pushFloorBlackboard = Game.Blackboard.CreateBlackboard<PushFloorBlackboard>("PushFloorBlackboard");
            pushFloorBlackboard.PlayerTurnRemainingActionCount = ThisGame.Player.CurrentPlayerMaxActionCount;
        }

        protected override void OnUpdateCallback() {
            ChangeState(PushFloorGameStates.PlayerTurnState);
        }

        protected override void OnExitCallback() { }
    }
}