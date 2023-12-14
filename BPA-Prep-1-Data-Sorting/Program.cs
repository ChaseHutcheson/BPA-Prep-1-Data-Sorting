using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace BPA_Prep_1_Data_Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //C:\Users\Hutcheson_Chase\source\repos\BPA-Prep-1-Data-Sorting\BPA-Prep-1-Data-Sorting\Sample_Data_Age.csv
            List<Person> list = new List<Person>();
            string[] lines = System.IO.File.ReadAllLines(@"../../../Sample_Data_Age.csv");
            for (int line = 1; line < lines.Length; line++)
            {
                lines[line] = lines[line].Trim();
                dynamic split = lines[line].Split(",");
                string name = split[0];
                int age = int.Parse(split[1]);
                Person result = new Person
                {
                    Name = name,
                    Age = age,
                };
                list.Add(result);
            }

            var Over64 = list.Where(x => x.Age > 64);

            var AplhebeticalOrder = list.OrderBy(x => x.Name);

            var Between18and24 = list.Where(x => x.Age >= 18 && x.Age <= 24);

            var Between25and35 = list.Where(x => x.Age >= 25 && x.Age <= 35);

            var Between36and55 = list.Where(x => x.Age >= 26 && x.Age <= 55);

            var Over55 = list.Where(x => x.Age > 55);




            using (FileStream fileStream = new FileStream(@"../../../Seniors.csv", FileMode.Create))
            {
                byte[] title = Encoding.UTF8.GetBytes("Name,Age\n");
                fileStream.Write(title, 0, title.Length);

                foreach (Person person in Over64)
                {

                    byte[] bytes = Encoding.UTF8.GetBytes(person.Name + "," + person.Age + "\n");
                    fileStream.Write(bytes, 0, bytes.Length);
                }
            };

            using (FileStream fileStream = new FileStream(@"../../../alpha_all.csv", FileMode.Create))
            {
                byte[] title = Encoding.UTF8.GetBytes("Name,Age\n");
                fileStream.Write(title, 0, title.Length);

                foreach (Person person in AplhebeticalOrder)
                {

                    byte[] bytes = Encoding.UTF8.GetBytes(person.Name + "," + person.Age + "\n");
                    fileStream.Write(bytes, 0, bytes.Length);
                }
            };

            using (FileStream fileStream = new FileStream(@"../../../alpha_all.csv", FileMode.Create))
            {
                byte[] title = Encoding.UTF8.GetBytes("Name,Age\n");
                fileStream.Write(title, 0, title.Length);

                foreach (Person person in AplhebeticalOrder)
                {

                    byte[] bytes = Encoding.UTF8.GetBytes(person.Name + "," + person.Age + "\n");
                    fileStream.Write(bytes, 0, bytes.Length);
                }
            };

            using (FileStream fileStream = new FileStream(@"../../../age_data.csv", FileMode.Create))
            {
                byte[] title = Encoding.UTF8.GetBytes("18-24,25-35,36-55,55+\n");
                fileStream.Write(title, 0, title.Length);

                byte[] bytes = Encoding.UTF8.GetBytes(Between18and24.Count() + "," + Between25and35.Count() + "," + Between36and55.Count() + "," + Over55.Count() + "\n");
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
