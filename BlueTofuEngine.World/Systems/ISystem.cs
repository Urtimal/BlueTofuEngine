using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Systems
{
    public interface ISystem
    {
        void OnNotification(IEntity entity, SystemEventArgs args);
        void OnTick(float deltaTime);
    }
}
