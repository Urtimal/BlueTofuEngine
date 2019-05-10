using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace D2MessageFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Path to the folder that contains the messages is needed");
                return;
            }

            var classRegex = new Regex("public class (.+) extends");
            var idRegex = new Regex("public static const protocolId:uint = (\\d+);");
            
            var files = getFiles(args[0]);
            var messages = new Dictionary<int, string>();
            using (var sw = new StreamWriter("messages.txt", false))
            {
                foreach (var file in files)
                {
                    var filecontent = File.ReadAllText(file);
                    if (classRegex.IsMatch(filecontent))
                    {
                        if (!int.TryParse(idRegex.Match(filecontent).Groups[1].Value, out int id))
                            continue;
                        if (messages.ContainsKey(id))
                            continue;
                        messages.Add(id, classRegex.Match(filecontent).Groups[1].Value + " - " + file.Replace(args[0], string.Empty));
                    }
                }
                var messageIds = messages.Keys.ToList();
                messageIds.Sort();
                foreach (var messageId in messageIds)
                    sw.WriteLine(messageId + ": " + messages[messageId]);
            }
        }

        static IEnumerable<string> getFiles(string path)
        {
            var list = new List<string>();

            list.AddRange(Directory.EnumerateFiles(path));
            foreach (var directory in Directory.EnumerateDirectories(path))
                list.AddRange(getFiles(directory));

            return list;
        }
    }
}
