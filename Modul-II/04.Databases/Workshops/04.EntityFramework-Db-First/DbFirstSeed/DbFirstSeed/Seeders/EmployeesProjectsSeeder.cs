using System;
using DbFirstSeed.RandomProvider;

namespace DbFirstSeed.Seeders
{
    public class EmployeesProjectsSeeder : ISeeder
    {
        public EmployeesProjectsSeeder(IRandomGenerator random)
        {
            this.RandomGenerator = random;
        }
        public IRandomGenerator RandomGenerator
        {
            get; private set;
        }

        public void Seed()
        {
            throw new NotImplementedException();
        }
    }
}
