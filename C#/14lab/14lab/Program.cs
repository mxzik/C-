using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace _14lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Tom", 29);
            Person person2 = new Person("Bill", 25);
            Person[] people = new Person[] { person, person2 };
            //Binnary
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);

                Console.WriteLine("Object was serialized");
            }

            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)formatter.Deserialize(fs);

                Console.WriteLine("Object wad desirealized");
                Console.WriteLine($"Name: {newPerson.Name} --- Age: {newPerson.Age}");
            }
            //Xml
            XmlSerializer formatter1 = new XmlSerializer(typeof(Person));

            using (FileStream fs1 = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                formatter1.Serialize(fs1, person);

                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs1 = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                Person newPerson = (Person)formatter1.Deserialize(fs1);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPerson.Name} --- Возраст: {newPerson.Age}");
            }
           //json
            string json = JsonSerializer.Serialize<Person>(person);
            Console.WriteLine(json);
            Person restoredPerson = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine(restoredPerson.Name);

            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                Person tom = new Person() { Name = "Tom", Age = 35 };
                JsonSerializer.SerializeAsync<Person>(fs, tom);
                Console.WriteLine("Data has been saved to file");
            }

            //using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            //{
            //    Person restoredPerso = JsonSerializer.DeserializeAsync<Person>(fs);
            //    Console.WriteLine($"Name: {restoredPerso.Name}  Age: {restoredPerso.Age}");
            //}
            //soap
            SoapFormatter formatter2 = new SoapFormatter();
            using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
            {
                formatter2.Serialize(fs, people);

                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("people.soap", FileMode.OpenOrCreate))
            {
                Person[] newPeople = (Person[])formatter2.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                foreach (Person p in newPeople)
                {
                    Console.WriteLine("Имя: {0} --- Возраст: {1}", p.Name, p.Age);
                }
            }
            //XPATH
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D://users.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlNode childnode = xRoot.SelectSingleNode("user[company='Microsoft']");
            foreach (XmlNode n in childnode)
                Console.WriteLine(n.InnerText);
            //Linq to xml
            XDocument xdoc = new XDocument(new XElement("phones",
            new XElement("phone",
            new XAttribute("name", "iPhone 6"),
            new XElement("company", "Apple"),
            new XElement("price", "40000")),
            new XElement("phone",
            new XAttribute("name", "Samsung Galaxy S5"),
            new XElement("company", "Samsung"),
            new XElement("price", "33000"))),
            new XComment("11"));
            xdoc.Save("phones.xml");
            XDocument xdoc1 = XDocument.Load("phones.xml");
            foreach (XElement phoneElement in xdoc1.Element("phones").Elements("phone"))
            {
                XAttribute nameAttribute = phoneElement.Attribute("name");
                XElement priceElement = phoneElement.Element("price");
                if (nameAttribute != null)
                {
                    Console.WriteLine($"Смартфон: {nameAttribute.Value}");
                    Console.WriteLine($"Цена: {priceElement.Value}");
                }
                Console.WriteLine();
            }
            XDocument xdoc2 = XDocument.Load("phones.xml");
            var items = from xe in xdoc2.Element("phones").Elements("phone")
                        where xe.Element("company").Value == "Samsung"
                        select new Phone
                        {
                            Name = xe.Attribute("name").Value,
                            Price = xe.Element("price").Value
                        };

            foreach (var item in items)
                Console.WriteLine($"{item.Name} - {item.Price}");
        }
    }
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    class Phone
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
