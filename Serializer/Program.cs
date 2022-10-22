using ClassLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serializer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CSVtoClass(@"C:\Users\БексултановД\Desktop\book.csv");
            List<PC> pcs = new List<PC>();
            pcs.Add(new PC("Apple", "485327", 4500));
            pcs.Add(new PC("Acer", "657823", 5000));
            pcs.Add(new PC("Lenovo", "126744", 4700));

            using (FileStream fs = new FileStream("pc.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(PC[]));
                formatter.Serialize(fs, pcs.ToArray());
            }
        }

        public static void CSVtoClass(string path)
        {
            //для сериализаций нужно использовать только массив, нельзя List, так как это класс
            List<Person> users = new List<Person>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(';');
                    Person person = new Person(words[0], words[1], words[2], Convert.ToInt32(words[3])); //int.Parse(words[3])
                    users.Add(person);
                }
            }
            using(FileStream fs = new FileStream("phone_book.soap", FileMode.OpenOrCreate))
            {
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(fs, users.ToArray());
            }
        }
    }

    [Serializable]
    public class Person
    {
        public string fName { get; set; }    
        public string sName { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }

        public Person(string fName, string sName, string phone, int birthday)
        {
            this.fName = fName;
            this.sName = sName;
            Phone = phone;
            Birthday = new DateTime(birthday);
        }

        public override string ToString()
        {
            return String.Format("First Name: {0} \n Second Name: {1} \n Phone Number: {2} \n Birthday: {3}", fName, sName, Phone, Birthday);
        }
    }
}
