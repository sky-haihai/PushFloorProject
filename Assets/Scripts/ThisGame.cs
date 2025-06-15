using Board;
using Card;
using CardEffect;
using Player;
using Unit;

public static class ThisGame {
    public static BoardModule BoardModule { get; internal set; }
    public static CardModule CardModule { get; internal set; }
    public static PlayerModule PlayerModule { get; internal set; }
    public static UnitModule UnitModule { get; internal set; }
}