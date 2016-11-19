using System.Linq;

namespace Computers.Seeding.DataGenerators
{
    using System.Data.Entity.Migrations;

    using Contracts;

    using Data;

    public class StorageTypeGenerator : IDataGenerator
    {
        public int Order => 0;

        public int Count => 2;

        public void Generate(ComputersEntitiesDb db, IRandomGenerator random)
        {
            if (db.StorageTypes.Count() >= this.Count)
            {
                return;
            }

            db.StorageTypes.AddOrUpdate(new StorageType() { StorageType1 = "HDD" });
            db.StorageTypes.AddOrUpdate(new StorageType() { StorageType1 = "SSD" });
            db.SaveChanges();
        }
    }
}
