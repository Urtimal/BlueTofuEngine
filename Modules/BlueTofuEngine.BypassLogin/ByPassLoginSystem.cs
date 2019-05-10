using BlueTofuEngine.BypassLogin.Messages;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Extensions;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.BypassLogin
{
    public class ByPassLoginSystem : ISystem
    {
        public void OnNotification(IEntity entity, SystemEventArgs args)
        {
            switch (args)
            {
                case ClientConnectedEventArgs ccea:
                    entity.Send(new ProtocolRequiredMessage());
                    entity.Send(new HelloConnectMessage());
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }
    }
}
