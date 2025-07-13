using XiheFramework.Runtime;
using XiheFramework.Runtime.Base;

namespace HandDeck {
    public class HandDeckModule : GameModuleBase {
        public override int Priority => (int)CoreModulePriority.CustomModuleDefault;

        public HandDeckBlackboard handDeckBlackboard;

        public uint[] GetCardIds() {
            return handDeckBlackboard.currentCardList.ToArray();
        }
        
        public void AcquireCard(params uint[] cardIds) {
            foreach (var cardId in cardIds) {
                handDeckBlackboard.currentCardList.Add(cardId);
            }

            Game.Event.Invoke(HandDeckEvents.OnAcquireCardEventName);
        }

        protected override void OnInstantiated() {
            handDeckBlackboard = Game.Blackboard.CreateBlackboard<HandDeckBlackboard>("HandDeckModule_HandDeckBlackboard");

            ThisGame.HandDeck = this;
        }
    }
}