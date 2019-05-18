using BlueTofuEngine.Core;
using BlueTofuEngine.World.Context;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World
{
    public class ContextFactory : Singleton<ContextFactory>
    {
        public IContext CreateBlank()
        {
            var context = ContextBuilder.Create().Build(ContextManager.Instance.GetNextId());
            ContextManager.Instance.Add(context);
            return context;
        }

        public uint GetNextId()
        {
            return ContextManager.Instance.GetNextId();
        }
    }
}
