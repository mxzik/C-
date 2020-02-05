using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5lab
{
    sealed partial class Tennis : SPort1, ISport
    {
        void ISport.DoClone()
        {
            if (Width * Height > 150)
                Console.WriteLine("Это не тенисное поле");
            else
                Console.WriteLine("Теннисное поле");
        }

        public override void DoClone()
        {
            Console.WriteLine("Площадь поля = {0}", Width * Height);
        }

        public override string ToString()
        {
            return base.ToString() + Width + Width.GetType() + Height + Height.GetType();
        }
    }
    class SkamArgumentException : ArgumentException
    {
        public SkamArgumentException(string message)
            : base(message)
        { }
    }
    class BrusException : Exception
    {
        public BrusException(string message)
            : base(message)
        { }
    }
    class BallException : NullReferenceException
    { 
        public string Value { get; }
        public BallException(string message, string val) : base(message)
        {
            Value = val;
        }
    }

}
