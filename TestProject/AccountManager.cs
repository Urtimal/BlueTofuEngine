using BlueTofuEngine.Core;
using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Network.Client;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    class AccountManager
    {
        private readonly IConfiguration _configuration;

        public AccountManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Load()
        {
            var path = _configuration.Get<string>("accounts.path") ?? "NOT FOUND";
            Console.WriteLine("Loading account from: '" + path + "'");
        }
    }

    [NetworkMessage(1)]
    class AccountLoginMessage : NetworkMessage
    {
        public AccountLoginMessage() : base(1)
        { }

        public override void Deserialize(ICustomDataReader reader)
        {
        }

        public override void Serialize(ICustomDataWriter writer)
        {
        }
    }

    static class AccountHandler
    {
        [NetworkMessageHandler(1)]
        public static void HandleLogin(NetworkClient client, AccountLoginMessage alm)
        {
            Console.WriteLine("Hola senior !");
        }
    }

    static class AccountExtensions
    {
        public static void AddAccounts(this IServiceCollection service)
        {   
            service.AddSingleton<AccountManager>();
        }

        public static void UseAccounts(this IAppBuilder app)
        {
            app.AddStartup((Action<AccountManager>)LoadAccounts);
        }

        public static void LoadAccounts(AccountManager accountManager)
        {
            accountManager.Load();
        }
    }
}
