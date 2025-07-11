using Board;
using UnityEngine;

namespace CardEffect.CardEffectCommand {
    public class MoveAllEffect : ICardEffectCommand {
        public uint CardEffectId => (uint)CardEffectType.MoveAll;

        public void EnqueueEffect(float arg0, float arg1, float arg2, float arg3, float arg4, CardEffectEvents.OnCardEffectTriggeredEventArgs onCardEffectTriggeredEventArgs,
            ref CardEffectEvaluationData evaluationData) {
            ThisGame.Board.GetCurrentBoardSize(out int x, out int y);
            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    evaluationData.EnqueueUnitMoveEffect(new BoardCoordinate(i, j), Mathf.RoundToInt(arg0));
                }
            }
        }
    }
}