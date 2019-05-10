using BlueTofuEngine.Core.AppBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Core
{
    public class AppEnvironment : IEnvironment
    {
        private readonly List<object> _objects;

        public AppEnvironment()
        {
            _objects = new List<object>();
        }

        public TObject Get<TObject>()
        {
            return (TObject)_objects.First(x => x is TObject);
        }

        public void Add(object obj)
        {
            _objects.Add(obj);
        }
    }
}
