using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.AppBuilder
{
    public abstract class AppStartup
    {
        public virtual void Configure(IAppBuilder app) { }
        public virtual void ConfigureServices(IServiceCollection services) { }
    }
}
