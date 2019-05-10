using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ErpoowEngine.Data
{
    public abstract class GameDataRepository
    {
        protected string _dataType;
    }

    public class GameDataRepository<T> : GameDataRepository where T : GameData, new()
    {
        private Dictionary<int, T> _fields;
        
        public GameDataRepository()
        {
            _fields = new Dictionary<int, T>();
            _dataType = new T().Type;
        }

        public void Add(T gameData)
        {
            if (_fields.ContainsKey(gameData.Id))
                _fields[gameData.Id] = gameData;
            else
                _fields.Add(gameData.Id, gameData);
        }
        
        public T Get(int id)
        {
            if (_fields.ContainsKey(id))
                return _fields[id];
            return new T();
        }

        public T Get(Func<T, bool> predicate)
        {
            return _fields.Values.FirstOrDefault(predicate) ?? new T();
        }

        public IEnumerable<T> GetAll()
        {
            return _fields.Values;
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            return _fields.Values.Where(predicate);
        }

        public T Load(int id)
        {
            var data = GameDataLoader.Load<T>(id);
            if (data.Loaded)
                Add(data);

            return data;
        }

        public void Load()
        {
            var dataCollection = GameDataLoader.LoadAll<T>();
            foreach (var data in dataCollection)
                Add(data);
        }

        public void Save(int id)
        {
            var data = Get(id);
            if (data.Loaded)
                GameDataLoader.Save(data);
        }

        public void Save()
        {
            GameDataLoader.Save<T>(_fields.Values);
        }

        public void Delete(T gameData)
        {
            if (_fields.ContainsKey(gameData.Id))
            {
                GameDataLoader.Delete(gameData);
                _fields.Remove(gameData.Id);
            }
        }
    }
}
