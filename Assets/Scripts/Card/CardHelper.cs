using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Board;
using XiheFramework.Runtime;

namespace Card {
    public static class CardHelper {
        public static string GetCardEffectDisplayDescription(string cardCommandStr, string cardDescription) {
            var result = new StringBuilder();

            var cardCommand = CardEffect.Create(cardCommandStr);
            if (cardCommand.effectId == 0) {
                Game.LogError($"Invalid card command: {cardCommandStr}");
                return cardDescription;
            }

            var withinBraces = false;
            var currentArgStr = new StringBuilder();
            foreach (var c in cardDescription) {
                if (withinBraces) {
                    if (c == '}') {
                        withinBraces = false;
                        if (!TryGetDescriptionArgTypeAndIndex(currentArgStr.ToString(), out var argType, out var argId)) {
                            continue;
                        }

                        var argValue = cardCommand.args[argId];

                        var argValueStr = argType switch {
                            CardEffectArgType.Number => argValue.ToString("0.0"),
                            CardEffectArgType.Range => argValue.ToString("0.0"), //TODO: load range table
                            CardEffectArgType.Target => argValue.ToString("0.0"), //TODO: load target table
                            _ => throw new ArgumentOutOfRangeException()
                        };

                        result.Append(argValueStr);
                        currentArgStr.Clear();
                    }
                    else {
                        currentArgStr.Append(c);
                    }
                }
                else if (c == '{') {
                    withinBraces = true;
                }
                else {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        private static bool TryGetDescriptionArgTypeAndIndex(string argString, out CardEffectArgType argType, out int argId) {
            argType = CardEffectArgType.Number;
            argId = 0;
            if (string.IsNullOrEmpty(argString)) {
                Game.LogError("Card description contains empty argument ID within one of the braces");
                return false;
            }

            var splitContentStrings = argString.Split(':');
            var argTypeStr = "";
            var argIdStr = "";
            if (splitContentStrings.Length == 2) {
                argTypeStr = splitContentStrings[0];
                argIdStr = splitContentStrings[1];
            }
            else {
                argIdStr = splitContentStrings[0];
            }

            switch (argTypeStr) {
                case "Number":
                    break;
                case "Range":
                    argType = CardEffectArgType.Range;
                    break;
                case "Target":
                    argType = CardEffectArgType.Target;
                    break;
                default:
                    Game.LogError($"Argument type must be Number, Range or Target. Can not parse: \"{splitContentStrings[0]}\" ");
                    return false;
            }

            if (!int.TryParse(argIdStr, out argId)) {
                Game.LogError($"Argument ID must be a number. Can not parse: \"{splitContentStrings[1]}\" ");
                return false;
            }

            if (argId < 0 || argId > 4) {
                Game.LogError($"Argument ID must be between 0 and 4. Current value: \"{argId.ToString()}\" ");
                return false;
            }

            return true;
        }

        public static bool TryParseCardCommands(string commandsStr, out CardEffect[] commands) {
            var result = new List<CardEffect>();
            var trimmedCardCommand = commandsStr.Replace("\n", "").Replace("\r", "");
            var commandStrings = trimmedCardCommand.Split(',');
            foreach (var command in commandStrings) {
                if (string.IsNullOrEmpty(command)) {
                    continue;
                }

                var cardCommand = CardEffect.Create(command);

                result.Add(cardCommand);
            }

            if (result.Count == 0) {
                commands = null;
                return false;
            }

            commands = result.ToArray();
            return true;
        }

        public static bool IsCardTriggerMatched(string cardTrigger, out BoardCoordinate[] matchedCoordinates) {
            matchedCoordinates = null;
            return false;
        }
    }
}