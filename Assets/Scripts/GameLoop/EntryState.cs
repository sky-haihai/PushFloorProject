using UnityEngine;
using XiheFramework.Runtime.FSM;

namespace GameLoop {
    public class EntryState : State<MonoBehaviour> {
        public EntryState(StateMachine parentStateMachine, string stateName, MonoBehaviour owner) : base(parentStateMachine, stateName, owner) { }

        protected override void OnEnterCallback() {
            
        }

        protected override void OnUpdateCallback() {
            // ChangeState(GameLoopStatesNames.Title);
        }

        protected override void OnExitCallback() { }
    }
}