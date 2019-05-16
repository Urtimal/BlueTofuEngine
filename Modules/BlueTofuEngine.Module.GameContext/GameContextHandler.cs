using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.GameServer;
using BlueTofuEngine.Module.GameContext.Core;
using BlueTofuEngine.Module.GameContext.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueTofuEngine.Module.GameContext
{
    public static class GameContextHandler
    {
        [NetworkMessageHandler(GameContextCreateRequestMessage.Id)]
        public static void OnCreateRequest(INetworkClient client, GameContextCreateRequestMessage gccrm)
        {
            client.GetEntity().Notify(new GameContextCreateRequestEventArgs());
        }

        [NetworkMessageHandler(MapInformationsRequestMessage.Id)]
        public static void OnMapInformationsRequest(INetworkClient client, MapInformationsRequestMessage mirm)
        {
            client.Send(new MapComplementaryInformationsDataMessage(mirm.MapId, client.GetEntity()));
        }
    }
}
