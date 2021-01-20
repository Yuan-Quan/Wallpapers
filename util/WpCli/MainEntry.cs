using System;
using System.IO;
using CommandDotNet;

    public class MainEntry
    {
        [Command(Name = "add",
        Usage = "add -f [image] or add -d [path]",
        Description = "to add an image, or a lot of images",
        ExtendedHelpText = "add an image, or a lot of images.")]
        public void AddAFile(
        [Option(LongName = "file", ShortName = "f",
        Description = "file you want to attach")]
        string fPath = null,
        [Option(LongName = "directory", ShortName = "d",
        Description = "file you want to attach, in a dir")]
        string dPath = null
        )
        {

            if (fPath == null && dPath == null)
            {
                var preForegroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Must provide a file or a dir");
                Console.ForegroundColor = preForegroundColor;
                return;
            }

            if (!(dPath == null))
            {
                addDir(dPath);
            }else
            {
                addAImg(fPath);
            }

            void addDir(string path)
            {
                string[] ls = Directory.GetFiles(path, "*ProfileHandler.cs",SearchOption.AllDirectories);
                foreach (var item in ls)
                {
                    addAImg(item);
                }
            }

            void addAImg(string path)
            {
                if(!File.Exists(path))
                {
                    var preForegroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No file found in given path");
                    Console.ForegroundColor = preForegroundColor;
                    return;
                }
                string extName = path.Substring(path.LastIndexOf('.'), path.Length - path.LastIndexOf('.'));
                Util.AddImage(path, @$"{Path.Combine(Directory.GetCurrentDirectory(), Util.GetSHA1Hash(path))}{extName}");
                }
        }

    }