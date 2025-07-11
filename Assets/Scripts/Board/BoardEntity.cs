using System.Collections.Generic;
using Card;
using GameConstant;
using UnityEngine;
using XiheFramework.Runtime;
using XiheFramework.Runtime.Entity;
using XiheFramework.Runtime.Utility;

namespace Board {
    public class BoardEntity : GameEntityBase {
        public override string GroupName => "BoardEntity";

        public int sizeX;
        public int sizeY;
        public Dictionary<int, BoardCellEntity> boardCells = new Dictionary<int, BoardCellEntity>(); //id: cantor pair

        public string debugTriggerString;

        public void GetBoardSize(out int x, out int y) {
            x = sizeX;
            y = sizeY;
        }

        //todo: change to mvc model instead of entity based
        public BoardData GetCurrentBoardData() {
            var data = new BoardData();
            var cellData = new BoardCellData[sizeX, sizeY];
            foreach (var boardCellData in boardCells) {
                CantorPairUtility.ReverseCantorPair(boardCellData.Key, out var col, out var row);
                cellData[col, row] = boardCellData.Value.cellData;
            }

            data.boardCellData = cellData;
            return data;
        }

        public void SwitchPosition(BoardCoordinate from, BoardCoordinate to) { }

        public override void OnInitCallback() {
            base.OnInitCallback();

            for (int i = 0; i < sizeX; i++) {
                for (int j = 0; j < sizeY; j++) {
                    //create board cell entity
                    var coordIdCantor = CantorPairUtility.CantorPair(i, j);
                    var boardCellEntity = Game.Entity.InstantiateEntity<BoardCellEntity>(ResourceAddresses.Board_BoardCellEntity);
                    Game.Entity.ChangeEntityOwner(boardCellEntity.EntityId, EntityId);
                    boardCellEntity.cellData.coordinate = new BoardCoordinate(i, j);
                    boardCellEntity.cellData.cellColorCode = (CellColorCode)Random.Range(1, 8);
                    boardCellEntity.UpdateCellStates();

                    boardCells.Add(coordIdCantor, boardCellEntity);
                }
            }
        }

        public override void OnUpdateCallback() {
            base.OnUpdateCallback();

            if (Game.Input(0).GetButtonDown("DebugFire")) {
                var currentBoardData = GetCurrentBoardData();
                var isMatched = BoardHelper.TryMatchCardTrigger(debugTriggerString, currentBoardData, out var matchedCoordinates);
                if (isMatched) {
                    foreach (var matchedCoordinate in matchedCoordinates) {
                        Debug.Log($"Matched at: col:{matchedCoordinate.col}, row:{matchedCoordinate.row}");
                    }
                }
                else {
                    Debug.LogWarning("No match found");
                }

                UpdateBoard();
            }
        }

        private void UpdateBoard() {
            foreach (var boardCellEntity in boardCells.Values) {
                boardCellEntity.UpdateCellStates();
            }
        }
    }
}