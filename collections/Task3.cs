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

            var dailyPlan = new List<(Product Product, double Amount)>
        {
            (products[4], 200),
            (products[3], 150),
            (products[0], 100),
            (products[6], 100),
            (products[5], 100),
            (products[7], 250),
            (products[1], 150)
        };

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

            double totalCalories = 0;
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
    }
}
