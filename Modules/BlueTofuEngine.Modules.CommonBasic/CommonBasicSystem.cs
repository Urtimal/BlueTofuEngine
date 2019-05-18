using BlueTofuEngine.Module.BaseApproach;
using BlueTofuEngine.Module.CommonBasic;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Modules.CommonBasic
{
    public class CommonBasicSystem : ISystem
    {
        public void OnNotification(IEntity entity, SystemEventArgs args)
        {
            switch (args)
            {
                case GameClientAuthenticatedEventArgs gcaea:
                    entity.Send(new BasicTimeMessage());
                    break;

                case SendNoOperationEventArgs snoea:
                    entity.Send(new BasicNoOperationMessage());
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }
    }
}
