using XiheFramework.Runtime.FSM;

namespace GameLoop.PushFloorFsm {
    public class EnvironmentTurnState: State<MainGameState> {
        public EnvironmentTurnState(StateMachine parentStateMachine, string stateName, MainGameState owner) : base(parentStateMachine, stateName, owner) { }
        protected override void OnEnterCallback() {
        }

        protected override void OnUpdateCallback() {
        }

        protected override void OnExitCallback() {
        }
    }
}