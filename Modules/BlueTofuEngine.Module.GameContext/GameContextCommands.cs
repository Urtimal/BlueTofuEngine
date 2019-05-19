using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Module.Base;
using BlueTofuEngine.Module.Chat;
using BlueTofuEngine.Module.GameContext.Data;
using BlueTofuEngine.Module.GameContext.Messages;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public static class GameContextCommands
    {
        #region Location infos

        public static void Command_LocationInfo(IEntity entity, string args)
        {
            var target = entity;
            if (!string.IsNullOrEmpty(args))
            {
                var t = CommandParser.ParseTarget(args, entity).FirstOrDefault();
                if (t != null)
                    target = t;
            }

            var format = "Map:{0}, Cell:{1}, Direction:{2}, World:{3}, SubArea:{4}, X:{5}, Y:{6}, CC:{7}";
            string str = string.Empty;
            var mapInfos = GameDataManager<MapPosition>.Instance.Get((int)target.Location().MapId);
            str = string.Format(format, (int)mapInfos.Id,
                                        target.Location().CellId,
                                        target.Location().Direction + "(" + ((int)target.Location().Direction) + ")",
                                        mapInfos.WorldMap,
                                        mapInfos.SubAreaId,
                                        mapInfos.PosX,
                                        mapInfos.PosY,
                                        MapCoordinate.GetCompressed((short)mapInfos.PosX, (short)mapInfos.PosY));
            entity.Notify(new SendInfoMessageEventArgs(InfoMessages.Custom, str));
        }

        #endregion

        public static void Command_ShowCell(IEntity entity, string args)
        {
            int cellId = 0;

            if (args.Contains(";"))
            {
                var coords = args.Split(';');
                if (!int.TryParse(coords[0], out int posx))
                    return;
                if (!int.TryParse(coords[1], out int posy))
                    return;

                if (posx < 0 || posx > 13 || posy < 0 || posy > 40)
                    return;

                cellId = (posy * 14) + posx;
            }
            else
            {
                if (!int.TryParse(args, out int cell))
                    return;
                cellId = cell;
            }

            entity.Notify(new ShowCellEventArgs(cellId));
        }

        #region Teleport

        public static void Command_Teleport(IEntity entity, string args)
        {
            var parts = args.Split(' ').Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x));
            if (parts.Count() < 3)
            {
                CommandTeleport_Help(entity);
                return;
            }

            var targets = CommandParser.ParseTarget(parts.ElementAt(0), entity);
            if (targets == null)
                return;

            var location = parts.ElementAt(1);
            switch (location)
            {
                case "cell":
                    teleportToCell(targets, parts.ElementAt(2));
                    break;
                case "map":
                    teleportToMap(targets, parts.ElementAt(2));
                    break;
                case "player":
                    teleportToPlayer(targets, parts.ElementAt(2), entity);
                    break;
                case "coords":
                    teleportToCoords(targets, parts.Skip(2), entity);
                    break;
            }
        }

        private static void teleportToCell(IEnumerable<IEntity> targets, string cell)
        {
            if (int.TryParse(cell, out int c) && c >= 0 && c <= 559)
            {
                foreach (var target in targets)
                {
                    target.Location().CellId = (ushort)c;
                    target.Context.Send(new GameRolePlayShowActorMessage(target));
                }
            }
        }

        private static void teleportToMap(IEnumerable<IEntity> targets, string map)
        {
            if (int.TryParse(map, out int m) && m > 0)
            {
                foreach (var target in targets.Where(x => x.Location().MapId != m))
                    target.Notify(new ChangeMapEventArgs(m, target.Location().CellId, target.Location().Direction));
            }
        }

        private static void teleportToPlayer(IEnumerable<IEntity> targets, string playerName, IEntity sender)
        {
            IEntity player;
            if (playerName == "%me%")
                player = sender;
            else
                player = EntityManager.Instance.Players.FirstOrDefault(x => x.Look().Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));

            if (player == null)
                return;

            var mapId = player.Location().MapId;
            var cellId = player.Location().CellId;
            var direction = player.Location().Direction;

            foreach (var target in targets)
            {
                if (target.Location().MapId == mapId)
                    teleportToCell(new List<IEntity> { target }, cellId.ToString());
                else
                    target.Notify(new ChangeMapEventArgs(mapId, cellId, direction));
            }
        }

        private static void teleportToCoords(IEnumerable<IEntity> targets, IEnumerable<string> options, IEntity sender)
        {
            var coords = options.ElementAt(0).Split(';');
            if (coords.Count() != 2)
                return;

            if (!short.TryParse(coords.ElementAt(0), out short coordX))
                return;
            if (!short.TryParse(coords.ElementAt(1), out short coordY))
                return;

            var compressedCoords = MapCoordinate.GetCompressed(coordX, coordY);
            var maps = GameDataManager<MapCoordinate>.Instance.Get(compressedCoords);
            if (maps == null)
                return;
            
            var originMap = GameDataManager<MapPosition>.Instance.Get((int)sender.Location().MapId);
            var worldId = originMap.WorldMap;
            if (options.Count() == 2 && int.TryParse(options.ElementAt(1), out int wId))
                worldId = wId;

            var mapId = -1;
            foreach (var map in maps.Maps)
            {
                var mapData = GameDataManager<MapPosition>.Instance.Get((int)map);
                if (mapData.WorldMap != worldId)
                    continue;
                mapId = (int)mapData.Id;
            }
            if (mapId == -1)
                mapId = (int)maps.Maps.First();

            teleportToMap(targets, mapId.ToString());
        }

        private static void CommandTeleport_Help(IEntity entity)
        {
            if (entity != null)
                entity.Notify(new SendInfoMessageEventArgs(InfoMessages.CustomError, "teleport", "target [cell,map,player] arg"));
            else
                Console.WriteLine("info  target messageId [args]");
        }

        #endregion
    }
}
