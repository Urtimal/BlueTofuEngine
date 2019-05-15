using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.CharacterSelectionBypass.Messages
{
    [NetworkMessage(Id)]
    public class CharacterListMessage : NetworkMessage
    {
        public const ushort Id = 151;
        
        public List<CharacterBaseInformations> Characters { get; set; }

        public CharacterListMessage(int numberToGenerate) : base(Id)
        {
            Characters = new List<CharacterBaseInformations>();

            //generateRandom(numberToGenerate);
            generateEachClass();
        }

        private void generateRandom(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var charaInfo = new CharacterBaseInformations();
                charaInfo.Initialize(CharacterGenerator.Instance.Generate());
                Characters.Add(charaInfo);
            }
        }

        private void generateEachClass()
        {
            foreach (var breed in CharacterGenerator.Instance.Breeds)
            {
                var charaInfo = new CharacterBaseInformations();
                charaInfo.Initialize(CharacterGenerator.Instance.Generate(breed.Id));
                Characters.Add(charaInfo);
            }
        }

        protected override void serializeContent(ICustomDataWriter writer)
        {
            writer.WriteUShort((ushort)Characters.Count); // Number of characters

            foreach (var character in Characters)
            {
                writer.WriteShort((short)character.ProtocolId);
                character.Serialize(writer);
            }

            writer.WriteBool(false); // Has startup actions
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override string GetSummary()
        {
            return Characters.Count + " characters";
        }
    }
}
