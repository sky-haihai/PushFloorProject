using System;
using System.Linq;

namespace Board {
    [Serializable]
    public class BoardData {
        public int RowSize {
            get {
                if (boardCellData == null) return 0;
                return boardCellData.GetLength(1);
            }
        }

        public int ColSize {
            get {
                if (boardCellData == null) return 0;
                return boardCellData.GetLength(0);
            }
        }

        public BoardCellData[,] boardCellData;

        public BoardData() { }

        public BoardData(int colSize, int rowSize) {
            this.boardCellData = new BoardCellData[colSize, rowSize];
        }

        public BoardData(BoardCellData[,] boardCellData) {
            this.boardCellData = boardCellData;
        }

        public BoardData DeepClone() {
            var newData = new BoardCellData[ColSize, RowSize];
            Array.Copy(boardCellData, newData, boardCellData.Length);
            return new BoardData(newData);
        }
    }
}