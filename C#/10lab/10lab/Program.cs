using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace _10lab
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();

            AddRandomItems(list);

            string k = "koldas";
            list.Add(k);
            Student student = new Student() { Name = "123" };
            list.Add(student.Name);

            ShowArrayList(list);

            Console.WriteLine("=============================================");
            list.Remove(k);

            ShowArrayList(list);

            Console.WriteLine("=============================================");
            int count = list.Count;
            Console.WriteLine(count);
            var b = list.Contains(3);
            Console.WriteLine(b);
            Console.WriteLine("=============================================");
            Stack<double> vs = new Stack<double>();

            PushToStack(vs);

            ShowStack(vs);

            Console.WriteLine("=============================================");

            PopfromStack(vs);

            ShowStack(vs);

            Console.WriteLine("=============================================");

            LinkedList<double> vs1 = new LinkedList<double>();

            Zap(vs1, vs);

            ShowLinkedlist(vs1);

            SearchLinked(vs1);

            Console.WriteLine("=============================================");
            Console.WriteLine("=============================================");


            LinkedList<Student> persons = new LinkedList<Student>();
            LinkedListNode<Student> tom = persons.AddLast(new Student() { Name = "Tom" });
            persons.AddLast(new Student() { Name = "John" });
            persons.AddFirst(new Student() { Name = "Bill" });

            Console.WriteLine(tom.Previous.Value.Name);
            Console.WriteLine(tom.Next.Value.Name);

            Console.WriteLine("=============================================");

            ObservableCollection<Student> students = new ObservableCollection<Student>
            {
                new Student {Name="Tom"},
                new Student {Name="Tim"},
                new Student {Name="Tomas"}

            };
            students.CollectionChanged += Students_CollectionChanged;
            students.Add(new Student { Name = "Bill" });
            students.RemoveAt(0);
            students[0] = new Student { Name = "Andrew" };
            foreach (Student student1 in students)
            {
                Console.WriteLine(student1.Name);
            }
        }
        private static void Students_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Student newUser = e.NewItems[0] as Student;
                    Console.WriteLine($"Добавлен новый объект: {newUser.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Student oldUser = e.OldItems[0] as Student;
                    Console.WriteLine($"Удален объект: {oldUser.Name}");
                    break;
            }
        }
    public static ArrayList AddRandomItems(ArrayList list)
        {
            ArrayList newList = list;

            for (int i = 1; i < 6; i++)
            {
                newList.Add(i);
            }

            return newList;
        }

        public static void ShowArrayList(ArrayList list)
        {
            foreach(object item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        public static Stack<double> PushToStack(Stack<double> vs)
        {
            Stack<double> stack1 = vs;
            for (double s = 1.3; s < 5.3; s++)
            {
                stack1.Push(s);
            }
            return stack1;
        }
        public static void ShowStack(Stack<double> vs)
        {
            foreach(double item1 in vs)
            {
                Console.WriteLine(item1);
            }
        }
        public static Stack<double> PopfromStack(Stack<double> vs)
        {
            Stack<double> stack1 = vs;
            Console.Write("Введите число: ");
            int n = int.Parse(Console.ReadLine());
            for (int j = 0; j < n; j++)
            {
               stack1.Pop();
            }
            return stack1;
        }
        public static LinkedList<double> Zap(LinkedList<double> vs1, Stack<double> vs)
        {
            LinkedList<double> linklist = vs1;
            Stack<double> stack2 = vs;
            foreach (double i in stack2)
            {
                linklist.AddLast(i);
            }
            return linklist;
        }
        public static void ShowLinkedlist(LinkedList<double> vs1)
        {
            foreach (double item1 in vs1)
            {
                Console.WriteLine(item1);
            }
        }

        public static void SearchLinked(LinkedList<double> vs1)
        {
            LinkedList<double> linked = vs1;
            Console.Write("Введите число: ");
            double n = double.Parse(Console.ReadLine());
            if (linked.Find(n) != null)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            Console.WriteLine();
        }

        class Student
        {
            public string Name { get; set; }
        }
    }
}
