using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Account
{
    public class AccountComponent : IComponent
    {
        public string ComponentName => "account";
        public uint AccountId { get; set; }
    }
}
