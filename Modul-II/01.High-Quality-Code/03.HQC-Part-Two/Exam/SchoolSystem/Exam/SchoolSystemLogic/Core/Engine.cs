using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SchoolSystemLogic.Commands;
using SchoolSystemLogic.Models.Contracts;
using SchoolSystemLogic.Models.Providers;

namespace SchoolSystemLogic.Core
{
    public class Engine
    {
        private const string EndCommand = "End";

        private readonly IReader reader;
        private readonly IWritter writter;

        static Engine()
        {
            Teachers = new Dictionary<int, ITeacher>();
            Students = new Dictionary<int, IStudent>();
        }

        public Engine(IReader reader, IWritter writter)
        {
            this.reader = reader;
            this.writter = writter;
        }

        internal static Dictionary<int, ITeacher> Teachers { get; set; }

        internal static Dictionary<int, IStudent> Students { get; set; }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var command = this.reader.ReadLine();
                    if (command == EndCommand)
                    {
                        break;
                    }

                    var commandType = command.Split(' ')[0];

                    var assembly = this.GetType().GetTypeInfo().Assembly;
                    var typeInfo = assembly.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(commandType.ToLower()))
                        .FirstOrDefault();

                    if (typeInfo == null)
                    {
                        throw new ArgumentException("The passed command is not found!");
                    }

                    var commandToExecute = Activator.CreateInstance(typeInfo) as ICommand;
                    var paramss = command.Split(' ').ToList();
                    paramss.RemoveAt(0);

                    if (commandToExecute == null)
                    {
                        throw new NullReferenceException("There is no such command!");
                    }

                    this.WriteLine(commandToExecute.Execute(paramss));
                }
                catch (Exception ex)
                {
                    this.WriteLine(ex.Message);
                }
            }
        }

        public void WriteLine(string message)
        {
            this.writter.WriteLine(message);
        }
    }
}
