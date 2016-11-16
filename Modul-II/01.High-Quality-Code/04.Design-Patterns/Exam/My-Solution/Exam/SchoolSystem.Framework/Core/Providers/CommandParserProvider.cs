using System;
using System.Collections.Generic;
using System.Linq;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Factories;
using SchoolSystem.Framework.Db;

namespace SchoolSystem.Framework.Core.Providers
{
    public class CommandParserProvider : IParser
    {
        private const string CreateStudentCommand = "CreateStudent";
        private const string CreateTeacherCommand = "CreateTeacher";
        private const string RemoveStudentCommand = "RemoveStudent";
        private const string RemoveTeacherCommand = "RemoveTeacher";
        private const string StudentLisMarksCommand = "StudentListMarks";
        private const string TeacherAddMarkCommand = "TeacherAddMark";

        private readonly ICommandFactory commandFactory;
        private readonly IStudentFactory studentFactory;
        private readonly ITeacherFactory teacherFactory;
        private readonly IDbProvider dbProvider;

        public CommandParserProvider(ICommandFactory commandFactory, IStudentFactory studentFactory, ITeacherFactory teacherFactory, IDbProvider dbProvider)
        {
            if (commandFactory == null)
            {
                throw new ArgumentNullException("Command factory can not be null!");
            }

            if (studentFactory == null)
            {
                throw new ArgumentNullException("Student factory can not be null");
            }

            if (teacherFactory == null)
            {
                throw new ArgumentNullException("Teacher factory can not be null!");
            }

            if (dbProvider == null)
            {
                throw new ArgumentNullException("Db provider can not be null!");
            }

            this.commandFactory = commandFactory;
            this.studentFactory = studentFactory;
            this.teacherFactory = teacherFactory;

            this.dbProvider = dbProvider;
        }
        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            ICommand command = this.FindCommand(commandName);

            return command;
        }

        private ICommand FindCommand(string commandName)
        {
            switch (commandName)
            {
                case CreateStudentCommand:
                    return this.commandFactory.GetCreateStudentCommand(studentFactory);
                case CreateTeacherCommand:
                    return this.commandFactory.GetCreateTeacherCommand(teacherFactory);
                case RemoveStudentCommand:
                    return this.commandFactory.GetRemoveStudentCommand(dbProvider);
                case RemoveTeacherCommand:
                    return this.commandFactory.GetRemoveTeacherCommand(dbProvider);
                case StudentLisMarksCommand:
                    return this.commandFactory.GetStudentListMarksCommand(dbProvider);
                case TeacherAddMarkCommand: return this.commandFactory.GetTeacherAddMarkCommand(dbProvider);
                default:
                    throw new ArgumentException("Invalid Command");
            }

        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return null;
            }

            return commandParts;
        }
    }
}
