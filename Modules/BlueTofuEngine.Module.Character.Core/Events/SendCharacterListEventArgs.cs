﻿using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public class SendCharacterListEventArgs : SystemEventArgs
    {
        public override bool CheckIsValid()
        {
            return true;
        }
    }
}
