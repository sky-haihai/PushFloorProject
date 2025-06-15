using Board;

namespace CardEffect.BasicCardEffectType {
    public class UnitDamageBasicEffect {
        public BoardCoordinate boardCoordinate;
        public float damageAmount;

        public UnitDamageBasicEffect(BoardCoordinate boardCoordinate, float damageAmount) {
            this.boardCoordinate = boardCoordinate;
            this.damageAmount = damageAmount;
        }
    }
}