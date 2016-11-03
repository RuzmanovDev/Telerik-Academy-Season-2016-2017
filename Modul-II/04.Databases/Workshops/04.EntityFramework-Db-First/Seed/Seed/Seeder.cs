using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed
{
    public class Seeder
    {
        private const int DepartementsCount = 100;
        private const int DepartementNameMinLength = 10;
        private const int DepartementNameMaxLength = 50;

        private const int EmployeeNameMinLength = 5;
        private const int EmployeenameMaxLength = 20;
        private const int EmployeesCount = 5000;

        private CompanyEntities11 dbContext;
        private readonly IRandomProvider randomProvider;

        public Seeder(IRandomProvider randomProvider)
        {
            this.dbContext = new CompanyEntities11();
            this.randomProvider = randomProvider;
        }

        public void SeedReports()
        {
            var employeeIds = dbContext.Employees.Select(e => e.Id).ToList();

            for (int i = 0; i < 250000; i++)
            {
                var report = new Report()
                {
                    GotToWorkAt = randomProvider.getRandomDate(),
                    EmployeeId = randomProvider.GetRandomNumber(1, EmployeesCount)
                };

                dbContext.Reports.Add(report);

                if (i % 100 == 0)
                {
                    dbContext.SaveChanges();
                    dbContext = new CompanyEntities11();
                }
            }

            dbContext.SaveChanges();
        }

        public void SeedProjectEmployees()
        {
            for (int i = 0; i < 2000; i++)
            {

            }
        }

        public void SeedProjects()
        {
            for (int i = 0; i < 1000; i++)
            {
                var project = new Projectss()
                {
                    Name = randomProvider.GetRandomString(5, 50)
                };

                dbContext.Projectsses.Add(project);

                if (i % 100 == 0)
                {
                    dbContext.SaveChanges();
                    dbContext = new CompanyEntities11();
                }
            }

            dbContext.SaveChanges();
        }

        public void SeedEmployees()
        {
            var allAddedEmployees = new List<Employee>();

            dbContext.Configuration.AutoDetectChangesEnabled = false;
            dbContext.Configuration.ValidateOnSaveEnabled = false;

            for (int i = 0; i < EmployeesCount; i++)
            {
                var managerIsNull = false;

                if (i % 20 == 0 || i == 0)
                {
                    managerIsNull = true;
                }


                var employee = new Employee()
                {
                    FirstName = randomProvider.GetRandomString(EmployeeNameMinLength, EmployeenameMaxLength),
                    LastName = randomProvider.GetRandomString(EmployeeNameMinLength, EmployeenameMaxLength),
                    DepartementID = randomProvider.GetRandomNumber(1, DepartementsCount),
                    YearSalary = randomProvider.GetRandomNumber(50000, 200000),
                };

                if (allAddedEmployees.Count > 0 && randomProvider.GetRandomNumber(1, 100) <= 95)
                {
                    employee.Employee2 = allAddedEmployees[randomProvider.GetRandomNumber(0, allAddedEmployees.Count - 1)];
                }

                allAddedEmployees.Add(employee);
                dbContext.Employees.Add(employee);


                if (i % 100 == 0)
                {
                    dbContext.SaveChanges();
                    dbContext = new CompanyEntities11();
                    dbContext.Configuration.AutoDetectChangesEnabled = false;
                    dbContext.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            dbContext.Configuration.AutoDetectChangesEnabled = true;
            dbContext.Configuration.ValidateOnSaveEnabled = true;
        }

        public void SeedDepartements()
        {
            for (int i = 0; i < DepartementsCount; i++)
            {
                var departament = new Departement()
                {
                    Name = randomProvider.GetRandomString(DepartementNameMinLength, DepartementNameMaxLength)
                };

                dbContext.Departements.Add(departament);
                dbContext.SaveChanges();
            }
        }
    }
}