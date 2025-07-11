using System;
using GameConstant;

namespace Board {
    public struct BoardCellData {
        public BoardCoordinate coordinate;
        public CellColorCode cellColorCode;

        public BoardCellData(BoardCoordinate coordinate, CellColorCode cellColorCode) {
            this.coordinate = coordinate;
            this.cellColorCode = cellColorCode;
        }
    }
}