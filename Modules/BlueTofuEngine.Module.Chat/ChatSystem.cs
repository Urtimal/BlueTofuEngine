using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Module.Chat.Messages;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.GameData;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
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
                    OnClientChat(entity, ccmea);
                    break;

                case ClientEnteringGameEventArgs cegea:
                    entity.Notify(new SendInfoMessageEventArgs(InfoMessages.WelcomeMessage));
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }

        private void OnClientChat(IEntity entity, ClientChatMessageEventArgs ccmea)
        {
            var message = new ChatServerMessage
            {
                SenderId = entity.Id,
                SenderName = entity.Look().Name,
                SenderAccountId = (int)entity.Account().AccountId,
                Channel = (int)ccmea.Channel,
                Content = ccmea.Content,
                FingerPrint = ccmea.Content,
                Prefix = string.Empty
            };
            //entity.Context()?.Context?.Send(message);
        }
    }
}
