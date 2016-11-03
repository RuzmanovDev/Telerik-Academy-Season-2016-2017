using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbFirstSeed.RandomProvider;
using DbFirstSeed.Seeders;

namespace DbFirstSeed
{
    public class Program
    {
        static void Main(string[] args)
        {
            var random = new RandomGenerator();
            var departmentSeeder = new DepartmentSeeder(random);
            var projectsSeeder = new ProjectsSeeder(random);
            var employeesSeder = new EmployeesSeeder(random);
            var reportSeeder = new ReportsSeeder(random);

            departmentSeeder.Seed();
            projectsSeeder.Seed();
            employeesSeder.Seed();
            reportSeeder.Seed();
        }
    }
}
