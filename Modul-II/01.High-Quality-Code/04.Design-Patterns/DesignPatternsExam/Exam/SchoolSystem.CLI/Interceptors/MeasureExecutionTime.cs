using Ninject.Extensions.Interception;
using SchoolSystem.Framework.Core.Contracts;
using System;
using System.Diagnostics;

namespace SchoolSystem.Cli.Interceptors
{
    public class MeasureExecutionTime : IInterceptor
    {
        private readonly IWriter writer;

        public MeasureExecutionTime(IWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("Writter can not be null!");
            }

            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            var stopwatch = new Stopwatch();
            var methodName = invocation.Request.Method.Name;
            var typeName = invocation.Request.Method.DeclaringType.Name;

            writer.WriteLine($"Calling method {methodName} of type {typeName}...");

            stopwatch.Start();
            invocation.Proceed();
            stopwatch.Stop();

            var ellapesMilliSeconds = stopwatch.ElapsedMilliseconds;

            writer.WriteLine($"Total execution time for method {methodName} of type {typeName} is {ellapesMilliSeconds} milliseconds");
        }
    }
}
