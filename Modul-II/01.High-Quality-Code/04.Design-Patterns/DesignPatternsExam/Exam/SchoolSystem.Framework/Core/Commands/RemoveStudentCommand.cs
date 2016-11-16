using System;
using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Db;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        private readonly IDbProvider dbProvider;

        public RemoveStudentCommand(IDbProvider dbProvider)
        {
            if (dbProvider == null)
            {
                throw new ArgumentNullException("The db provider can not be null!");
            }

            this.dbProvider = dbProvider;
        }

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            this.dbProvider.RemoveStudent(studentId);
            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
