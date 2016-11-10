using DITEst.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITEst
{
    public class Goshko : IHacker
    {
        private readonly IIOProvider ioProvider;

        public Goshko(IIOProvider ioProvider)
        {
            this.ioProvider = ioProvider;
        }
        [Log]
        public void Hack()
        {
            this.ioProvider.Write("Gosho was hacked");
        }


        public void DoNotHack()
        {
            ioProvider.Write("Goshko Was Not Hacked");
        }
    
    }
}
