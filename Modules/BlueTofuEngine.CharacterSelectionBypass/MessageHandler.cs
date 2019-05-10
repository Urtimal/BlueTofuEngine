using BlueTofuEngine.CharacterSelectionBypass.Messages;
using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Client;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.GameServer;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using System;
using System.Threading;

namespace BlueTofuEngine.CharacterSelectionBypass
{
    public static class MessageHandler
    {
        [NetworkMessageHandler(AuthenticationTicketMessage.Id)]
        public static void OnAuthenticationTicketMessage(INetworkClient client, AuthenticationTicketMessage im)
        {
            client.Send(new AuthenticationTicketAcceptedMessage());
            
            var accountId = client.GetEntity().GetComponent<AccountComponent>().AccountId;
            client.Send(new AccountCapabilitiesMessage(accountId));
        }

        [NetworkMessageHandler(CharactersListRequestMessage.Id)]
        public static void OnCharacterListRequest(INetworkClient client, CharactersListRequestMessage clrm)
        {
            client.Send(new CharacterListMessage(5));
        }

        [NetworkMessageHandler(CharacterSelectionMessage.Id)]
        public static void OnCharacterSelection(INetworkClient client, CharacterSelectionMessage csm)
        {
            var loginEntity = client.GetEntity();
            var characterEntity = EntityManager.Instance.Get((uint)csm.CharacterId);
            characterEntity.AddComponent<AccountComponent>();
            characterEntity.AddComponent<NetworkComponent>();
            characterEntity.AddComponent<MapComponent>();
            characterEntity.Account().AccountId = loginEntity.Account().AccountId;
            characterEntity.Network().Client = loginEntity.Network().Client;
            characterEntity.RefId = loginEntity.RefId;
            EntityManager.Instance.Delete(loginEntity.Id);

            client.Send(new CharacterSelectedSuccessMessage(characterEntity));
            client.Send(new CharacterLoadingCompleteMessage());
            characterEntity.Notify(new ClientEnteringGameEventArgs(characterEntity));
        }
    }
}
