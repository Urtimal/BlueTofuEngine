using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Module.Account;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.LoginServer
{
    public static class LoginEntityExtensions
    {
        public static IEntity CreateLogin(this EntityFactory factory, INetworkClient client)
        {
            var entity = EntityBuilder.Create()
                                .AddComponent<NetworkComponent>()
                                .AddComponent<AccountComponent>()
                                .Build(EntityManager.Instance.GetNextId());
            
            entity.GetComponent<NetworkComponent>().Client = client;

            EntityManager.Instance.Add(entity);
            return entity;
        }
    }
}
