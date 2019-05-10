using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Events
{
    public abstract class SystemEventArgs
    {
        public abstract bool CheckIsValid();
    }
}
