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

            foreach (char sym in numbers)
            {
                if (char.IsDigit(sym))
                {
                    try
                    {
                       
                        int num = int.Parse(sym.ToString());
                        list.Add(num);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"'{sym}' ei ole kehtiv number. Palun proovige uuesti.");
                        return;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine($"'{sym}' ületab int tüübi piire. Palun proovige uuesti.");
                        return;
                    }
                }
                else if (!char.IsWhiteSpace(sym))
                {
                
                    Console.WriteLine($"'{sym}' ei ole kehtiv sisend. Palun sisestage ainult numbrid.");
                    return;
                }
            }

            if (list.Count == 1)
            {
                Console.WriteLine(list[0]);
                Console.ReadLine();
            }
            else
            {
                foreach (int num in list)
                {
                    int index = list.IndexOf(num);
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
                Console.ReadLine();
            }
        }
    }




}
