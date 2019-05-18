using BlueTofuEngine.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    public class CharacterChannelsUserData : UserData
    {
        public uint CharacterId { get; set; }
        public string Channels { get; set; }
        public string DisallowedChannels { get; set; }

        public IEnumerable<ChatChannelType> GetChannels()
        {
            return Channels.Split(',').Select(x => (ChatChannelType)int.Parse(x));
        }

        public IEnumerable<ChatChannelType> GetDisallowedChannels()
        {
            return DisallowedChannels.Split(',').Select(x => (ChatChannelType)int.Parse(x));
        }

        public void SetChannels(IEnumerable<ChatChannelType> channels, bool isDisallowed)
        {
            var str = string.Join(",", channels.Select(x => (int)x));
            if (isDisallowed)
                DisallowedChannels = str;
            else
                Channels = str;
        }
    }
}
