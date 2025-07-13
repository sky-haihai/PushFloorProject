using XiheFramework.Runtime.FSM;

namespace GameLoop.PushFloorFsm {
    public class GameOverState: State<MainGameState> {
        public GameOverState(StateMachine parentStateMachine, string stateName, MainGameState owner) : base(parentStateMachine, stateName, owner) { }
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