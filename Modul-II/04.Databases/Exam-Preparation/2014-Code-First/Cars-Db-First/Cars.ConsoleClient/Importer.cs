using Cars.ConsoleClient.Models;
using Cars.Data;
using Cars.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Text;
using System.Threading.Tasks;
using Cars.Data.Migrations;
using System.Data.Entity.Validation;

namespace Cars.ConsoleClient
{
    public class Importer
    {
        public void ImportCars()
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());

            var manufacturerNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var cityNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var dealerNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < 1; i++)
            {
                var path = $"../../Data.Json.Files/data.{i}.json";
                var fileContetn = File.ReadAllText(path);
                var jsonsCars = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CarJsonModel>>(fileContetn);

                foreach (var car in jsonsCars)
                {
                    cityNames.Add(car.Dealer.City);
                    manufacturerNames.Add(car.ManufacturerName);
                    dealerNames.Add(car.Dealer.Name);
                }

                var db = new CarsDbContext();

                Console.WriteLine("Adding Cities");
                foreach (var city in cityNames)
                {
                    var newCity = new City() { Name = city };

                    db.Cities.AddOrUpdate(c => c.Name, newCity);
                    Console.Write(".");
                }

                db.SaveChanges();

                Console.WriteLine("Adding Manufacturers");
                db = new CarsDbContext();
                foreach (var manufName in manufacturerNames)
                {
                    var newManyfacturer = new Manufacturer() { Name = manufName };
                    db.Manufacturers.AddOrUpdate(m => m.Name, newManyfacturer);
                    Console.Write(".");
                }

                db.SaveChanges();

                Console.WriteLine("Adding Delaers");
                db = new CarsDbContext();
                foreach (var dealerName in dealerNames)
                {
                    var newDealer = new Dealer() { Name = dealerName };
                    db.Dealers.AddOrUpdate(d => d.Name, newDealer);
                    Console.Write(".");
                }

                db.SaveChanges();

                Console.WriteLine("Adding cars");
                db = new CarsDbContext();

                foreach (var car in jsonsCars)
                {

                    var databaseCarCity = db.Cities.FirstOrDefault(x => x.Name == car.Dealer.City);

                    if (databaseCarCity == null)
                    {
                        throw new ArgumentException("Invalid city name!");
                    }

                    var newCar = new Car()
                    {
                        Dealer = db.Dealers.FirstOrDefault(x => x.Name == car.Dealer.Name),
                        Manufacturer = db.Manufacturers.FirstOrDefault(x => x.Name == car.ManufacturerName),
                        Model = car.Model,
                        Price = car.Price,
                        Transmition = car.TransmitionType,
                        Year = car.Year
                    };

                    //db.Configuration.AutoDetectChangesEnabled = true;
                    if (!newCar.Dealer.Cities.Any(c => c.Name == databaseCarCity.Name))
                    {
                        databaseCarCity.Dealers.Add(newCar.Dealer);
                    }

                    db.Cars.Add(newCar);
                    Console.Write(".");
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {

                    }

                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                }

                db.SaveChanges();
            }
        }
    }
}
