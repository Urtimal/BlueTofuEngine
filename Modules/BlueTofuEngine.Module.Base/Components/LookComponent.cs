using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Module.Base
{
    public class LookComponent : IComponent
    {
        public string ComponentName => "look";

        public string Name { get; set; }
        public short BonesId { get; set; }
        public List<short> Skins { get; set; }
        public List<int> IndexedColors { get; set; }
        public List<short> Scales { get; set; }

        public LookComponent()
        {
            Skins = new List<short>();
            IndexedColors = new List<int>();
            Scales = new List<short>();
        }

        public void AddSkin(short skinId) => safeAdd(Skins, skinId);
        public void RemoveSkin(short skinId) => safeRemove(Skins, skinId);

        private void safeAdd<T>(List<T> list, T value)
        {
            if (!list.Contains(value))
                list.Add(value);
        }

        private void safeRemove<T>(List<T> list, T value)
        {
            if (list.Contains(value))
                list.Remove(value);
        }
    }
}
