using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace _15lab1
{
    class Program
    {
        static Mutex mutex = new Mutex();
        public static Thread thread, thread1, thread2;
        public static int num;
        public static int num2;

        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();
            try
            {
                //Console.WriteLine("Task 1");

                //for (int i = 0; i < processes.Length; i++)
                //{
                //    try
                //    {
                //        Console.WriteLine($"ID: {processes[i].Id}\tИмя процесса: {processes[i].ProcessName}\tВремя начала: {processes[i].StartTime}\tПриоритет: {processes[i].PriorityClass}\t Состояник: " + (processes[i].Responding ? "Run" : "Stop"));
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine($"ID: {processes[i].Id}\tИмя процесса: {processes[i].ProcessName}\tException - {ex.Message}");
                //    }
                //}

                //Console.WriteLine("Task 2");
                //AppDomain domain = AppDomain.CurrentDomain;
                //Console.WriteLine($"Имя домена: { domain.FriendlyName} ID: {domain.Id} Путь: {domain.BaseDirectory}");
                //Console.WriteLine("Все сборки: ");
                //var Assemblies = from asembl in domain.GetAssemblies()
                //                 orderby asembl.GetName().Name
                //                 select asembl;
                //foreach (var asembl in Assemblies)
                //{
                //    Console.WriteLine($"Имя сборки: {asembl.GetName().Name}\t Версия: {asembl.GetName().Version}");
                //}
                //AppDomain appDomain = AppDomain.CreateDomain("New Domain");
                //appDomain.DomainUnload += DomUnload;
                //appDomain.AssemblyLoad += AssLoad;
                //Console.WriteLine($"Домен {appDomain.FriendlyName}");
                //appDomain.Load("15lab1");
                //Assembly[] assembly = appDomain.GetAssemblies();
                //foreach (Assembly assemb in assembly)
                //{
                //    Console.WriteLine($"Имя: {assemb.GetName().Name}");
                //}
                //AppDomain.Unload(appDomain);
                //Console.WriteLine("Домен выгружен!");

                //Console.WriteLine("Task 3");
                //Console.WriteLine("Введите число");
                //num = Convert.ToInt32(Console.ReadLine());
                //thread = new Thread(new ThreadStart(Task3));
                //thread.Start();
                //thread.Join();

                Console.WriteLine("Task 4");
                string txt;
                bool check = false;
                do
                {
                    Console.WriteLine("Введите число");
                    txt = Console.ReadLine();
                    try
                    {
                        num2 = Convert.ToInt32(txt);
                        check = true;
                        Thread thread1 = new Thread(Chet);
                        Thread thread2 = new Thread(NeChet);
                        thread1.Start();

                        thread1.Join();
                        thread2.Start();
                        thread2.Join();
                        Thread ev = new Thread(new ThreadStart(Even));
                        Thread od = new Thread(new ThreadStart(Odd));
                        ev.Start();
                        od.Start();
                        ev.Join();
                        od.Join();

                        Console.WriteLine("\nTask 5");
                        int y = 0;
                        TimerCallback time = new TimerCallback(Task5);
                        Timer tm = new Timer(time, y, 1000, 00);
                        Console.ReadLine();
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                while (!check);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }


        private static void DomUnload(object sender, EventArgs args)
        {
            Console.WriteLine("Домен загружен!!!");
        }

        private static void AssLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("Сборка загружена!!!");
        }

        public static void Task3()
        {
            StreamWriter sw = new StreamWriter("task3.txt");
            for (int i = 0; i <= num; ++i)
            {
                sw.Write(i + ", ");
                Console.Write(i + ", ");
                Thread.Sleep(1000);
            }
            sw.Close();
            Console.WriteLine("\nИнформация потока: ");
            Console.WriteLine($"ID: {thread.ManagedThreadId}");
            Console.WriteLine($"Имя: {thread.Name}");
            Console.WriteLine($"Статус: {thread.ThreadState}");
            Console.WriteLine($"Приоритет: {thread.Priority}");
        }

        public static void Chet()
        {
            mutex.WaitOne();
            StreamWriter sw = new StreamWriter("task4.txt");
            Console.WriteLine("Четные числа: ");
            sw.WriteLine("Четные числа: ");
            for (int i = 2; i <= num2; i += 2)
            {
                sw.Write(i + ", ");
                Console.Write(i + ", ");
                Thread.Sleep(500);
            }
            Console.WriteLine();
            sw.Close();
            mutex.ReleaseMutex();
        }

        public static void NeChet()
        {
            mutex.WaitOne();
            StreamReader streamReader = new StreamReader("task4.txt");
            List<string> vs = new List<string>();
            while (!streamReader.EndOfStream)
            {
                vs.Add(streamReader.ReadLine()); ;
            }
            streamReader.Close();

            StreamWriter sw = new StreamWriter("task4.txt");
            foreach (string result in vs)
            {
                sw.WriteLine(result);
            }
            sw.WriteLine();
            Console.WriteLine("Нечетные числа: ");
            sw.WriteLine("Нечетные числа: ");
            for (int i = 1; i <= num2; i += 2)
            {
                sw.Write(i + ", ");
                Console.Write(i + ", ");
                Thread.Sleep(300);
            }
            sw.WriteLine();
            Console.WriteLine();
            sw.Close();
            mutex.ReleaseMutex();
        }
        public static void Task5(object t)
        {
            int x = (int)t;
            for (int i = 1; i <= 3; i++, x++)
                Console.WriteLine($"{x}+{i} = {x + i}");
            Console.WriteLine();
        }

        static void Even()
        {
            using (var mutex = new Mutex(false, "UNIQUE_NAME"))
            {

                for (int i = 0; i <= num2; i += 2)
                {
                    mutex.WaitOne();
                    using (var aFile = new FileStream("task4.txt", FileMode.Append, FileAccess.Write, FileShare.Write))
                    using (StreamWriter writer = new StreamWriter(aFile))
                    {
                        mutex.WaitOne();
                        writer.Write(i + ", ");
                        Console.Write(i + ", ");
                        Thread.Sleep(1500);
                        mutex.ReleaseMutex();

                    }

                    mutex.ReleaseMutex();
                }
            }
        }

        static void Odd()
        {
            using (var mutex = new Mutex(false, "UNIQUE_NAME"))
            {

                for (int i = 1; i <= num2; i += 2)
                {
                    mutex.WaitOne();
                    using (var aFile = new FileStream("task4.txt", FileMode.Append, FileAccess.Write, FileShare.Write))
                    using (StreamWriter writer = new StreamWriter(aFile))
                    {
                        mutex.WaitOne();
                        writer.Write(i + ", ");
                        Console.Write(i + ", ");
                        Thread.Sleep(1500);
                        mutex.ReleaseMutex();

                    }

                    mutex.ReleaseMutex();
                }
            }
        }
    }
}