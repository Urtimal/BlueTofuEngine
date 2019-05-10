using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    public static class ChatCommands
    {
        public static void Command_Info(string args)
        {
            var entities = EntityManager.Instance.Players;
            var ids = args.Split(' ');
            foreach (var id in ids)
            {
                if (int.TryParse(id, out int messageId))
                {
                    foreach (var player in entities)
                        player.Notify(new SendInfoMessageEventArgs(messageId));
                }
            }
        }
    }
}
