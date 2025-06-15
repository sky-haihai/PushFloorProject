using System;
using XiheFramework.Runtime.Base;

namespace Unit {
    public class UnitModule : GameModuleBase {
        public override int Priority => (int)CoreModulePriority.CustomModuleDefault;

        public uint[] GetAllUnitIds() {
            return Array.Empty<uint>();
        }
    }
}