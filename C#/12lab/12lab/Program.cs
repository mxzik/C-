using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace _12lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Reflector reflector = new Reflector();
            reflector.GetInfo("_12lab.Student");
            reflector.PublicMethods("_12lab.Student");
            reflector.PropertyInfo("_12lab.Student");
            reflector.Interfaces("_12lab.Student");
            reflector.GetMethodsByParamets("_12lab.Student", typeof(int));
            Reflector.CallMethod("_12lab.Student", "Sum");
            Console.ReadKey();
        }
    }
    public class TestingMethod
    {
        public void Methode(int param)
        {
            Console.WriteLine("Hellou " + param);
        }
    }

}
