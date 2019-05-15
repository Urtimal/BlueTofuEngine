using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    [NetworkMessage(Id)]
    public class CharacterCreationRequestMessage : NetworkMessage
    {
        public const ushort Id = 160;

        public string Name { get; set; }
        public int Breed { get; set; }
        public bool Sex { get; set; }
        public List<int> Colors { get; set; }
        public int CosmeticId { get; set; }

        public CharacterCreationRequestMessage() : base(Id)
        {
            Colors = new List<int>();
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            Name = reader.ReadUTF();
            Breed = reader.ReadByte();
            Sex = reader.ReadBool();
            for (int i = 0; i < 5; i++)
                Colors.Add(reader.ReadInt());
            CosmeticId = reader.ReadVarShort();
        }
    }
}
