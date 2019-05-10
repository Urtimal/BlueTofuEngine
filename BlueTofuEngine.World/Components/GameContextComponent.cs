using BlueTofuEngine.World.Context;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Game.GameContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Components
{
    public class GameContextComponent : IComponent
    {
        public string Name => "gamecontext";

        public GameContextType Type { get; set; }
        public IContext Context { get; set; }
    }

    public static class GameContextComponentExtension
    {
        public static GameContextComponent Context(this IEntity entity)
        {
            return entity.GetComponent<GameContextComponent>();
        }
    }
}
