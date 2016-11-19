using System.Collections.Generic;
using System.Linq;

namespace Computers.Seeding.DataGenerators
{
    using System.Data.Entity.Migrations;

    using Contracts;

    using Data;

    public class StorageDeviceGenerator : IDataGenerator
    {
        public int Order => 1;

        public int Count => 30;

        public void Generate(ComputersEntitiesDb db, IRandomGenerator random)
        {
            if (db.Storages.Count() >= this.Count)
            {
                return;
            }

            var capacities = new[] { 256, 512, 1024, 2048, 4096 };

            var storageDevices = new HashSet<Storage>();
            var storageTypes = db.StorageTypes.ToList();

            while (storageDevices.Count < this.Count)
            {
                var storageIndex = random.GetRandomNumber(0, 100);
                StorageType type = null;

                if (storageIndex < 25)
                {
                    type = storageTypes[1];
                }
                else
                {
                    type = storageTypes[0];
                }

                var device = new Storage()
                             {
                                 StorageType = type,
                                 Capacity = capacities[random.GetRandomNumber(0, capacities.Length - 1)],
                             };

                storageDevices.Add(device);

                db.Storages.AddOrUpdate(device);
            }

            db.SaveChanges();
        }
    }
}
