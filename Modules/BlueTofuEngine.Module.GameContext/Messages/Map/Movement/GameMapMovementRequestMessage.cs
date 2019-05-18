using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    [NetworkMessage(Id)]
    public class GameMapMovementRequestMessage : NetworkMessage
    {
        public const ushort Id = 950;

        public List<uint> Keys { get; set; }
        public long MapId { get; set; }

        public GameMapMovementRequestMessage() : base(Id)
        {
            Keys = new List<uint>();
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            var keyCount = reader.ReadShort();
            for (int i = 0; i < keyCount; i++)
                Keys.Add((uint)reader.ReadShort());
            MapId = (long)reader.ReadDouble();
        }
    }
}
