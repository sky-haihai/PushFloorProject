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

            var commands = cardInfo.cardCommand.Split(',');
            var evaluationData = new CardEffectEvaluationData();
            foreach (var command in commands) {
                ExecuteEffectCommand(command, args, ref evaluationData);
            }

            EvaluateCardEffect(evaluationData);
        }

        public CardInfo GetCardInfo(uint cardId) {
            return CardBlackboard.CardInfoDict.GetValueOrDefault(cardId);
        }

        #endregion


        #region Private

        private void ExecuteEffectCommand(string command, CardEffectEvents.OnCardEffectTriggeredEventArgs onCardEffectTriggeredEventArgs, ref CardEffectEvaluationData evaluationData) {
            var argStrings = command.Split('|');
            var args = new List<float>();
            for (int i = 0; i < argStrings.Length; i++) {
                if (float.TryParse(argStrings[i], out float result)) {
                    args.Add(result);
                }
            }

            if (m_CardEffectCommands.TryGetValue((uint)args[0], out var cardEffectCommand)) {
                cardEffectCommand.EnqueueEffect(args[1], args[2], args[3], args[4], args[5], onCardEffectTriggeredEventArgs, ref evaluationData);
            }
        }

        private void EvaluateCardEffect(CardEffectEvaluationData evaluationData) {
            while (evaluationData.addBuffEffectQueue.Count > 0) {
                var effect = evaluationData.addBuffEffectQueue.Dequeue();
                //add buff
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