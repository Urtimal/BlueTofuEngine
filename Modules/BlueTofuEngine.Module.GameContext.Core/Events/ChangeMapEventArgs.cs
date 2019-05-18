using BlueTofuEngine.Module.Base;
using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public class ChangeMapEventArgs : SystemEventArgs
    {
        public long MapId { get; set; }
        public ushort CellId { get; set; }
        public Direction Dir { get; set; }

        public ChangeMapEventArgs(long mapId, ushort cellId, Direction dir)
        {
            MapId = mapId;
            CellId = cellId;
            Dir = dir;
        }

        public override bool CheckIsValid()
        {
            return MapId > 0 && CellId >= 0;
        }
    }
}
