using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seed
{
    public class Startup
    {
        static void Main(string[] args)
        {
            IRandomProvider randomProvider = new RandomProvider();
            var seeder = new Seeder(randomProvider);
            //seeder.SeedDepartements();
            //seeder.SeedEmployees();
            seeder.SeedReports();
            //seeder.SeedProjects();
            //seeder.SeedProjectEmployees();
        }

    }
}
