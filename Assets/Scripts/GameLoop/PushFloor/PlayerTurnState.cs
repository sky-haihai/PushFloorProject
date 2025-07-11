using Player;
using XiheFramework.Runtime.FSM;

namespace GameLoop.PushFloor {
    public class PlayerTurnState : State<MainGameState> {
        public PlayerTurnState(StateMachine parentStateMachine, string stateName, MainGameState owner) : base(parentStateMachine, stateName, owner) { }
        protected override void OnEnterCallback() {
        }

        protected override void OnUpdateCallback() {
            throw new System.NotImplementedException();
        }

        protected override void OnExitCallback() {
            throw new System.NotImplementedException();
        }
    }
}