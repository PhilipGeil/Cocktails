using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    class Alcohol
    {
        public int AlcoholId { get; set; }
        public string Name { get; set; }
        public Alcohol(string name)
        {
            this.Name = name;
        }
    }
}
