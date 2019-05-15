using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Module.Account;
using BlueTofuEngine.Module.Base;
using BlueTofuEngine.Module.BaseApproach;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.StandardApproach
{
    public class ApproachSystem : ISystem
    {
        public void OnNotification(IEntity entity, SystemEventArgs args)
        {
            switch (args)
            {
                case ClientConnectedEventArgs ccea:
                    entity.Send(new ProtocolRequiredMessage());
                    entity.Send(new HelloGameMessage());
                    break;

                case AuthenticationRequestEventArgs area:
                    UserDataService.Instance.Reload<AccountUserData>();
                    var account = UserDataService.Instance.Get<AccountUserData>(x => x.Token == area.Ticket);
                    if (account == null)
                        AuthenticationFailed(entity);
                    else
                    {
                        account.Token = null;
                        UserDataService.Instance.Update(account);
                        entity.Account().AccountId = account.AccountId;
                        entity.Network().Client.Nickname = account.Username;
                        AuthenticationSuccess(entity);
                    }
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }

        #region Network

        public void AuthenticationSuccess(IEntity entity)
        {
            entity.Send(new AuthenticationTicketAcceptedMessage());
            entity.Notify(new GameClientAuthenticatedEventArgs());
        }

        public void AuthenticationFailed(IEntity entity)
        {
            entity.Send(new AuthenticationTicketRefusedMessage());
        }

        #endregion
    }
}
