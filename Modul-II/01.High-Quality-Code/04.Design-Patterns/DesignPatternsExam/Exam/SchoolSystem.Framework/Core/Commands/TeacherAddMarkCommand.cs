using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Db;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        private readonly IDbProvider dbProvider;

        public TeacherAddMarkCommand(IDbProvider dbProvider)
        {
            if (dbProvider == null)
            {
                throw new ArgumentNullException("Db provider can not be null!");
            }

            this.dbProvider = dbProvider;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var student = this.dbProvider.GetStudentById(studentId);
            var teacher = this.dbProvider.GetTeacherById(teacherId);

            teacher.AddMark(student, mark);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
