using Cars.Data;
using Cars.Data.Migrations;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.ConsoleClient
{
    class Startup
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
            var db = new CarsDbContext();
            //db.Database.CreateIfNotExists();

            var importer = new Importer();

            importer.ImportCars();
        }
    }
}
