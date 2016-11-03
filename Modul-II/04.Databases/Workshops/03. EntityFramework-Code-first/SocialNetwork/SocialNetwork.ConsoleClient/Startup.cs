namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Searcher;
    using Data;
    using System.Data.Entity.Validation;
    using Data.Migrations;
    using SocialNetwork.Models.Models;

    public class Startup
    {
        public static void Main()
        {
            //try
            //{
            //    var dbContex = new SocialDbContext();
            //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialDbContext, Configuration>());

            //    dbContex.Posts.Add(new Post()
            //    {
            //        PostedOn = DateTime.Now,
            //        Content = "Sdasdasddsadas"
            //    });

            //    dbContex.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{

            //}

            //Importer.Create(Console.Out).Import();

            ISocialNetworkService searcher = new SocialNetworkService();
            DataSearcher.Search(searcher);
        }
    }
}
