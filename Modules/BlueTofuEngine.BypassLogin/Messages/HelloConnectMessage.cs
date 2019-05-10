using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.BypassLogin.Messages
{
    [NetworkMessage(Id)]
    public class HelloConnectMessage : NetworkMessage
    {
        public const ushort Id = 3;

        public string Salt { get; set; }
        public List<byte> Key { get; set; }

        public HelloConnectMessage() : base(Id)
        { }
        
        protected override void serializeContent(ICustomDataWriter writer)
        {
            string data = "00206a756d7763356b6d2558463c5f6e293351336e63574c415846622265684b4f2bb1021c6739e89c88ea8509b0a515ea4a8f91f2a64b415effb94366c7a6de67fdd1de56e9cdd71d1c08eb8252036c00bd1a898ddea0c37276c6af6be90e2c0319660cb6af3ad039d341df2acff17853f9a78b34037f426190b527d93c286fcdce78f9091d8b63e37b289d9d46ff432779fdf53b3b9432902540d8dffd9516ceedf592db9070f6bdb2ddff8dc697cea6283bd554fbcecbf010d81d47d8a16c3571db1fd57b30a30429b5d0c86aefd9e3b6df5c0ab84a05fc8811a52ae780b0199a8416db75e63dd425361f22c2bde0a5ca1b262d2bd4a0cdc9b286c74f3232826a60c028e7364ea45de764d3bd97ca27e69ae690e9d45fe139843936129d88a1fc737b1ee39b11b54c40fe311904ab5f5f9bd4c862294c0431ceae1a390c66ce3cbdbd8a4c997afff92c1a72610ca56f9516d718";
            var bytes = new List<byte>();
            while (!string.IsNullOrEmpty(data))
            {
                bytes.Add(byte.Parse(data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber));
                data = data.Substring(2);
            }
            writer.WriteBytes(bytes.ToArray());

            //writer.WriteUTF(Salt);
            //writer.WriteVarInt(Key.Count);
            //for (int i = 0; i < Key.Count; i++)
            //    writer.WriteByte(Key[i]);
        }

        public override void Deserialize(ICustomDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
