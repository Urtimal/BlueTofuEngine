using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ErpoowEngine.Utils
{
    public static class SafeFileReadWrite
    {
        public static string Read(string filename)
        {
            if (!File.Exists(filename))
                return string.Empty;

            var started = DateTime.Now;
            while (true)
            {
                if (DateTime.Now - started > TimeSpan.FromSeconds(30))
                    throw new TimeoutException("Unable to read the file in 30 seconds");
                try
                {
                    var filecontent = File.ReadAllText(filename);
                    return filecontent;
                }
                catch { }
            }
        }

        public static void Write(string filename, string content)
        {
            var started = DateTime.Now;
            while (true)
            {
                if (DateTime.Now - started > TimeSpan.FromSeconds(30))
                    throw new TimeoutException("Unable to write the file in 30 seconds");
                try
                {
                    File.WriteAllText(filename, content);
                    return;
                }
                catch { }
            }
        }
    }
}
