using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Chat
{
    public class ShowSmileyEventArgs : SystemEventArgs
    {
        public int Smiley { get; set; }

        public ShowSmileyEventArgs(int smiley)
        {
            Smiley = smiley;
        }

        public override bool CheckIsValid()
        {
            return Smiley >= 0;
        }
    }
}
