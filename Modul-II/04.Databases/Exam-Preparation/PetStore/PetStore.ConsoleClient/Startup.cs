namespace PetStore.ConsoleClient
{
    using Importer;
    using Data;
    using System;
    using Data.Data;
    using Data.Repositories;
    using Ninject;

    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel(new PetStoreModule());

            var countryImporter = kernel.Get<CountriesImporter>();
            var speciesImporter = kernel.Get<SpeciesImporter>();
            var petsImporter = kernel.Get<PetsImporter>();
            var categorieImporter = kernel.Get<CategoriesImporter>();
            var productImporter = kernel.Get<ProductsImporter>();

            // CountriesImport
            countryImporter.Import();
            speciesImporter.Import();
            petsImporter.Import();
            categorieImporter.Import();
            productImporter.Import();

        }
    }
}
