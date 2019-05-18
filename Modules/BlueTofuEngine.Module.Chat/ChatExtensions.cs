using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Command;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Module.Chat;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlueTofuEngine.GameServer
{
    public static class ChatExtensions
    {
        public static void UseChat(this IAppBuilder app)
        {
            NetworkMessageRepository.Instance.SearchMessagesInAssembly(Assembly.GetExecutingAssembly());
            NetworkMessageHandlerService.Instance.SearchHandlersInAssembly(Assembly.GetExecutingAssembly());
            SystemManager.Instance.Add<ChatSystem>();
            ConsoleCommandService.Instance.Register("infoMessage", ChatCommands.Command_Info);
            ActionQueueManager.Instance.AddActionToQueue(ActionQueues.CharacterLoading, OnCharacterLoading);
        }

        private static void OnCharacterLoading(IEntity entity)
        {
            entity.Notify(new SendInfoMessageEventArgs(InfoMessages.WelcomeMessage));
        }
    }
}
