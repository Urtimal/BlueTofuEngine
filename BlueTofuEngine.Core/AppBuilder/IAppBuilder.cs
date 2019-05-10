using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.AppBuilder
{
    public interface IAppBuilder
    {
        IConfiguration Configuration { get; }
        IServiceProvider Services { get; }
        
        void AddStartup(Delegate startupDelegate);
        void AddShutdown(Delegate shutdownDelegate);

        IAppBuilder UseStartup<TStartup>() where TStartup : AppStartup, new();
        IApplication Build();
    }
}
