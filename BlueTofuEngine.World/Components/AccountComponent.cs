using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Components
{
    public class AccountComponent : IComponent
    {
        public string Name => "account";
        public uint AccountId { get; set; }
    }
    
    public static class AccountComponentExtensions
    {
        public static AccountComponent Account(this IEntity entity)
        {
            return entity.GetComponent<AccountComponent>();
        }
    }
}
