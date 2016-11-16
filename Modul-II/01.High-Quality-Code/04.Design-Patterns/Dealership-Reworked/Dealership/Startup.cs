using Dealership.Engine;
using Ninject;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel(new NinjectConfig());
            var engine = kernel.Get<IDealershipEngine>();

            engine.Start();
        }
    }
}
