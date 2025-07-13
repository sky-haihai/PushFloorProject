using Board;
using Buff;
using Card;
using GameConstant;
using GameLoop.PushFloorFsm;
using HandDeck;
using Player;
using Unit;
using UnityEngine;
using UnityEngine.SceneManagement;
using XiheFramework.Runtime;
using XiheFramework.Runtime.FSM;

namespace GameLoop {
    public class MainGameState : State<MonoBehaviour> {
        public MainGameState(StateMachine parentStateMachine, string stateName, MonoBehaviour owner) : base(parentStateMachine, stateName, owner) { }

        protected override void OnEnterCallback() {
            Game.Scene.LoadScene(ResourceAddresses.Scene_Game, LoadSceneMode.Single, InitGame);
            SubscribeEvent(GameLoopEvents.OnGameOver, OnGameOver);
        }

        private void OnGameOver(object sender, object e) {
            // load entry
        }

        private void InitGame() {
            Game.InstantiateGameModule<BoardModule>();
            Game.InstantiateGameModule<BuffModule>();
            Game.InstantiateGameModule<CardModule>();
            Game.InstantiateGameModule<PlayerModule>();
            Game.InstantiateGameModule<UnitModule>();
            Game.InstantiateGameModule<HandDeckModule>();

            var fsm = Game.Fsm.CreateStateMachine(PushFloorGameStates.PushFloorFsmName);
            fsm.AddState(new PrepareDataState(fsm, PushFloorGameStates.PrepareDataState, this));
            fsm.AddState(new PlayerTurnState(fsm, PushFloorGameStates.PlayerTurnState, this));
            fsm.AddState(new EnvironmentTurnState(fsm, PushFloorGameStates.EnvironmentTurnState, this));
            fsm.AddState(new GameOverState(fsm, PushFloorGameStates.GameOverState, this));
            fsm.SetInitialState(PushFloorGameStates.PrepareDataState);
            fsm.OnStart();
        }

        protected override void OnUpdateCallback() { }

        protected override void OnExitCallback() { }
    }
}