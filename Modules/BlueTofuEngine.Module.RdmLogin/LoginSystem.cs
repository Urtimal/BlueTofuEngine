using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Utils;
using BlueTofuEngine.Module.Account;
using BlueTofuEngine.Module.Base;
using BlueTofuEngine.Module.BaseLogin;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueTofuEngine.Module.RdmLogin
{
    public class LoginSystem : ISystem
    {
        public void OnNotification(IEntity entity, SystemEventArgs args)
        {
            switch (args)
            {
                case ClientConnectedEventArgs ccea:
                    entity.Send(new ProtocolRequiredMessage());
                    entity.Send(new RawDataMessage());
                    break;

                case ClientAuthentificationRequestEventArgs carea:
                    var hashedPassword = MD5Utils.Hash(carea.Password);
                    var account = UserDataService.Instance.Get<AccountUserData>(x => x.Username.Equals(carea.Username));
                    if (account == null)
                    {
                        account = new AccountUserData
                        {
                            CreationDate = DateTime.Now,
                            IsAdmin = false,
                            Nickname = carea.Username,
                            AccountId = (uint)UserDataService.Instance.GetAll<AccountUserData>().Count() + 1,
                            LastConnectionDate = DateTime.Now,
                            Username = carea.Username,
                            Password = hashedPassword,
                            SecretQuestion = "Pas de question secrete, pas de suppression :)"
                        };
                        UserDataService.Instance.Add(account);
                    }
                    else
                    {
                        if (!account.Password.Equals(hashedPassword))
                        {
                            AuthentificationFailed(entity, IdentificationFailureReason.WrongCredentials);
                            return;
                        }
                    }

                    account.LastConnectionDate = DateTime.Now;
                    UserDataService.Instance.Update(account);
                    AuthentificationSuccess(entity, account);
                    //ServerList(entity);
                    RedirectToServer(entity, account, "127.0.0.1:5556", 1);
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }

        #region Network

        private void AuthentificationFailed(IEntity entity, IdentificationFailureReason reason)
        {
            entity.Send(new IdentificationFailedMessage(IdentificationFailureReason.WrongCredentials));
        }

        private void AuthentificationSuccess(IEntity entity, AccountUserData account)
        {
            entity.Network().Client.Nickname = account.Nickname;
            entity.Account().AccountId = account.AccountId;

            var ism = new IdentificationSuccessMessage
            {
                HasRights = account.IsAdmin,
                AccountId = (int)account.AccountId,
                Username = account.Username,
                Nickname = account.Nickname,
                SecretQuestion = "Elle est ou la poulette ?",
                AccountCreation = account.CreationDate
            };
            entity.Send(ism);
        }

        private void ServerList(IEntity entity)
        {
            var servers = new List<Server> { GameDataManager<Server>.Instance.Get(1), GameDataManager<Server>.Instance.Get(3) };
            var slm = new ServerListMessage(servers);
            entity.Send(slm);
        }

        private void RedirectToServer(IEntity entity, AccountUserData account, string host, int serverId)
        {

        }

        #endregion
    }
}
