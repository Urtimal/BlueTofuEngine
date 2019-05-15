using BlueTofuEngine.Core.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Account
{
    public class AccountCapabilityUserData : UserData
    {
        public uint AccountId { get; set; }
        public bool CanCreateCharacter { get; set; }
        public string BreedsVisibile { get; set; }
        public string BreedsAvailable { get; set; }
        public int Status { get; set; }
    }
}
