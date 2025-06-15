using Board;

namespace CardEffect.BasicCardEffectType {
    public class UnitMoveBasicEffect {
        public BoardCoordinate boardCoordinate;
        public int moveUnit;

        public UnitMoveBasicEffect(BoardCoordinate boardCoordinate, int moveUnit) {
            this.boardCoordinate = boardCoordinate;
            this.moveUnit = moveUnit;
        }
    }
}