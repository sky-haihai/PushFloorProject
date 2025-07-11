using XiheFramework.Runtime.Utility;

namespace Board {
    public struct BoardCoordinate {
        public int row;
        public int col;

        public int CantorPair => CantorPairUtility.CantorPair(col, row);

        public BoardCoordinate(int col, int row) {
            this.col = col;
            this.row = row;
        }

        public static BoardCoordinate operator +(BoardCoordinate a, BoardCoordinate b) {
            return new BoardCoordinate(a.col + b.col, a.row + b.row);
        }
    }
}