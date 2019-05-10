using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Account.UserData
{
    public class AccountUserData
    {
        public uint Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastConnectionDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
