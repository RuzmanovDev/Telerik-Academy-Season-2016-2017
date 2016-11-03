using DbFirstSeed.RandomProvider;
using DbFirstSeed.Data;

namespace DbFirstSeed.Seeders
{
    public class ProjectsSeeder : ISeeder
    {
        private const int ProjectsCount = 1000;

        public ProjectsSeeder(IRandomGenerator random)
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
            db.Configuration.ValidateOnSaveEnabled = false;
            for (int i = 0; i < ProjectsCount; i++)
            {
                var project = new Project()
                {
                    Name = this.RandomGenerator.GetRandomString(5, 50)
                };

                db.Projects.Add(project);
                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    db = new CompanyDbContext();
                    db.Configuration.ValidateOnSaveEnabled = false;

                }

                db.SaveChanges();
            }

            db.SaveChanges();
            db.Dispose();
        }
    }
}
