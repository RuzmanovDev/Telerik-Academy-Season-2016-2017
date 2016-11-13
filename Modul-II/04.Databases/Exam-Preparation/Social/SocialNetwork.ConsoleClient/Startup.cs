using Ninject;
using SocialNetwork.ConsoleClient.Importers;
using SocialNetwork.ConsoleClient.NinjectConfig;
using SocialNetwork.Data;
using SocialNetwork.Data.Repositories;
using SocialNetwork.Data.UnitOfWorks;
using SocialNetwork.Models;

namespace SocialNetwork.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel(new Config());

            var importer = kernel.Get<Importer>();

            importer.Import();

        }
    }
}
