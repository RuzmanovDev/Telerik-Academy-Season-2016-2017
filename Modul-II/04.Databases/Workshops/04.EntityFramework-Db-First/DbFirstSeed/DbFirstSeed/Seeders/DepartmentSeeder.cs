using DbFirstSeed.RandomProvider;
using DbFirstSeed.Data;

namespace DbFirstSeed.Seeders
{
    public class DepartmentSeeder : ISeeder
    {
        private const int DepartmentsCount = 100;
        public DepartmentSeeder(IRandomGenerator random)
        {
            this.RandomGenerator = random;
        }

        public IRandomGenerator RandomGenerator
        {
            get; private set;
        }

        public void Seed()
        {
            var db = new CompanyDbContext();

            for (int i = 0; i < DepartmentsCount; i++)
            {
                var newDepartment = new Department()
                {
                    Name = this.RandomGenerator.GetRandomString(10, 50)
                };

                db.Departments.Add(newDepartment);
            };

            db.SaveChanges();
        }
    }
}
