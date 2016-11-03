using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbFirstSeed.RandomProvider;
using DbFirstSeed.Data;

namespace DbFirstSeed.Seeders
{
    public class EmployeesSeeder : ISeeder
    {
        private const int EmployeesCount = 5000;

        public EmployeesSeeder(IRandomGenerator random)
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
            var departmentsId = db.Departments.Select(d => d.Id).ToList();
            var procent = (EmployeesCount * 5) / 100;
            var alreadyAddedEmployees = new List<Employee>();

            for (int i = 0; i < EmployeesCount; i++)
            {

                int? managerId = null;

                if(i > procent)
                {
                    var randomManagerId = alreadyAddedEmployees[this.RandomGenerator.GetRandomInt(0, alreadyAddedEmployees.Count - 1)].Id;
                    managerId = randomManagerId;
                }
                var employee = new Employee()
                {
                    FirstName = this.RandomGenerator.GetRandomString(5, 20),
                    LastName = this.RandomGenerator.GetRandomString(5, 20),
                    DepartmentId = departmentsId[this.RandomGenerator.GetRandomInt(0, departmentsId.Count())],
                    Salary = this.RandomGenerator.GetRandomInt(50000, 200000),
                    ManagerId = managerId,

                };

                alreadyAddedEmployees.Add(employee);
                db.Employees.Add(employee);
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
