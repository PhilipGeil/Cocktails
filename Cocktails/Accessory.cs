using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    class Accessory
    {
        public int AccessoryId { get; set; }
        public string Name { get; set; }
        public Accessory(string name)
        {
            this.Name = name;
        }
    }
}
