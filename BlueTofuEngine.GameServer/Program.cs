using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Network.Message;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlueTofuEngine.GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = GameServerApp.Create(args)
                        .UseStartup<GameServerStartup>()
                        .Build();

            app.Run();

            Console.WriteLine("End");
            Console.ReadLine();
        }
    }

    class GameServerStartup : AppStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<NetworkMessageHandlerService>();
        }

        public override void Configure(IAppBuilder app)
        {
            app.UseBypassCharacterSelection();
            app.UseGameContext();
            app.UseChat();
            app.UseCommonBasic();
        }
    }
}
