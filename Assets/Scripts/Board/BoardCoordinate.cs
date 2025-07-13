using XiheFramework.Runtime.Utility;

namespace Board {
    public struct BoardCoordinate {
        public int row;
        public int col;

        public BoardCoordinate(int col, int row) {
            this.col = col;
            this.row = row;
        }

        public static BoardCoordinate operator +(BoardCoordinate a, BoardCoordinate b) {
            return new BoardCoordinate(a.col + b.col, a.row + b.row);
        }

        public static BoardCoordinate operator -(BoardCoordinate a, BoardCoordinate b) {
            return new BoardCoordinate(a.col - b.col, a.row - b.row);
        }

        public static BoardCoordinate Up => new BoardCoordinate(0, 1);
        public static BoardCoordinate Down => new BoardCoordinate(0, -1);
        public static BoardCoordinate Left => new BoardCoordinate(-1, 0);
        public static BoardCoordinate Right => new BoardCoordinate(1, 0);
    }
}