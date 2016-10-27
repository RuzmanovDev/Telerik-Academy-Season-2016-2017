using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using StudentSystem.Models.Models;
using System.Data.Entity;

namespace StudentSystem.ConsoleClient
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());

            var db = new StudentSystemDbContext();

            var student = new Student()
            {
                Name = "Petar",
                Number = "111111"
            };

            db.Students.Add(student);

            db.SaveChanges();
        }
    }
}
