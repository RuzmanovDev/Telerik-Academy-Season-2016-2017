using System.Collections.Generic;
using System.Linq;

namespace Computers.Seeding.DataGenerators
{
    using System.Data.Entity.Migrations;

    using Contracts;

    using Data;

    public class ComputersGenerator : IDataGenerator
    {
        public int Order => 50;

        public int Count => 50;

        public void Generate(ComputersEntitiesDb db, IRandomGenerator random)
        {
            if (db.Computers.Count() >= this.Count)
            {
                return;
            }

            var computersToAdd = new HashSet<Computer>();
            var vendors = db.Vendors.ToList();
            var cpus = db.Cpus.ToList();
            var storages = db.Storages.ToList();
            var gpus = db.Gpus.ToList();
            var types = db.ComputerTypes.ToList();
            var possibleMemories = new[] { 1, 2, 3, 4, 6, 8, 12, 16, 24, 32, 64, 128 };

            while (computersToAdd.Count < this.Count)
            {
                var nameLength = random.GetRandomNumber(3, 50);
                var randomString = random.GetRandomString(nameLength);
                var numberOfStorages = random.GetRandomNumber(1, 10);
                var numberOfGpus = random.GetRandomNumber(1, 4);
                var computerGpus = new HashSet<Gpu>();
                var computerStorages = new HashSet<Storage>();

                for (int i = 0; i < numberOfGpus; i++)
                {
                    var gpu = gpus[random.GetRandomNumber(0, gpus.Count - 1)];
                    computerGpus.Add(gpu);
                }

                for (int i = 0; i < numberOfStorages; i++)
                {
                    var storage = storages[random.GetRandomNumber(0, storages.Count - 1)];
                    computerStorages.Add(storage);
                }

                var computer = new Computer()
                               {
                                   Vendor = vendors[random.GetRandomNumber(0, vendors.Count - 1)],
                                   Cpu = cpus[random.GetRandomNumber(0, cpus.Count - 1)],
                                   Model = randomString,
                                   Storages = computerStorages,
                                   Gpus = computerGpus,
                                   Memory = possibleMemories[random.GetRandomNumber(0, possibleMemories.Length - 1)],
                                   ComputerType = types[random.GetRandomNumber(0, 2)]
                               };

                computersToAdd.Add(computer);
            }

            foreach (var computer in computersToAdd)
            {
                db.Computers.AddOrUpdate(computer);
            }

            db.SaveChanges();
        }
    }
}
