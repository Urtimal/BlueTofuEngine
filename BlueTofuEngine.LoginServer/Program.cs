using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Network.Message;
using Microsoft.Extensions.DependencyInjection;
using System;
using BlueTofuEngine.BypassLogin;

namespace BlueTofuEngine.LoginServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = LoginServerApp.Create(args)
                        .UseStartup<LoginServerStartup>()
                        .Build();

            app.Run();

            Console.WriteLine("End");
            Console.ReadLine();
        }
    }

    class LoginServerStartup : AppStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<NetworkMessageHandlerService>();
        }

        public override void Configure(IAppBuilder app)
        {
            app.UseBypassLogin();
        }
    }
}
