using Ninject;
using Ninject.Modules;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Repositories;
using SuperheroesUniverse.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroUniverse.ConsoleClient.NinjectConfig
{
    public class Config : NinjectModule
    {
        public override void Load()
        {
            this.Bind<DbContext>().To<SuperheroesDbContext>().InSingletonScope();
            this.Bind(typeof(IGenericRepository<>)).To(typeof(EfRepository<>));
            this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<UnitOfWork>());
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}
