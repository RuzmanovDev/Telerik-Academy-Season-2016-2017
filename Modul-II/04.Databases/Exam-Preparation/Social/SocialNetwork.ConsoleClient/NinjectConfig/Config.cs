using Ninject;
using Ninject.Modules;
using SocialNetwork.Data;
using SocialNetwork.Data.Repositories;
using SocialNetwork.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.ConsoleClient.NinjectConfig
{
    public class Config : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<SocialDbContext>().InSingletonScope();
            this.Bind(typeof(IGenericRepository<>)).To(typeof(EfRepository<>));
            this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<UnitOfWork>());
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            this.Bind<DataProvider>().To<DataProvider>();

        }
    }
}
