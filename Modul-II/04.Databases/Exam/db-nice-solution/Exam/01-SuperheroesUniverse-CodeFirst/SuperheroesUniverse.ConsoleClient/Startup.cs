namespace SuperheroesUniverse.ConsoleClient
{
    using System;
    using System.Reflection;

    using Data.Common;

    using Exports;

    using Importer;

    using Ninject;

    public class Startup
    {
        private static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var db = kernel.Get<ISuperheroesDataProvider>();

            var importer = kernel.Get<IImporter>();
            importer.ImportData(db);
            Console.WriteLine("Imported data from JSON.");

            var exporter = kernel.Get<ISuperheroesUniverseExporter>();
            exporter.ExportAllSuperheroes();
            exporter.ExportSuperheroDetails(1);
            exporter.ExportSuperheroesByCity("New York");
            exporter.ExportSupperheroesWithPower("Martial arts");
            exporter.ExportFractions();
            exporter.ExportFractionDetails(1);
            Console.WriteLine("Exported data to XML.");
        }
    }
}
