using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.World.Systems;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.GameServer
{
    public class GameServerStartup : AppStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<NetworkMessageHandlerService>();
        }

        public override void Configure(IAppBuilder app)
        {
            app.UseAccounts();
            app.UseCharacters();

            app.UseStandardApproach();
            app.UseGameContext();
            app.UseChat();
            app.UseCommonBasic();

            app.AddStartup((Action)SystemManager.Instance.Start);
            app.AddShutdown((Action)SystemManager.Instance.Stop);
            app.AddStartup((Action)UserDataService.Instance.Initialize);
        }
    }
}
