using Ninject;
using Ninject.Modules;
using PetStore.Data;
using PetStore.Data.Data;
using PetStore.Data.Repositories;
using PetStore.Importer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.ConsoleClient
{
    public class PetStoreModule : NinjectModule
    {
        public override void Load()
        {

            //var dbContext = new PetStoreDb();
            this.Bind<DbContext>().To<PetStoreDb>().InSingletonScope();
            this.Bind<PetStoreDb>().To<PetStoreDb>().InSingletonScope();

            this.Bind<Func<IPetStoreData>>().ToMethod(ctx => () => ctx.Kernel.Get<PetStoreData>());
            //var petStoreData = new PetStoreData(dbContext);

            //var countriesRepo = new PetsDbRepository<Country>(dbContext);
            this.Bind(typeof(IGenericRepository<>)).To(typeof(PetsDbRepository<>));

            //var randomProvider = new RandomGenerator();
            this.Bind<IRandomGenerator>().To<RandomGenerator>();

            //var countryImporter = new CountriesImporter(petStoreData, countriesRepo, randomProvider);
            this.Bind<IImporter>().To<CountriesImporter>().Named("CountriesImporter");
            this.Bind<IImporter>().To<SpeciesImporter>().Named("SpeciesImporter");
            this.Bind<IImporter>().To<PetsImporter>().Named("PetsImporter");
            this.Bind<IImporter>().To<CategoriesImporter>().Named("CategoriesImporter");
            this.Bind<IImporter>().To<ProductsImporter>().Named("ProductsImporter");
        }
    }
}
