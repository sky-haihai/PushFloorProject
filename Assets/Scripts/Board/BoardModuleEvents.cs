namespace Board {
    public class BoardModuleEvents {
        public const string OnCellCoordSwitchedEventName = "OnCellCoordSwitched";

        public struct OnCellCoordSwitchedEventArgs {
            public uint originCellEntityId;
            public uint destinationCellEntityId;
            public BoardCoordinate originBoardCoordinate;
            public BoardCoordinate destinationBoardCoordinate;
        }
    }
}