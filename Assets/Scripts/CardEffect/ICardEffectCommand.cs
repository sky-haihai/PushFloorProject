namespace CardEffect {
    public interface ICardEffectCommand {
        public uint CardEffectId { get; }
        public void EnqueueEffect(float arg0, float arg1, float arg2, float arg3, float arg4, CardEffectEvents.OnCardEffectTriggeredEventArgs onCardEffectTriggeredEventArgs, ref CardEffectEvaluationData evaluationData);
    }
}