
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
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Valige ülesanne:");
                Console.WriteLine("1 - Ülesanne 1");
                Console.WriteLine("2 - Ülesanne 2");
                Console.WriteLine("3 - Ülesanne 3");
                Console.WriteLine("4 - Ülesanne 4");
                Console.WriteLine("0 - Välju");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Task1.Execute();
                        break;
                    case "2":
                        Task2.Execute();
                        break;
                    case "3":
                        Task3.Execute();
                        break;
                    case "4":
                        Task4.Execute();
                        break;
                    case "0":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Vale valik, proovige uuesti.");
                        break;
                }
            }
        }
    }
}