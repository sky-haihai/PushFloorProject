using System;
using System.Collections.Generic;
using System.Linq;
using CardEffect;
using GameConstant;
using UnityEngine;
using XiheFramework.Runtime;
using XiheFramework.Runtime.Base;
using XiheFramework.Runtime.Blackboard;
using XiheFramework.Runtime.Console;
using XiheFramework.Runtime.Utility;
using XiheFramework.Utility.Csv2Json;

namespace Card {
    public class CardModule : GameModuleBase {
        public override int Priority => (int)CoreModulePriority.CustomModuleDefault;
        public CardBlackboard CardBlackboard { get; private set; }

        public int cardEffectArgCount = 5;

        private readonly Dictionary<uint, ICardEffectCommand> m_CardEffectCommands = new();

        #region Public Methods

        public void ExecuteCard(CardEffectEvents.OnCardEffectTriggeredEventArgs args) {
            var cardId = args.cardId;
            var cardInfo = CardBlackboard.CardInfoDict[cardId];

            if (cardInfo == null) {
                Game.LogError($"Card ID:{cardId} does not exist in card Json or not loaded");
                return;
            }

            if (string.IsNullOrEmpty(cardInfo.cardCommand)) {
                Game.LogWarning($"Card ID:{args.cardId} has no command");
                return;
            }

            if (!CardHelper.TryParseCardCommands(cardInfo.cardCommand, out var cardCommands)) {
                return;
            }

            var evaluationData = new CardEffectEvaluationData();
            foreach (var cardEffectStr in cardCommands) {
                EvaluateCardEffect(cardEffectStr, args, ref evaluationData);
            }

            ExecuteCardEffectsEvaluationData(evaluationData);
        }

        public CardInfo GetCardInfo(uint cardId) {
            return CardBlackboard.CardInfoDict.GetValueOrDefault(cardId);
        }

        #endregion

        #region Private

        private void EvaluateCardEffect(CardEffect cardEffect, CardEffectEvents.OnCardEffectTriggeredEventArgs onCardEffectTriggeredEventArgs, ref CardEffectEvaluationData evaluationData) {
            if (m_CardEffectCommands.TryGetValue(cardEffect.effectId, out var cardEffectCommand)) {
                var arg0 = cardEffect.args.Length > 0 ? cardEffect.args[0] : 0f;
                var arg1 = cardEffect.args.Length > 1 ? cardEffect.args[1] : 0f;
                var arg2 = cardEffect.args.Length > 2 ? cardEffect.args[2] : 0f;
                var arg3 = cardEffect.args.Length > 3 ? cardEffect.args[3] : 0f;
                var arg4 = cardEffect.args.Length > 4 ? cardEffect.args[4] : 0f;
                cardEffectCommand.EnqueueEffect(arg0, arg1, arg2, arg3, arg4, onCardEffectTriggeredEventArgs, ref evaluationData);
            }
        }

        private void ExecuteCardEffectsEvaluationData(CardEffectEvaluationData evaluationData) {
            while (evaluationData.addBuffEffectQueue.Count > 0) {
                var effect = evaluationData.addBuffEffectQueue.Dequeue();
                //add buff
                
            }
            
            while (evaluationData.spawnOnCellEffectQueue.Count > 0) {
                var effect = evaluationData.spawnOnCellEffectQueue.Dequeue();
                //spawn unit
                
            }
            
            while (evaluationData.unitMoveEffectQueue.Count > 0) {
                var effect = evaluationData.unitMoveEffectQueue.Dequeue();
                //move unit
                
            }
            
            while (evaluationData.unitDamageEffectQueue.Count > 0) {
                var effect = evaluationData.unitDamageEffectQueue.Dequeue();
                //damage unit
                
            }
            
            while (evaluationData.destroyBoardCellQueue.Count > 0) {
                var effect = evaluationData.destroyBoardCellQueue.Dequeue();
                //destroy board cell
                
            }
        }

        private void RegisterAllCardEffectCommand() {
            m_CardEffectCommands.Clear();
            var commandTypes = SystemUtil.GetAllImplementedTypeFrom<ICardEffectCommand>();

            foreach (var type in commandTypes) {
                var command = (ICardEffectCommand)Activator.CreateInstance(type);
                m_CardEffectCommands.TryAdd(command.CardEffectId, command);
            }
        }

        private void OnCardEffectTriggered(object sender, object e) {
            var args = (CardEffectEvents.OnCardEffectTriggeredEventArgs)e;

            ExecuteCard(args);
        }

        #endregion


        #region Life Cycle

        protected override void OnInstantiated() {
            base.OnInstantiated();

            ThisGame.Card = this;

            RegisterAllCardEffectCommand();

            //create card blackboard
            CardBlackboard = Game.Blackboard.CreateBlackboard<CardBlackboard>("CardModule_CardBlackboard");
            CardBlackboard.CardInfoDict = JsonLoader.LoadDataList<CardInfo>(ResourceAddresses.CsvToJsonData_CardTableJson).ToDictionary(x => x.id);

            Game.Event.Subscribe(CardEffectEvents.OnCardEffectTriggeredEventName, OnCardEffectTriggered);
        }

        #endregion
    }
}