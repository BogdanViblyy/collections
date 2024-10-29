using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collections
{
    public class Task4
    {
        public static void Execute()
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
                        QuizCountrysides(countrysides);
                        break;
                    default:
                        keepRunning = false;
                        break;
                }
            }
        }

        private static void AddNewCountryside(Dictionary<string, string> countrysides)
        {
            Console.WriteLine("Sisestage pealinn");
            string capitalInput = Console.ReadLine();
            Console.WriteLine("Sisestage maakond");
            string countryInput = Console.ReadLine();
            countrysides.Add(capitalInput, countryInput);
            Console.WriteLine("Lisatud");
        }

        private static void QuizCountrysides(Dictionary<string, string> countrysides)
        {
            Random random = new Random();
            var shuffledCountrysides = countrysides.OrderBy(x => random.Next()).ToList();
            int rightAnswersCount = 0;

            foreach (var item in shuffledCountrysides)
            {
                Console.WriteLine($"Sisestage {item.Value} pealinn");
                string quizzAnswer = Console.ReadLine();
                if (quizzAnswer == item.Key)
                {
                    rightAnswersCount++;
                    Console.WriteLine("Õige!");
                }
                else
                {
                    Console.WriteLine("Vale!");
                }
            }
            Console.WriteLine($"Õigete vastuste kogus: {rightAnswersCount}");
        }
    }
}
