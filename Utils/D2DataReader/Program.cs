using D2DataLib.D2I;
using D2DataLib.DLM;
using Newtonsoft.Json;
using ShellProgressBar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace D2DataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //var lang = new LangDictionary("fr");
            //lang.Import("input\\lang\\i18n_fr.d2i");

            //Console.WriteLine(lang.Get(114, false));
            //Console.WriteLine(lang.Get(114, true));

            var inputFolder = @"E:\Dofus Server\Dofus 2\exported_data\output\pak\maps";
            var outputFolder = @"E:\Dofus Server\Dofus 2\exported_data\output\maps";

            var files = new List<string>();
            foreach (var dir in Directory.EnumerateDirectories(inputFolder))
                files.AddRange(Directory.EnumerateFiles(dir).Where(x => Path.GetExtension(x).Equals(".dlm", StringComparison.OrdinalIgnoreCase)));

            var masterBarOptions = new ProgressBarOptions
            {
                ForegroundColor = ConsoleColor.Yellow,
                ForegroundColorDone = ConsoleColor.DarkGreen,
                BackgroundColor = ConsoleColor.DarkGray,
                BackgroundCharacter = '\u2593'
            };
            var progressBar = new ProgressBar(files.Count, "Exporting maps", masterBarOptions);
            foreach (var file in files)
            {
                progressBar.Message = "Exporting " + Path.GetFileName(file) + "...";
                ExportMap(file, outputFolder);
                progressBar.Tick();
            }
            progressBar.Dispose();

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        //#region D2O

        //static void ExportAllD2o()
        //{
        //    var dataFiles = Directory.EnumerateFiles(InputData);
        //    Console.WriteLine(dataFiles.Count() + " file to export. Ready ?");
        //    Console.ReadLine();

        //    var masterBarOptions = new ProgressBarOptions
        //    {
        //        ForegroundColor = ConsoleColor.Yellow,
        //        ForegroundColorDone = ConsoleColor.DarkGreen,
        //        BackgroundColor = ConsoleColor.DarkGray,
        //        BackgroundCharacter = '\u2593'
        //    };
        //    var progressBar = new ProgressBar(dataFiles.Count(), "Export data" , masterBarOptions);

        //    var started = DateTime.Now;
        //    foreach (var file in dataFiles)
        //        ExportD2o(file, true, progressBar);
        //    var duration = (DateTime.Now - started).TotalSeconds;

        //    progressBar.Dispose();
        //    Console.WriteLine("Completed in " + (duration >= 1 ? (int)duration : duration) + " sec(s)");
        //}

        //static void ExportD2o(string filename, bool skipAsk = false, ProgressBar masterBar = null)
        //{
        //    var doc = new D2oDocument();
        //    doc.Read(File.OpenRead(filename));

        //    if (!skipAsk)
        //    {
        //        foreach (var c in doc.Classes)
        //            Console.WriteLine(c.ToString());

        //        Console.WriteLine("Ready to export ? ");
        //        Console.ReadLine();
        //    }

        //    var dataPath = Path.Combine(OutputData, Path.GetFileNameWithoutExtension(filename));
        //    if (Directory.Exists(dataPath))
        //    {
        //        Directory.Delete(dataPath, true);
        //        while (Directory.Exists(dataPath)) Thread.Sleep(10);
        //    }
        //    Directory.CreateDirectory(dataPath);

        //    var progressBarOptions = new ProgressBarOptions
        //    {
        //        ForegroundColor = ConsoleColor.Yellow,
        //        ForegroundColorDone = ConsoleColor.DarkGreen,
        //        BackgroundColor = ConsoleColor.DarkGray,
        //        BackgroundCharacter = '\u2593'
        //    };
        //    ProgressBarBase bar = null;
        //    if (masterBar != null)
        //        bar = masterBar.Spawn(doc.Index.Count, Path.GetFileNameWithoutExtension(filename), progressBarOptions);
        //    else
        //        bar = new ProgressBar(doc.Index.Count, Path.GetFileNameWithoutExtension(filename), progressBarOptions);

        //    var progress = new Progress<int>(_ =>
        //    {
        //        bar.Tick();
        //    });

        //    doc.ExportJson(dataPath, progress);

        //    if (bar is ProgressBar pbar)
        //        pbar.Dispose();
        //    else if (bar is ChildProgressBar cpbar)
        //        cpbar.Dispose();

        //    if (masterBar != null)
        //        masterBar.Tick();
        //}

        //#endregion

        //#region D2I

        //public static void ImportLang(string name)
        //{
        //    var path = Path.Combine(InputLang, "i18n_" + name + ".d2i");
        //    if (!File.Exists(path))
        //    {
        //        Console.WriteLine("File not found: " + path);
        //        return;
        //    }

        //    var dico = new D2iDictionary();
        //    dico.Read(File.OpenRead(path));

        //    D2iAccessor.Dictionary = dico;
        //    Console.WriteLine("Lang '" + name + "' successfully imported");
        //}

        //#endregion

        //#region D2P

        //public static void ExtractPak(string filepath, string outputPath)
        //{
        //    var collection = new PakCollection();
        //    collection.Read(filepath);

        //    Console.WriteLine(collection.Entries.Count + " file to extract. Ready ?");
        //    Console.ReadLine();

        //    var masterBarOptions = new ProgressBarOptions
        //    {
        //        ForegroundColor = ConsoleColor.Yellow,
        //        ForegroundColorDone = ConsoleColor.DarkGreen,
        //        BackgroundColor = ConsoleColor.DarkGray,
        //        BackgroundCharacter = '\u2593'
        //    };
        //    var progressBar = new ProgressBar(collection.Entries.Count, "Extract files", masterBarOptions);
        //    var progress = new Progress<string>(filename => progressBar.Tick(filename));
        //    collection.ExtractAll(outputPath, progress);
        //    progressBar.Dispose();
        //}

        //#endregion

        //#region SWL

        //public static void ExtractSwl(string filepath, string outputPath)
        //{
        //    var file = new SwlFile();
        //    if (!file.Read(filepath))
        //        return;

        //    if (!Directory.Exists(Path.GetDirectoryName(outputPath)))
        //        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        //    file.ExtractSwf(outputPath);
        //}

        //public static void ExtractAllSwl(string srcDirectory, string destDirectory)
        //{
        //    var files = Directory.EnumerateFiles(srcDirectory);
        //    Console.WriteLine(files.Count() + " file to extract. Ready ?");
        //    Console.ReadLine();

        //    var masterBarOptions = new ProgressBarOptions
        //    {
        //        ForegroundColor = ConsoleColor.Yellow,
        //        ForegroundColorDone = ConsoleColor.DarkGreen,
        //        BackgroundColor = ConsoleColor.DarkGray,
        //        BackgroundCharacter = '\u2593'
        //    };
        //    var progressBar = new ProgressBar(files.Count(), "Extract files", masterBarOptions);
        //    foreach (var file in files)
        //    {
        //        var destFile = Path.Combine(destDirectory, Path.GetFileNameWithoutExtension(file) + ".swf");
        //        ExtractSwl(file, destFile);
        //        progressBar.Tick(Path.GetFileName(file));
        //    }
        //    progressBar.Dispose();
        //}

        //#endregion

        #region DLM

        public static void ExportMap(string filepath, string destFolder)
        {
            var map = DlmReader.Read(filepath, destFolder);
            var jsonFile = Path.Combine(destFolder, map.Id + ".json");
            File.WriteAllText(jsonFile, map.ToJson());
        }

        #endregion

        //#region ELE

        //public static void ExportEle(string inputFile, string outputDir)
        //{
        //    var collection = EleReader.Read(inputFile);
        //    collection.ReadElements();
        //    collection.Close();

        //    Console.WriteLine(collection.Elements.Count + " elements to export. Ready ?");
        //    Console.ReadLine();

        //    var masterBarOptions = new ProgressBarOptions
        //    {
        //        ForegroundColor = ConsoleColor.Yellow,
        //        ForegroundColorDone = ConsoleColor.DarkGreen,
        //        BackgroundColor = ConsoleColor.DarkGray,
        //        BackgroundCharacter = '\u2593'
        //    };
        //    var progressBar = new ProgressBar(collection.Elements.Count, "Extract elements", masterBarOptions);
        //    var progress = new Progress<string>(filename => progressBar.Tick(filename));
        //    collection.ExportToJson(outputDir, progress);
        //    progressBar.Dispose();
        //}

        //#endregion
    }
}
