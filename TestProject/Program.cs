using BlueTofuEngine.Core;
using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Configuration;
using BlueTofuEngine.Core.Network.Message;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = TestApp.Create(args)
                        .UseStartup<LoginServerStartup>()
                        .Build();

            app.Run();

            Console.WriteLine("End");
            Console.ReadLine();
        }
    }

    class TestApp : BaseApplication
    {
        public static AppBuilder<TestApp> Create(string[] args)
        {
            return CreateBuilder<TestApp>(args);
        }

        protected override void OnRun()
        {
            Console.WriteLine("Let's go!");

            var loginMessage = new AccountLoginMessage();
            ServiceProvider.GetRequiredService<NetworkMessageHandlerService>().Handle(null, loginMessage);
        }
    }

    class LoginServerStartup : AppStartup
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<NetworkMessageHandlerService>();
            services.AddAccounts();
        }

        public override void Configure(IAppBuilder app)
        {
            NetworkMessageRepository.Instance.SearchMessagesInAssembly(typeof(AccountManager).Assembly);
            app.Services.GetRequiredService<NetworkMessageHandlerService>().SearchHandlersInAssembly(typeof(AccountManager).Assembly);

            app.UseAccounts();
        }
    }
}
