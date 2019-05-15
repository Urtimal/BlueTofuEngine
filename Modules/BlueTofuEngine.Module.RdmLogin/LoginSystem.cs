using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Utils;
using BlueTofuEngine.Module.Account;
using BlueTofuEngine.Module.Base;
using BlueTofuEngine.Module.BaseLogin;
using BlueTofuEngine.Module.BaseLogin.Utils;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.GameData;
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
                        account = CreateAccount(carea.Username, hashedPassword);
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
                    RedirectToServer(entity, "127.0.0.1", 5556, 1);
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }

        #region Network

        private AccountUserData CreateAccount(string username, string password)
        {
            var account = new AccountUserData
            {
                CreationDate = DateTime.Now,
                IsAdmin = false,
                Nickname = username,
                AccountId = (uint)UserDataService.Instance.GetAll<AccountUserData>().Count() + 1,
                LastConnectionDate = DateTime.Now,
                Username = username,
                Password = password,
                SecretQuestion = "Pas de question secrète, pas de suppression :)"
            };
            string breeds = string.Join(",", GameDataManager<Breed>.Instance.GetAllId());
            var capabilities = new AccountCapabilityUserData
            {
                AccountId = account.AccountId,
                CanCreateCharacter = true,
                Status = (int)GameHierarchy.Player,
                BreedsVisibile = breeds,
                BreedsAvailable = breeds
            };
            UserDataService.Instance.Add(account);
            UserDataService.Instance.Add(capabilities);

            return account;
        }

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

        private void RedirectToServer(IEntity entity, string host, int port, int serverId)
        {
            var ssdm = new SelectedServerDataMessage
            {
                ServerId = serverId,
                Address = host,
                Ports = new List<int> { port },
                CanCreateNewCharacter = true,
                Ticket = TicketGenerator.Generate(32)
            };
            var account = UserDataService.Instance.Get<AccountUserData>(x => x.AccountId == entity.Account().AccountId);
            account.Token = ssdm.Ticket;
            UserDataService.Instance.Update(account);
            
            Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromMilliseconds(500));
                entity.Send(ssdm);
                await Task.Delay(TimeSpan.FromMilliseconds(500));
                entity.Network().Client.Disconnect();
            });
        }

        #endregion
    }
}
