using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace collections
{
    public class Task2
    {
        public static void Execute()
        {
            int listLenght = 0;
            Console.WriteLine("Sisestage listi pikkus");
            string listLenghtString = Console.ReadLine();

            Random random = new Random();
            List<int> randomNumbers = new List<int>();


            try
            {
                listLenght = int.Parse(listLenghtString);
                if (listLenght > 0)
                {
                    Console.WriteLine($"Te sisestasite: {listLenght}");

                }
                else
                {
                    Console.WriteLine("Number peab olema suurem kui null. Palun proovige uuesti.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Vale sisend. Palun sisestage kehtiv täisarv.");
            }
             for (int i = 0; i < listLenght; i++)
            {
                randomNumbers.Add(random.Next(0, 101));
            }

            Console.WriteLine(string.Join(", ", randomNumbers));

            List<int> oddNumbers = randomNumbers.Where(num => num % 2 != 0).ToList();
            List<int> evenNumbers = randomNumbers.Where(num => num % 2 == 0).ToList();

            oddNumbers.AddRange(evenNumbers);
            Console.WriteLine(string.Join(", ", oddNumbers));
        }
    }
}
