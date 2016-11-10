using DITEst.DiConfig;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITEst
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var kernerl = new StandardKernel(new NinjectConfig());
            var hacker = kernerl.Get<IHacker>("Hacker");
            var goshko = kernerl.Get<IHacker>("Goshko");

            goshko.Hack();
            goshko.DoNotHack();

            hacker.Hack();
            hacker.DoNotHack();
        }
    }
}
