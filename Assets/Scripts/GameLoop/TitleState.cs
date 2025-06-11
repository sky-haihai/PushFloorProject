using UnityEngine;
using XiheFramework.Runtime.FSM;

namespace GameLoop {
    public class TitleState : State<MonoBehaviour> {
        public TitleState(StateMachine parentStateMachine, string stateName, MonoBehaviour owner) : base(parentStateMachine, stateName, owner) { }
        
        protected override void OnEnterCallback() {
            //load title scene
            // Game.Scene.LoadScene(ResourceAddresses.Scene_Title, LoadSceneMode.Single, () => {
            //     //open title page
            //     Game.UI.OpenPage(ResourceAddresses.UILayout_TitlePage);
            // });
        }

        protected override void OnUpdateCallback() { }

        protected override void OnExitCallback() { }
    }
}