using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekz
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point();
            point.ToString();
            ColorPoint point1 = new ColorPoint();
            point = point1;
        }
    }
    public class Point
    {
        public int x = 10; 
        public int y = 20;
        public String ToString()
        { return "Point " + x + " " + y; }
    }
    public class ColorPoint : Point
    {
        public int x = -78;
        new public String ToString() 
        {return "ColorPoint " + x +base.ToString(); }
        new public int Sum()
        { return base.x + base.y + x; }
    }
}
