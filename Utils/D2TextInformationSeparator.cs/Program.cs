using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace D2TextInformationSeparator.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            var messages = new Dictionary<int, Dictionary<int, string>>();
            foreach (var file in Directory.EnumerateFiles(args[0]))
            {
                var info = JsonConvert.DeserializeObject<InfoMessages>(File.ReadAllText(file));
                if (!messages.ContainsKey(info.typeId))
                    messages.Add(info.typeId, new Dictionary<int, string>());
                if (!messages[info.typeId].ContainsKey(info.messageId))
                    messages[info.typeId].Add(info.messageId, info.textId);
            }
            foreach (var kvp in messages)
            {
                using (var sw = new StreamWriter(kvp.Key + ".json", false))
                {
                    foreach (var message in kvp.Value)
                        sw.WriteLine(message.Key + "=" + message.Value);
                }
            }
        }

        class InfoMessages
        {
            public int typeId { get; set; }
            public int messageId { get; set; }
            public string textId { get; set; }
        }
    }
}
