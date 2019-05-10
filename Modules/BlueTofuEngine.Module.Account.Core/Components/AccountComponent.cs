using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Account
{
    public class AccountComponent : IComponent
    {
        public string Name => "account";
        public uint AccountId { get; set; }
    }
}
