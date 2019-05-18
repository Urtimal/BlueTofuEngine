using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlueTofuEngine.Core.Utils
{
    public static class MD5Utils
    {
        public static string Hash(string str)
        {
            using (var md5 = MD5.Create())
            {
                var data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                return string.Join("", data.Select(x => x.ToString("x2")));
            }
        }
    }
}
