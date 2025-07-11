
using GameConstant;
using UnityEngine;
using XiheFramework.Runtime;
using XiheFramework.Runtime.Resource;

namespace GameLoop {
    public class StartMainLoop : MonoBehaviour {
        private string m_EventHandlerId;

        private void Start() {
            m_EventHandlerId = Game.Event.Subscribe(ResourceModuleEvents.OnDefaultResourcesLoadedEvtName, OnDefaultResourcesLoaded);
        }

        private void OnDefaultResourcesLoaded(object sender, object e) {
            var fsm = Game.Fsm.CreateStateMachine(GameLoopStates.GameLoopFsm);
            fsm.AddState(new EntryState(fsm, GameLoopStates.Entry, Game.Fsm)); //play logo
            fsm.AddState(new TitleState(fsm, GameLoopStates.Title, Game.Fsm)); //enter title screen
            fsm.AddState(new MainGameState(fsm, GameLoopStates.Game, Game.Fsm)); //main pachinko game
            fsm.SetInitialState(GameLoopStates.Entry);
            fsm.OnStart();
        }

        private void OnDestroy() {
            Game.Event.Unsubscribe(ResourceModuleEvents.OnDefaultResourcesLoadedEvtName, m_EventHandlerId);
        }
    }
}