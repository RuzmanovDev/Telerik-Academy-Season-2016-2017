namespace Computers.Seeding.DataGenerators
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Contracts;

    using Data;

    public class ComputerTypeGenerator : IDataGenerator
    {
        public int Order => 0;

        public int Count => 3;

        public void Generate(ComputersEntitiesDb db, IRandomGenerator random)
        {
            if (db.ComputerTypes.Count() >= this.Count)
            {
                return;
            }

            db.ComputerTypes.AddOrUpdate(new ComputerType() { Type = "Notebook" });
            db.ComputerTypes.AddOrUpdate(new ComputerType() { Type = "Desktop" });
            db.ComputerTypes.AddOrUpdate(new ComputerType() { Type = "Ultrabook" });
            db.SaveChanges();
        }
    }
}
