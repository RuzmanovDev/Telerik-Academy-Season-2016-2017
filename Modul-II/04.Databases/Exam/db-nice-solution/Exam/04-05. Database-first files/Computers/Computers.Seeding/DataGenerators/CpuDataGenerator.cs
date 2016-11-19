using System.Collections.Generic;
using System.Linq;

namespace Computers.Seeding.DataGenerators
{
    using System.Data.Entity.Migrations;

    using Contracts;

    using Data;

    public class CpuDataGenerator : IDataGenerator
    {
        public int Order => 3;

        public int Count => 10;

        public void Generate(ComputersEntitiesDb db, IRandomGenerator random)
        {
            if (db.Cpus.Count() >= this.Count)
            {
                return;
            }

            var cpusToAdd = new HashSet<Cpu>();
            var vendors = db.Vendors.ToList();

            while (cpusToAdd.Count < this.Count)
            {
                var nameLength = random.GetRandomNumber(3, 50);
                var randomString = random.GetRandomString(nameLength);

                var cpu = new Cpu()
                          {
                              Vendor = vendors[random.GetRandomNumber(0, vendors.Count - 1)],
                              Model = randomString,
                              ClockCycles = (float)random.GetRandomNumber(100, 500) / 100,
                              Cores = random.GetRandomNumber(1, 24)
                          };

                cpusToAdd.Add(cpu);
            }

            foreach (var cpu in cpusToAdd)
            {
                db.Cpus.AddOrUpdate(cpu);
            }

            db.SaveChanges();
        }
    }
}
