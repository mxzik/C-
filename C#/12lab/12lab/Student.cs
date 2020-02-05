using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12lab
{
    class Student : IDo
    {
        private int[] massive;
        public int i = 4;
        public Student(int[] massive1)
        {
            massive = massive1;
        }
        public int[] Massive
        {
            get
            {
                return massive;
            }
            set
            {
                massive = value;
            }
        }

        public int this[int i]
        {
            get
            {
                return massive[i];
            }
            set
            {
                massive[i] = value;
            }
        }
        public bool NullMassive()
        {
            for (int i = 0; i < massive.Length; i++)
            {
                if (massive[i] == 0)
                {
                    return true;
                }
            }
            return false;
        }
        void IDo.Print()
        {
            Console.WriteLine("Я учусь! ");
        }
        public int Sum(ref string x1, ref string x2)
        {
            int x3 = int.Parse(x1) + int.Parse(x2);
            return x3;
        }
    }
}
