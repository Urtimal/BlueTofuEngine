using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Account
{
    public class ClientAuthentifiedEventArgs : SystemEventArgs
    {
        public uint AccountId { get; set; }

        public override bool CheckIsValid()
        {
            return AccountId >= 0;
        }
    }
}
