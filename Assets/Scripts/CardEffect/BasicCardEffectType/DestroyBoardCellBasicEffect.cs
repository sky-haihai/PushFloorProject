using Board;

namespace CardEffect.BasicCardEffectType {
    public class DestroyBoardCellBasicEffect {
        public BoardCoordinate boardCoordinate;
        public DestroyBoardCellBasicEffect(BoardCoordinate boardCoordinate) {
            this.boardCoordinate = boardCoordinate;
        }
    }
}