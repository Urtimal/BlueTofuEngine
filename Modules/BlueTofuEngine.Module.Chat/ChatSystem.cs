using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Module.Chat.Messages;
using BlueTofuEngine.Module.Stats.Messages;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Extensions;
using BlueTofuEngine.World.Game.GameContext;
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

                case ClientEnteringGameEventArgs cegea:
                    entity.Notify(new SendInfoMessageEventArgs(10089));
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }
    }
}
