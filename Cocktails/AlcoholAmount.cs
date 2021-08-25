using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    class AlcoholAmount
    {
        public int AlcoholAmountId { get; set; }
        public double Amount { get; set; }
        public string MeasureType { get; set; }
        public Alcohol Alcohol { get; set; }

        public AlcoholAmount() { }

        public AlcoholAmount(double amount, string measureType, Alcohol alcohol)
        {
            this.Amount = amount;
            this.MeasureType = measureType;
            this.Alcohol = alcohol;
        }
    }
}
