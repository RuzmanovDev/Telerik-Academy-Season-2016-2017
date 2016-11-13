using Cars.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
            : base("Cars")
        {
        }

        public virtual DbSet<Car> Cars { get; set; } 

        public virtual DbSet<City> Cities { get; set; } 

        public virtual DbSet<Dealer> Dealers { get; set; } 

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Dealer>().Property(dealer => dealer.Name).IsUnicode(true);
        }
    }
}
