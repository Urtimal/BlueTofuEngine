using BlueTofuEngine.Core;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    public class GameServerInformations : NetworkType
    {
        public uint ServerId { get; set; }
        public int Type { get; set; }
        public bool IsMonoAccount { get; set; }
        public ServerStatus Status { get; set; }
        public ServerCompletion Completion { get; set; }
        public bool IsSelectable { get; set; }
        public int CharacterCount { get; set; }
        public int CharacterSlots { get; set; }
        public double Date { get; set; }

        public GameServerInformations(Server server)
        {
            ProtocolId = 25;

            ServerId = server.Id;
            Type = server.GameType;
            IsMonoAccount = server.MonoAccount;
            Completion = (ServerCompletion)server.Population;
            Status = ServerStatus.Online;
            IsSelectable = true;
            CharacterCount = 0;
            CharacterSlots = 5;
            Date = server.OpeningDate;
        }

        public override void Serialize(ICustomDataWriter writer)
        {
            var box = new ByteBox();
            box[0] = IsMonoAccount;
            box[1] = IsSelectable;
            writer.WriteByte(box.Value);
            writer.WriteVarShort((short)ServerId);
            writer.WriteByte((byte)Type);
            writer.WriteByte((byte)Status);
            writer.WriteByte((byte)Completion);
            writer.WriteByte((byte)CharacterCount);
            writer.WriteByte((byte)CharacterSlots);
            writer.WriteDouble(Date);
        }
    }
}
