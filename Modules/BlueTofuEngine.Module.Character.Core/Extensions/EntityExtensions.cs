using BlueTofuEngine.Module.Character;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine
{
    public static class EntityExtensions
    {
        public static CharacterComponent Character(this IEntity entity)
        {
            return entity.GetComponent<CharacterComponent>();
        }
    }
}
