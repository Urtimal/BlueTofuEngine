using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public class CharacterSystem : ISystem
    {
        public void OnNotification(IEntity entity, SystemEventArgs args)
        {
            switch (args)
            {
                case SendCharacterRestrictionsEventArgs screa:
                    entity.Send(new SetCharacterRestrictionsMessage(entity));
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }
    }
}
