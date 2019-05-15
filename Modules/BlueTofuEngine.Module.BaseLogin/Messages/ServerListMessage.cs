using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    [NetworkMessage(Id)]
    public class ServerListMessage : NetworkMessage
    {
        public const ushort Id = 30;

        public List<GameServerInformations> Servers { get; private set; }
        public bool CanCreateNewCharacters { get; set; } = true;

        public ServerListMessage(IEnumerable<Server> servers) : base(Id)
        {
            Servers = new List<GameServerInformations>();

            init(servers);
        }

        private void init(IEnumerable<Server> servers)
        {
            Servers.AddRange(servers.Select(x => new GameServerInformations(x)));
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteShort((short)Servers.Count);
            foreach (var server in Servers)
                server.Serialize(writer);
            writer.WriteVarShort(0); // Already connected to server id
            writer.WriteBool(CanCreateNewCharacters);
        }
    }
}
