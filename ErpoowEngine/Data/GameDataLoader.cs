using ErpoowEngine.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ErpoowEngine.Data
{
    public static class GameDataLoader
    {
        public static string DataFolder { get; set; } = "data/";

        private static string getDataFileName(string dataType, int id)
        {
            var path = Path.Combine(DataFolder, dataType);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                var fileid = getDataFileId(file);
                if (fileid != id)
                    continue;

                return file;
            }

            return null;
        }

        private static int getDataFileId(string filename)
        {
            var regex = new Regex(@"^(\d+)(_+.*)?\.json$");
            var match = regex.Match(Path.GetFileName(filename));
            if (!match.Success)
                return -1;
            
            try
            {
                return int.Parse(match.Groups[1].Value);
            }
            catch { return -1; }
        }

        public static T Load<T>(string filename) where T : GameData, new()
        {
            var fileId = getDataFileId(filename);
            if (fileId == -1)
                return new T();

            var filecontent = SafeFileReadWrite.Read(filename);
            var loadedData = JsonConvert.DeserializeObject<T>(filecontent);
            loadedData.Id = fileId;
            return loadedData;
        }

        public static T Load<T>(int id) where T : GameData, new()
        {
            try
            {
                var filename = getDataFileName(new T().Type, id);
                if (filename == null)
                    return new T();

                var loadedData = Load<T>(filename);
                return loadedData;
            }
            catch { return new T(); }
        }

        public static IEnumerable<T> LoadAll<T>() where T : GameData, new()
        {
            var list = new List<T>();
            var path = Path.Combine(DataFolder, new T().Type);
            if (!Directory.Exists(path))
                return list;

            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                var data = Load<T>(file);
                if (!data.Loaded)
                    continue;
                list.Add(data);
            }

            return list;
        }

        public static bool Save<T>(T data) where T : GameData
        {
            try
            {
                var filename = getDataFileName(data.Type, data.Id);
                if (filename == null)
                    filename = Path.Combine(DataFolder, data.Type, data.Id + ".json");
                SafeFileReadWrite.Write(filename, JsonConvert.SerializeObject(data, Formatting.Indented));
                return true;
            }
            catch { return false; }
        }

        public static bool Save<T>(IEnumerable<T> dataCollection) where T : GameData
        {
            bool success = true;

            foreach (var data in dataCollection)
            {
                if (!Save(data))
                    success = false;
            }

            return success;
        }

        public static bool Delete<T>(T data) where T : GameData, new()
        {
            if (!data.Loaded)
                return false;

            try
            {
                var fileData = getDataFileName(new T().Type, data.Id);
                if (fileData == null)
                    return false;
                File.Delete(fileData);
                return !File.Exists(fileData);
            }
            catch { return false; }
        }
    }
}
