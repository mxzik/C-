using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int w, u;
            //int a = 12;
            //short b;
            //long c, d = a;
            //byte e = (byte)a;
            //b = (short)a;
            //c = (long)a;
            //Console.WriteLine("short - {0} long ia - {1} long neia - {2} byte - {3}", b, c, d, e);
            //Console.ReadLine();
            Person person = new Person { Name = "Kiril" };
            Console.WriteLine($"My name is {person.Name}");
            string inf = String.Format("My name is {0}", person.Name);
            Console.WriteLine(inf);
            string text = "хороший день";

            text = text.Replace("хороший", "плохой");
            Console.WriteLine(text);
            var tuple = (ie: 1, ei: 11);
            Console.WriteLine(tuple.ie);
            Console.WriteLine(tuple.ei);
            try
            {
                unchecked
                {
                    w = (int)214748 * 1000000;
                }
            }
            catch (OverflowException)
            {
                Console.Write("Переполнение\n\n");
            }
            string str1 = "abc";
            string str2 = "йлabs";
            Console.WriteLine(string.Compare(str1, str2));
            Console.WriteLine(string.CompareOrdinal(str1, str2));
            Console.WriteLine(str1.CompareTo(str2));
            Console.ReadLine();
        }
    }
    class Person
    {
        public string Name { get; set; }
    }
}
