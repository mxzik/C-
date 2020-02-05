using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kontr
{
    class Program
    {
        static void Main(string[] args)
        {
            double min = double.MinValue;
            Console.WriteLine(min);
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            string c = a + b;
            Console.WriteLine(c);
            int[][] mass = new int[2][];
            mass[0] = new int[3] { 1, 2, 3 };
            mass[1] = new int[5] { 1, 2, 3, 4, 5 };
            foreach (int[] i in mass)
            {
                foreach (int number in i)
                {
                    Console.Write($"{number} \t");
                }
                Console.WriteLine();
            }
            Time c1 = new Time { Minutes = 23, Seconds = 12 };
            Time c2 = new Time { Minutes = 12, Seconds = 12};
            bool result = c1 < c2;
            bool result1 = c1 == c2;
            bool result2 = c1 > c2;
            Console.WriteLine(result);
            Console.WriteLine(result1);
            Student student = new Prepod();
            Console.ReadKey();
        }
        public class Time
        {
            public int Hours { get; } = 16;
            public int Minutes { get; set; }
            public int Seconds { get; set; }

            public static bool operator ==(Time time, Time time1)
            {
                return time == time1;
            }
            public static bool operator !=(Time time, Time time1)
            {
                return time != time1;
            }
            public static bool operator <(Time time, Time time1)
            {
                return time < time1;
            }
            public static bool operator >(Time time, Time time1)
            {
                return time > time1;
            }
        }
        interface IStudy 
        {
            void Study();
        }
        class Student
        {
            void Study()
            {
                Console.WriteLine("Учусь");
            }
        }
        class Prepod : Student
        {
            void Study()
            {
                Console.WriteLine("Учу");
            }
            
        }


    }
}
