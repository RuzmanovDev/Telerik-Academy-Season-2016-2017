using Ninject.Extensions.Interception.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Request;
using Ninject;

namespace DITEst.Interceptors
{
    public class LogAttribute : InterceptAttribute
    {
        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return request.Context.Kernel.Get<LogInterceptor>();
        }
    }
}
