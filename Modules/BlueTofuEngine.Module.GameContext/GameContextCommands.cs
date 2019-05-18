using BlueTofuEngine.Module.Base;
using BlueTofuEngine.Module.Chat;
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
        #region Teleport

        public static void Command_Teleport(IEntity entity, string args)
        {
            var parts = args.Split(' ').Select(x => x.Trim());
            if (parts.Count() != 3)
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
                foreach (var target in targets)
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
