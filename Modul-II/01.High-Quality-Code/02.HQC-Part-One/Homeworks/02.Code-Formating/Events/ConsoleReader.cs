namespace Events
{
    using System;

    using Events.Contracts;

    public class ConsoleReader : ICommandReader
    {
        public string ReadCommand()
        {
            return Console.ReadLine();
        }
    }
}
