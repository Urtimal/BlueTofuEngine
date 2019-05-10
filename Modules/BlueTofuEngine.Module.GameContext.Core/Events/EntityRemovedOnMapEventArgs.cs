using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public class EntityRemovedOnMapEventArgs : SystemEventArgs
    {
        public IEntity Entity { get; set; }

        public EntityRemovedOnMapEventArgs(IEntity entity)
        {
            Entity = entity;
        }

        public override bool CheckIsValid()
        {
            return Entity != null;
        }
    }
}
