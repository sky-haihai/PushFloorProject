using System;
using CardEffect;
using GameConstant;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using XiheFramework.Runtime.Entity;

namespace Board {
    public class BoardCellEntity : GameEntityBase {
        public override string GroupName => "BoardCellEntity";

        // public BoardCoordinate boardCoordinate;
        // public CellColorType cellColorType;
        public BoardCellData cellData = new BoardCellData(default, CellColorCode.None);
        public Renderer mainRenderer;

        public void UpdateCellStates() {
            transform.position = new Vector3(cellData.coordinate.col, 0, cellData.coordinate.row);
            mainRenderer.material.color = cellData.cellColorCode switch {
                CellColorCode.None => new Color(1, 1, 1, 0.2f),
                CellColorCode.Red => Color.red,
                CellColorCode.Blue => Color.blue,
                CellColorCode.Green => Color.green,
                CellColorCode.Yellow => Color.yellow,
                CellColorCode.Purple => new Color(1, 0, 1),
                CellColorCode.Black => Color.black,
                CellColorCode.White => Color.white,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private void OnDrawGizmos() {
            Handles.Label(transform.position, $"({cellData.coordinate.col}, {cellData.coordinate.row})");
        }
    }
}