using BlueTofuEngine.Core.Network;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Extensions
{
    public static class EntityExtensions
    {
        public static void Send(this IEntity entity, INetworkMessage message)
        {
            entity.Network()?.Client.Send(message);
        }

        #region Basic components

        public static ContextComponent Context(this IEntity entity)
        {
            return entity.GetComponent<ContextComponent>();
        }

        public static FighterComponent Fighter(this IEntity entity)
        {
            return entity.GetComponent<FighterComponent>();
        }

        public static LookComponent Look(this IEntity entity)
        {
            return entity.GetComponent<LookComponent>();
        }

        public static NetworkComponent Network(this IEntity entity)
        {
            return entity.GetComponent<NetworkComponent>();
        }

        #endregion
    }
}
