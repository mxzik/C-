using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using System.IO.Compression;


namespace _13lab
{
    public class KKADIskInfo
    {
        public static void DiskInfo()
        {
            using (StreamWriter sw = new StreamWriter(@"D:\лабы\C#\13lab\kkalogfile.txt", false))
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine($"Name: {drive.Name}");
                    Console.WriteLine($"Type: {drive.DriveType}");
                    Console.WriteLine($"File System: {drive.DriveFormat}");
                    sw.WriteLine($"Name: {drive.Name}");
                    sw.WriteLine($"Type: {drive.DriveType}");
                    sw.WriteLine($"File System: {drive.DriveFormat}");
                    if (drive.IsReady)
                    {
                        Console.WriteLine($"Disk space: {drive.TotalSize}");
                        Console.WriteLine($"Free space: {drive.TotalFreeSpace}");
                        Console.WriteLine($"Mark: {drive.VolumeLabel}");
                        sw.WriteLine($"Disk space: {drive.TotalSize}");
                        sw.WriteLine($"Free space: {drive.TotalFreeSpace}");
                        sw.WriteLine($"Mark: {drive.VolumeLabel}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
        public class KKADirInfo
        {
            public static void DirInfo()
            {
            using (StreamWriter sw = new StreamWriter(@"D:\лабы\C#\13lab\kkalogfile.txt", true))
            {
                string dirName = "D:\\лабы";
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                int a = 0;
                int b = 0;
                if (Directory.Exists(dirName))
                {
                    string[] dirs = Directory.GetDirectories(dirName);
                    Console.WriteLine($"Time of creation: {dirInfo}");
                    Console.WriteLine("SubDir:");
                    sw.WriteLine($"Time of creation: {dirInfo}");
                    sw.WriteLine("SubDir:");
                    foreach (string s in dirs)
                    {
                        Console.WriteLine(s);
                        sw.WriteLine(s);
                    }
                    Console.WriteLine($"Time of creationа: {dirInfo.CreationTime}");
                    sw.WriteLine($"Time of creation: {dirInfo.CreationTime}");

                    foreach (string s in dirs)
                    {
                        b++;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Amount of SubDirs: " + b);
                    sw.WriteLine("Amount of SubDirs: " + b);
                    string[] files = Directory.GetFiles(dirName);
                    foreach (string s in files)
                    {
                        a++;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Amount of SubDirs: " + a);
                    sw.WriteLine("Amount of SubDirs: " + a);
                    sw.WriteLine();
                }
            }
            }
        }
    public class KKAFileInfo
    {
        public static void FileInfo()
        {
            using (StreamWriter sw = new StreamWriter(@"D:\лабы\C#\13lab\kkalogfile.txt", true))
            {
                string path = @"D:\\1.txt";
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)
                {
                    Console.WriteLine("File name: {0}", fileInf.Name);
                    Console.WriteLine("Rasshirenie: {0}", fileInf.Extension);
                    Console.WriteLine("time of creation: {0}", fileInf.CreationTime);
                    Console.WriteLine("Size: {0}", fileInf.Length);
                    Console.WriteLine("Full path: {0}", fileInf.DirectoryName);
                    sw.WriteLine("File name: {0}", fileInf.Name);
                    sw.WriteLine("Rasshirenie: {0}", fileInf.Extension);
                    sw.WriteLine("time of creation: {0}", fileInf.CreationTime);
                    sw.WriteLine("Size: {0}", fileInf.Length);
                    sw.WriteLine("Full path: {0}", fileInf.DirectoryName);
                }
            }
        }
    }
    public class KKAFileManager
    {
            public static void CreateDir(string path)
            {
                Directory.CreateDirectory(path);
            }
            public static void RemoveDir(string path)
            {
                Directory.Delete(path);
            }
            public static void MoveDir(string path, string path1)
            {
            Directory.Move(path, path1);
            }
            public static void CopyFile(string path, string name)
            {
                File.Copy(path, name);
            }
            public static void Delete(string path)
            {
                File.Delete(path);
            }
            public static void CreateFile(string path) 
            {
                File.Create(path);
            }
    }
    public class LogFile
    {
        static int count = System.IO.File.ReadAllLines(@"D:\лабы\C#\13lab\kkalogfile.txt").Length;
        static string[] lines = new string[count];
        static string line;
        static bool check = false;
        static string word;
        static string hours;
        static string date;
        public static void SearchKeyWord()
        {
            StreamReader streamReader = new StreamReader(@"D:\лабы\C#\13lab\kkalogfile.txt", false);
            int count = System.IO.File.ReadAllLines(@"D:\лабы\C#\13lab\kkalogfile.txt").Length;
            WriteLine("Количество записей d файле - "+ count);
            WriteLine("Enter keyword");
            word = ReadLine();
            WriteLine();
            check = false;
            while (!streamReader.EndOfStream)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    lines[i] = streamReader.ReadLine();
                }
                check = true;
                if (check)
                {
                    for (int i = 0; i < count - 1; i++)
                    {
                        if (lines[i].Contains(word))
                        {
                            WriteLine("Строка - " + lines[i]);
                        }
                        check = false;
                    }
                }
                else { Console.WriteLine("Таких записей нету"); }
            }
            streamReader.Close();
        }

        public static void SearchDay()
        {
            StreamReader streamReader = new StreamReader(@"D:\лабы\C#\13lab\kkalogfile1.txt");
            WriteLine("Set date: ");
            date = ReadLine();
            check = false;
            while (!streamReader.EndOfStream)
            {
                lines[0] = streamReader.ReadLine();
                lines[1] = streamReader.ReadLine();
                lines[2] = streamReader.ReadLine();
                lines[3] = streamReader.ReadLine();
                lines[4] = streamReader.ReadLine();
                check = true;
                if (check)
                {
                    line = lines[3];
                    line = line.Substring(line.IndexOf(' ') + 1, 2);
                    if (line == date)
                    {
                        WriteLine(lines[0]);
                        WriteLine(lines[1]);
                        WriteLine(lines[2]);
                        WriteLine(lines[3]);
                        WriteLine(lines[4]);
                        check = false;
                    }
                }
            }
            streamReader.Close();
        }

        public static void SearchTime()
        {
            try
            {
                StreamReader streamReader = new StreamReader(@"D:\лабы\C#\13lab\kkalogfile1.txt");
                WriteLine("Enter hours: ");
                hours = ReadLine();
                check = false;
                while (!streamReader.EndOfStream)
                {
                    lines[0] = streamReader.ReadLine();
                    lines[1] = streamReader.ReadLine();
                    lines[2] = streamReader.ReadLine();
                    lines[3] = streamReader.ReadLine();
                    lines[4] = streamReader.ReadLine();
                    check = true;
                    if (check)
                    {
                        line = lines[0];
                        line = line.Substring(line.IndexOf(' ') + 1);
                        line = line.Substring(line.IndexOf(' ') + 1);
                        line = line.Substring(line.IndexOf(' ') + 1, line.IndexOf(':') - (line.IndexOf(' ') + 1));

                        if (Convert.ToInt32(hours) == int.Parse(line))
                        {
                            WriteLine(lines[0]);
                            WriteLine(lines[1]);
                            WriteLine(lines[2]);
                            WriteLine(lines[3]);
                            WriteLine(lines[4]);
                            count++;
                            check = false;
                        }
                    }
                    else
                    {
                        WriteLine("Нету записей!");
                        break;
                    }
                }
                streamReader.Close();
                WriteLine($"Count of notes: {count}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void LastHour()
        {
            StreamReader streamReader = new StreamReader(@"D:\лабы\C#\13lab\kkalogfile.txt");
            List<string> ListLog = new List<string>();
            List<string> ListLogResult = new List<string>();
            DateTime time = DateTime.Now;
            int Hour = time.Hour;
            string Date = time.Day + "." + time.Month + "." + time.Year;
            string line, line2;
            while (!streamReader.EndOfStream)
            {
                ListLog.Add(streamReader.ReadLine());
            }
            streamReader.Close();
            for (int i = 0; i < ListLog.Count; i++)
            {
                if (ListLog[i].Contains("Время"))
                {
                    line = ListLog[i];
                    line = line.Substring(line.IndexOf(' ') + 1);
                    line2 = line.Substring(0, line.IndexOf(' '));
                    line = line.Substring(line.IndexOf(' ') + 1);
                    line = line.Substring(line.IndexOf(' ') + 1, line.IndexOf(':') - (line.IndexOf(' ') + 1));
                    if (Hour == Convert.ToInt32(line) && Date == line2)
                    {
                        ListLogResult.Add(ListLog[i - 3]);
                        ListLogResult.Add(ListLog[i - 2]);
                        ListLogResult.Add(ListLog[i - 1]);
                        ListLogResult.Add(ListLog[i]);
                        ListLogResult.Add(ListLog[i + 1]);
                    }
                }
            }
            StreamWriter writer = new StreamWriter(@"D:\лабы\C#\13lab\kkalogfile.txt", true);
            writer.WriteLine("\n\nFor last hour:");
            for (int i = 0; i < ListLogResult.Count; i++)
                writer.WriteLine(ListLogResult[i]);
            writer.Close();
        }
    }
}
