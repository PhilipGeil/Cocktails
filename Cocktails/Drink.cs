using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    class Drink
    {
        public int DrinkId { get; set; }
        public string Name { get; set; }
        public List<AlcoholAmount> AlcoholAmounts { get; set; }
        public List<MixerAmount> MixerAmounts { get; set; }
        public List<Accessory> Accessories { get; set; }

        public Drink(string name)
        {
            this.Name = name;
        }

        public Drink(string name, List<AlcoholAmount> AlcoholAmounts, List<MixerAmount> mixerAmounts, List<Accessory> accessories)
        {
            this.Name = name;
            this.AlcoholAmounts = AlcoholAmounts;
            this.MixerAmounts = mixerAmounts;
            this.Accessories = accessories;
        }
    }
}
