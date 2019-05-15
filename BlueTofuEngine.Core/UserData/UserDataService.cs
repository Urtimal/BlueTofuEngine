using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Core.Database
{
    public class UserDataService : Singleton<UserDataService>
    {
        private readonly List<Action<ModelBuilder>> _modelCreationActions;
        private EngineDbContext _context;

        public UserDataService()
        {
            _modelCreationActions = new List<Action<ModelBuilder>>();
        }

        public void RegisterModelCreation(Action<ModelBuilder> modelCreationAction)
        {
            _modelCreationActions.Add(modelCreationAction);
        }

        public void Initialize()
        {
            var builder = new DbContextOptionsBuilder<EngineDbContext>();
            builder.UseNpgsql("Host=127.0.0.1;Database=bte;Username=bte;Password=bte");
            _context = new EngineDbContext(builder.Options, _modelCreationActions);
            _context.Database.EnsureCreated();
        }

        public void Add<TUserData>(TUserData data) where TUserData : UserData
        {
            if (data == null)
                return;

            data.Id = Guid.NewGuid();
            _context.Set<TUserData>().Add(data);
            _context.SaveChanges();
        }
        
        public TUserData Get<TUserData>(object pKey) where TUserData : UserData
        {
            return _context.Set<TUserData>().Find(pKey);
        }

        public TUserData Get<TUserData>(Func<TUserData, bool> predicate) where TUserData : UserData
        {
            return _context.Set<TUserData>().FirstOrDefault(predicate);
        }

        public IEnumerable<TUserData> GetAll<TUserData>() where TUserData : UserData
        {
            return _context.Set<TUserData>().ToList();
        }

        public IEnumerable<TUserData> GetAll<TUserData>(Func<TUserData, bool> predicate) where TUserData : UserData
        {
            return _context.Set<TUserData>().Where(predicate);
        }

        public void Update<TUserData>(TUserData data) where TUserData : UserData
        {
            if (data == null)
                return;
            
            _context.Set<TUserData>().Update(data);
            _context.SaveChanges();
        }

        public void Delete<TUserData>(Guid id) where TUserData : UserData
        {
            var data = Get<TUserData>(id);
            if (data != null)
            {
                _context.Set<TUserData>().Remove(data);
                _context.SaveChanges();
            }
        }
    }
}
