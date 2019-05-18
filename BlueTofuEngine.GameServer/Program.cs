using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.World.Context;
using BlueTofuEngine.World.Systems;
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
        }
    }
}
