using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Db;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        private readonly IDbProvider dbProvider;

        public RemoveTeacherCommand(IDbProvider dbProvider)
        {
            if (dbProvider == null)
            {
                throw new ArgumentNullException("The db provider can not be null!");
            }

            this.dbProvider = dbProvider;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);

            this.dbProvider.RemoveTeacher(teacherId);
            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
