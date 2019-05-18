using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public class SpawnEntityOnMapEventArgs : SystemEventArgs
    {
        public IEntity Entity { get; set; }

        public SpawnEntityOnMapEventArgs(IEntity entity)
        {
            Entity = entity;
        }
        public override bool CheckIsValid()
        {
            return Entity != null;
        }
    }
}
