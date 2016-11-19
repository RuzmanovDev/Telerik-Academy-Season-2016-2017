namespace SuperheroesUniverse.Importer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Data.Common;

    using Dto;

    using Models;
    using Models.Enums;

    using Newtonsoft.Json;

    public class Importer : IImporter
    {
        public void ImportData(ISuperheroesDataProvider db)
        {
            var directory = @"..\..\..\..\02. Json-Data\";
            var files = Directory.GetFiles(directory)
                                 .Where(fileName => fileName.EndsWith(".json"))
                                 .ToList();

            foreach (var file in files)
            {
                var jsonString = File.ReadAllText(file);
                var fileHeroes = JsonConvert.DeserializeObject<SuperheroData>(jsonString);

                using (var unitOfWork = db.UnitOfWork())
                {
                    foreach (var superhero in fileHeroes.Data)
                    {
                        var city = db.Cities.GetAll.FirstOrDefault(c => c.Name == superhero.City.Name);
                        if (city == null)
                        {
                            var country = db.Countries.GetAll.FirstOrDefault(c => c.Name == superhero.City.Country);

                            if (country == null)
                            {
                                var planet = db.Planets.GetAll.FirstOrDefault(p => p.Name == superhero.City.Planet);

                                if (planet == null)
                                {
                                    planet = new Planet()
                                             {
                                                 Name = superhero.City.Planet
                                             };
                                }
                                country = new Country()
                                          {
                                              Name = superhero.City.Country,
                                              Planet = planet
                                          };
                            }

                            city = new SuperheroesUniverse.Models.City()
                                   {
                                       Country = country,
                                       Name = superhero.City.Name
                                   };
                            db.Cities.Add(city);
                            unitOfWork.Commit();
                        }

                        var heroAlignment = (Alignment)Enum.Parse(typeof(Alignment), superhero.Alignment, true);
                        var superheroFractions = new HashSet<Fraction>();

                        if (superhero.Fractions != null)
                        {
                            foreach (var fraction in superhero.Fractions)
                            {
                                var dbFraction = db.Fractions.GetAll.FirstOrDefault(f => f.Name == fraction);
                                if (dbFraction == null)
                                {
                                    dbFraction = new Fraction() { Name = fraction, Alignment = heroAlignment };
                                    db.Fractions.Add(dbFraction);
                                    unitOfWork.Commit();
                                }

                                var fractionPlanet =
                                    dbFraction.Planets.FirstOrDefault(p => p.Name == superhero.City.Planet);

                                if (fractionPlanet == null)
                                {
                                    var planet = db.Planets.GetAll.FirstOrDefault(p => p.Name == superhero.City.Planet);
                                    if (planet == null)
                                    {
                                        planet = new Planet()
                                        {
                                            Name = superhero.City.Planet
                                        };
                                    }
                                    dbFraction.Planets.Add(planet);
                                    unitOfWork.Commit();
                                }
                                superheroFractions.Add(dbFraction);
                            }
                        }

                        var superheroPowers = new HashSet<Power>();
                        if (superhero.Powers != null)
                        {
                            foreach (var power in superhero.Powers)
                            {
                                var dbpower = db.Powers.GetAll.FirstOrDefault(f => f.Name == power);
                                if (dbpower == null)
                                {
                                    dbpower = new Power() { Name = power };
                                    db.Powers.Add(dbpower);
                                    unitOfWork.Commit();
                                }
                                superheroPowers.Add(dbpower);
                            }
                        }

                        var superHeroCity = db.Cities.GetAll.FirstOrDefault(c => c.Name == superhero.City.Name);
                        var heroToDb = new SuperheroesUniverse.Models.Superhero()
                                       {
                                           City = superHeroCity,
                                           CityId = superHeroCity.Id,
                                           Fractions = superheroFractions,
                                           Alignment = heroAlignment,
                                           Name = superhero.Name,
                                           Powers = superheroPowers,
                                           SecretIdentity = superhero.SecretIdentity,
                                           Story = superhero.Story,
                                       };

                        var heroFromDb =
                            db.Superheroes.GetAll.FirstOrDefault(x => x.SecretIdentity == heroToDb.SecretIdentity);
                        if (heroFromDb == null)
                        {
                            db.Superheroes.Add(heroToDb);
                        }
                        else
                        {
                            heroFromDb.Name = heroToDb.Name;
                            heroFromDb.City = heroToDb.City;
                            heroFromDb.Alignment = heroToDb.Alignment;
                            heroFromDb.SecretIdentity = heroToDb.SecretIdentity;
                            heroFromDb.Story = heroToDb.Story;
                        }
                    }

                    unitOfWork.Commit();
                }
            }
        }
    }
}
