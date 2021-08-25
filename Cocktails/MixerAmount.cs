using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    class MixerAmount
    {
        public int MixerAmountId { get; set; }
        public double Amount { get; set; }
        public string MeasureType { get; set; }
        public Mixer Mixer { get; set; }
        public MixerAmount() { }
        public MixerAmount(double amount, string measureType, Mixer mixer)
        {
            this.Amount = amount;
            this.MeasureType = measureType;
            this.Mixer = mixer;
        }
    }
}
