using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace BlueTofuEngine.Core.AppBuilder
{
    public class AppBuilder<TApp> : IAppBuilder where TApp : BaseApplication, new()
    {
        public IConfiguration Configuration { get; }
        public IServiceProvider Services => _serviceProvider;

        public IEnumerable<Delegate> StartupDelegates => _startups;
        public IEnumerable<Delegate> ShutdownDelegates => _shutdowns;

        private readonly List<Delegate> _startups;
        private readonly List<Delegate> _shutdowns;
        private readonly IServiceCollection _serviceCollection;

        private AppStartup _appStartup;
        private ServiceProvider _serviceProvider;
        
        public AppBuilder(IEnvironment env)
        {
            Configuration = env.Get<IConfiguration>();
            _serviceCollection = env.Get<IServiceCollection>();

            _startups = new List<Delegate>();
            _shutdowns = new List<Delegate>();
        }

        void IAppBuilder.AddStartup(Delegate startupDelegate)
        {
            _startups.Add(startupDelegate);
        }

        void IAppBuilder.AddShutdown(Delegate shutdownDelegate)
        {
            _startups.Add(shutdownDelegate);
        }

        public IAppBuilder UseStartup<TStartup>() where TStartup : AppStartup, new()
        {
            _appStartup = Activator.CreateInstance<TStartup>();

            return this;
        }

        IApplication IAppBuilder.Build()
        {
            _appStartup.ConfigureServices(_serviceCollection);
            _serviceCollection.AddSingleton(Configuration);
            _serviceProvider = _serviceCollection.BuildServiceProvider();
            _appStartup.Configure(this);

            var app = new TApp();
            app.Initialize(_serviceProvider.GetRequiredService<IConfiguration>(), _serviceProvider, _startups, _shutdowns);
            return app;
        }
    }
}
