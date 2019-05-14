using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BlueTofuEngine.Module.Base.Utils
{
    public static class EntityLookParser
    {
        public static EntityLook Parse(string look)
        {
            var regex = new Regex(@"{(\d*)\|(\d*)\|(\d*)\|(\d*)}");
            var match = regex.Match(look);
            if (!match.Success)
                return null;

            var entityLook = new EntityLook();
            entityLook.BonesId = short.Parse(match.Groups[1].Value);
            entityLook.Skins.Add(short.Parse(match.Groups[2].Value));
            entityLook.Scales.Add(short.Parse(match.Groups[4].Value));

            return entityLook;
        }
    }
}
