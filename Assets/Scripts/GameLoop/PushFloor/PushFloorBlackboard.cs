using XiheFramework.Runtime.Blackboard;

namespace GameLoop.PushFloor {
    public class PushFloorBlackboard : IBlackboard {
        public int CurrentTurn { get; set; }
        public int PlayerTurnRemainingActionCount { get; set; }

        public void OnCreated() { }

        public void OnRelease() { }
    }
}