using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Events
{
    public class ClientConnectedEventArgs : SystemEventArgs
    {
        public override bool CheckIsValid()
        {
            return true;
        }
    }
}
