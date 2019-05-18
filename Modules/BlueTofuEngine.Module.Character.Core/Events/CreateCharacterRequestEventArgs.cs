using BlueTofuEngine.World.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public class CreateCharacterRequestEventArgs : SystemEventArgs
    {
        public string Name { get; set; }
        public Breeds Breed { get; set; }
        public Gender Sex { get; set; }
        public IEnumerable<int> Colors { get; set; }
        public int CosmeticId { get; set; }

        public override bool CheckIsValid()
        {
            return !string.IsNullOrEmpty(Name) && Breed > Breeds.Undefined;
        }
    }
}
