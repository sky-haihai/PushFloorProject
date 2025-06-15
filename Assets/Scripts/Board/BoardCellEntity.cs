using CardEffect;
using XiheFramework.Runtime.Entity;

namespace Board {
    public class BoardCellEntity : GameEntityBase {
        public override string GroupName => "BoardCellEntity";
        
        public BoardCoordinate boardCoordinate;
    }
}