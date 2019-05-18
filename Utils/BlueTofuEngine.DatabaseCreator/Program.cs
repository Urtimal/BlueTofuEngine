using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Core.Utils;
using BlueTofuEngine.Module.Account;
using System;

namespace BlueTofuEngine.DatabaseCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Get model building...");
            IAppBuilder app = null;
            app.UseAccounts();
            app.UseCharacters();
            app.UseStats();
            app.UseGameContext();
            app.UseChat();
            Console.WriteLine("Building database...");
            UserDataService.Instance.Initialize();

            Console.WriteLine("Done");
        }
    }
}
