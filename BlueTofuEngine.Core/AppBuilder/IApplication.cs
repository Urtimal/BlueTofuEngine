using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.AppBuilder
{
    public interface IApplication
    {
        IServiceProvider ServiceProvider { get; }
        void Run();
    }
}
