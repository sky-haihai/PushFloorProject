using Board;

namespace CardEffect.BasicCardEffectType {
    public class SpawnOnCellBasicEffect {
        public BoardCoordinate coord;
        public uint unitId;
        
        public SpawnOnCellBasicEffect(BoardCoordinate coord, uint unitId) {
            this.coord = coord;
            this.unitId = unitId;
        }
    }
}