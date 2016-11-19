using SuperheroesUniverse.Data.Services;
using SuperheroesUniverse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SuperheroUniverse.ConsoleClient.Queries
{
    public class Searcher : ISuperheroesUniverseExporter
    {
        SuperHeroesDataProvider dataProvider;

        public Searcher(SuperHeroesDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public string ExportAllSuperheroes()
        {
            var allHeroes = dataProvider.SuperHeroesRepository.GetAll().ToList();
            var superHeroes = new XElement("superheroes");
            foreach (var hero in allHeroes)
            {
                superHeroes.Add(
               new XElement("superhero", new XAttribute("id", hero.Id)),
                new XElement("name", hero.Name),
                new XElement("secretIdentity", hero.SecretIdentity),
                new XElement("alignment", hero.Alignment),
                new XElement("powers",
                hero.Powers.Select(p =>
                    new XElement("power", p.Name))),
                new XElement("City", hero.City.Name + ", ", hero.City.Country.Name + ", ", hero.City.Country.Planet.Name));
            }

            return superHeroes.ToString();
        }

        public string ExportFractionDetails(object fractionId)
        {
            var fractionById = this.dataProvider.FractionsRepository.GetAll<Fraction>(f => f.Id == (int)fractionId, null).FirstOrDefault();
            var fraction = new XElement("fraction", new XAttribute("id", fractionById.Id), new XAttribute("membersCount", fractionById.Members.Count),
                new XElement("name", fractionById.Name),
                new XElement("planets", fractionById.PlanetsUnderProtection.Select(p =>
                    new XElement("planet", p.Name))),
                new XElement("members", fractionById.Members.Select(m =>
                    new XElement("member", new XAttribute("id", m.Id), m.Name))));

            return fraction.ToString();
        }

        public string ExportFractions()
        {
            var allFractions = dataProvider.FractionsRepository.GetAll().ToList();
            var allFractionsXml = new XElement("fractions");

            foreach (var fr in allFractions)
            {
                allFractionsXml.Add(
                    new XElement("fraction", new XAttribute("id", fr.Id), new XAttribute("members", fr.Members.Count)),
                    new XElement("name", fr.Name),
                    new XElement("planets", fr.PlanetsUnderProtection.Select(p =>
                        new XElement("planet", p.Name)))
                    );
            }
            return allFractionsXml.ToString();
        }

        public string ExportSuperheroDetails(object superheroId)
        {
            var sh = this.dataProvider.SuperHeroesRepository.GetById(superheroId);
            var superHeroXml = new XElement("superhero", new XAttribute("id", sh.Id),
                new XElement("name", sh.Name),
                new XElement("secretIdentity", sh.SecretIdentity),
                new XElement("alignment", sh.Alignment),
                new XElement("powers", sh.Powers.Select(p =>
                    new XElement("power", p.Name))));

            return superHeroXml.ToString();
        }

        public string ExportSuperheroesByCity(string cityName)
        {
            var heroes = this.dataProvider.SuperHeroesRepository.GetAll<Superhero>(h => h.City.Name == cityName, null).ToList();

            var superHeroes = new XElement("superheroes");
            foreach (var hero in heroes)
            {
                superHeroes.Add(
               new XElement("superhero", new XAttribute("id", hero.Id)),
                new XElement("name", hero.Name),
                new XElement("secretIdentity", hero.SecretIdentity),
                new XElement("alignment", hero.Alignment),
                new XElement("powers",
                hero.Powers.Select(p =>
                    new XElement("power", p.Name))),
                new XElement("City", hero.City.Name + ", ", hero.City.Country.Name + ", ", hero.City.Country.Planet.Name));
            }

            return superHeroes.ToString();
        }

        public string ExportSupperheroesWithPower(string power)
        {
            var heroesWithPowers = this.dataProvider.SuperHeroesRepository.GetAll<Superhero>(s => s.Powers.Count > 0, null).ToList();

            var superHeroes = new XElement("superheroes");
            foreach (var hero in heroesWithPowers)
            {
                superHeroes.Add(
               new XElement("superhero", new XAttribute("id", hero.Id)),
                new XElement("name", hero.Name),
                new XElement("secretIdentity", hero.SecretIdentity),
                new XElement("alignment", hero.Alignment),
                new XElement("powers",
                hero.Powers.Select(p =>
                    new XElement("power", p.Name))),
                new XElement("City", hero.City.Name + ", ", hero.City.Country.Name + ", ", hero.City.Country.Planet.Name));
            }
            return superHeroes.ToString();
        }
    }
}
