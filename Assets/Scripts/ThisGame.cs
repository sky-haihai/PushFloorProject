using Board;
using Buff;
using Card;
using CardEffect;
using Player;
using Unit;

public static class ThisGame {
    public static BoardModule Board { get; internal set; }
    public static BuffModule Buff { get; internal set; }
    
    public static CardModule Card { get; internal set; }
    public static PlayerModule Player { get; internal set; }
    public static UnitModule Unit { get; internal set; }
}