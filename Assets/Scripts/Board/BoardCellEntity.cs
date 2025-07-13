using System;
using CardEffect;
using GameConstant;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using XiheFramework.Runtime;
using XiheFramework.Runtime.Entity;
using XiheFramework.Utility.Extension;

namespace Board {
    public class BoardCellEntity : GameEntityBase, IPointerDownHandler, IPointerUpHandler {
        public override string GroupName => "BoardCellEntity";

        // public BoardCoordinate boardCoordinate;
        // public CellColorType cellColorType;
        public BoardCellData cellData = new BoardCellData(default, CellColorCode.None);
        public Renderer mainRenderer;

        //debug
        public float dragResponseDistance = 0.6f;
        public bool canBeDragged = false;

        private bool m_IsDragging;
        private BoardCoordinate m_DestinationCoordinate;

        public override void OnUpdateCallback() {
            base.OnUpdateCallback();

            if (m_IsDragging) {
                FollowMouse();
                UpdateDestinationCoordinate();
            }
        }

        private void FollowMouse() {
            var mousePosition = Game.Input(0).controllers.Mouse.screenPosition.ToVector3(V2ToV3Type.XY);
            mousePosition.z = Mathf.Abs(transform.position.y - Camera.main.transform.position.y);
            var mouseWorld = Camera.main.ScreenToWorldPoint(mousePosition);

            transform.position = mouseWorld;
        }

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


            if (m_IsDragging) {
                var mousePosition = Game.Input(0).controllers.Mouse.screenPosition.ToVector3(V2ToV3Type.XY);
                mousePosition.z = Mathf.Abs(transform.position.y - Camera.main.transform.position.y);
                var mouseWorld = Camera.main.ScreenToWorldPoint(mousePosition);

                var coordRealPosition = new Vector3(cellData.coordinate.col, 0, cellData.coordinate.row);

                Gizmos.DrawLine(coordRealPosition, mouseWorld);

                Handles.Label((mouseWorld - coordRealPosition) / 2f + coordRealPosition, $"{(mouseWorld - coordRealPosition).magnitude}");
            }
        }

        private void UpdateDestinationCoordinate() {
            var coordRealPosition = new Vector2(cellData.coordinate.col, cellData.coordinate.row);
            var deltaFromCoordinate = transform.position.ToVector2(V3ToV2Type.XZ) - coordRealPosition;
            m_DestinationCoordinate = cellData.coordinate;
            if (deltaFromCoordinate.magnitude < dragResponseDistance) {
                return;
            }

            if (Mathf.Abs(deltaFromCoordinate.x) > Mathf.Abs(deltaFromCoordinate.y)) {
                if (deltaFromCoordinate.x > 0) {
                    m_DestinationCoordinate = cellData.coordinate + BoardCoordinate.Right;
                }
                else {
                    m_DestinationCoordinate = cellData.coordinate + BoardCoordinate.Left;
                }
            }
            else {
                if (deltaFromCoordinate.y > 0) {
                    m_DestinationCoordinate = cellData.coordinate + BoardCoordinate.Up;
                }
                else {
                    m_DestinationCoordinate = cellData.coordinate + BoardCoordinate.Down;
                }
            }

            Debug.Log($"UpdateDestinationCoordinate: {m_DestinationCoordinate.col}, {m_DestinationCoordinate.row}");
        }

        public void OnPointerDown(PointerEventData eventData) {
            m_IsDragging = true;
            Debug.Log("OnPointerDown");
        }

        public void OnPointerUp(PointerEventData eventData) {
            Debug.Log("OnPointerUp");

            m_IsDragging = false;
            if (!Equals(m_DestinationCoordinate, cellData.coordinate)) {
                ThisGame.Board.SwitchPosition(cellData.coordinate, m_DestinationCoordinate);
            }
        }
    }
}