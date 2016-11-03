using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbFirstSeed.RandomProvider;
using DbFirstSeed.Data;

namespace DbFirstSeed.Seeders
{
    public class ReportsSeeder : ISeeder
    {
        private const int ReportsCount = 250000;
        public ReportsSeeder(IRandomGenerator random)
        {
            this.RandomGenerator = random;
        }
        public IRandomGenerator RandomGenerator
        {
            get; set;
        }

        public void Seed()
        {
            var db = new CompanyDbContext();
            var employeeIds = db.Employees.Select(e => e.Id).ToList();

            for (int i = 0; i < ReportsCount; i++)
            {
                var report = new Report()
                {
                    EmployeeId = employeeIds[this.RandomGenerator.GetRandomInt(0, employeeIds.Count)],
                    TimeOfReport = DateTime.Now.AddDays(this.RandomGenerator.GetRandomInt(0, 100))
                };

                db.Reports.Add(report);

                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    db = new CompanyDbContext();
                }

                db.SaveChanges();
            }
        }
    }
}
