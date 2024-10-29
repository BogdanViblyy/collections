using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections
{
    public class Task3
    {
        public static void Execute()
        {
            List<Product> products = new List<Product>
            {
            new Product { Name = "porgand", Calories = 41 },
            new Product { Name = "leib", Calories = 271 },
            new Product { Name = "kartul", Calories = 77 },
            new Product { Name = "õun", Calories = 52 },
            new Product { Name = "kanarind", Calories = 165 },
            new Product { Name = "brokoli", Calories = 34 },
            new Product { Name = "riis", Calories = 130 },
            new Product { Name = "piim", Calories = 42 }
            };
            double weight = 0;
            double height = 0;
            int age = 0;
            string gender = "";
            string activity = "";
            List<string> activityLevels = new List<string>
            {
            "Istuv eluviis",
            "Vähene aktiivsus",
            "Mõõdukas aktiivsus",
            "Kõrge aktiivsus",
            "Väga kõrge aktiivsus"
            };

            Console.WriteLine("Sisestage oma andmeid ");
            Console.WriteLine("Kaal:");
            while (true)
            {
                try
                {
                    weight = double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {

                    Console.WriteLine("Vale format.");
                }
            }

            Console.WriteLine("Pikkus:");
            while (true)
            { 
                try
                {
                    height = double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Vale format.");
                }
            }
            
            Console.WriteLine("Vanus:");
            while (true)
            {
                try
                {
                    age = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {

                    Console.WriteLine("Vale format.");
                }
            }
            Console.WriteLine("Sugu(mees/naine):");
            while (true)
            {
                try
                {
                    gender = Console.ReadLine().ToLower();
                    if (gender == "mees" || gender == "naine")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Palun sisestage 'mees' või 'naine'.");
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Vale format.");
                }
            }

          
            
            Console.WriteLine("Aktiivsus (Istuv eluviis/Vähene aktiivsus/Mõõdukas aktiivsus/Kõrge aktiivsus/Väga kõrge aktiivsus):");
            while (true)
            {
                try
                {
                    activity = Console.ReadLine();
                    if (activityLevels.Contains(activity))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Valesti kirjutatud.");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Vale format.");
                }
            }
            

            Human user = new Human { Weight = weight, Height = height, Age = age, Gender = gender, Activity = activity };
            double dailyCalories = CalculateBMR(user.Weight, user.Height, user.Age, user.Gender, user.Activity);

            Console.WriteLine($"Teie BMR on: {dailyCalories} kalorit");
            Console.WriteLine("Valige millise toode diet te tahate näha?\n");
            foreach (Product product in products)
        {
            Console.WriteLine(product.Name);
        }

        string dietChoice = Console.ReadLine();
        Product dietProduct = products.FirstOrDefault(p => p.Name.Equals(dietChoice, StringComparison.OrdinalIgnoreCase));

        if (dietProduct != null)
        {
            int dailyPlan = (int)(dailyCalories / dietProduct.Calories);
            Console.WriteLine($"Saate süüa {dietProduct.Name} {dailyPlan} korda.");
        }
        else
        {
            Console.WriteLine("Valitud toodet ei leitud.");
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
    }
}
