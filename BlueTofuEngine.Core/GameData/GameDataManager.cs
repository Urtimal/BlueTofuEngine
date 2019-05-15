using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;
using System.Linq;

namespace BlueTofuEngine.Core.GameData
{
    public class GameDataManager<TData> : Singleton<GameDataManager<TData>> where TData : new()
    {
        private readonly Dictionary<int, TData> _cachedData;
        private readonly string _genericName;

        public GameDataManager()
        {
            _cachedData = new Dictionary<int, TData>();
            _genericName = getGenericName();
        }

        private string getGenericName()
        {
            var type = typeof(TData);
            var attr = type.GetCustomAttribute<GameDataAttribute>();
            return attr?.Name ?? type.Name;
        }

        public TData Get(int key)
        {
            if (_cachedData.TryGetValue(key, out TData data))
                return data;

            var path = Path.Combine("data", _genericName, key + ".json");
            if (!File.Exists(path))
                return default;

            try
            {
                var loadedData = JsonConvert.DeserializeObject<TData>(File.ReadAllText(path));
                _cachedData.Add(key, loadedData);
                return loadedData;
            }
            catch
            {
                return default;
            }
        }

        public IEnumerable<int> GetAllId()
        {
            var path = Path.Combine("data", _genericName);
            return Directory.EnumerateFiles(path)
                            .Where(x => Path.GetExtension(x).Equals(".json", StringComparison.OrdinalIgnoreCase))
                            .Select(x => int.Parse(Path.GetFileNameWithoutExtension(x)));
        }
    }
}
