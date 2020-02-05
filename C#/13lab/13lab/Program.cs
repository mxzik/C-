using System;
using System.IO;
using System.IO.Compression;

namespace _13lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\лабы\C#\KKAInspect\file1.txt";
            string path1 = @"D:\лабы\C#\KKAFiles\file1.txt";
            string path2 = @"D:\лабы\C#\KKAInspect";
            FileInfo fileInf = new FileInfo(path);
            FileInfo fileInf1 = new FileInfo(path1);
            KKADIskInfo.DiskInfo();
            KKADirInfo.DirInfo();
            KKAFileInfo.FileInfo();
            KKAFileManager.CreateDir(@"D:\лабы\C#\KKAInspect");
            using (StreamWriter sw = new StreamWriter(@"D:\лабы\C#\file.txt", false))
            {
                sw.WriteLine("Шиш шарапит");
            }
            if(!fileInf.Exists)
            {
                KKAFileManager.CopyFile(@"D:\лабы\C#\file.txt", @"D:\лабы\C#\KKAInspect\file1.txt");
            }
            KKAFileManager.Delete(@"D:\лабы\C#\file.txt");
            KKAFileManager.CreateDir(@"D:\лабы\C#\KKAFiles");
            var dirInfo = new DirectoryInfo(@"D:\лабы\C#\KKAInspect");
            if (!fileInf1.Exists)
            {
                foreach (FileInfo fi in dirInfo.GetFiles("*.txt"))
                {
                    KKAFileManager.CopyFile(@"D:\лабы\C#\KKAInspect\" + fi.Name,
                        @"D:\лабы\C#\KKAFiles\" + fi.Name);
                }
            }
            if (!Directory.Exists(path2))
            {
                KKAFileManager.MoveDir(@"D:\лабы\C#\KKAInspect", @"D:\лабы\C#\KKAFiles");
            }
            string sourceFolder = @"D:\лабы\C#\KKAFiles\"; 
            string zipFile = @"D:\лабы\C#\KKAFiles\test.zip"; 
            string targetFolder = @"D:\лабы\C#\KKATEST";
            string zipFile1 = @"D:\лабы\C#\KKATEST\file1.txt";
            FileInfo fileInf3 = new FileInfo(zipFile);
            FileInfo file = new FileInfo(zipFile1);
            if (!fileInf3.Exists)
            {
                ZipFile.CreateFromDirectory(sourceFolder, zipFile);
            }
            if(!file.Exists)
            {
                ZipFile.ExtractToDirectory(zipFile, targetFolder);
            }
            try
            {
                LogFile.SearchKeyWord();
                //LogFile.SearchTime();
                //LogFile.SearchDay();
            }

            finally
            {
            }
        }
    }
}
