using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace LP_Lab15
{
    class Program
    {
        static Mutex mutexObj = new Mutex();
        static void Main(string[] args)
        {
            var allProc = Process.GetProcesses();
            foreach (Process process in allProc)
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("Proc ID: " + process.Id);
                Console.WriteLine("Name: " + process.ProcessName);
                Console.WriteLine("Priority: " + process.BasePriority);
                Console.WriteLine("Threads amount: " + process.Threads.Count);
            }
            Console.WriteLine("-----------------");

            AppDomain currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine("current domain name: " + currentDomain.FriendlyName);
            Console.WriteLine("base dir" + currentDomain.BaseDirectory);
            int num = 10;
            TimerCallback tm = new TimerCallback(Message);
            Timer timer = new Timer(tm, num, 0, 1000);

            Console.WriteLine("-----------------");

            AppDomain secondDomain = AppDomain.CreateDomain("2dom");
            secondDomain.Load("15lab");
            InfoDomainApp(secondDomain);
            AppDomain.Unload(secondDomain);

            Console.WriteLine("-----------------");

            Thread T1 = new Thread(work1);
            Thread T2 = new Thread(work2);
            T1.Priority = ThreadPriority.BelowNormal;
            T2.Priority = ThreadPriority.AboveNormal;

            Thread thread1 = new Thread(new ThreadStart(TestClass.PrintBW));

            Thread thread2 = new Thread(new ThreadStart(TestClass.PrintHW));

            thread1.Priority = ThreadPriority.Lowest;

            thread2.Priority = ThreadPriority.Highest;
            mutexObj.WaitOne();
            thread1.Start();

            thread2.Start();
            T1.Start();
            T2.Start();
            mutexObj.ReleaseMutex();
            //while (thread1.IsAlive)
            //{
            //    Console.WriteLine("thread1 is alive");
            //    Thread.Sleep(300);
            //}
            //while (thread2.IsAlive)
            //{
            //    Console.WriteLine("thread2 is alive");
            //    Thread.Sleep(300);
            //}
        }
        public static void work1()
        {

            Console.WriteLine("T1 thread is working..");
            Thread.Sleep(300);
        }
        public static void work2()
        {
            Console.WriteLine("T2 thread is working..");
        }
        public static void Message(object obj)
        {
            int x = (int)obj;
            for (int i = 0; i < x; i++)
            {
                Console.Write("sds");
            }
            Console.WriteLine();
        }
        static void InfoDomainApp(AppDomain defaultD)
        {
            Console.WriteLine("*** Информация о домене приложения ***\n");
            Console.WriteLine("-> Имя: {0}\n-> ID: {1}\n-> По умолчанию? {2}\n-> Путь: {3}\n",
                defaultD.FriendlyName, defaultD.Id, defaultD.IsDefaultAppDomain(), defaultD.BaseDirectory);

            Console.WriteLine("Загружаемые сборки: \n");
            // Извлекаем информацию о загружаемых сборках с помощью LINQ-запроса
            var infAsm = from asm in defaultD.GetAssemblies()
                         orderby asm.GetName().Name
                         select asm;
            foreach (var a in infAsm)
                Console.WriteLine("-> Имя: \t{0}\n-> Версия: \t{1}", a.GetName().Name, a.GetName().Version);
        }
    }

    public class TestClass
    {
        private static object threadLock = new object();
        const int n = 20;
        public static void PrintHW()
        {
            lock (threadLock)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 == 1)
                        Console.WriteLine(i);
                    Thread.Sleep(200);
                }
            }
        }

        public static void PrintBW()
        {
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 == 0)
                        Console.WriteLine(i);
                    Thread.Sleep(200);
                }  
        }
    }

}