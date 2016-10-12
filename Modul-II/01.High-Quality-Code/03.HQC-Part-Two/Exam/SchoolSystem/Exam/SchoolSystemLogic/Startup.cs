using SchoolSystemLogic.Core;
using SchoolSystemLogic.Models.Providers;

namespace SchoolSystemLogic
{
    public class Startup
    {
        public static void Main()
        {
            IReader consoleReaderProvider = new ConsoleReaderProvider();
            IWritter consoleWritterProvider = new ConsoleWritterProvider();

            var service = new Engine(consoleReaderProvider, consoleWritterProvider);
            service.Start();
        }
    }
}
