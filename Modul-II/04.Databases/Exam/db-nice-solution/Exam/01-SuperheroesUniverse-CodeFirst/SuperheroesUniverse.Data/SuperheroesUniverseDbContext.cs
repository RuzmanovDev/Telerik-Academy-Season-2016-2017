namespace SuperheroesUniverse.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Models;

    public class SuperheroesUniverseDbContext : DbContext
    {
        public SuperheroesUniverseDbContext()
            : base("name=SuperheroesUniverseDbContext")
        {
            this.Database.CreateIfNotExists();
        }

        public virtual IDbSet<Power> Powers { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Planet> Planets { get; set; }

        public virtual IDbSet<Superhero> Superheroes { get; set; }

        public virtual IDbSet<Fraction> Fractions { get; set; }

        public virtual IDbSet<HeroRelationship> HeroRelationships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<HeroRelationship>()
            //            .HasMany(i => i.Superhero)
            //            .WithRequired()
            //            .WillCascadeOnDelete(false);
        }
    }
}
