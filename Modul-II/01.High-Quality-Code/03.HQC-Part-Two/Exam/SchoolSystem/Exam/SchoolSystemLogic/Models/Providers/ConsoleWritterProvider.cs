using System;

namespace SchoolSystemLogic.Models.Providers
{
    public class ConsoleWritterProvider : IWritter
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(char value)
        {
            Console.WriteLine(value);
        }

        public void Write(char value)
        {
            Console.Write(value);
        }
    }
}
