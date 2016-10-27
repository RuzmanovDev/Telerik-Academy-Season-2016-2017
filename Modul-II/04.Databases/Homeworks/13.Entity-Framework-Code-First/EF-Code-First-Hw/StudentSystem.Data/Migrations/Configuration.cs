namespace StudentSystem.Data.Migrations
{
    using Models.Models;
    using System;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            context.Students.AddOrUpdate(new Student()
            {
                Name = "Gosho",
                Number = "12323",
            });

            context.Homeworks.AddOrUpdate(new Homework()
            {
                Content = "WTF is this going to work",
                TimeSent = DateTime.Now
            });

            context.Courses.AddOrUpdate(new Course()
            {
                Name = "Data bases",
                Description = "Learn Db",
            });
        }
    }
}
