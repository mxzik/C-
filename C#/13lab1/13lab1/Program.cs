using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace _13lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter(@"D:\лабы\C#\13lab1\log.txt"))
            {
                var freeSpace = BVADiskInfo.FreeSpaceInfo();
                foreach (string key in freeSpace.Keys)
                {
                    sw.WriteLine(key + ":" + freeSpace[key]);
                }

                var pathinfo = BVAFileInfo.PathInfo(@"D:\лабы\C#\13lab1\log.txt");
                sw.WriteLine(pathinfo);

                sw.WriteLine(BVAFileInfo.FileParamsInfo(@"D:\лабы\C#\13lab1\log.txt"));
                sw.WriteLine(BVAFileInfo.DateAddInfo(@"D:\лабы\C#\13lab1\log.txt"));

                sw.WriteLine("File Amount");
                sw.WriteLine(BVADirInfo.FileAmount(@"D:\лабы\C#\"));

                BVAFileManager.CreateDir(@"D:\лабы\C#\BVAInspect");
                BVAFileManager.CreateDir(@"D:\лабы\C#\BVAFiles");
                var dirInfo = new DirectoryInfo(@"D:\лабы\C#\BVAInspect");
                foreach (FileInfo fi in dirInfo.GetFiles("*.txt"))
                {
                    BVAFileManager.CopyFile(@"D:\лабы\C#\BVAInspect\" + fi.Name,
                        @"D:\лабы\C#\BVAFiles\" + fi.Name);
                }

                //ZipFile
            }
        }
    }
}
