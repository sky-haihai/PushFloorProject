namespace CardEffect.CardEffectCommand {
    public class DamageOnCubeEffect : ICardEffectCommand {
        public uint CardEffectId => (uint)CardEffectType.DamageOnCube;

        public void EnqueueEffect(float arg0, float arg1, float arg2, float arg3, float arg4, CardEffectEvents.OnCardEffectTriggeredEventArgs onCardEffectTriggeredEventArgs, ref CardEffectEvaluationData evaluationData) {
            foreach (var coordinate in onCardEffectTriggeredEventArgs.coordinates) {
                evaluationData.EnqueueUnitDamageEffect(coordinate, arg0);
            }
        }
    }
}