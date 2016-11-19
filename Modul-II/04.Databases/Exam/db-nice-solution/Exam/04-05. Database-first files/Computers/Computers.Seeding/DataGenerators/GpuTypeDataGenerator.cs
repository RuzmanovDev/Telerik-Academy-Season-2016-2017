namespace Computers.Seeding.DataGenerators
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Contracts;

    using Data;

    public class GpuTypeDataGenerator : IDataGenerator
    {
        public int Order => 0;

        public int Count => 2;

        public void Generate(ComputersEntitiesDb db, IRandomGenerator random)
        {
            if (db.GpuTypes.Count() >= this.Count)
            {
                return;
            }

            db.GpuTypes.AddOrUpdate(new GpuType() { Name = "Internal" });
            db.GpuTypes.AddOrUpdate(new GpuType() { Name = "External" });
            db.SaveChanges();
        }
    }
}
