using System.Collections.Generic;
using Board;
using CardEffect.BasicCardEffectType;
using CardEffect.CardEffectCommand;

namespace CardEffect {
    public class CardEffectEvaluationData {
        public Queue<UnitMoveBasicEffect> unitMoveEffectQueue = new Queue<UnitMoveBasicEffect>();
        public Queue<UnitDamageBasicEffect> unitDamageEffectQueue = new Queue<UnitDamageBasicEffect>();
        public Queue<DestroyBoardCellBasicEffect> destroyBoardCellQueue = new Queue<DestroyBoardCellBasicEffect>();
        public Queue<AddBuffBasicEffect> addBuffEffectQueue = new Queue<AddBuffBasicEffect>();
        public Queue<SpawnOnCellBasicEffect> spawnOnCellEffectQueue = new Queue<SpawnOnCellBasicEffect>();

        public void EnqueueUnitMoveEffect(BoardCoordinate boardCoordinate, int moveUnit) {
            unitMoveEffectQueue.Enqueue(new UnitMoveBasicEffect(boardCoordinate, moveUnit));
        }

        public void EnqueueUnitDamageEffect(BoardCoordinate boardCoordinate, float damageAmount) {
            unitDamageEffectQueue.Enqueue(new UnitDamageBasicEffect(boardCoordinate, damageAmount));
        }

        public void EnqueueRemoveCubeEffect(BoardCoordinate boardCoordinate) {
            destroyBoardCellQueue.Enqueue(new DestroyBoardCellBasicEffect(boardCoordinate));
        }

        public void EnqueueAddBuffEffect(BoardCoordinate boardCoordinate,uint buffId) {
            addBuffEffectQueue.Enqueue(new AddBuffBasicEffect(boardCoordinate, buffId));
        }

        public void EnqueueSpawnOnCellEffect(BoardCoordinate boardCoordinate, uint unitId) {
            spawnOnCellEffectQueue.Enqueue(new SpawnOnCellBasicEffect(boardCoordinate, unitId));
        }
    }
}