using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4peregr
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection g = new MyCollection();
            g.th.Hours = 23;
            int p = 5;
            List<int> coll = MyCollection.NewCollection(10);
            MyCollection.WriteMyCollection(coll);
            List<int> coll1 = MyCollection.NewCollection1(10);
            MyCollection.WriteMyCollection(coll1);
            int h = coll.Sum();
            Console.WriteLine("Сумма чисел в строке = {0}", h);
            MyCollection.invers(coll);
            MyCollection.invers(coll, coll1);
            MyCollection.invers(coll, coll1, true);
            MyCollection.invers(coll, coll1, 55);
            List<int> coll2 = coll.YDs(p);
            foreach(int c in coll2)
                Console.Write("{0}\t", c);
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.ReadKey();
        }
        class MyCollection
        {
            public int sa;
            public static int d;
            public Date2 th;
            public class Fd : MyCollection
            {
                public int sf;
                public new class Date2
                {

                }
            }
            public class Date2
            {
                public int Hours { get; set; }
                public int Minutes { get; set; }
                public int Seconds { get; set; }
            }
            public static List<int> NewCollection(int i)
            {
                Random ran = new Random();
                List<int> arr = new List<int>();
                for (int j = 0; j < i; j++)
                    arr.Add(ran.Next(1, 50));
                return arr;
            }
            public static List<int> NewCollection1(int i)
            {
                Random ran1 = new Random();
                List<int> arr1 = new List<int>();
                for (int g = 0; g < i; g++)
                    arr1.Add(ran1.Next(50, 100));
                return arr1;
            }
            public static void WriteMyCollection(List<int> arr)
            {
                foreach (int a in arr)
                    Console.Write("{0}\t", a);
                Console.WriteLine("\n");
            }
            public static void invers(List<int> arr)
            {
                int len = arr.Count;
                for (int i = 0; i < len / 2; i++)
                {
                    int t = arr[i];
                    arr[i] = arr[len - i - 1];
                    arr[len - i - 1] = t;
                }

                for (int j = 0; j <= arr.Count - 1; j++)
                {
                    Console.Write("{0}\t", arr[j]);
                }

                Console.WriteLine();
            }
            public static void invers(List<int> arr, List<int> arr1)
            {
                List<int> arr2 = new List<int>();
                var newList = arr.Concat(arr1);
                foreach (int b in newList)
                    Console.Write("{0}   ", b);
                Console.WriteLine("\n");
            }
            public static void invers(List<int> arr, List<int> arr1, bool t)
            {
                if (arr == arr1)
                    Console.WriteLine(t);
                else
                    Console.WriteLine(!t);
            }
            public static void invers(List<int> arr, List<int> arr1, int s)
            {
                arr.AddRange(arr1);
                arr.Add(s);
                foreach (int n in arr)
                    Console.Write("{0}   ", n);
                Console.WriteLine("\n");

            }
        }
    }
    public static class StringExtension
    {
        public static int Sum(this List<int> arr)
        {
            int counter = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                counter += arr[i];
            }
            return counter;
        }
        public static List<int> YDs(this List<int> arr, int k)
        {
            for(int i = arr.Count - 1; i > k; i-- )
            { 
            arr.RemoveAt(i);
           }
            return arr;
        }
    }
}