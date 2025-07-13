using System.Collections.Generic;
using System.Linq;
using Board;
using CardEffect;
using Player;
using XiheFramework.Runtime;
using XiheFramework.Runtime.FSM;

namespace GameLoop.PushFloorFsm {
    public class PlayerTurnState : State<MainGameState> {
        public PlayerTurnState(StateMachine parentStateMachine, string stateName, MainGameState owner) : base(parentStateMachine, stateName, owner) { }

        protected override void OnEnterCallback() {
            ThisGame.Player.ResetPlayerActionPointToMax();
            ThisGame.HandDeck.AcquireCard(1, 2, 3, 4, 5);

            SubscribeEvent(BoardModuleEvents.OnCellCoordSwitchedEventName, OnCellCoordSwitched);
        }

        private void OnCellCoordSwitched(object sender, object e) {
            if (e is not BoardModuleEvents.OnCellCoordSwitchedEventArgs args) {
                return;
            }
            
            //detect match for each card in hand deck
            var handDeckCardIds = ThisGame.HandDeck.GetCardIds();
            foreach (var cardId in handDeckCardIds) {
                if (!ThisGame.Board.TryMatchCardTrigger(cardId, out var coordinates, out var cardTriggerPattern)) {
                    continue;
                }

                foreach (var coordinate in coordinates) {
                    var allCoveredCoords = cardTriggerPattern.cells.Select(offset => coordinate + offset.coordinate).ToArray();
                    CardEffectEvents.OnCardEffectTriggeredEventArgs cardEffectTriggeredEventArgs = new CardEffectEvents.OnCardEffectTriggeredEventArgs(cardId, allCoveredCoords);
                    ThisGame.Card.ExecuteCard(cardEffectTriggeredEventArgs);
                }
            }
        }

        protected override void OnUpdateCallback() { }

        protected override void OnExitCallback() { }
    }
}