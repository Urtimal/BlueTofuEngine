using BlueTofuEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueTofuEngine.World.Context
{
    public class ContextManager : Singleton<ContextManager>
    {
        public IEnumerable<IContext> Contextes => _contextes.Values;

        private readonly Dictionary<uint, IContext> _contextes;
        private uint _idCounter = 1;

        public ContextManager()
        {
            _contextes = new Dictionary<uint, IContext>();
        }

        public uint GetNextId()
        {
            return _idCounter++;
        }

        public void Add(IContext context)
        {
            _contextes.Add(context.Id, context);
        }

        public IContext Get(uint id)
        {
            if (_contextes.TryGetValue(id, out IContext context))
                return context;
            return null;
        }

        public void Delete(uint id)
        {
            _contextes.Remove(id);
        }
    }
}
