using System;
using Card;
using UnityEngine;
using UnityEngine.Serialization;
using XiheFramework.Runtime;
using XiheFramework.Runtime.Base;

namespace Board {
    public class BoardModule : GameModuleBase {
        public override int Priority => (int)CoreModulePriority.CustomModuleDefault;

        public BoardEntity boardEntity;

        public void GetCurrentBoardSize(out int x, out int y) {
            boardEntity.GetBoardSize(out x, out y);
        }

        public BoardCoordinate GetBoardCoordinateByMousePosition(Vector2 mouseScreenPosition) {
            return default;
        }

        public bool TryMatchCardTrigger(uint cardId, out BoardCoordinate[] matchedCoordinates, out CardTriggerPattern cardTriggerPattern) {
            var cardInfo = ThisGame.Card.GetCardInfo(cardId);
            if (cardInfo != null) {
                return boardEntity.TryMatchCardTrigger(cardInfo.cardTrigger, out matchedCoordinates, out cardTriggerPattern);
            }

            matchedCoordinates = null;
            cardTriggerPattern = null;
            return false;
        }

        public void SwitchPosition(BoardCoordinate from, BoardCoordinate to) {
            if (boardEntity.SwitchPosition(from, to)) {
                var args = new BoardModuleEvents.OnCellCoordSwitchedEventArgs();
                Game.Event.Invoke(BoardModuleEvents.OnCellCoordSwitchedEventName, args);
            }
        }

        protected override void OnInstantiated() {
            base.OnInstantiated();

            ThisGame.Board = this;
        }
    }
}