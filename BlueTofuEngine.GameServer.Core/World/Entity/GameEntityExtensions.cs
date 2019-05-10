using BlueTofuEngine.Core.Network;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.GameServer
{
    public static class GameEntityExtensions
    {
        public static IEntity CreateClient(this EntityFactory factory, INetworkClient client, uint accountId)
        {
            var entity = EntityBuilder.Create()
                                .AddComponent<NetworkComponent>()
                                .AddComponent<AccountComponent>()
                                .Build(EntityManager.Instance.GetNextId());

            entity.GetComponent<AccountComponent>().AccountId = accountId;
            entity.GetComponent<NetworkComponent>().Client = client;

            entity.RefId = client.Id;

            EntityManager.Instance.Add(entity);
            return entity;
        }

        public static IEntity GetEntity(this INetworkClient client)
        {
            return EntityManager.Instance.GetByRef(client.Id);
        }
    }
}
