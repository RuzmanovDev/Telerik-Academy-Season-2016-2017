using PetStore.Data;
using PetStore.Data.Data;
using PetStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Importer
{
    public class ProductsImporter : IImporter
    {
        private Func<IPetStoreData> petstoreData;
        private IGenericRepository<Product> productsRepo;
        private IRandomGenerator random;
        private PetStoreDb dbContext;

        public ProductsImporter(Func<IPetStoreData> petstoreData, IGenericRepository<Product> productsRepo, IRandomGenerator random, PetStoreDb dbContext)
        {
            this.petstoreData = petstoreData;
            this.productsRepo = productsRepo;
            this.random = random;
            this.dbContext = dbContext;
        }
        public void Import()
        {
            using (var petsStoreData = this.petstoreData())
            {
                var categoryIds = this.dbContext.Categories.Select(x => x.Id).ToList();

                for (int i = 0; i < 20000; i++)
                {
                    var product = new Product()
                    {
                        Name = this.random.RandomString(5, 25),
                        Price = this.random.RandomNumber(10, 1000),
                        CategoryId = categoryIds[i % categoryIds.Count]
                    };
                    this.productsRepo.Add(product);

                    if (i % 100 == 0)
                    {
                        petsStoreData.Commit();
                    }
                }
                petsStoreData.Commit();
            }
        }
    }
}
