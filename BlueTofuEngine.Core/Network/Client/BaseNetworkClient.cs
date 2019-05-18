using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using ErpoowEngine.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Core.Network.Client
{
    public abstract class BaseNetworkClient : INetworkClient
    {
        public Guid Id { get; private set; }
        public INetworkServer Server { get; private set; }
        public string Endpoint => _client.RemoteEndPoint;
        public string Nickname { get; set; }

        private readonly EEClient _client;
        private int _counter = 0;

        public BaseNetworkClient(EEClient client, INetworkServer server)
        {
            Id = Guid.NewGuid();
            Server = server;
            _client = client;
            _client.DataReceived += Handle;
            _client.Disconnected += OnDisconnect;

            OnConnected();
        }

        public void Send(byte[] message)
        {
            _client.Send(message);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("[" + Nickname + "] >> " + message.Length + " bytes");
            Console.ResetColor();
        }

        public void Send(INetworkMessage message)
        {
            var data = new CustomDataWriter();
            message.Serialize(data);
            //var path = Path.Combine("packets", Nickname + "_" + _counter.ToString("0000") + "_" + ((NetworkMessage)message).MessageId + ".bin");
            //if (!Directory.Exists(Path.GetDirectoryName(path)))
            //    Directory.CreateDirectory(Path.GetDirectoryName(path));
            //File.WriteAllBytes(path, data.GetBytes());
            //_counter++;
            _client.Send(data.GetBytes());
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("[" + Nickname + "] >> " + message.GetName() + " | " + message.GetSummary());
            Console.ResetColor();
        }
        
        public void Handle(byte[] message)
        {
            var header = BitConverter.ToUInt16(message.Take(2).Reverse().ToArray(), 0);
            var messageId = header >> 2;
            var lengthType = header & 3;
            var data = message.Skip(6);
            var networkMessage = NetworkMessageRepository.Instance.Get((uint)messageId);
            int messageLength = 0;
            if (networkMessage == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("[" + Nickname + "] << UnknownMessage(" + messageId + ") | Size: " + message.Length + " bytes");
                Console.ResetColor();
                return;
            }
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[" + Nickname + "] << " + networkMessage.GetName() + " | " + networkMessage.GetSummary());
            Console.ResetColor();
            NetworkMessageHandlerService.Instance.Handle(this, (NetworkMessage)networkMessage);
        }

        protected virtual void OnDisconnect()
        {
            _client.DataReceived -= Handle;
            _client.Disconnected -= OnDisconnect;
            Server.DisconnectClient(Id);
        }

        protected virtual void OnConnected() { }

        public void Disconnect()
        {
            Server.DisconnectClient(Id);
        }

        public void Close()
        {
            _client.Close();
        }
    }
}
