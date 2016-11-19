namespace SuperheroesUniverse.Data.Common
{
    using System;

    using Models;

    public class SuperheroesDataProvider : ISuperheroesDataProvider
    {
        private IRepository<Superhero> superheroes;
        private IRepository<City> cities;
        private IRepository<Planet> planets;
        private IRepository<Country> countries;
        private IRepository<Fraction> fractions;
        private IRepository<HeroRelationship> relationships;
        private IRepository<Power> powers;
        private Func<IUnitOfWork> unitOfWork;

        public SuperheroesDataProvider(
            IRepository<Superhero> superheroes,
            IRepository<City> cities,
            IRepository<Planet> planets,
            IRepository<Country> countries,
            IRepository<Fraction> fractions,
            IRepository<HeroRelationship> relationships,
            IRepository<Power> powers,
            Func<IUnitOfWork> unitOfWork)
        {
            this.Superheroes = superheroes;
            this.Cities = cities;
            this.Planets = planets;
            this.Countries = countries;
            this.Fractions = fractions;
            this.Relationships = relationships;
            this.Powers = powers;
            this.UnitOfWork = unitOfWork;
        }

        public IRepository<Superhero> Superheroes
        {
            get { return this.superheroes; }
            set { this.superheroes = value; }
        }

        public IRepository<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }

        public IRepository<Planet> Planets
        {
            get { return this.planets; }
            set { this.planets = value; }
        }

        public IRepository<Country> Countries
        {
            get { return this.countries; }
            set { this.countries = value; }
        }

        public IRepository<Fraction> Fractions
        {
            get { return this.fractions; }
            set { this.fractions = value; }
        }

        public IRepository<HeroRelationship> Relationships
        {
            get { return this.relationships; }
            set { this.relationships = value; }
        }

        public IRepository<Power> Powers
        {
            get { return this.powers; }
            set { this.powers = value; }
        }

        public Func<IUnitOfWork> UnitOfWork
        {
            get { return this.unitOfWork; }
            set { this.unitOfWork = value; }
        }
    }
}
