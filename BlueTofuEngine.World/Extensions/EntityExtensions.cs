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
    }
}
