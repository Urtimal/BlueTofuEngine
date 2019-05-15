using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseApproach
{
    public class AuthenticationRequestEventArgs : SystemEventArgs
    {
        public string Ticket { get; set; }

        public AuthenticationRequestEventArgs(string ticket)
        {
            Ticket = ticket;
        }

        public override bool CheckIsValid()
        {
            return !string.IsNullOrEmpty(Ticket);
        }
    }
}
