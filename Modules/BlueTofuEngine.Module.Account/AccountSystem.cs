using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Module.BaseApproach;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Account
{
    public class AccountSystem : ISystem
    {
        public void OnNotification(IEntity entity, SystemEventArgs args)
        {
            switch (args)
            {
                case GameClientAuthenticatedEventArgs gcaea:
                    var accountCapabilities = UserDataService.Instance.Get<AccountCapabilityUserData>(entity.Account().AccountId);
                    if (accountCapabilities != null)
                        entity.Send(AccountCapabilitiesMessage.FromUserData(accountCapabilities));
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }
    }
}
