
using BlueTofuEngine.World.Components;

namespace BlueTofuEngine.Module.GameContext
{
    public class GameContextComponent : IComponent
    {
        public string ComponentName => "context";

        public GameContextType Type { get; set; }
        public uint ContextualId { get; set; }
    }
}
