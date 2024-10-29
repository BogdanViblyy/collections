using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections
{
    public class Task2
    {
        public static void Execute()
        {
            Random random = new Random();
            List<int> randomNumbers = new List<int>();

            for (int i = 0; i < 20; i++)
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
