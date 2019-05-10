using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Command;
using BlueTofuEngine.Core.Network;
using BlueTofuEngine.GameServer.Network;
using BlueTofuEngine.World.Context;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.GameServer
{
    public class GameServerApp : BaseApplication
    {
        public static AppBuilder<GameServerApp> Create(string[] args)
        {
            return CreateBuilder<GameServerApp>(args);
        }

        private Network.GameServer _server;

        protected override void OnRun()
        {
            _server = new Network.GameServer();
            _server.Initialize("127.0.0.1", 5556);
            Console.WriteLine("Starting server...");
            _server.Start();

            Console.WriteLine("Server started on port 5556");
            var cmd = string.Empty;
            while (cmd != "stop")
            {
                if (cmd.StartsWith("send"))
                    send_command(cmd.Substring(4));
                else if (!string.IsNullOrEmpty(cmd))
                {
                    var index = cmd.IndexOf(' ');
                    if (index != -1)
                    {
                        var commandName = cmd.Substring(0, index);
                        ConsoleCommandService.Instance.Execute(commandName, cmd.Substring(cmd.IndexOf(' ') + 1));
                    }
                }
                cmd = Console.ReadLine();
            }
        }

        private void send_command(string command)
        {
            try
            {
                var args = command.Split(',').Select(x => x.Trim());
                var messageId = ushort.Parse(args.First());
                var message = new CustomNetworkMessage(messageId);

                foreach (var arg in args.Skip(1))
                {
                    var parts = arg.Split(':');
                    switch (parts[0])
                    {
                        case "b":
                            message.Add(byte.Parse(parts[1]));
                            break;
                        case "sb":
                            message.Add(sbyte.Parse(parts[1]));
                            break;
                        case "s":
                            message.Add(short.Parse(parts[1]));
                            break;
                        case "us":
                            message.Add(ushort.Parse(parts[1]));
                            break;
                        case "vs":
                            message.Add(short.Parse(parts[1]), true);
                            break;
                        case "vus":
                            message.Add(ushort.Parse(parts[1]), true);
                            break;
                        case "i":
                            message.Add(int.Parse(parts[1]));
                            break;
                        case "ui":
                            message.Add(uint.Parse(parts[1]));
                            break;
                        case "vi":
                            message.Add(int.Parse(parts[1]), true);
                            break;
                        case "vui":
                            message.Add(uint.Parse(parts[1]), true);
                            break;
                        case "l":
                            message.Add(long.Parse(parts[1]));
                            break;
                        case "ul":
                            message.Add(ulong.Parse(parts[1]));
                            break;
                        case "vl":
                            message.Add(long.Parse(parts[1]), true);
                            break;
                        case "vul":
                            message.Add(ulong.Parse(parts[1]), true);
                            break;
                        case "bo":
                            message.Add(bool.Parse(parts[1]));
                            break;
                        case "f":
                            message.Add(float.Parse(parts[1]));
                            break;
                        case "d":
                            message.Add(double.Parse(parts[1]));
                            break;
                        case "utf":
                            message.Add(parts[1]);
                            break;
                    }
                }

                foreach (var client in _server.Clients)
                    client.Send(message);
            }
            catch
            {
                Console.WriteLine("ERRROR");
            }
        }
    }
}
