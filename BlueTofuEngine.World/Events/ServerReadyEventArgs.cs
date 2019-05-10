using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Events
{
    public class ServerReadyEventArgs : SystemEventArgs
    {
        public override bool CheckIsValid()
        {
            return true;
        }
    }
}
