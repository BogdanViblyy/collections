
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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {

                Action[] methods = new Action[] { Task1, Task2, Task3, Task4 };
                Console.WriteLine("Sisestage ülesanne number");
                string numstr = Console.ReadLine();
                int number = int.Parse(numstr);
                methods[number - 1]();
            }

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
                        int numbSum = list[list.Count - 1] + list[index + 1];
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
                result1 += num.ToString() + ", ";

            }
            Console.WriteLine(result1);


            List<int> oddNumbers = new List<int>();
            List<int> evenNumbers = new List<int>();


            foreach (int num in randomNumbers)
            {
                if (num % 2 == 0)
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
        private static void Task3()
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "porgand", Calories = 41 }, // 100 g
                new Product { Name = "leib", Calories = 271 }, // 100 g
                new Product { Name = "kartul", Calories = 77 }, // 100 g
                new Product { Name = "õun", Calories = 52 }, // 100 g
                new Product { Name = "kanarind", Calories = 165 }, // 100 g
                new Product { Name = "brokoli", Calories = 34 }, // 100 g
                new Product { Name = "riis", Calories = 130 }, // 100 g
                new Product { Name = "piim", Calories = 42 } // 100 g
            };

            var dailyPlan = new List<(Product Product, double Amount)>
            {
                (products[4], 200), // kanarind
                (products[3], 150), // õun
                (products[0], 100), // porgand
                (products[6], 100), // riis
                (products[5], 100), // brokoli
                (products[7], 250), // piim
                (products[1], 150)  // leib
            };
            double totalCalories = 0;

            Console.WriteLine("Sisestage oma andmeid ");

            Console.WriteLine("Kaal:");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Pikkus:");
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("Vanus:");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Sugu(mees/naine):");
            string gender = Console.ReadLine();

            Console.WriteLine("Aktiivsus (Istuv eluviis/Vähene aktiivsus/Mõõdukas aktiivsus/Kõrge aktiivsus/Väga kõrge aktiivsus):");
            string activity = Console.ReadLine();

            Human user = new Human { Weight = weight, Height = height, Age = age, Gender = gender, Activity = activity };
            double dailyCalories = CalculateBMR(user.Weight, user.Height, user.Age, user.Gender, user.Activity);

            Console.WriteLine($"Teie BMR on: {dailyCalories} kalorit");
            Console.WriteLine("Te saate tarbida järgmisi tooteid:");

            foreach (var item in dailyPlan)
            {
                double productCalories = (item.Product.Calories * item.Amount) / 100;
                totalCalories += productCalories;
                Console.WriteLine($"{item.Product.Name}: {item.Amount} grammi, {productCalories} kalorit");
            }
        }

        private static double CalculateBMR(double weight, double height, int age, string gender, string activity)
        {
            double result;

            if (gender.ToLower() == "mees")
            {
                result = 66 + (13.7 * weight) + (5 * height) - (6.8 * age);
            }
            else if (gender.ToLower() == "naine")
            {
                result = 655 + (9.6 * weight) + (1.8 * height) - (4.7 * age);
            }
            else
            {
                return -1;
            }

            return activity switch
            {
                "Istuv eluviis" => result * 1.2,
                "Vähene aktiivsus" => result * 1.375,
                "Mõõdukas aktiivsus" => result * 1.55,
                "Kõrge aktiivsus" => result * 1.725,
                "Väga kõrge aktiivsus" => result * 1.9,
                _ => -1
            };
        }
        private static void Task4()
        {
            Dictionary<string, string> countrysides = new Dictionary<string, string>
            {
                { "Tallinn", "Harjumaa" },
                { "Tartu", "Tartumaa" },
                { "Pärnu", "Pärnumaa" },
                { "Narva", "Ida-Virumaa" },
                { "Rakvere", "Lääne-Virumaa" },
                { "Haapsalu", "Läänemaa" },
                { "Kuressaare", "Saaremaa" },
                { "Viljandi", "Viljandimaa" },
                { "Paide", "Järvamaa" },
                { "Jõgeva", "Jõgevamaa" },
                { "Valga", "Valgamaa" },
                { "Võru", "Võrumaa" },
                { "Põlva", "Põlvamaa" },
                { "Rapla", "Raplamaa" },
                { "Kärdla", "Hiiumaa" }
            };

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Menüü:");
                Console.WriteLine("1 - Kuvada pealinna või maakonna nime järgi");
                Console.WriteLine("2 - Lisa uus");
                Console.WriteLine("3 - teadmise kontroll");
                string answer = Console.ReadLine();



                switch (answer)
                {
                    case "1":
                        Console.WriteLine("Sisestage");
                        string input = Console.ReadLine();
                        string capital = countrysides.Keys.FirstOrDefault(c => c == input);
                        if (capital != null)
                        {
                            Console.WriteLine(countrysides[capital]);
                        }
                        else
                        {
                            string name = countrysides.Values.FirstOrDefault(n => n == input);
                            if (name != null)
                            {
                                foreach (var item in countrysides)
                                {
                                    if (item.Value == name)
                                    {
                                        Console.WriteLine(item.Key);
                                    }

                                }
                            }
                            else
                            {
                                Console.WriteLine("Lisa uus? j/e");
                                if (Console.ReadLine() == "j")
                                {
                                    AddNewCountryside(countrysides);
                                }

                            }
                        }
                        break;
                    case "2":
                        AddNewCountryside(countrysides);
                        break;
                    case "3":
                        Random random = new Random();
                        List<KeyValuePair<string, string>> shuffledCountrysides = new List<KeyValuePair<string, string>>(countrysides);
                        int n = shuffledCountrysides.Count;

                        while (n > 1)
                        {
                            int k = random.Next(n--);
                            var temp = shuffledCountrysides[n];
                            shuffledCountrysides[n] = shuffledCountrysides[k];
                            shuffledCountrysides[k] = temp;
                        }

                        int rightAnswersCount = 0;
                        foreach(var item in shuffledCountrysides)
                        {
                            Console.WriteLine($"Sisestage {item.Value} pealinn");
                            string quizzAnswer = Console.ReadLine();
                            if (quizzAnswer == item.Key)
                            {
                                rightAnswersCount++ ;
                                Console.WriteLine("Õige!");

                            }
                            else
                            {
                                Console.WriteLine("Vale!");
                            }


                        }
                        Console.WriteLine($"Õigete vastuste kogus: {rightAnswersCount}");
                        break;
                    default:
                        keepRunning= false;
                        break;
                        
                }




            }


        }
        static void AddNewCountryside(Dictionary<string, string> countrysides)
        {
            Console.WriteLine("Sisestage pealinn");
            string capitalInput = Console.ReadLine();


            Console.WriteLine("Sisestage maakond");
            string countryInput = Console.ReadLine();
            countrysides.Add(capitalInput, countryInput);
            Console.WriteLine("Lisatud");
        }


    }
}