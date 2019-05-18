using BlueTofuEngine.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Account
{
    public class AccountUserData : UserData
    {
        public uint AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastConnectionDate { get; set; }
        public string SecretQuestion { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
