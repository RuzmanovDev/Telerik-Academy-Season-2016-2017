using PetStore.Data;
using PetStore.Data.Data;
using PetStore.Data.Repositories;
using System;

namespace PetStore.Importer
{
    public class CountriesImporter : IImporter
    {
        private const int NumberOfCountries = 20;
        private const int CountryNameMinLength = 5;
        private const int CountryNameMaxLength = 50;

        private Func<IPetStoreData> petstoreData;
        private IGenericRepository<Country> countryRepo;
        private IRandomGenerator random;

        public CountriesImporter(Func<IPetStoreData> petstoreData, IGenericRepository<Country> countryRepo, IRandomGenerator random)
        {
            this.petstoreData = petstoreData;
            this.countryRepo = countryRepo;
            this.random = random;
        }

        public void Import()
        {
            using (var petstoreData = this.petstoreData())
            {
                for (int i = 0; i < NumberOfCountries; i++)
                {
                    this.countryRepo.Add(new Country()
                    {
                        Name = random.RandomString(CountryNameMinLength, CountryNameMaxLength)
                    });
                }
                petstoreData.Commit();
            }
        }
    }
}
