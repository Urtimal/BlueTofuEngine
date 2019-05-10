using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D2DataLib.DLM
{
    public static class DlmReader
    {
        public const string EncryptionKey = "649ae451ca33ec53bbcbcc33becf15f4";
        public static Map Read(string filepath, string outputFolder)
        {
            decompressDlm(filepath, outputFolder);
            var s = File.OpenRead(Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filepath) + ".map"));

            var header = s.ReadByte();
            if (header != 77)
                return null;

            var map = new Map();

            map.Version = s.ReadByte();
            map.Id = s.ReadUInt();
            if (map.Version >= 7)
            {
                map.Encrypted = s.ReadBoolean();
                map.EncryptionVersion = s.ReadByte();
                var dataLen = s.ReadInt();
                if (map.Encrypted)
                {
                    var decryptionKey = Encoding.UTF8.GetBytes(EncryptionKey);
                    var data = s.ReadBytes(dataLen, false).ToArray();
                    for (int i = 0; i < data.Length; i++)
                        data[i] ^= decryptionKey[i % decryptionKey.Length];
                    //File.WriteAllBytes(Path.Combine(outputFolder, map.Id + ".mapd"), data);
                    readMapData(new MemoryStream(data), map);
                    s.Close();
                    File.Delete(Path.Combine(outputFolder, map.Id + ".map"));
                    return map;
                }
            }

            readMapData(s, map);
            File.Delete(Path.Combine(outputFolder, map.Id + ".map"));
            return map;
        }

        private static void readMapData(Stream s, Map map)
        {
            map.RelativeId = s.ReadUInt();
            map.Type = s.ReadByte();
            map.SubAreaId = s.ReadInt();
            map.Neighbours.Top = s.ReadUInt();
            map.Neighbours.Bottom = s.ReadUInt();
            map.Neighbours.Left = s.ReadUInt();
            map.Neighbours.Right = s.ReadUInt();
            map.ShadowBonusOnEntities = s.ReadUInt();

            if (map.Version >= 9)
            {
                var readColor = s.ReadUInt();
                map.BackgroundColor.Alpha = (byte)((readColor & 0b11111111_00000000_00000000_00000000) >> 32);
                map.BackgroundColor.Red =   (byte)((readColor & 0b00000000_11111111_00000000_00000000) >> 16);
                map.BackgroundColor.Green = (byte)((readColor & 0b00000000_00000000_11111111_00000000) >> 8);
                map.BackgroundColor.Blue =  (byte)((readColor & 0b00000000_00000000_00000000_11111111) >> 0);

                readColor = s.ReadUInt();
                map.GridColor.Alpha = (byte)((readColor & 0b11111111_00000000_00000000_00000000) >> 32);
                map.GridColor.Red =   (byte)((readColor & 0b00000000_11111111_00000000_00000000) >> 16);
                map.GridColor.Green = (byte)((readColor & 0b00000000_00000000_11111111_00000000) >> 8);
                map.GridColor.Blue =  (byte)((readColor & 0b00000000_00000000_00000000_11111111) >> 0);
            }
            else if (map.Version >= 3)
            {
                map.BackgroundColor.Red = (byte)s.ReadByte();
                map.BackgroundColor.Green = (byte)s.ReadByte();
                map.BackgroundColor.Blue = (byte)s.ReadByte();
            }

            if (map.Version >= 4)
            {
                map.ZoomScale = s.ReadUShort() / 100f;
                map.ZoomOffsetX = s.ReadShort();
                map.ZoomOffsetY = s.ReadShort();
                if (map.ZoomScale < 1)
                {
                    map.ZoomScale = 1;
                    map.ZoomOffsetX = 0;
                    map.ZoomOffsetY = 0;
                }
            }

            if (map.Version > 10)
                map.TacticalModeTemplateId = s.ReadInt();

            map.UseLowPassFilter = s.ReadByte() == 1;
            map.UseReverb = s.ReadByte() == 1;
            if (map.UseReverb)
                map.PresetId = s.ReadInt();
            else
                map.PresetId = -1;

            var backgroundCount = s.ReadByte();
            for (int i = 0; i < backgroundCount; i++)
                map.BackgroundFixtures.Add(Fixture.FromRaw(s));

            var foregroundCount = s.ReadByte();
            for (int i = 0; i < foregroundCount; i++)
                map.ForegroundFixtures.Add(Fixture.FromRaw(s));
            
            s.ReadInt(); // ???

            map.GroundCRC = s.ReadInt();

            var layerCount = s.ReadByte();
            for (int i = 0; i < layerCount; i++)
                map.Layers.Add(Layer.FromRaw(s, map.Version));

            var cellCount = AtouinConstants.MapCellsCount;
            for (int i = 0; i < cellCount; i++)
                map.Cells.Add(CellData.FromRaw(s, map, i));

            s.Close();
        }

        private static void decompressDlm(string filepath, string outputFolder)
        {
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            var mapId = Path.GetFileNameWithoutExtension(filepath);
            var or = File.OpenRead(filepath);
            var s = new ZlibStream(or, CompressionMode.Decompress);
            var mapBytes = s.ReadToEnd();
            File.WriteAllBytes(Path.Combine(outputFolder, mapId + ".map"), mapBytes.ToArray());
            s.Close();
            or.Close();
        }
    }
}
