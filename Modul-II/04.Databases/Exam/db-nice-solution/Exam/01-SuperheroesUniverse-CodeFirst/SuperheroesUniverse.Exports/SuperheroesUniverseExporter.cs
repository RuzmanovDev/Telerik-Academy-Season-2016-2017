namespace SuperheroesUniverse.Exports
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    using Data.Common;

    using Dtos;

    public class SuperheroesUniverseExporter : ISuperheroesUniverseExporter
    {
        private const string DirectoryPath = @"..\..\..\..\03. Xml Files\";
        private ISuperheroesDataProvider db;

        public SuperheroesUniverseExporter(ISuperheroesDataProvider db)
        {
            if (db == null)
            {
                throw new ArgumentNullException();
            }

            this.db = db;
        }

        public string ExportAllSuperheroes()
        {
            var heroes = this.db.Superheroes.GetAll.ToList();
            var serializable = heroes.Select(hero => new SuperheroDto()
                                                     {
                                                         Name = hero.Name,
                                                         City = hero.City.Name,
                                                         Alignment = hero.Alignment.ToString(),
                                                         Id = hero.Id,
                                                         SecretIdentity = hero.SecretIdentity,
                                                         Powers = hero.Powers.Select(p => p.Name).ToArray()
                                                     });
            var container = new SuperheroesCollection { Superheroes = serializable.ToArray() };
            var result = this.Serialize(container, "AllSuperheroes-Export.xml");

            return result;
        }

        public string ExportSupperheroesWithPower(string power)
        {
            var safePowerName = power.Replace(' ', '-');
            var heroes = this.db.Superheroes.GetAll.Where(h => h.Powers.Any(p => p.Name == power)).ToList();
            var serializable = heroes.Select(hero => new SuperheroDto()
                                                     {
                                                         Name = hero.Name,
                                                         City = hero.City.Name,
                                                         Alignment = hero.Alignment.ToString(),
                                                         Id = hero.Id,
                                                         SecretIdentity = hero.SecretIdentity,
                                                         Powers = hero.Powers.Select(p => p.Name).ToArray()
                                                     });
            var container = new SuperheroesCollection { Superheroes = serializable.ToArray() };

            var result = this.Serialize(container, $"HeroesWithPower{safePowerName}-Export.xml");

            return result;
        }

        public string ExportSuperheroDetails(object superheroId)
        {
            var hero = this.db.Superheroes.GetById(superheroId);
            var dto = new SuperheroDto()
                      {
                          Name = hero.Name,
                          City = hero.City.Name,
                          Alignment = hero.Alignment.ToString(),
                          Id = hero.Id,
                          SecretIdentity = hero.SecretIdentity,
                          Powers = hero.Powers.Select(p => p.Name).ToArray()
                      };
            var container = new SuperheroesCollection { Superheroes = new[] { dto } };

            var result = this.Serialize(container, $"HeroWithId{(int)superheroId}-Export.xml");

            return result;
        }

        public string ExportSuperheroesByCity(string cityName)
        {
            var safeFileCityName = cityName.Replace(' ', '-');
            var heroes = this.db.Superheroes.GetAll.Where(h => h.City.Name == cityName).ToList();
            var serializable = heroes.Select(hero => new SuperheroDto()
                                                     {
                                                         Name = hero.Name,
                                                         City = hero.City.Name,
                                                         Alignment = hero.Alignment.ToString(),
                                                         Id = hero.Id,
                                                         SecretIdentity = hero.SecretIdentity,
                                                         Powers = hero.Powers.Select(p => p.Name).ToArray()
                                                     });
            var container = new SuperheroesCollection { Superheroes = serializable.ToArray() };

            var result = this.Serialize(container, $"HeroesFrom-{safeFileCityName}-Export.xml");

            return result;
        }

        public string ExportFractions()
        {
            var fractions = this.db.Fractions.GetAll.ToList();
            var dtos = fractions.Select(f => new FractionDto()
                                             {
                                                 Id = f.Id,
                                                 Planets = f.Planets.Select(p => p.Name).ToArray(),
                                                 MembersCount = f.Superheroes.Count,
                                                 Name = f.Name
                                             })
                                .ToArray();

            var container = new FractionContainer { Fractions = dtos };

            var result = this.Serialize(container, "AllFractions-Export.xml");
            return result;
        }

        public string ExportFractionDetails(object fractionId)
        {
            var fraction = this.db.Fractions.GetById(fractionId);
            var dtos = new FractionDto()
                       {
                           Id = fraction.Id,
                           Planets = fraction.Planets.Select(p => p.Name).ToArray(),
                           MembersCount = fraction.Superheroes.Count,
                           Name = fraction.Name
                       };

            var container = new FractionContainer();
            container.Fractions = new[] { dtos };

            var result = this.Serialize(container, $"FractionsForId-{(int)fractionId}-Export.xml");
            return result;
        }

        private string Serialize<T>(T fractions, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            var fileStream = new FileStream(DirectoryPath + fileName,
                                            FileMode.Create,
                                            FileAccess.Write, FileShare.Read);
            xmlSerializer.Serialize(fileStream, fractions);
            fileStream.Close();

            var result = File.ReadAllText(DirectoryPath + fileName);

            return result;
        }
    }
}
