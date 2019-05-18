using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    [NetworkMessage(Id)]
    public class CharacterFirstSelectionMessage : CharacterSelectionMessage
    {
        public new const ushort Id = 6084;

        public bool DoTutorial { get; set; }

        public CharacterFirstSelectionMessage() : base(Id)
        {
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            base.Deserialize(reader);

            DoTutorial = reader.ReadBool();
        }

        public override string GetSummary()
        {
            return base.GetSummary() + " - Tutorial: " + DoTutorial;
        }
    }
}
