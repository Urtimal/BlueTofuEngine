using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Command;
using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Module.Chat;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Systems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlueTofuEngine
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
            ActionQueueManager.Instance.AddActionToQueue(ActionQueues.ClientDisconnected, OnClientDisconnected);
            UserDataService.Instance.RegisterModelCreation(OnChatModelCreation);
        }

        private static void OnChatModelCreation(ModelBuilder builder)
        {
            builder.Entity<CharacterChannelsUserData>()
                   .ToTable("CharacterChannels");
            builder.Entity<CharacterChannelsUserData>()
                   .HasKey(x => new { x.CharacterId });
        }

        private static void OnCharacterLoading(IEntity entity)
        {
            entity.AddComponent<ChatComponent>();

            var channels = UserDataService.Instance.Get<CharacterChannelsUserData>(entity.Character().CharacterId);
            if (channels == null)
            {
                channels = new CharacterChannelsUserData();
                var defaultsChannels = new List<ChatChannelType>()
                {
                    ChatChannelType.General,
                    ChatChannelType.Team,
                    ChatChannelType.Guild,
                    ChatChannelType.Alliance,
                    ChatChannelType.Party,
                    ChatChannelType.Private,
                    ChatChannelType.Community
                };
                channels.SetChannels(defaultsChannels, false);
                var defaultDisallowed = new List<ChatChannelType>()
                {
                    ChatChannelType.Admin,
                    ChatChannelType.Noob,
                    ChatChannelType.Community
                };
                channels.SetChannels(defaultDisallowed, true);
                channels.CharacterId = entity.Character().CharacterId;
                UserDataService.Instance.Add(channels);
            }

            entity.Chat().EnabledChannels.AddRange(channels.GetChannels());
            entity.Chat().DisallowedChannels.AddRange(channels.GetDisallowedChannels());

            entity.Send(new EnabledChannelsMessage
            {
                Channels = entity.Chat().EnabledChannels,
                DisallowedChannels = entity.Chat().DisallowedChannels
            });
            
            entity.Notify(new SendInfoMessageEventArgs(InfoMessages.WelcomeMessage));
        }

        private static void OnClientDisconnected(IEntity entity)
        {
            if (!entity.HasComponent<ChatComponent>())
                return;

            var channels = UserDataService.Instance.Get<CharacterChannelsUserData>(entity.Character().CharacterId);
            channels.SetChannels(entity.Chat().EnabledChannels, false);
            channels.SetChannels(entity.Chat().DisallowedChannels, true);
            UserDataService.Instance.Update(channels);
        }
    }
}
