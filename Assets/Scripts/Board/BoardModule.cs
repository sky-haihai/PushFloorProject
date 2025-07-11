using System;
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

        public void SwitchPosition(BoardCoordinate from, BoardCoordinate to) {
            boardEntity.SwitchPosition(from, to);
        }

        protected override void OnInstantiated() {
            base.OnInstantiated();

            ThisGame.Board = this;
        }
    }
}