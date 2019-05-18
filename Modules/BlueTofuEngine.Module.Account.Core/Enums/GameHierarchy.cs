using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Account
{
    public enum GameHierarchy
    {
        Unavailable = -1,
        Player = 0,
        Moderator = 10,
        GameMasterPadawan = 20,
        GameMaster = 30,
        Admin = 40,
        UnknownSpecialUser = 50
    }
}
