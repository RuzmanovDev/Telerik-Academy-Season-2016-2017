using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITEst.Interceptors
{
    public class LogInterceptor : IInterceptor
    {
        private readonly IIOProvider ioProvider;

        public LogInterceptor(IIOProvider ioProvider)
        {
            this.ioProvider = ioProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            this.ioProvider.Write($"Before log ");

            invocation.Proceed();

            ioProvider.Write($"after log");
        }
    }
}
