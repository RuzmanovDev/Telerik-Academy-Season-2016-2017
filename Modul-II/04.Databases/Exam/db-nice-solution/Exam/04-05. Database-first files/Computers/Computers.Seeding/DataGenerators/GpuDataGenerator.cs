namespace Computers.Seeding.DataGenerators
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Contracts;

    using Data;

    public class GpuDataGenerator : IDataGenerator
    {
        public int Order => 2;

        public int Count => 15;

        public void Generate(ComputersEntitiesDb db, IRandomGenerator random)
        {
            if (db.Gpus.Count() >= this.Count)
            {
                return;
            }

            var possibleMemories = new[] { 1, 2, 3, 4, 8, 12, 24 };
            var gpusToAdd = new HashSet<Gpu>();

            var gpuTypes = db.GpuTypes.ToList();
            var vendors = db.Vendors.ToList();

            while (gpusToAdd.Count < this.Count)
            {
                var randomNumber = random.GetRandomNumber(0, 100);
                GpuType gpuType = null;

                if (randomNumber < 33)
                {
                    gpuType = gpuTypes[0];
                }
                else
                {
                    gpuType = gpuTypes[1];
                }
                var nameLength = random.GetRandomNumber(3, 50);
                var randomString = random.GetRandomString(nameLength);

                var gpu = new Gpu()
                          {
                              Vendor = vendors[random.GetRandomNumber(0, vendors.Count - 1)],
                              Model = randomString,
                              GpuType = gpuType,
                              Memory = possibleMemories[random.GetRandomNumber(0, possibleMemories.Length - 1)],
                          };

                gpusToAdd.Add(gpu);
            }

            foreach (var gpu in gpusToAdd)
            {
                db.Gpus.AddOrUpdate(gpu);
            }

            db.SaveChanges();
        }
    }
}
