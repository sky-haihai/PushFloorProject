using System.Collections.Generic;
using Board;

namespace CardEffect {
    public static class CardEffectEvents {
        public const string OnCardEffectTriggeredEventName = "OnCardEffectTriggered";

        public struct OnCardEffectTriggeredEventArgs {
            public uint cardId;
            public BoardCoordinate[] coordinates;

            public OnCardEffectTriggeredEventArgs(uint cardId, BoardCoordinate[] coordinates) {
                this.cardId = cardId;
                this.coordinates = coordinates;
            }
        }
    }
}