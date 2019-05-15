using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    public class ClientAuthentificationRequestEventArgs : SystemEventArgs
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public ClientAuthentificationRequestEventArgs(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override bool CheckIsValid()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }
    }
}
