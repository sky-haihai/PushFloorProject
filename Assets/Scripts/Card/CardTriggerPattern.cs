using System.Collections.Generic;
using System.Linq;
using Board;
using GameConstant;

namespace Card {
    public class CardTriggerPattern {
        public int width; //5
        public int height; //5
        public List<BoardCellData> cells;

        public CardTriggerPattern() {
            cells = new List<BoardCellData>();
        }

        public CardTriggerPattern(List<BoardCellData> cells) {
            this.cells = cells.ConvertAll(cell => new BoardCellData(cell.coordinate, cell.cellColorCode));
        }
    }
}