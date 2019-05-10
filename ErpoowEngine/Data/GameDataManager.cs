using System;
using System.Collections.Generic;
using System.Text;

namespace ErpoowEngine.Data
{
    public static class GameDataManager
    {
        private static Dictionary<Type, GameDataRepository> _repositories = new Dictionary<Type, GameDataRepository>();

        public static GameDataRepository<T> Get<T>() where T : GameData, new()
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repository = new GameDataRepository<T>();
                repository.Load();
                _repositories.Add(typeof(T), repository);
            }

            return (GameDataRepository<T>)_repositories[typeof(T)];
        }
    }
}
