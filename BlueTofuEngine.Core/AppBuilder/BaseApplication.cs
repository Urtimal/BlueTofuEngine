using BlueTofuEngine.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.AppBuilder
{
    public abstract class BaseApplication : IApplication
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }
        
        private IEnumerable<Delegate> _startupDelegates;
        private IEnumerable<Delegate> _shutdownDelegates;

        public static AppBuilder<TApp> CreateBuilder<TApp>(string[] args) where TApp : BaseApplication, new()
        {
            var env = new AppEnvironment();
            env.Add(new ServiceCollection());
            env.Add(new DefaultConfiguration());
            return new AppBuilder<TApp>(env);
        }

        public void Initialize(IConfiguration configuration, IServiceProvider serviceProvider, IEnumerable<Delegate> startups, IEnumerable<Delegate> shutdowns)
        {
            Configuration = configuration;
            _startupDelegates = startups;
            _shutdownDelegates = shutdowns;
            ServiceProvider = serviceProvider;
            GlobalServiceProvider.Services = serviceProvider;
        }

        public void Run()
        {
            foreach (var startupDelegate in _startupDelegates)
                ServiceProvider.InvokeMethod(startupDelegate);

            OnRun();

            foreach (var shutdownDelegate in _shutdownDelegates)
                ServiceProvider.InvokeMethod(shutdownDelegate);
        }

        protected abstract void OnRun();
    }
}
