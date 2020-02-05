using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Example ex = new Example(678))
            {
                Console.WriteLine(ex.GetState());
            }
        }
        class Example : IDisposable
        {
            private readonly int _state;
            public Example(int state)
            {
                _state = state;
            }
            public int GetState() => _state;
            public void Dispose()
            {

            }
        }
    }
}
