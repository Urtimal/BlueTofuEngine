using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Utils
{
    public static class RandomUtils
    {
        public static int Next(int min, int max)
        {
            var rand = new Random();
            return rand.Next(min, max);
        }
    }
}
