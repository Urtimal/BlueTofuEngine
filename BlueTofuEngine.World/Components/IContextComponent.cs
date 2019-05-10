using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Components
{
    public interface IContextComponent : IComponent
    {
        Guid InstanceId { get; set; }
    }
}
