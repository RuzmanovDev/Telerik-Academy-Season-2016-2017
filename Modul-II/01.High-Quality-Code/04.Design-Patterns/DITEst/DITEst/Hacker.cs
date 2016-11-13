using DITEst.Interceptors;
using System;

namespace DITEst
{
    public class Hacker : IHacker
    {
        private readonly IIOProvider ioProvider;

        public Hacker(IIOProvider ioProvider)
        {
            this.ioProvider = ioProvider;
        }

        public void DoNotHack()
        {
            ioProvider.Write("You Were not hacked");
        }

      
        public void Hack()
        {
            this.ioProvider.Write("YOu Were Hacked");
        }
    }
}
