namespace Computers.Seeding.DataGenerators
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Contracts;

    using Data;

    public class VendorDataGenerator : IDataGenerator
    {
        public int Order => 0;

        public int Count => 15;

        public void Generate(ComputersEntitiesDb db, IRandomGenerator random)
        {
            if (db.Vendors.Count() >= this.Count)
            {
                return;
            }

            var vendorNames = new HashSet<string>();

            while (vendorNames.Count < this.Count)
            {
                var nameLength = random.GetRandomNumber(3, 50);
                var randomString = random.GetRandomString(nameLength);
                vendorNames.Add(randomString);
            }

            var vendorsToInsert = vendorNames.Select(vendorName => new Vendor() { Name = vendorName });

            foreach (var vendor in vendorsToInsert)
            {
                db.Vendors.AddOrUpdate(vendor);
            }

            db.SaveChanges();
        }
    }
}
