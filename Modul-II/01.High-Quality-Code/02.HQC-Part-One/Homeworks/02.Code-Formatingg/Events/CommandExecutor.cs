namespace Events
{
    using System;
    using Contracts;

    public class CommandExecutor
    {
        private const string AddEventsCommand = "AddEvent";
        private const string DeleteEventsCommand = "DeleteEvents";
        private const string ListEventCommand = "ListEvents";
        private const char LineSeperator = '|';
        private const char CommandA = 'A';
        private const char CommandD = 'D';
        private const char CommandL = 'L';
        private const char CommandE = 'E';

        private readonly ICommandReader commandReader;

        private IEventsHolder events;

        public CommandExecutor(IEventsHolder eventsHolder, ICommandReader commandReader)
        {
            this.events = eventsHolder;
            this.commandReader = commandReader;
        }

        public bool ExecuteNextCommand()
        {
            string command = this.commandReader.ReadCommand();
            char commandToExecute = command[0];

            if (commandToExecute == CommandA)
            {
                this.AddEvent(command);
                return true;
            }

            if (commandToExecute == CommandD)
            {
                this.DeleteEvents(command);
                return true;
            }

            if (commandToExecute == CommandL)
            {
                this.ListEvents(command);
                return true;
            }

            if (commandToExecute == CommandE)
            {
                return false;
            }

            return false;
        }

        private void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf(LineSeperator);
            DateTime date = this.GetDate(command, ListEventCommand);
            string countString = command.Substring(pipeIndex + 1);

            int count = int.Parse(countString);
            this.events.ListEvents(date, count);
        }

        private void DeleteEvents(string command)
        {
            string title = command.Substring(DeleteEventsCommand.Length + 1);
            this.events.DeleteEvents(title);
        }

        private void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;

            this.GetParameters(command, AddEventsCommand, out date, out title, out location);

            this.events.AddEvent(date, title, location);
        }

        private void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
        {
            dateAndTime = this.GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf(LineSeperator);

            int lastPipeIndex = commandForExecution.LastIndexOf(LineSeperator);
            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }
    }
}
