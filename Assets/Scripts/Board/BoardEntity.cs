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

        public int sizeX; //col size
        public int sizeY; //row size

        private Dictionary<BoardCoordinate, BoardCellEntity> m_BoardCellEntities = new Dictionary<BoardCoordinate, BoardCellEntity>(); //id: cantor pair
        private BoardData m_BoardData; //id: cantor pair

        //debug
        public string debugTriggerString;

        #region Public Methods

        public void GetBoardSize(out int x, out int y) {
            x = sizeX;
            y = sizeY;
        }

        //todo: change to mvc model instead of entity based
        public BoardData GetBoardData() {
            return m_BoardData;
        }

        public bool SwitchPosition(BoardCoordinate origin, BoardCoordinate destination) {
            // var fromEntity = m_BoardCellEntities[from];
            // var toEntity = m_BoardCellEntities[to];
            // m_BoardCellEntities[from] = toEntity;
            // m_BoardCellEntities[to] = fromEntity;

            if (origin.Equals(destination)) {
                RefreshBoard();
                return false;
            }

            var temp = m_BoardData.boardCellData[origin.col, origin.row];
            m_BoardData.boardCellData[origin.col, origin.row] = m_BoardData.boardCellData[destination.col, destination.row];
            m_BoardData.boardCellData[origin.col, origin.row].coordinate = origin;
            m_BoardData.boardCellData[destination.col, destination.row] = temp;
            m_BoardData.boardCellData[destination.col, destination.row].coordinate = destination;
            RefreshBoard();
            return true;
        }

        public bool TryMatchCardTrigger(string triggerString, out BoardCoordinate[] matchedCoordinates, out CardTriggerPattern cardTriggerPattern) {
            var isMatched = BoardHelper.TryMatchCardTrigger(triggerString, m_BoardData, out matchedCoordinates, out cardTriggerPattern);
            if (isMatched) {
                foreach (var matchedCoordinate in matchedCoordinates) {
                    Debug.Log($"Matched at: col:{matchedCoordinate.col}, row:{matchedCoordinate.row}");
                }
            }
            else {
                Debug.LogWarning("No match found");
            }

            return isMatched;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Destroy all board cell entities and re-instantiate them
        /// </summary>
        private void RefreshBoard() {
            foreach (var boardCellData in m_BoardData.boardCellData) {
                if (m_BoardCellEntities.ContainsKey(boardCellData.coordinate)) {
                    Game.Entity.DestroyEntity(m_BoardCellEntities[boardCellData.coordinate].EntityId);
                    m_BoardCellEntities.Remove(boardCellData.coordinate);
                }

                //create board cell entity
                var boardCellEntity = Game.Entity.InstantiateEntity<BoardCellEntity>(ResourceAddresses.Board_BoardCellEntity);
                Game.Entity.ChangeEntityOwner(boardCellEntity.EntityId, EntityId);
                boardCellEntity.cellData.coordinate = boardCellData.coordinate;
                boardCellEntity.cellData.cellColorCode = boardCellData.cellColorCode;
                boardCellEntity.UpdateCellStates();

                m_BoardCellEntities.Add(boardCellData.coordinate, boardCellEntity);
            }

            Debug.Log($"Board refreshed");
        }

        #endregion

        #region Life Cycle

        public override void OnInitCallback() {
            base.OnInitCallback();
            CreateRandomizedBoard();
            RefreshBoard();
        }

        private void CreateRandomizedBoard() {
            m_BoardData = new BoardData(sizeX, sizeY);
            for (int col = 0; col < sizeX; col++) {
                for (int row = 0; row < sizeY; row++) {
                    var boardCellData = new BoardCellData();
                    boardCellData.coordinate = new BoardCoordinate(col, row);
                    boardCellData.cellColorCode = (CellColorCode)Random.Range(1, 8);
                    m_BoardData.boardCellData[col, row] = boardCellData;
                }
            }
        }

        public override void OnUpdateCallback() {
            base.OnUpdateCallback();

            if (Game.Input(0).GetButtonDown("DebugFire")) {
                var isMatched = BoardHelper.TryMatchCardTrigger(debugTriggerString, m_BoardData, out var matchedCoordinates, out var cardTriggerPattern);
                if (isMatched) {
                    foreach (var matchedCoordinate in matchedCoordinates) {
                        Debug.Log($"Matched at: col:{matchedCoordinate.col}, row:{matchedCoordinate.row}");
                    }
                }
                else {
                    Debug.LogWarning("No match found");
                }

                RefreshBoard();
            }
        }

        #endregion
    }
}