using BlueTofuEngine.Module.GameContext;
using BlueTofuEngine.World.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine
{
    public static class ContextExtensions
    {
        public static MapContextComponent Map(this IContext context)
        {
            return context.GetComponent<MapContextComponent>();
        }
    }
}