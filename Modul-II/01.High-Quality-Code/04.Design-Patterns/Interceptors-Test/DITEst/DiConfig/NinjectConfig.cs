using DITEst.Interceptors;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Interception.Invocation;

namespace DITEst.DiConfig
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
         
            this.Bind<IIOProvider>().To<ConsoleIO>().InSingletonScope();
            this.Bind<IHacker>().To<Hacker>().Named("Hacker");
            this.Bind<IHacker>().To<Goshko>().Named("Goshko");

            this.Bind<Hacker>().To<Hacker>();
            this.Bind<Goshko>().To<Goshko>();
        }
    }
}
