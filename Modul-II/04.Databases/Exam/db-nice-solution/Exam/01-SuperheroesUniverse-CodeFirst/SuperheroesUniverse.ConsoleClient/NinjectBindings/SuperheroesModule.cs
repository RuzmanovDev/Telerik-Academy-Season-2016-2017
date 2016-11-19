namespace SuperheroesUniverse.ConsoleClient.NinjectBindings
{
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Reflection;

    using Data;
    using Data.Common;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Modules;
    public  class SuperheroesModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                 .SelectAllClasses()
                 .BindDefaultInterface();
            });

            this.Bind<DbContext>().To<SuperheroesUniverseDbContext>().InSingletonScope();
            this.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));
            this.Bind<Func<IUnitOfWork>>().ToMethod(ctx => () => ctx.Kernel.Get<IUnitOfWork>());
            this.Bind<IUnitOfWork>().To<EfUnitOfWork>();
        }
    }
}
