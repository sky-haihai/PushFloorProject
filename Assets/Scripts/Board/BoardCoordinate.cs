using XiheFramework.Runtime.Utility;

namespace Board {
    public struct BoardCoordinate {
        public int x;
        public int y;
        
        public int CantorPair => CantorPairUtility.CantorPair(x, y);
        
        public BoardCoordinate(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}