using System;
using System.Collections.Generic;
using Card;
using GameConstant;
using UnityEngine;
using XiheFramework.Runtime;

namespace Board {
    public static class BoardHelper {
        /// <summary>
        /// Try match a card trigger to a given board, return the first coordinates of all matched pattern on the board
        /// </summary>
        /// <param name="cardTrigger"></param>
        /// <param name="boardData"></param>
        /// <param name="matchedCoordinates"></param>
        /// <param name="cardTriggerPattern"></param>
        /// <returns></returns>
        public static bool TryMatchCardTrigger(string cardTrigger, BoardData boardData, out BoardCoordinate[] matchedCoordinates, out CardTriggerPattern cardTriggerPattern) {
            matchedCoordinates = null;
            cardTriggerPattern = null;
            if (string.IsNullOrEmpty(cardTrigger)) {
                Game.LogError("card trigger can not be empty");
                return false;
            }

            if (!ParseTriggerPattern(cardTrigger, out cardTriggerPattern)) {
                return false;
            }

            var cachedBoardData = boardData.DeepClone();
            var result = new List<BoardCoordinate>();
            for (int row = 0; row < cachedBoardData.RowSize; row++) {
                for (int col = 0; col < cachedBoardData.ColSize; col++) {
                    if (cachedBoardData.boardCellData[col, row].cellColorCode == CellColorCode.None) {
                        continue;
                    }

                    if (MatchPatternAt(cachedBoardData, new BoardCoordinate(col, row), cardTriggerPattern)) {
                        result.Add(new BoardCoordinate(col, row));

                        //remove matched cell from board for next match attempt
                        foreach (var matchedCellData in cardTriggerPattern.cells) {
                            cachedBoardData.boardCellData[col + matchedCellData.coordinate.col, row + matchedCellData.coordinate.row].cellColorCode = CellColorCode.None;
                        }
                    }
                }
            }

            matchedCoordinates = result.ToArray();
            return result.Count > 0;
        }

        private static bool MatchPatternAt(BoardData board, BoardCoordinate origin, CardTriggerPattern pattern) {
            int maxRow = board.RowSize;
            int maxCol = board.ColSize;

            foreach (var point in pattern.cells) {
                var target = origin + point.coordinate;

                if (target.row < 0 || target.col < 0 || target.row >= maxRow || target.col >= maxCol)
                    return false;

                if (board.boardCellData[target.col, target.row].cellColorCode != point.cellColorCode)
                    return false;
            }

            return true;
        }

        private static bool ParseTriggerPattern(string cardTrigger, out CardTriggerPattern cardTriggerPattern, int patternWidth = 5) {
            if (cardTrigger.Length == 0) {
                Game.LogError("card trigger can not be empty");
                cardTriggerPattern = null;
                return false;
            }

            cardTriggerPattern = new CardTriggerPattern();
            int index = 0;
            int smallRow = int.MaxValue;
            int smallCol = int.MaxValue;
            int bigRow = 0;
            int bigCol = 0;

            for (int i = 0; i < cardTrigger.Length;) {
                if (char.IsDigit(cardTrigger[i])) {
                    int start = i;
                    while (i < cardTrigger.Length && char.IsDigit(cardTrigger[i])) i++;
                    int skip = int.Parse(cardTrigger[start..i]);
                    index += skip;
                }
                else {
                    CellColorCode color;
                    switch (cardTrigger[i]) {
                        case 'R':
                            color = CellColorCode.Red;
                            break;
                        case 'B':
                            color = CellColorCode.Blue;
                            break;
                        case 'G':
                            color = CellColorCode.Green;
                            break;
                        case 'Y':
                            color = CellColorCode.Yellow;
                            break;
                        case 'P':
                            color = CellColorCode.Purple;
                            break;
                        case 'K':
                            color = CellColorCode.Black;
                            break;
                        case 'W':
                            color = CellColorCode.White;
                            break;
                        default:
                            Game.LogError($"Unknown color code: {cardTrigger[i]} at {i}");
                            return false;
                    }

                    int row = index / patternWidth;
                    int col = index % patternWidth;
                    if (row < smallRow) smallRow = row;
                    if (col < smallCol) smallCol = col;
                    if (row > bigRow) bigRow = row;
                    if (col > bigCol) bigCol = col;

                    cardTriggerPattern.cells.Add(new BoardCellData(new BoardCoordinate(col, row), color));
                    index++;
                    i++;
                }
            }

            if (cardTriggerPattern.cells.Count == 0) {
                return false;
            }

            cardTriggerPattern.width = bigCol - smallCol + 1;
            cardTriggerPattern.height = bigRow - smallRow + 1;

            for (var j = 0; j < cardTriggerPattern.cells.Count; j++) {
                var cell = cardTriggerPattern.cells[j];
                cell.coordinate.col -= smallCol;
                cell.coordinate.row -= smallRow;
                cardTriggerPattern.cells[j] = cell;
            }

            foreach (var cell in cardTriggerPattern.cells) {
                Debug.Log($" {cell.coordinate.col}, {cell.coordinate.row}, {cell.cellColorCode}");
            }

            return true;
        }
    }
}