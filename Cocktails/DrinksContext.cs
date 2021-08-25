using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    class DrinksContext : DbContext
    {
        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<AlcoholAmount> AlcoholAmounts { get; set; }
        public DbSet<Mixer> Mixers { get; set; }
        public DbSet<MixerAmount> MixerAmounts { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Drink> Drinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql("Host=localhost;Database=cocktails;Username=entity;Password=Test1234");
    }
}
