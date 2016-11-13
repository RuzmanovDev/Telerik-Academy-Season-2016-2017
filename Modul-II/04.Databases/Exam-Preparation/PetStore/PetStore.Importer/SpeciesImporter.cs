using PetStore.Data;
using PetStore.Data.Data;
using PetStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Importer
{
    public class SpeciesImporter : IImporter
    {
        private const int NumberOfSpecies = 20;
        private const int SpecieNameMinLength = 5;
        private const int SpecieNameMaxLength = 50;

        private Func<IPetStoreData> petstoreData;
        private IGenericRepository<Species> speciesRepo;
        private IRandomGenerator random;
        private PetStoreDb dbContext;

        public SpeciesImporter(Func<IPetStoreData> petstoreData, IGenericRepository<Species> speciesRepo, IRandomGenerator random, PetStoreDb dbContext)
        {
            this.petstoreData = petstoreData;
            this.speciesRepo = speciesRepo;
            this.random = random;
            this.dbContext = dbContext;
        }

        public void Import()
        {
            using (var petstoreData = this.petstoreData())
            {
                var allCountryIds = dbContext.Countries.Select(c => c.Id).ToList();

                var index = 0;
                for (int i = 0; i < NumberOfSpecies; i++)
                {
                    this.speciesRepo.Add(new Species()
                    {
                        Name = random.RandomString(SpecieNameMinLength, SpecieNameMaxLength),
                        OriginCountryId = allCountryIds[index]
                    });

                    if (i % 5 == 0)
                    {
                        index++;
                        if (index >= allCountryIds.Count)
                        {
                            index = 0;
                        }
                    }
                }
                petstoreData.Commit();
            }
        }
    }
}
