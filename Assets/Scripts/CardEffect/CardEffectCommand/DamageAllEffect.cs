using Board;

namespace CardEffect.CardEffectCommand {
    public class DamageAllEffect : ICardEffectCommand {
        public uint CardEffectId => (uint)CardEffectType.DamageAll;

        public void EnqueueEffect(float arg0, float arg1, float arg2, float arg3, float arg4, CardEffectEvents.OnCardEffectTriggeredEventArgs onCardEffectTriggeredEventArgs,
            ref CardEffectEvaluationData evaluationData) {
            //get all coordinates
            ThisGame.Board.GetCurrentBoardSize(out int x, out int y);
            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    evaluationData.EnqueueUnitDamageEffect(new BoardCoordinate(i, j), arg0);
                }
            }
        }
    }
}