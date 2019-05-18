using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Module.Character;
using BlueTofuEngine.Module.Chat.Messages;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.GameData;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueTofuEngine.Module.Chat
{
    public class ChatSystem : ISystem
    {
        public void OnNotification(IEntity entity, SystemEventArgs args)
        {
            switch (args)
            {
                case SendInfoMessageEventArgs simea:
                    var tim = new TextInformationMessage(simea.Type, simea.MessageId, simea.Args.ToArray());
                    entity.Send(tim);
                    break;

                case ClientChatMessageEventArgs ccmea:
                    OnClientChat(entity, ccmea.Channel, ccmea.Content);
                    break;

                case ClientPrivateMessageEventArgs cpmea:
                    OnClientPrivateChat(entity, cpmea.ReceiverName, cpmea.Content);
                    break;

                case ToggleChatChannelEventArgs tccea:
                    if (!entity.Chat().DisallowedChannels.Contains(tccea.Channel))
                    {
                        if (tccea.Enable && !entity.Chat().EnabledChannels.Contains(tccea.Channel))
                            entity.Chat().EnabledChannels.Add(tccea.Channel);
                        else if (!tccea.Enable && entity.Chat().EnabledChannels.Contains(tccea.Channel))
                            entity.Chat().EnabledChannels.Remove(tccea.Channel);
                        entity.Send(new ChannelEnablingChangeMessage(tccea.Channel, tccea.Enable));
                    }
                    break;

                case ShowSmileyEventArgs ssea:
                    ShowSmiley(entity, ssea.Smiley);
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }

        #region Handlers
        
        private void OnClientChat(IEntity entity, ChatChannelType channel, string content)
        {
            if (entity.Chat().DisallowedChannels.Contains(channel))
                return;

            if (channel == ChatChannelType.Guild)
                ChatError(entity, ChatErrorType.NoGuild);
            else if (channel == ChatChannelType.Alliance)
                ChatError(entity, ChatErrorType.Alliance);
            else if (channel == ChatChannelType.Party)
                ChatError(entity, ChatErrorType.NoParty);
            else if (channel == ChatChannelType.Team)
                ChatError(entity, ChatErrorType.NoTeam);
            else
            {
                var message = new ChatServerMessage
                {
                    SenderId = entity.GameContext().ContextualId,
                    SenderName = entity.Look().Name,
                    SenderAccountId = (int)entity.Account().AccountId,
                    Channel = (int)channel,
                    Content = content,
                    FingerPrint = content,
                    Prefix = string.Empty
                };
                entity.Context.Send(message);
            }
        }

        private void OnClientPrivateChat(IEntity entity, string receiverName, string content)
        {
            if (receiverName.Equals(entity.Look().Name, StringComparison.OrdinalIgnoreCase))
            {
                ChatError(entity, ChatErrorType.InteriorMonologue);
                return;
            }

            var receiver = EntityManager.Instance.Players.Where(x => x.HasComponent<CharacterComponent>())
                                                         .FirstOrDefault(x => x.Look().Name.Equals(receiverName, StringComparison.OrdinalIgnoreCase));
            if (receiver == null)
            {
                ChatError(entity, ChatErrorType.ReceiverNotFound);
                return;
            }
            
            receiver.Send(new ChatServerMessage
            {
                SenderId = entity.GameContext().ContextualId,
                SenderName = entity.Look().Name,
                SenderAccountId = (int)entity.Account().AccountId,
                Channel = (int)ChatChannelType.Private,
                Content = content,
                FingerPrint = content,
                Prefix = string.Empty
            });
            entity.Send(new ChatServerCopyMessage
            {
                ReceiverId = receiver.GameContext().ContextualId,
                ReceiverName = receiver.Look().Name,
                Channel = (int)ChatChannelType.Private,
                Content = content,
                FingerPrint = content
            });
        }
        
        private void ChatError(IEntity entity, ChatErrorType error)
        {
            entity.Send(new ChatErrorMessage(error));
        }

        private void ShowSmiley(IEntity entity, int smiley)
        {
            var message = new ChatSmileyMessage
            {
                EntityId = entity.GameContext().ContextualId,
                AccountId = (int)(entity.Account()?.AccountId ?? 0),
                SmileyId = smiley
            };
            entity.Context.Send(message);
        }

        #endregion
    }
}
