using XiheFramework.Runtime.FSM;

namespace GameLoop.PushFloor {
    public class EnvironmentTurnState: State<MainGameState> {
        public EnvironmentTurnState(StateMachine parentStateMachine, string stateName, MainGameState owner) : base(parentStateMachine, stateName, owner) { }
        protected override void OnEnterCallback() {
            throw new System.NotImplementedException();
        }

        protected override void OnUpdateCallback() {
            throw new System.NotImplementedException();
        }

        protected override void OnExitCallback() {
            throw new System.NotImplementedException();
        }
    }
}