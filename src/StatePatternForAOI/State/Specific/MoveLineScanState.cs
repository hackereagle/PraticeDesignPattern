﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatePatternForAOI.StateManager.Specific;

namespace StatePatternForAOI.State.Specific
{
    class MoveLineScanState:StatePatternForAOI.State.Base.IState
    {
        public MoveLineScanState(string info)
        {
            this.Info = info;
        }

        public override void NexStage(StateManager.Specific.StateManager stateManager)
        {
            stateManager.State = new StatePatternForAOI.State.Specific.PlaceLineScanState("線掃描吹料");
        }

        public override void PreState(StateManager.Specific.StateManager stateManager)
        {
            stateManager.State = new StatePatternForAOI.State.Specific.PickState("吸料狀態");
        }
    }
}
