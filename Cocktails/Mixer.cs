using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    class Mixer
    {
        public int MixerId { get; set; }
        public string Name { get; set; }

        public Mixer(string name)
        {
            this.Name = name;
        }
    }
}
