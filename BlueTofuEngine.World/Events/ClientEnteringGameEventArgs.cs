using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Events
{
    public class ClientEnteringGameEventArgs : SystemEventArgs
    {
        public IEntity Entity { get; set; }

        public ClientEnteringGameEventArgs(IEntity entity)
        {
            Entity = entity;
        }

        public override bool CheckIsValid()
        {
            return Entity != null;
        }
    }
}
