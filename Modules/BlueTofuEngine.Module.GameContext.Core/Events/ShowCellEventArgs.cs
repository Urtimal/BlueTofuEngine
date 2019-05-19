using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public class ShowCellEventArgs : SystemEventArgs
    {
        public int CellId { get; set; }

        public ShowCellEventArgs(int cellId)
        {
            CellId = cellId;
        }

        public override bool CheckIsValid()
        {
            return CellId >= 0 && CellId <= 559;
        }
    }
}
