using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User(1.1);
            user.Work += DisplayMessage;
            user.Upgradevers(5.5);
            User user1 = new User(1.2);
            user1.Work += DisplayMessage;
            user1.Set_Username("admin");
            user1.Set_Password("1233545");
            user1.Upgradevers(0.2);
            user1.Set_Inform(" user             1,  was  created 19.11.19 in 17:15  ");
            user1.Get_Inf();
            Action<string> op;
            op = user1.ToUpp;
            Operation(user1.Inform, op);
            op = user1.ToLow;
            Operation(user1.Inform, op);
            Func<string, string> func = Delspace;
            string str = GetStr(user1.Inform, func);
            Console.WriteLine(str);
        }
        static string GetStr(string inform, Func<string,string> func)
        {
            string result = null;
            if (inform != null)
                result = func(inform);
            return result;
        }
        static string Delspace(string inform)
        {
            string sd, sf;
            sd = Regex.Replace(inform, "[ ]+", " ");
            sf = sd.Trim();
            return sf;
        }
        static void Operation(string x1, Action<string> op)
        {
                op(x1);
        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class User
    {
        public delegate void Account(string message);
        public event Account Work;
        public string Inf { get; set; }
        public User(double version)
        {
        Version = version;
        }
        public string Inform { get; set; }
        public void Set_Inform(string inform)
        {
            Inform = inform;
        }
        public string Username { get; set; }
        public void Set_Username(string username)
        {
            Username = username;
        }
        public string Password { get; set; }
        public void Set_Password(string password)
        {
            Password = password;
        }
        public double Version { get; set; }
        public void Upgradevers(double version)
        {
            if (Username == null && Password == null)
            {
                Version += version;
                if (Version >= 4.5)
                {
                    Version = 4.5;
                    Work?.Invoke($"Была достигнута максимальная версия: {Version}");
                }
                Work?.Invoke($"Версия была обновлена до версии: {Version}");
            }
            else
                Work?.Invoke($"Версия не может быть обновлена из-за наличия зарегестрированного пользователя: {Username}");

        }
        public void ToUpp(string inform)
        {
            string sq;
            sq = inform.ToUpper();
            Console.WriteLine(sq);
        }
        public void ToLow(string inform)
        {
            string sq;
            sq = inform.ToLower();
            Console.WriteLine(sq);
        }
        public void Get_Inf()
        {
            Console.WriteLine($"Имя пользователя: {Username.ToUpper()}, Пароль: {Password.ToUpper()}, Версия: {Version}, Информация о пользователе: {Inform.ToUpper()}");
        }
    }

}
