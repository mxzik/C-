using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Arrint = new int[5] { 4, 5, 18, 56, 8 };
            CollectionType<int> numbers = new CollectionType<int>(Arrint.Length, Arrint);
            for (int j = 0; j < 10; j++)
                numbers.Add(j);
            numbers.Remove(5);
            numbers.Remove(56);
            char[] vs = new char[2] { 'h', 'A' };
            CollectionType<char> collectionType = new CollectionType<char>(vs.Length, vs);
            collectionType.Add('s');
            collectionType.Add('s');
            collectionType.Remove('A');
            //CollectionType<Invent> invent = new CollectionType<Invent>(Arrint.Length);
            for (int i = 0; i < numbers.Count(); i++)
            {
                Console.WriteLine(numbers.GetItem(i));
            }
            Console.WriteLine("===================================");
            for (int i = 0; i < collectionType.Count(); i++)
            {
                Console.WriteLine(collectionType.GetItem(i));
            }
            Console.ReadKey();
        }
        interface IOperation<T>
        {
            void Add(T item);
            void Remove(T item);

        }
        public class CollectionType<T> : IOperation<T> where T : struct
        {
            public int LongOb { get; set; }
            public int Amount1 { get; set; }
            T[] data;
            public CollectionType ( int i, T[] item)
            {
                LongOb = i;
                data = new T[i];
                for (int j = 0; j < item.Length; j++)
                    data[j] = item[j];
            }
            public void Add(T item)
            {
                T[] newData = new T[data.Length + 1];
                for (int i = 0; i < data.Length; i++)
                {
                    newData[i] = data[i];
                }
                newData[data.Length] = item;
                data = newData;
            }
            public void Remove(T item)
            {
                int index = -1;
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].Equals(item))
                    {
                        index = i;
                        break;
                    }
                }
                if (index > -1)
                {
                    T[] newData = new T[data.Length - 1];
                    for (int i = 0, j = 0; i < data.Length; i++)
                    {
                        if (i == index) continue;
                        newData[j] = data[i];
                        j++;
                    }
                    data = newData;
                }
            }
            public T GetItem(int index)
            {
                if (index > -1 && index < data.Length)
                {
                    return data[index];
                }
                else
                    throw new IndexOutOfRangeException();
            }
            public int Count()
            {
                return data.Length;
            }
        }
        public class Invent
        {
            public int Amount { get; set; }
            public Invent(int amount)
            {
                Amount = amount;
            }

        }
    }
    }
