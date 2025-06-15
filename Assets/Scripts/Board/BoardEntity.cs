using System.Collections.Generic;
using GameConstant;
using UnityEngine;
using XiheFramework.Runtime;
using XiheFramework.Runtime.Entity;

namespace Board {
    public class BoardEntity : GameEntityBase {
        public override string GroupName => "BoardEntity";

        public int sizeX;
        public int sizeY;
        public Dictionary<int, BoardCellEntity> boardCells = new Dictionary<int, BoardCellEntity>();

        public void GetBoardSize(out int x, out int y) {
            x = sizeX;
            y = sizeY;
        }

        public void SwitchPosition(BoardCoordinate from, BoardCoordinate to) { }

        public override void OnInitCallback() {
            base.OnInitCallback();

            for (int i = 0; i < sizeX; i++) {
                for (int j = 0; j < sizeY; j++) {
                    //create board cell entity
                    var boardCellEntity = Game.Entity.InstantiateEntity(ResourceAddresses.Board_BoardCellEntity);
                    boardCellEntity.transform.position = new Vector3(i, 0, j);
                }
            }
        }
    }
}