using BlueTofuEngine.Module.Chat;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine
{
    public static class EntityExtensions
    {
        public static ChatComponent Chat(this IEntity entity)
        {
            return entity.GetComponent<ChatComponent>();
        }
    }
}
