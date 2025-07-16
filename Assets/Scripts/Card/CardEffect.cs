namespace Card {
    public struct CardEffect {
        public uint effectId;
        public float[] args;

        public static CardEffect Create(string cardCommandStr) {
            var result = new CardEffect {
                args = new float[5]
            };

            var args = cardCommandStr.Split('|');
            if (!uint.TryParse(args[0], out var parsedCardEffectId)) {
                result.effectId = 0;
                return result;
            }

            result.effectId = parsedCardEffectId;

            for (int i = 1; i < args.Length; i++) {
                if (float.TryParse(args[i], out var parsedArg)) {
                    result.args[i - 1] = parsedArg;
                }
            }

            return result;
        }
    }
}