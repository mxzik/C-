using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            A.B b = new A.B();
            a.Print();
            b.Print();
        }
    }
    public class A
    {
        public class B : A
        {
             public override void Print()
            {
                Console.WriteLine("B");
            }
        }
        virtual public void Print()
        {
            Console.WriteLine("A");
        }
    }
}
