using System;
using System.Collections.Generic;

namespace Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DrinksContext())
            {
                DalManager dalManager = new DalManager(db);
                List<string> options = new List<string>()
                {
                    "Opret test drinks",
                    "Print alle drinks",
                    "Ryd hele databasen",
                    "Søg efter drink",
                    "Opret alkohol",
                    "Opret mixer",
                    "Omdøb drink",
                    "Luk programmet",
                };

                while (true)
                {
                    Console.Clear();
                    for (int i = 0; i < options.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {options[i]}");
                    }
                    switch (Console.ReadLine())
                    {
                        case "1":
                            PrepareOption("Creating drinks");
                            try
                            {
                                dalManager.CreateDrinks();
                                Console.WriteLine("Drink has been made");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Shit don't work mate");
                                throw;
                            }
                            EndOption();
                            break;
                        case "2":
                            PrepareOption("Fetching drinks...");
                            try
                            {
                                List<Drink> drinks = dalManager.GetAllDrinks();
                                if (drinks.Count == 0)
                                {
                                    Console.WriteLine("There is no drinks");
                                }
                                foreach (Drink drink in drinks)
                                {
                                    PrintDrink(drink);
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Did not work buddy");
                                throw;
                            }
                            EndOption();
                            break;
                        case "3":
                            PrepareOption("Clearing database");
                            try
                            {
                                dalManager.ClearDatabase();
                                Console.WriteLine("Drinks has been cleared");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Could not clear the database");
                                throw;
                            }
                            EndOption();
                            break;
                        case "4":
                            PrepareOption("Enter search text");
                            try
                            {
                                string search = Console.ReadLine();
                                List<Drink> drinks = dalManager.SearchForDrink(search);
                                if (drinks.Count == 0)
                                {
                                    Console.WriteLine("There were no results...");
                                }
                                foreach (Drink drink in drinks)
                                {
                                    PrintDrink(drink, search);
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("There was an error searching for the drink");
                                throw;
                            }
                            EndOption();
                            break;
                        case "5":
                            PrepareOption("Enter alcohol name:");
                            try
                            {
                                dalManager.CreateAlcohol(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Couldn't create the alcohol");
                                throw;
                            }
                            EndOption();
                            break;
                        case "6":
                            PrepareOption("Enter mixer name:");
                            try
                            {
                                dalManager.CreateMixer(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Couldn't create the mixer");
                                throw;
                            }
                            EndOption();
                            break;
                        case "7":
                            PrepareOption("Choose the drink to rename:");
                            try
                            {
                                List<Drink> drinks = dalManager.GetAllDrinks();
                                for (int i = 0; i < drinks.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {drinks[i].Name}");
                                }
                                int selection = int.Parse(Console.ReadLine()) - 1;
                                Console.WriteLine("Enter the new name:");
                                string newName = Console.ReadLine();
                                dalManager.RenameDrink(drinks[selection], newName);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Failed to rename drink");
                                throw;
                            }
                            break;
                        case "8":
                            Environment.Exit(1);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        static void PrepareOption(string title)
        {
            Console.Clear();
            Console.WriteLine(title);
        }

        static void EndOption()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any enter to continue...");
            Console.ReadLine();
        }

        static void PrintDrink(Drink drink)
        {
            Console.WriteLine("----------------------");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(drink.Name);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("-------Alcohol--------");
            foreach (AlcoholAmount alcoholAmount in drink.AlcoholAmounts)
            {
                Console.WriteLine($"{alcoholAmount.Alcohol.Name} {alcoholAmount.Amount}{alcoholAmount.MeasureType}");
            }
            Console.WriteLine("--------Mixer---------");
            foreach (MixerAmount mixerAmount in drink.MixerAmounts)
            {
                Console.WriteLine($"{mixerAmount.Mixer.Name} {mixerAmount.Amount}{mixerAmount.MeasureType}");
            }
            if (drink.Accessories.Count != 0)
            {
                Console.WriteLine("----Instruktioner----");
                foreach (Accessory accessory in drink.Accessories)
                {
                    Console.WriteLine(accessory.Name);
                }
            }
            Console.WriteLine("----------------------");
        }

        static void PrintDrink(Drink drink, string searchWord)
        {
            Console.WriteLine("----------------------");
            if (drink.Name.ToLower().Contains(searchWord.ToLower()))
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            Console.WriteLine(drink.Name);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("-------Alcohol--------");
            foreach (AlcoholAmount alcoholAmount in drink.AlcoholAmounts)
            {
                if (alcoholAmount.Alcohol.Name.ToLower().Contains(searchWord.ToLower()))
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                Console.WriteLine($"{alcoholAmount.Alcohol.Name} {alcoholAmount.Amount}{alcoholAmount.MeasureType}");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("--------Mixer---------");
            foreach (MixerAmount mixerAmount in drink.MixerAmounts)
            {
                if (mixerAmount.Mixer.Name.ToLower().Contains(searchWord.ToLower()))
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                Console.WriteLine($"{mixerAmount.Mixer.Name} {mixerAmount.Amount}{mixerAmount.MeasureType}");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            if (drink.Accessories.Count != 0)
            {
                Console.WriteLine("----Instruktioner----");
                foreach (Accessory accessory in drink.Accessories)
                {
                    if (accessory.Name.ToLower().Contains(searchWord.ToLower()))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                    }
                    Console.WriteLine(accessory.Name);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            Console.WriteLine("----------------------");
        }
    }
}
