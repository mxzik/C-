using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int c = 1;
            string[] months = { "December", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novenber" };
            int n = 5;
            var selectedTeams = from t in months
                                where t.Length == n
                                select t;
            Print(selectedTeams);
            Console.WriteLine();
            var q = months.OrderBy(t => t);
            Print(q);
            var inclU = from h in months where h.Contains('u') && h.Length >= 4 select h;
            Print(inclU);
            Random rand = new Random();
            int[][] mass = new int[3][];
            mass[0] = new int[3];
            for (int j = 0; j < mass[0].Length; j++)
            {
                mass[0][j] = rand.Next(0, 10);
            }
            Print1(mass[0]);
            mass[1] = new int[3];
            for (int j = 0; j < mass[1].Length; j++)
            {
                mass[1][j] = rand.Next(0, 10);
            }
            Print1(mass[1]);
            mass[2] = new int[3];
            for (int j = 0; j < mass[2].Length; j++)
            {
                mass[2][j] = rand.Next(0, 10);
            }
            Print1(mass[2]);
            Console.WriteLine("=================================");
            for (int i = 0; i <= 2; i++)
            {
                var vas = mass[i].All(t => t % 2 == 0);
                var vas1 = mass[i].All(t => t % 2 == 1);
                if (vas)
                {
                    Console.Write("Массив со всеми четными элементами: ");
                    Print1(mass[i]);
                }
                else if(vas1)
                {
                    Console.Write("Массив со всеми нечетными элементами: ");
                    Print1(mass[i]);
                }
                else
                    Console.WriteLine("ошибка");
            }
            int[] vs = { 2, 4, 6, 8, 10 };
            int[] vs1 = { 1, 2, 4 };
            int[] vs2 = { 1, 2, 4 };
            bool var = vs.All(t => t % 2 == 0);
            if (var)
            {
                Print1(vs);
            }
            else
                Console.WriteLine("oshibka");
            Console.WriteLine("=================================");
            for (int i = 0; i < 2; i++)
            {

                var sumel = mass[i].Contains (2);
                if (sumel)
                    a++;
            }
            Console.WriteLine("2 содержится в кол-ве массиввов = " + a);
            Console.WriteLine("=================================");
            var sumel1 = mass[0].Sum();
            int b = sumel1;
            var sumel2 = mass[1].Sum();
            if (b < sumel2)
                b = sumel2;
            var sumel3 = mass[2].Sum();
            if (b < sumel3)
                b = sumel3;
            Console.WriteLine(b);
            Console.WriteLine("=================================");
            if (Equals(vs, vs1))
                c++;
            else if (Equals(vs, vs2))
                c++;
            else if (Equals(vs1, vs2))
                c++;
            Console.WriteLine("Равных массивов - " + c);
            Console.WriteLine("=================================");
            List<Team> teams = new List<Team>()
        {
        new Team { Name = "Бавария", Country ="Германия" },
        new Team { Name = "Барселона", Country ="Испания" }
        };
            List<Player> players = new List<Player>()
        {
        new Player {Name="Месси", Team="Барселона"},
        new Player {Name="Неймар", Team="Барселона"},
        new Player {Name="Роббен", Team="Бавария"}
        };
            var result = players.Join(teams, // второй набор
                 p => p.Team, // свойство-селектор объекта из первого набора
                 t => t.Name, // свойство-селектор объекта из второго набора
                 (p, t) => new { Name = p.Name, Team = p.Team, Country = t.Country }); // результат
            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
        }
        public static void Print(IEnumerable<string> str)
        {
            foreach (string q in str)
            {
                Console.Write(q + " ");
            }
            Console.WriteLine();
        }
        public static void Print1(IEnumerable<int> str)
        {
            foreach (int q in str)
            {
                Console.Write(q + " ");
            }
            Console.WriteLine();
        }
        static bool Equals(int[] array1, int[] array2)
        {
            return array1.Except(array2).Count() == 0 && array2.Except(array1).Count() == 0;
        }
    }
    class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}