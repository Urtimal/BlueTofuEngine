using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.LoginServer
{
    public class LoginServerApp : BaseApplication
    {
        public static AppBuilder<LoginServerApp> Create(string[] args)
        {
            return CreateBuilder<LoginServerApp>(args);
        }

        private Network.LoginServer _server;

        protected override void OnRun()
        {
            _server = new Network.LoginServer();
            _server.Initialize("127.0.0.1", 5555);
            Console.WriteLine("Starting server...");
            _server.Start();

            Console.WriteLine("Server started on port 5555");
            var cmd = string.Empty;
            while (cmd != "stop")
            {
                cmd = Console.ReadLine();
            }
        }
    }
}
