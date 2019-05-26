using BlueTofuEngine.Core.Network;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using D2RealTimeAnalyser.Types;
using PacketDotNet;
using SharpPcap;
using SharpPcap.WinPcap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace D2RealTimeAnalyser
{
    class Program
    {
        static Dictionary<int, Action<INetworkMessage>> _msgToAnalyses;
        static Dictionary<int, string> _messages;

        static void Main(string[] args)
        {
            NetworkTypeFactory.Instance.SearchTypesInAssembly(Assembly.GetExecutingAssembly());
            NetworkMessageRepository.Instance.SearchMessagesInAssembly(Assembly.GetExecutingAssembly());

            _msgToAnalyses = new Dictionary<int, Action<INetworkMessage>>
            {
                { MapComplementaryInformationsDataMessage.Id, OnMapComplementaryInformationsData }
            };


            _messages = new Dictionary<int, string>();
            var fileLines = File.ReadAllLines("messages.txt");
            foreach (var line in fileLines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var parts = line.Split(':');
                var msgId = int.Parse(parts[0]);
                var msgName = parts[1].Split('-').First().Trim();
                _messages.Add(msgId, msgName);
            }

            var devices = CaptureDeviceList.Instance;
            
            for (int i = 0; i < devices.Count; i++)
                Console.WriteLine(i + ": " + devices[i].Description);

            Console.Write("\nChoose a device to listen: ");
            var userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out int deviceId))
                return;

            if (deviceId < 0 || deviceId >= devices.Count)
                return;

            var device = devices[deviceId];

            Console.WriteLine("Listening on '" + device.Description + "'... Press enter to stop");

            device.OnPacketArrival += (s, e) =>
            {
                var packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
                var tcp = (TcpPacket)packet.Extract(typeof(TcpPacket));
                if (tcp != null)
                {
                    if (tcp.PayloadData.Length > 0)
                    {
                        //var time = e.Packet.Timeval.Date;
                        //var len = e.Packet.Data.Length;
                        //var tcpLen = tcp.PayloadData.Length;
                        //var serverSide = tcp.SourcePort == 5555;
                        //var msgHeaderSpan = tcp.PayloadData.Take(2).Reverse().ToArray();
                        //var msgHeader = BitConverter.ToInt16(msgHeaderSpan);
                        //var msgId = (msgHeader & 0xFFFC) >> 2;
                        //if (messages.ContainsKey(msgId))
                        //{
                        //    Console.ForegroundColor = serverSide ? ConsoleColor.Magenta : ConsoleColor.Cyan;
                        //    Console.WriteLine("[" + time.ToString("HH:mm:ss.fff") + "] {" + msgId + "} " + messages[msgId]);
                        //    Console.ResetColor();
                        //}
                        Handle(tcp.PayloadData);
                    }
                }
            };
            device.Open();
            device.Filter = "tcp port 5555";

            device.StartCapture();
            Console.ReadLine();
            device.StopCapture();

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static void Handle(byte[] message)
        {
            var header = BitConverter.ToUInt16(message.Take(2).Reverse().ToArray(), 0);
            var messageId = header >> 2;
            var lengthType = header & 3;
            var data = message.Skip(2);
            var networkMessage = NetworkMessageRepository.Instance.Get((uint)messageId);
            int messageLength = 0;
            if (networkMessage == null)
                return;
            if (lengthType != 0)
            {
                var reader = new CustomDataReader(data.ToArray());
                switch (lengthType)
                {
                    case 1:
                        messageLength = reader.ReadByte();
                        break;
                    case 2:
                        messageLength = reader.ReadUShort();
                        break;
                    case 3:
                        messageLength = reader.ReadByte() << 16;
                        messageLength |= reader.ReadUShort();
                        break;
                }
                networkMessage.Deserialize(reader);   
            }
            if (_msgToAnalyses.ContainsKey(messageId))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(_messages[messageId]);
                Console.ResetColor();
                _msgToAnalyses[messageId].Invoke(networkMessage);
            }
        }

        static void OnMapComplementaryInformationsData(INetworkMessage msg)
        {
            var mcid = (MapComplementaryInformationsDataMessage)msg;
            
            Console.WriteLine("SubArea: " + mcid.SubAreaId);
            Console.WriteLine("Map: " + mcid.MapId);
            Console.WriteLine("Houses: " + mcid.Houses.Count);
        }
    }
}
