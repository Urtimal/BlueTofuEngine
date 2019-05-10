using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core
{
    public interface IConfiguration
    {
        TValue Get<TValue>(string name);
        void Set<TValue>(string name, TValue value);
    }
}
