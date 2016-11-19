namespace SuperheroesUniverse.Data.Common
{
    using System;

    using Models;

    public interface ISuperheroesDataProvider
    {
        IRepository<Superhero> Superheroes { get; }

        IRepository<City> Cities { get; }

        IRepository<Planet> Planets { get; }

        IRepository<Country> Countries { get; }

        IRepository<Fraction> Fractions { get; }

        IRepository<HeroRelationship> Relationships { get; }

        IRepository<Power> Powers { get; }

        Func<IUnitOfWork> UnitOfWork { get; }
    }
}
