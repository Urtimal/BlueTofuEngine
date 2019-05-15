using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseApproach
{
    public class GameClientAuthenticatedEventArgs : SystemEventArgs
    {
        public override bool CheckIsValid()
        {
            return true;
        }
    }
}
