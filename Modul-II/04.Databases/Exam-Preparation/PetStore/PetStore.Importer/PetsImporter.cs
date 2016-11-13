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
    public class PetsImporter : IImporter
    {
        private const int NumberOfPets = 500;

        private Func<IPetStoreData> petstoreData;
        private IGenericRepository<Pet> petsRepo;
        private IRandomGenerator random;
        private PetStoreDb dbContext;

        public PetsImporter(Func<IPetStoreData> petstoreData, IGenericRepository<Pet> petsRepo, IRandomGenerator random, PetStoreDb dbContext)
        {
            this.petstoreData = petstoreData;
            this.petsRepo = petsRepo;
            this.random = random;
            this.dbContext = dbContext;
        }
        public void Import()
        {
            using (var petsData = this.petstoreData())
            {
                int speciesIndex = 0;
                var allSpeciesIds = this.dbContext.Species.Select(x => x.Id).ToList();
                dbContext.Configuration.AutoDetectChangesEnabled = false;
                dbContext.Configuration.ValidateOnSaveEnabled = false;
                for (int i = 0; i < NumberOfPets; i++)
                {
                    var newPet = new Pet()
                    {
                        Price = this.random.RandomNumber(5, 2500),
                        ColorId = this.random.RandomNumber(1, 4),
                        TimeOfBirth = this.random.RandomDateTime(new DateTime(2010, 1, 1), new DateTime(2016, 1, 1)),
                        Breed = this.random.RandomString(5, 30),
                        SpeciesId = allSpeciesIds[speciesIndex]
                    };

                    if(i%50 == 0)
                    {
                        speciesIndex++;
                        if (speciesIndex>= allSpeciesIds.Count)
                        {
                            speciesIndex = 0;
                        }
                    }
                    petsRepo.Add(newPet);
                }
                petsData.Commit();
            }
        }
    }
}
