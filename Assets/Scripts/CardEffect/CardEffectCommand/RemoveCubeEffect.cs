using Board;

namespace CardEffect.CardEffectCommand {
    public class RemoveCubeEffect : ICardEffectCommand {
        public uint CardEffectId => (uint)CardEffectType.RemoveEffectedCube;

        public void EnqueueEffect(float arg0, float arg1, float arg2, float arg3, float arg4, CardEffectEvents.OnCardEffectTriggeredEventArgs onCardEffectTriggeredEventArgs, ref CardEffectEvaluationData evaluationData) {
            var coords = onCardEffectTriggeredEventArgs.coordinates;
            foreach (var coord in coords) {
                evaluationData.EnqueueRemoveCubeEffect(coord);
            }
        }
    }
}