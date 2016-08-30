namespace Events
{
    using Contracts;

    public class EntryPoint
    {
        public static void Main()
        {
            ICommandReader consoleReader = new ConsoleReader();
            IEventsHolder eventsHolder = new EventsHolder();

            var commandExecutor = new CommandExecutor(eventsHolder, consoleReader);

            while (commandExecutor.ExecuteNextCommand())
            {
            }
        }
    }
}
