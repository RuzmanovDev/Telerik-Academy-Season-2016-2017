using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Db;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        private readonly IDbProvider dbProvider;

        public StudentListMarksCommand(IDbProvider dbProvider)
        {
            if (dbProvider == null)
            {
                throw new ArgumentNullException("Db provider can not be null!");
            }

            this.dbProvider = dbProvider;
        }
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            var student = this.dbProvider.GetStudentById(studentId);
            return student.ListMarks();
        }
    }
}
