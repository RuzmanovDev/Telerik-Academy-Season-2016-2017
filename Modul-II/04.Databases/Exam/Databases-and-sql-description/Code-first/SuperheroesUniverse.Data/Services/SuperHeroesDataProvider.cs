using SuperheroesUniverse.Data.Repositories;
using SuperheroesUniverse.Data.UnitOfWork;
using SuperheroesUniverse.Models;
using System;

namespace SuperheroesUniverse.Data.Services
{
    public class SuperHeroesDataProvider
    {
        public SuperHeroesDataProvider(
            IGenericRepository<Superhero> superHeroesRepository,
            IGenericRepository<City> citiesRepository,
            IGenericRepository<Country> countriesRepository,
            IGenericRepository<Fraction> fractionsRepository,
            IGenericRepository<Planet> planetsRepository,
            IGenericRepository<Power> powersRepository,
            Func<IUnitOfWork> unitofWork

            )
        {
            this.SuperHeroesRepository = superHeroesRepository;
            this.CitiesRepository = citiesRepository;
            this.CountriesRepository = countriesRepository;
            this.FractionsRepository = fractionsRepository;
            this.PlanetsRepository = planetsRepository;
            this.PowersRepository = powersRepository;
            this.UnitofWork = unitofWork;
        }

        public IGenericRepository<Superhero> SuperHeroesRepository { get; set; }

        public IGenericRepository<City> CitiesRepository { get; set; }

        public IGenericRepository<Country> CountriesRepository { get; set; }

        public IGenericRepository<Fraction> FractionsRepository { get; set; }

        public IGenericRepository<Planet> PlanetsRepository { get; set; }

        public IGenericRepository<Power> PowersRepository { get; set; }

        public Func<IUnitOfWork> UnitofWork { get; set; }
    }
}
