namespace CardEffect {
    public static class CardEffectEvaluationHelper {
        public static void EvaluateCardEffect(CardEffectEvaluationData evaluationData) {
            while (evaluationData.spawnOnCellEffectQueue.Count > 0) {
                var effect = evaluationData.spawnOnCellEffectQueue.Dequeue();
                //ThisGame.Unit.SpawnUnit(...);
            }

            while (evaluationData.addBuffEffectQueue.Count > 0) {
                var effect = evaluationData.addBuffEffectQueue.Dequeue();
                //ThisGame.Buff.AddBuff(...);
            }

            while (evaluationData.unitMoveEffectQueue.Count > 0) {
                var effect = evaluationData.unitMoveEffectQueue.Dequeue();
            }

            while (evaluationData.unitDamageEffectQueue.Count > 0) {
                var effect = evaluationData.unitDamageEffectQueue.Dequeue();
            }

            while (evaluationData.destroyBoardCellQueue.Count > 0) {
                var effect = evaluationData.destroyBoardCellQueue.Dequeue();
            }
        }
    }
}