using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public static class CharacterHandlers
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
    }
}
