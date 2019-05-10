using BlueTofuEngine.Module.Account;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine
{
    public static class EntityExtensions
    {
        public static AccountComponent Account(this IEntity entity)
        {
            return entity.GetComponent<AccountComponent>();
        }
    }
}
