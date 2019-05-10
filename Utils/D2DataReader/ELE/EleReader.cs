using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D2DataLib.ELE
{
    public static class EleReader
    {
        public static ElementCollection Read(string inputFile)
        {
            var tmpFile = decompressFile(inputFile);
            var s = File.OpenRead(tmpFile);
            var collection = new ElementCollection();
            collection.TmpFile = tmpFile;
            collection.Read(s);
            return collection;
        }

        private static string decompressFile(string inputFile)
        {
            var outputFile = inputFile + ".raw";
            var sr = File.OpenRead(inputFile);
            var s = new ZlibStream(sr, CompressionMode.Decompress);
            var bytes = s.ReadToEnd().ToArray();
            File.WriteAllBytes(outputFile, bytes);
            s.Close();
            sr.Close();
            return outputFile;
        }
    }
}
