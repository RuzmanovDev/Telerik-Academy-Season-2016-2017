using PetStore.Data;
using PetStore.Data.Data;
using PetStore.Data.Repositories;
using System;

namespace PetStore.Importer
{
    public class CategoriesImporter : IImporter
    {
        private Func<IPetStoreData> petstoreData;
        private IGenericRepository<Category> categoryRepo;
        private IRandomGenerator random;

        public CategoriesImporter(Func<IPetStoreData> petstoreData, IGenericRepository<Category> categoryRepo, IRandomGenerator random)
        {
            this.petstoreData = petstoreData;
            this.categoryRepo = categoryRepo;
            this.random = random;
        }

        public void Import()
        {
            using (var petstoreData = this.petstoreData())
            {
                for (int i = 0; i < 50; i++)
                {
                    var category = new Category()
                    {
                        Name = this.random.RandomString(5, 20)
                    };

                    this.categoryRepo.Add(category);
                }

                petstoreData.Commit();
            }
        }
    }
}
