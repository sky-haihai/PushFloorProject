using Board;

namespace CardEffect.BasicCardEffectType {
    public class AddBuffBasicEffect {
        public BoardCoordinate coord;
        public uint buffId;
        public AddBuffBasicEffect(BoardCoordinate coord, uint buffId) {
            this.coord = coord;
            this.buffId = buffId;
        }
    }
}