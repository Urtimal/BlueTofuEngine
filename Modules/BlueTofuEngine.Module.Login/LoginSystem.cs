using BlueTofuEngine.Module.Base;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Login
{
    public class LoginSystem : ISystem
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
