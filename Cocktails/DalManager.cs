using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    class DalManager
    {
        DrinksContext db;
        public DalManager(DrinksContext drinksContext)
        {
            db = drinksContext;
        }
        /// <summary>
        /// Creates 3 simple drinks for showing purpose
        /// </summary>
        public void CreateDrinks()
        {
            // Create some alcohols
            Alcohol vodka = new Alcohol("Vodka");
            Alcohol tequila = new Alcohol("Tequila");
            Alcohol darkrum = new Alcohol("Dark rum");
            Alcohol kahlua = new Alcohol("Kahlua");
            Alcohol tripleSec = new Alcohol("Triple Sec");
            Alcohol orangeCuraCao = new Alcohol("Orange Curacao");

            db.Alcohols.Add(vodka);
            db.Alcohols.Add(tequila);
            db.Alcohols.Add(darkrum);
            db.Alcohols.Add(kahlua);
            db.Alcohols.Add(tripleSec);
            db.Alcohols.Add(orangeCuraCao);

            // Define the amounts
            AlcoholAmount whiteRussianAmounts = new AlcoholAmount(90, "ml", vodka);
            AlcoholAmount kahluaAmount = new AlcoholAmount(30, "ml", kahlua);
            AlcoholAmount margaritaAmounts = new AlcoholAmount(60, "ml", tequila);
            AlcoholAmount tripleSecAmount = new AlcoholAmount(30, "ml", tripleSec);
            AlcoholAmount orangeCuracaoAmount = new AlcoholAmount(15, "ml", orangeCuraCao);
            AlcoholAmount maitaiAmounts = new AlcoholAmount(50, "ml", darkrum);

            db.AlcoholAmounts.Add(whiteRussianAmounts);
            db.AlcoholAmounts.Add(margaritaAmounts);
            db.AlcoholAmounts.Add(maitaiAmounts);

            // Create the accessories
            Accessory margaritaAccessory = new Accessory("salt rim, crushed ice, lime segment");
            Accessory maitaiAccessory = new Accessory("lime section, maraschino cherry, lime segment");

            db.Accessories.Add(margaritaAccessory);
            db.Accessories.Add(maitaiAccessory);

            // Create the mixers
            Mixer freshCream = new Mixer("Fresh Cream");
            Mixer limeJuice = new Mixer("Lime Juice");
            Mixer almondSyrup = new Mixer("Almond Syrup");

            db.Mixers.Add(freshCream);
            db.Mixers.Add(limeJuice);
            db.Mixers.Add(almondSyrup);

            MixerAmount freshCreamAmount = new MixerAmount(30, "ml", freshCream);
            MixerAmount limeJuiceTenMl = new MixerAmount(10, "ml", limeJuice);
            MixerAmount limeJuiceSixtyMl = new MixerAmount(60, "ml", limeJuice);
            MixerAmount almondSyrupAmount = new MixerAmount(60, "ml", almondSyrup);

            db.MixerAmounts.Add(freshCreamAmount);
            db.MixerAmounts.Add(limeJuiceTenMl);
            db.MixerAmounts.Add(limeJuiceSixtyMl);
            db.MixerAmounts.Add(almondSyrupAmount);

            Drink whiteRussian = new("White Russian", new List<AlcoholAmount>()
                {
                    whiteRussianAmounts,
                    kahluaAmount,
                }, new List<MixerAmount>()
                {
                    freshCreamAmount
                }, new List<Accessory>());
            Drink margarita = new("Margarita", new List<AlcoholAmount>()
                {
                    tripleSecAmount,
                    margaritaAmounts,
                }, new List<MixerAmount>()
                {
                    limeJuiceSixtyMl,
                }, new List<Accessory>()
                {
                    margaritaAccessory,
                });
            Drink maiTai = new Drink("Mai Tai", new List<AlcoholAmount>()
                {
                    maitaiAmounts,
                    orangeCuracaoAmount
                }, new List<MixerAmount>()
                {
                    limeJuiceTenMl,
                    almondSyrupAmount,
                }, new List<Accessory>()
                {
                    maitaiAccessory,
                });

            db.Drinks.Add(whiteRussian);
            db.Drinks.Add(margarita);
            db.Drinks.Add(maiTai);
            db.SaveChanges();
        }
        /// <summary>
        /// Returns a list with all the drinks in the database
        /// </summary>
        /// <returns></returns>
        public List<Drink> GetAllDrinks()
        {
            return db.Drinks.Include(a => a.AlcoholAmounts).ThenInclude(a => a.Alcohol).Include(m => m.MixerAmounts).ThenInclude(m => m.Mixer).Include(a => a.Accessories).ToList();
        }
        /// <summary>
        /// Searches for a drink - it searches through the name, alcohols, mixers and accessories.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<Drink> SearchForDrink(string search)
        {
            return GetAllDrinks().Where(d => d.Name.ToLower().Contains(search.ToLower()) || d.AlcoholAmounts.Any(a => a.Alcohol.Name.ToLower().Contains(search.ToLower())) || d.MixerAmounts.Any(m => m.Mixer.Name.ToLower().Contains(search.ToLower())) || d.Accessories.Any(a => a.Name.ToLower().Contains(search.ToLower()))).ToList();
        }
        /// <summary>
        /// Clears the database
        /// </summary>
        public void ClearDatabase()
        {
            foreach (Alcohol a in db.Alcohols)
            {
                db.Alcohols.Remove(a);
            }
            foreach (AlcoholAmount a in db.AlcoholAmounts)
            {
                db.AlcoholAmounts.Remove(a);
            }
            foreach (Mixer m in db.Mixers)
            {
                db.Mixers.Remove(m);
            }
            foreach (MixerAmount m in db.MixerAmounts)
            {
                db.MixerAmounts.Remove(m);
            }
            foreach (Accessory accessory in db.Accessories)
            {
                db.Accessories.Remove(accessory);
            }
            foreach (Drink drink in db.Drinks)
            {
                db.Drinks.Remove(drink);
            }
            db.SaveChanges();
        }
        /// <summary>
        /// Create a new alcohol
        /// </summary>
        /// <param name="name"></param>
        public void CreateAlcohol(string name)
        {
            db.Alcohols.Add(new Alcohol(name));
            db.SaveChanges();
        }
        /// <summary>
        /// Create a new alcohol amount
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="measureType"></param>
        /// <param name="alcohol"></param>
        public void CreateAlcoholAmount(double amount, string measureType, Alcohol alcohol)
        {
            db.AlcoholAmounts.Add(new AlcoholAmount(amount, measureType, alcohol));
            db.SaveChanges();
        }
        /// <summary>
        /// Create a new mixer amount
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="measureType"></param>
        /// <param name="mixer"></param>
        public void CreateMixerAmount(double amount, string measureType, Mixer mixer)
        {
            db.MixerAmounts.Add(new MixerAmount(amount, measureType, mixer));
            db.SaveChanges();
        }
        /// <summary>
        /// Create a new mixer
        /// </summary>
        /// <param name="name"></param>
        public void CreateMixer(string name)
        {
            db.Mixers.Add(new Mixer(name));
            db.SaveChanges();
        }
        /// <summary>
        /// Create an accessory
        /// </summary>
        /// <param name="name"></param>
        public void CreateAccessory(string name)
        {
            db.Accessories.Add(new Accessory(name));
            db.SaveChanges();
        }
        /// <summary>
        /// Create a drink
        /// </summary>
        /// <param name="name"></param>
        /// <param name="alcoholAmounts"></param>
        /// <param name="mixerAmounts"></param>
        /// <param name="accessories"></param>
        public void CreateDrink(string name, List<AlcoholAmount> alcoholAmounts, List<MixerAmount> mixerAmounts, List<Accessory> accessories)
        {
            db.Drinks.Add(new Drink(name, alcoholAmounts, mixerAmounts, accessories));
            db.SaveChanges();
        }

        public void RenameDrink(Drink drink, string newName)
        {
            db.Drinks.Find(drink.DrinkId).Name = newName;
            db.SaveChanges();
        }
    }
}
