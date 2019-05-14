using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Events
{
    public class ClientEnteringGameEventArgs : SystemEventArgs
    {
        public ClientEnteringGameEventArgs()
        {
        }

        public override bool CheckIsValid()
        {
            return true;
        }
    }
}
