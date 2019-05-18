using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public static class CharacterListHandlers
    {
        [NetworkMessageHandler(CharactersListRequestMessage.Id)]
        public static void OnCharacterListRequest(INetworkClient client, CharactersListRequestMessage clrm)
        {
            client.GetEntity().Notify(new SendCharacterListEventArgs());
        }

        [NetworkMessageHandler(CharacterCreationRequestMessage.Id)]
        public static void OnCharacterCreationRequest(INetworkClient client, CharacterCreationRequestMessage ccrm)
        {
            var ccrea = new CreateCharacterRequestEventArgs
            {
                Name = ccrm.Name,
                Breed = (Breeds)ccrm.Breed,
                Sex = ccrm.Sex ? Gender.Female : Gender.Male,
                CosmeticId = ccrm.CosmeticId,
                Colors = ccrm.Colors
            };
            client.GetEntity().Notify(ccrea);
        }

        [NetworkMessageHandler(CharacterSelectionMessage.Id)]
        public static void OnCharacterSelection(INetworkClient client, CharacterSelectionMessage csm)
        {
            client.GetEntity().Notify(new CharacterSelectionEventArgs(csm.CharacterId));
        }

        [NetworkMessageHandler(CharacterFirstSelectionMessage.Id)]
        public static void OnCharacterFirstSelection(INetworkClient client, CharacterFirstSelectionMessage cfsm)
        {
            client.GetEntity().Notify(new CharacterSelectionEventArgs(cfsm.CharacterId));
        }
    }
}
