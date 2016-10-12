using System.Collections.Generic;
using SchoolSystemLogic.Core;
using SchoolSystemLogic.Models;
using SchoolSystemLogic.Models.Contracts;

namespace SchoolSystemLogic.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            var teacherFirstName = parameters[0];
            var teacherLastName = parameters[1];
            var teacherSubject = (SubjectType)int.Parse(parameters[2]);

            ITeacher teacher = new Teacher(teacherFirstName, teacherLastName, teacherSubject);

            Engine.Teachers.Add(id, teacher);

            var result = $"A new teacher with name {teacherFirstName} {teacherLastName}, subject {teacherSubject} and ID {id++} was created.";

            return result;
        }
    }
}
