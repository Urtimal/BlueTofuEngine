using BlueTofuEngine.Core.Network;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine
{
    public static class NetworkClientExtensions
    {
        public static IEntity GetEntity(this INetworkClient client)
        {
            return EntityManager.Instance.GetByRef(client.Id);
        }
    }
}
