using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.GameContext
{
    [NetworkMessage(Id)]
    public class ShowCellMessage : NetworkMessage
    {
        public const ushort Id = 5612;

        public short CellId { get; set; }
        public int SenderId { get; set; }

        public ShowCellMessage(short cell, int sender) : base(Id)
        {
            CellId = cell;
            SenderId = sender;
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteDouble(SenderId);
            writer.WriteVarShort(CellId);
        }
    }
}
