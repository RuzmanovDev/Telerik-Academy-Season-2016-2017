using Ninject;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Migrations;
using SuperheroesUniverse.Data.Services;
using SuperheroUniverse.ConsoleClient.NinjectConfig;
using SuperheroUniverse.ConsoleClient.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroUniverse.ConsoleClient
{
    public class Startup
    {
        static void Main(string[] args)
        {
            // only for db creation
            //var db = new SuperheroesDbContext();
            //db.Database.CreateIfNotExists();
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SuperheroesDbContext, Configuration>());

            var kernel = new StandardKernel(new Config());
            var importer = kernel.Get<Importer>();
            var exporet = kernel.Get<Searcher>();

            //importer.Import();

            // export TO Xml
            var allsUperHeroes = exporet.ExportAllSuperheroes();
            var pathToExportallheroes = @"../../../../03. Xml Files/allheroes.xml";
            File.WriteAllText(pathToExportallheroes, allsUperHeroes);
            Console.WriteLine(allsUperHeroes);

            var allFractions = exporet.ExportFractions();
            var pathToExportallfractions = @"../../../../03. Xml Files/allfractions.xml";
            File.WriteAllText(pathToExportallfractions, allFractions);
            Console.WriteLine(allFractions);

            var fractionDetails = exporet.ExportFractionDetails(1);
            var pathToFractionDetails = @"../../../../03. Xml Files/fractionDetails.xml";
            File.WriteAllText(pathToFractionDetails, fractionDetails);
            Console.WriteLine(fractionDetails);

            var superHeroDetails = exporet.ExportSuperheroDetails(1);
            var pathToSuperHeroDetails = @"../../../../03. Xml Files/superHeroDetails.xml";
            File.WriteAllText(pathToSuperHeroDetails, superHeroDetails);
            Console.WriteLine(superHeroDetails);

            //export superheroes with powers
            var superHeroesWIthPowers = exporet.ExportSupperheroesWithPower("Intelligence");
            var pathToExportShWithPowers = @"../../../../03. Xml Files/superHeroWithSpecificPower.xml";
            File.WriteAllText(pathToExportShWithPowers, superHeroesWIthPowers);
            Console.WriteLine(superHeroesWIthPowers);

            // export superheroes from city
            var superheroesFormCity = exporet.ExportSuperheroesByCity("Gotham");
            var pathToShWithSpecificCity = @"../../../../03. Xml Files/superHeroWithSpecificCity.xml";
            File.WriteAllText(pathToShWithSpecificCity, superheroesFormCity);
            Console.WriteLine(superheroesFormCity);
        }
    }
}
