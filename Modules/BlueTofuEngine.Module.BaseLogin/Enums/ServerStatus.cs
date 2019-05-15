using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.BaseLogin
{
    public enum ServerStatus
    {
        Unknown,
        Offline,
        Starting,
        Online,
        NoJoin,
        Saving,
        Stopping,
        Full
    }
}
