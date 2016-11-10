using Dealership.Contracts;
using Dealership.Factories;
using Dealership.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dealership.Engine
{
    public sealed class DealershipEngine : IDealershipEngine
    {
        private const string UserNotLogged = "You are not logged! Please login first!";

        private readonly IDealershipFactory factory;
        private readonly ICommandFactory commandFactory;
        private readonly IInputOutputProcessor commandProcessor;
        private readonly ICommandHandler commandHandler;

        private ICollection<IUser> users;
        private IUser loggedUser;

      

        public DealershipEngine(
            IDealershipFactory factory,
            IInputOutputProcessor commandProcessor, 
            ICommandFactory commandFactory, 
            ICommandHandler commandHandler)
        {
            this.factory = factory;
            this.users = new List<IUser>();
            this.loggedUser = null;
            this.commandProcessor = commandProcessor;
            this.commandFactory = commandFactory;
            this.commandHandler = commandHandler;
        }

        public void Start()
        {
            var commands = this.ReadCommands();
            var commandResult = this.ProcessCommands(commands);
            this.PrintReports(commandResult);
        }

        public IUser LoggedUser
        {
            get { return loggedUser; }
        }

        ICollection<IUser> Users
        {
            get { return this.users; }
        }

        ICollection<IUser> IDealershipEngine.Users
        {
            get { return this.users; }
        }

        public void SetLoggedUser(IUser user)
        {
            this.loggedUser = user;
        }

        private IList<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();

            var input = commandProcessor.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                var currentCommand = this.commandFactory.CreateCommand(input);
                commands.Add(currentCommand);

                input = commandProcessor.ReadLine();
            }

            return commands;
        }

        private IList<string> ProcessCommands(IList<ICommand> commands)
        {
            var reports = new List<string>();

            foreach (var command in commands)
            {
                try
                {
                    var report = this.ProcessSingleCommand(command);
                    reports.Add(report);
                }
                catch (Exception ex)
                {
                    reports.Add(ex.Message);
                }
            }

            return reports;
        }

        private void PrintReports(IList<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
                output.AppendLine(new string('#', 20));
            }

            commandProcessor.WriteLine(output.ToString());
        }

        private string ProcessSingleCommand(ICommand command)
        {
            if (command.Name != "RegisterUser" && command.Name != "Login")
            {
                if (this.loggedUser == null)
                {
                    return UserNotLogged;
                }
            }

            return this.commandHandler.HandleCommand(command, this);
        }

    }
}
