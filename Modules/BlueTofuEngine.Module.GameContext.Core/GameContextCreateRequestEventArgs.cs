using BlueTofuEngine.World.Events;
using System;

namespace BlueTofuEngine.Module.GameContext.Core
{
    public class GameContextCreateRequestEventArgs : SystemEventArgs
    {
        public override bool CheckIsValid()
        {
            return true;
        }
    }
}
