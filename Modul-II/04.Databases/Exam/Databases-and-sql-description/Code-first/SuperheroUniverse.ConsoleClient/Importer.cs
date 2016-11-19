using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuperheroesUniverse.Data.Services;
using SuperheroesUniverse.Models;
using SuperheroUniverse.ConsoleClient.JsonModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroUniverse.ConsoleClient
{
    public class Importer
    {
        SuperHeroesDataProvider dataProvider;

        public Importer(SuperHeroesDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public void Import()
        {
            var path = @"../../../../02. Json-Data/sample-data.json";

            var fileContetnt = File.ReadAllText(path);
            var jsonText = JObject.Parse(fileContetnt).SelectToken("data").ToString();

            var superheroes = JsonConvert.DeserializeObject<List<SuperheroJson>>(jsonText);

            var alreadyAddedSuperHeroes = new HashSet<SuperheroJson>();
            var alreadyAddedCities = new HashSet<string>();
            var alreadyAddedPowers = new HashSet<string>();
            var alreadyAddedCountries = new HashSet<string>();
            var alreadyAddedPlanets = new HashSet<string>();
            var alreadyAddedFractions = new HashSet<string>();

            foreach (var superHero in superheroes)
            {
                var newHero = new Superhero()
                {
                    Name = superHero.Name,
                    SecretIdentity = superHero.SecretIdentity,
                    Alignment = ParseEnum<AlignmentType>(superHero.Alingment),
                    Story = superHero.Story
                };

                // city
                var city = new City()
                {
                    Name = superHero.City.Name
                };

                // country
                var country = new Country()
                {
                    Name = superHero.City.Country
                };

                // planet
                var planet = new Planet()
                {
                    Name = superHero.City.Planet
                };

                newHero.City = city;
                city.Country = country;
                city.Country.Planet = planet;

                if (!alreadyAddedCities.Contains(city.Name))
                {
                    this.dataProvider.CitiesRepository.AddOrUpdate(city);
                }

                if (!alreadyAddedCountries.Contains(city.Country.Name))
                {
                    this.dataProvider.CountriesRepository.AddOrUpdate(city.Country);
                }

                if (!alreadyAddedPlanets.Contains(city.Country.Planet.Name))
                {
                    this.dataProvider.PlanetsRepository.AddOrUpdate(city.Country.Planet);
                }

                alreadyAddedPlanets.Add(city.Country.Planet.Name);
                alreadyAddedCities.Add(city.Name);
                alreadyAddedCountries.Add(city.Country.Name);

                foreach (var power in superHero.Powers)
                {
                    var newPower = new Power()
                    {
                        Name = power
                    };

                    this.dataProvider.PowersRepository.AddOrUpdate(newPower);
                    newHero.Powers.Add(newPower);
                }

                foreach (var fraction in superHero.Fractions)
                {
                    if (!alreadyAddedFractions.Contains(fraction))
                    {
                        var newFraction = new Fraction()
                        {
                            Name = fraction,
                            Alignment = newHero.Alignment
                        };
                        newFraction.PlanetsUnderProtection.Add(city.Country.Planet);
                        this.dataProvider.FractionsRepository.AddOrUpdate(newFraction);
                        newHero.Fraction.Add(newFraction);
                        alreadyAddedFractions.Add(newFraction.Name);
                    }
                }

                this.dataProvider.SuperHeroesRepository.AddOrUpdate(newHero);
                using (var unitOfWork = this.dataProvider.UnitofWork())
                {
                    unitOfWork.Commit();
                }
                //Console.WriteLine(newHero.Id);
                //Console.WriteLine(newHero.Name);
                //Console.WriteLine(newHero.Name);
                //Console.WriteLine(newHero.Story);
                //Console.WriteLine(newHero.City.Name);
                //Console.WriteLine(newHero.City.Country.Name);
                //Console.WriteLine(newHero.City.Country.Planet.Name);
            }

        }

        private T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
