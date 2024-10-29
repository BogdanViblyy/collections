using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections
{
    using System;
    using System.Collections.Generic;

    public class Task1
    {
        public static void Execute()
        {
            Console.WriteLine("Sisestage numbrid tühikuita.");
            string numbers = Console.ReadLine();

            List<int> list = new List<int>();
            string[] numberStrings = numbers.Split(' ');

            foreach (string numberString in numberStrings)
            {
                if (int.TryParse(numberString, out int num))
                {
                    list.Add(num);
                }
                else
                {
                    Console.WriteLine($"'{numberString}' ei ole kehtiv number. Palun proovige uuesti.");
                    return; 
                }
            }

            if (list.Count == 1)
            {
                Console.WriteLine(list[0]);
            }
            else
            {
                for (int index = 0; index < list.Count; index++)
                {
                    int numbSum;
                    if (index != 0 && index != list.Count - 1)
                    {
                        numbSum = list[index - 1] + list[index + 1];
                    }
                    else if (index == 0)
                    {
                        numbSum = list[list.Count - 1] + list[index + 1];
                    }
                    else
                    {
                        numbSum = list[index - 1] + list[0];
                    }
                    Console.WriteLine(numbSum);
                }
            }
        }
    }



}
