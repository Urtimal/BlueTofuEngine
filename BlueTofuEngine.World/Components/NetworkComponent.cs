using BlueTofuEngine.Core.Network;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Components
{
    public class NetworkComponent : IComponent
    {
        public string Name => "network";
        public INetworkClient Client { get; set; }
    }
}
