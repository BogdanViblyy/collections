using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;


namespace collections
{
    class Program
    {


        static void Main(string[] args)
        {
            Action[] methods = new Action[]{ Task1, Task2};
            Console.WriteLine("Sisestage ülesanne number");
            string numstr = Console.ReadLine();
            int number = int.Parse(numstr);
            methods[number - 1]();
            
        }
        private static void Task1()
        {
            Console.WriteLine("Sisestage numbrid tühikuita.");
            string numbers = Console.ReadLine();

            List<int> list = new List<int>();
            foreach (char sym in numbers)
            {
                string symStr = sym.ToString();
                int num = int.Parse(symStr); /*123453453535345*/
                list.Add(num);
            }
            
            if (list.Count == 1)
            {
                Console.WriteLine(numbers[0]);
                Console.ReadLine();
                
            }
            else
            {


                foreach (int num in list)
                {
                    int index = list.IndexOf(num);
                    if (index != 0 && index != list.Count)
                    {
                        int numbSum = list[index - 1] + list[index + 1];
                        Console.WriteLine(numbSum);
                    }
                    else if (index == 0)
                    {
                        int numbSum = list[list.Count-1] + list[index + 1];
                        Console.WriteLine(numbSum);
                    }
                    else
                    {
                        int numbSum = list[index - 1] + list[0];
                        Console.WriteLine(numbSum);
                    }

                }
                Console.ReadLine();
                
            }
        }
        private static void Task2()
        {
            Random random = new Random();

            
            List<int> randomNumbers = new List<int>();

            
            for (int i = 0; i < 20; i++)
            {                
                randomNumbers.Add(random.Next(0, 101));
            }
           
            string result1 = "";
            foreach (int num in randomNumbers)
            {
                result1 += num.ToString()+", ";

            }
            Console.WriteLine(result1);


            List<int> oddNumbers = new List<int>();
            List<int> evenNumbers = new List<int>();


            foreach (int num in randomNumbers)
            {
                if (num % 2 ==0)
                {
                    oddNumbers.Add(num);
                }
                else
                { 
                    evenNumbers.Add(num);
                }
            }

            oddNumbers.AddRange(evenNumbers);
            string result2 = "";
            foreach (int num in oddNumbers)
            {
                result2 += num.ToString() + ", ";
                
            }
            Console.WriteLine(result2);

        }

    }
}