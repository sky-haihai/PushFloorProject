using Board;
using UnityEngine;

namespace CardEffect.CardEffectCommand {
    public class AddBuffAllEffect : ICardEffectCommand {
        public uint CardEffectId => (uint)CardEffectType.AddBuffAll;

        public void EnqueueEffect(float arg0, float arg1, float arg2, float arg3, float arg4, CardEffectEvents.OnCardEffectTriggeredEventArgs onCardEffectTriggeredEventArgs,
            ref CardEffectEvaluationData evaluationData) {
            var buffId = (uint)Mathf.RoundToInt(arg0);
            //get all coordinates
            ThisGame.BoardModule.GetCurrentBoardSize(out int x, out int y);
            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    evaluationData.EnqueueAddBuffEffect(new BoardCoordinate(i, j), buffId);
                }
            }
        }
    }
}