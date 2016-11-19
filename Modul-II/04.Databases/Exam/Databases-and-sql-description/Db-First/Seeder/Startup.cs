using Seeder.Data;

namespace Seeder
{
    public class Startup
    {
        static void Main()
        {
            var db = new ComputersEntities();

            IRandomProvider randomProvider = new RandomProvider();
            var seeder = new Seeder(randomProvider,db);

            seeder.SeedGPUTypes();
            seeder.SeedComputerTypes();
            seeder.SeedStorageDevisesTypes();

            seeder.SeedGpus();
            seeder.SeedCpus();
            seeder.SeedSorageDevices();

            seeder.SeedComputers();
        }
    }
}
