using UnityEngine;

namespace CardEffect.CardEffectCommand {
    public class AddBuffOnCubeEffect : ICardEffectCommand {
        public uint CardEffectId => (uint)CardEffectType.AddBuffOnCube;

        public void EnqueueEffect(float arg0, float arg1, float arg2, float arg3, float arg4, CardEffectEvents.OnCardEffectTriggeredEventArgs onCardEffectTriggeredEventArgs,
            ref CardEffectEvaluationData evaluationData) {
            var buffId = (uint)Mathf.RoundToInt(arg0);
            foreach (var coordinate in onCardEffectTriggeredEventArgs.coordinates) {
                evaluationData.EnqueueAddBuffEffect(coordinate, buffId);
            }
        }
    }
}