using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.GameServer;
using BlueTofuEngine.Module.Base;
using BlueTofuEngine.Module.Character;
using BlueTofuEngine.Module.GameContext.Data;
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
            var mapContext = MapManager.Instance.GetMapContext(mirm.MapId);
            client.Send(new MapComplementaryInformationsDataMessage(mapContext));
            client.GetEntity().Notify(new SendCharacterRestrictionsEventArgs());
        }

        [NetworkMessageHandler(GameMapMovementRequestMessage.Id)]
        public static void OnGameMapMovementRequest(INetworkClient client, GameMapMovementRequestMessage gmmrm)
        {
            client.GetEntity().Notify(new MoveEntityOnMapEventArgs(client.GetEntity(), gmmrm.Keys));
        }

        [NetworkMessageHandler(GameMapMovementConfirmMessage.Id)]
        public static void OnGameMapMovementConfirm(INetworkClient client, GameMapMovementConfirmMessage gmmcm)
        {
            var location = client.GetEntity().Location();
            location.CellId = location.NextCellId;
            location.Direction = location.NextDirection;
        }

        [NetworkMessageHandler(ChangeMapMessage.Id)]
        public static void OnChangeMapRequest(INetworkClient client, ChangeMapMessage cmm)
        {
            var eventArgs = new ChangeMapEventArgs(0, client.GetEntity().Location().CellId, client.GetEntity().Location().Direction);

            int cellId = client.GetEntity().Location().CellId;
            int posX = cellId % 14;
            int posY = cellId / 14;
            Direction dir;
            if (posX == 0)
            {
                dir = Direction.Left;
                eventArgs.CellId += 13;
            }
            else if (posX == 13)
            {
                dir = Direction.Right;
                eventArgs.CellId -= 13;
            }
            else if ((posY == 0 || posY == 1))
            {
                dir = Direction.Up;
                eventArgs.CellId += 532;
            }
            else if ((posY == 39 || posY == 38))
            {
                dir = Direction.Down;
                eventArgs.CellId -= 532;
            }
            else
                return;

            MapScrollAction scrollActions = GameDataManager<MapScrollAction>.Instance.Get((int)client.GetEntity().Location().MapId);
            if (scrollActions == null)
                eventArgs.MapId = cmm.MapId;
            else
            {
                switch (dir)
                {
                    case Direction.Up:
                        if (scrollActions.TopMapExists)
                            eventArgs.MapId = (long)scrollActions.TopMapId;
                        break;
                    case Direction.Down:
                        if (scrollActions.BottomMapExists)
                            eventArgs.MapId = (long)scrollActions.BottomMapId;
                        break;
                    case Direction.Left:
                        if (scrollActions.LeftMapExists)
                            eventArgs.MapId = (long)scrollActions.LeftMapId;
                        break;
                    case Direction.Right:
                        if (scrollActions.RightMapExists)
                            eventArgs.MapId = (long)scrollActions.RightMapId;
                        break;
                }

                if (eventArgs.MapId == 0)
                    eventArgs.MapId = cmm.MapId;
            }

            client.GetEntity().Notify(eventArgs);
        }
    }
}
