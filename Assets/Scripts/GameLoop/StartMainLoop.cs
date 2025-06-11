
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
            // var fsm = Game.Fsm.CreateStateMachine(GameLoopStatesNames.GameLoopFsm);
            // fsm.AddState(new EntryState(fsm, GameLoopStatesNames.Entry, Game.Fsm)); //play logo
            // fsm.AddState(new TitleState(fsm, GameLoopStatesNames.Title, Game.Fsm)); //enter title screen
            // fsm.AddState(new MainGameState(fsm, GameLoopStatesNames.Game, Game.Fsm)); //main pachinko game
            // fsm.SetInitialState(GameLoopStatesNames.Entry);
            // fsm.OnStart();
        }

        private void OnDestroy() {
            Game.Event.Unsubscribe(ResourceModuleEvents.OnDefaultResourcesLoadedEvtName, m_EventHandlerId);
        }
    }
}