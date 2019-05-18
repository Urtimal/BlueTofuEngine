using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public class MoveEntityOnMapEventArgs : SystemEventArgs
    {
        public IEntity Entity { get; set; }
        public IEnumerable<uint> KeyMovements { get; set; }

        public MoveEntityOnMapEventArgs(IEntity entity, IEnumerable<uint> keyMovements)
        {
            Entity = entity;
            KeyMovements = keyMovements;
        }

        public override bool CheckIsValid()
        {
            return Entity != null && KeyMovements != null;
        }
    }
}
