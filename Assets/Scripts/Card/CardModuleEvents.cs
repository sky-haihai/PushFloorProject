namespace Card {
    public static class CardModuleEvents {
        public const string OnCardEffectExecuted = "OnCardEffectExecuted";
        
        public struct OnCardEffectExecutedEventArgs {
            public uint cardId;
        }
    }
}