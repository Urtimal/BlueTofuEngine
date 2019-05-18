using BlueTofuEngine.Core;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    public class MapManager : Singleton<MapManager>
    {
        private readonly Dictionary<long, IContext> _loadedMaps;

        public MapManager()
        {
            _loadedMaps = new Dictionary<long, IContext>();
        }

        public IContext GetMapContext(long mapId)
        {
            if (_loadedMaps.ContainsKey(mapId))
                return _loadedMaps[mapId];
            var context = ContextFactory.Instance.CreateBlank();
            context.AddComponent<MapContextComponent>();
            context.Map().Id = mapId;
            _loadedMaps.Add(mapId, context);
            return context;
        }
    }
}
