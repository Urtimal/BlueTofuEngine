using BlueTofuEngine.Core.Network;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine
{
    public static class EntityExtensions
    {
        public static void Send(this IEntity entity, INetworkMessage message)
        {
            entity.Network()?.Client.Send(message);
        }

        #region Basic components
        
        public static NetworkComponent Network(this IEntity entity)
        {
            return entity.GetComponent<NetworkComponent>();
        }

        #endregion
    }
}
