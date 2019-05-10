using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public class EntitySpawnedOnMapEventArgs : SystemEventArgs
    {
        public IEntity Entity { get; set; }

        public EntitySpawnedOnMapEventArgs(IEntity entity)
        {
            Entity = entity;
        }

        public override bool CheckIsValid()
        {
            return Entity != null;
        }
    }
}
