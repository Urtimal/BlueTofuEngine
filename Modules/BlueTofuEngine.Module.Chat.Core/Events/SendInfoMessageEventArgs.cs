using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Module.Chat.Core;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    public class SendInfoMessageEventArgs : SystemEventArgs
    {
        public InfoMessageType Type { get; set; }
        public short MessageId { get; set; }
        public List<string> Args { get; set; }

        public SendInfoMessageEventArgs()
        {
            Args = new List<string>();
        }

        public SendInfoMessageEventArgs(int id)
        {
            Args = new List<string>();

            var infoMessage = GameDataManager<InfoMessage>.Instance.Get(id);
            if (infoMessage != null)
            {
                Type = (InfoMessageType)infoMessage.Type;
                MessageId = (short)infoMessage.Id;
            }
        }

        public override bool CheckIsValid()
        {
            return MessageId > 0 && Args != null;
        }
    }
}
