using BlueTofuEngine.Module.Base;
using BlueTofuEngine.Module.Character;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    public static class ChatCommands
    {
        public static void Command_Info(IEntity entity, string args)
        {
            var parts = args.Split(' ').Select(x => x.Trim());
            if (parts.Count() < 2)
            {
                sendCommandInfoHelp(entity);
                return;
            }

            var target = parts.ElementAt(0);
            var messageIdStr = parts.ElementAt(1);
            
            if (!int.TryParse(messageIdStr, out int messageId))
            {
                sendCommandInfoHelp(entity);
                return;
            }
            var message = new SendInfoMessageEventArgs(messageId);
            message.Args.AddRange(parts.Skip(2));

            var targets = CommandParser.ParseTarget(target, entity);
            if (targets == null)
                return;
            foreach (var t in targets.Where(x => x.HasComponent<CharacterComponent>()))
                t.Notify(message);
        }

        private static void sendCommandInfoHelp(IEntity entity)
        {
            if (entity != null)
                entity.Notify(new SendInfoMessageEventArgs(InfoMessages.CustomError, "info", "target messageId [args]"));
            else
                Console.WriteLine("info  target messageId [args]");
        }
    }
}
