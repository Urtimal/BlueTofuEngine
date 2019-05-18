using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public class RemoveEntityOnMapEventArgs : SystemEventArgs
    {
        public IEntity Entity { get; set; }

        public RemoveEntityOnMapEventArgs(IEntity entity)
        {
            Entity = entity;
        }

        public override bool CheckIsValid()
        {
            return Entity != null;
        }
    }
}
