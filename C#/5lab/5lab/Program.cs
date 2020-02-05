using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace _5lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = 23;
            object sa = b;
            Boolean saa = sa is int;
            Console.WriteLine(saa);
            Boolean ball3 = sa is string;
            Console.WriteLine(ball3);

            Console.WriteLine("========================");

            try
            {
                Skam skam = new Skam(11, 2.5, 0.23, 8, 50, 10);
                Brus brus = new Brus(5, 2, 1.58, 12, 100, "дерево");
                Baskeball baskeball1 = new Baskeball
                {
                    Color = null
                };
                List<string> aa = new List<string>();
                aa[2] = "232";
                int x = 5;
                int y = x / 2;
                Console.WriteLine($"Результат: {y}");
                int[] numbers = new int[4];
                numbers[3] = 9;
                string str = "123";
                object obj = str;
                int a = (int)obj;

            }
            catch (SkamArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }

            catch (BrusException lk)
            {
                Console.WriteLine("Ошибка: " + lk.Message);
            }
            catch (BallException inner)
            {
                Console.WriteLine($"error : {inner}");
                Debug.Assert(inner.Value != null, "Values array cannot be null");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Деление на ноль");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Блок finally");
            }
            Console.WriteLine("========================");

            Ball ball = new Ball();
            ball.Balls(4);
            Boolean ball2 = ball is object;
            Console.WriteLine(ball2);
            Baskeball baskeball = new Baskeball();
            Ball ball1 = baskeball as Ball;
            Console.WriteLine(ball1.ToString());
            ball1.ToString();
            Ball ball4 = new Ball();
            ball4.ToString();
            baskeball.Balls1(4, "Черный");
            Tennis tennis = new Tennis(12, 5);
            tennis.Knd("Тенис");
            ((ISport)tennis).DoClone();
            SPort1 port1 = new Tennis(21, 6);
            tennis.DoClone();
            Kanat kanat = new Kanat(12, 12);
            kanat.DisplayInfo();
            Console.WriteLine("========================");
            //Gym gym = new Gym();

            //gym.GetInvents();

            //gym.AddInvent(new Brus(1, 1, 1, 1, 1, "1"));
            //gym.AddInvent(new Skam(2, 2, 2, 2, 2, 2));

            //Console.WriteLine("========================");

            //gym.GetInvents();

            //Console.WriteLine("========================");

            //gym.GetInventsByPrice(0, 30);

            //Console.WriteLine("========================");

            //gym.GetInvetsSortByPrice();

            Console.ReadKey();
        }
    }
    public abstract class Invent
    {
        public int Amount { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public int Price { get; set; }
        public int Priceofone { get; set; }
        public Invent(int amount, double length, double height, int price, int priceofone)
        {
            Amount = amount;
            Length = length;
            Height = height;
            Price = price;
            Priceofone = priceofone;
        }

        public abstract void Display();

        public override string ToString()
        {
            return Amount + " " + Length + " " + Height + " " + Price + " " + Priceofone + " ";
        }
    }

    class Brus : Invent
    {
        private string material;
        public string Material
        {
            get { return material; }
            set
            {
                if (value == "дерево" || value == "железо" | value == "метал" || value == "железо и дерево")
                    material = value;
                else
                    throw new BrusException("Из такого материала лавки не строятся");
               
            }
        }
        public Brus(int amount, double length, double height, int priceofone, int price, string material) : base(amount, length, height, priceofone, price)
        {
            Material = material;
        }

        public override void Display()
        {
            Console.WriteLine($"Количество брусьев = {Amount}, длина = {Length}, высота = {Height}, цена одного = {Priceofone}, цена - {Price} материал - {Material}");
        }
        public override string ToString()
        {
            return base.ToString() + Material;
        }
    }
    class Skam : Invent
    {
        private int amofseats;
        public Skam(int amount, double length, double height, int priceofone, int price, int amofseats) : base(amount, length, height, priceofone, price)
        {
            Amofseats = amofseats;
        }
        public int Amofseats
        {
            get { return amofseats; }
            set
            {
                if (value > 12)
                    throw new SkamArgumentException("Более 12 человек на скамейку не помещается");
                else
                    amofseats = value;
            }
        }

        public override void Display()
        {
            Console.WriteLine($"Количество брусьев = {Amount}, длина = {Length}, высота = {Height}, цена одного = {Priceofone}, бюджет - {Price}, количество мест - {Amofseats}");
        }
        public override string ToString()
        {
            return base.ToString() + Amofseats;
        }

    }
    public class Ball
    {
        public int x = 20;
        public void Balls(int w)
        {
            Console.WriteLine("Количество мячей = " + x + " Футбольных мячей = " + w);
        }
        public override string ToString()
        {
            return base.ToString() + x + x.GetType().ToString();
        }
    }
    class Baskeball : Ball
    {
        public int y = 7;
        private string color;
        public string Color {
            get { return color; }
            set
            {
                if (value == null)
                    throw new BallException("null строка", value);
                else
                    color = value;
            }
        }
        public void Balls1(int w, string Color)
        {
            Console.WriteLine("Общее количество мячей = " + x + ", Футбольных мячей = " + w + ", количество баскетбольных мячей :" + y);
            Console.WriteLine("Цвет баскетбольного - " + Color);
        }
    }

    abstract class SPort1
    {
        public abstract void DoClone();
    }

    interface ISport
    {        
        void DoClone();
        void Knd(string kind);
        void Numberofplayers(int a);

    }
    sealed partial class Tennis : SPort1, ISport
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Tennis(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public void Knd(string kind)
        {
            Console.WriteLine("Вид спорта - " + kind);
        }

        public void Numberofplayers(int a)
        {
            if (a == 2)
                Console.WriteLine("Правильно");
            else
                Console.WriteLine("Неверно");
        }
    }
    struct Kanat
    {
        public int length;
        public int age;
        public Kanat(int length, int age)
        {
            this.length = length;
            this.age = age;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($": {length}  Age: {age}");
        }
        
    }
    enum Skis
    {
        Small = 12,
        Medium,
        Large = 23,
    }

    public class Gym
    {
        private List<Invent> Invents { get; set; }

        public Gym()
        {
            Invents = new List<Invent>()
            {
                new Skam(20, 10, 10, 10, 10, 10),
                new Brus(20, 20, 10, 60, 30, "метал"),
                new Skam(20, 30, 10, 30, 10, 10),
                new Brus(20, 40, 10, 40, 40, "дерево"),
                new Skam(20, 50, 10, 50, 10, 10),
            };
        }

        public void AddInvent(Invent invent)
        {
            this.Invents.Add(invent);
        }

        public void RemoverInvent()
        {
            this.Invents.Remove(Invents.Last());
        }

        public void GetInvents()
        {
            foreach (Invent invent in this.Invents)
            {
                if (invent is Brus)
                {
                    Console.WriteLine("Brus: " + invent);
                }
                if (invent is Skam)
                {
                    Console.WriteLine("Skam: " + invent);
                }
            }
        }

        public void GetInventsByPrice(int price1, int price2)
        {
            foreach (Invent invent in this.Invents)
            {
                if (invent.Price >= price1 && invent.Price <= price2)
                {
                    if (invent is Brus)
                    {
                        Console.WriteLine("Brus: " + invent);
                    }
                    if (invent is Skam)
                    {
                        Console.WriteLine("Skam: " + invent);
                    }
                }
            }
        }
        public void GetInvetsSortByPrice()
        {
            this.Invents = Invents.OrderByDescending(x => x.Price).ToList();

            foreach (Invent invent in this.Invents)
            {
                if (invent is Brus)
                {
                    Console.WriteLine("Brus: " + invent);
                }
                if (invent is Skam)
                {
                    Console.WriteLine("Skam: " + invent);
                }
            }
        }
    }
}
