using System.Collections.Generic;
using SchoolSystemLogic.Core;
using SchoolSystemLogic.Models;
using SchoolSystemLogic.Models.Contracts;

namespace SchoolSystemLogic.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            var studentFirstName = parameters[0];
            var studentLastName = parameters[1];
            var studentGrade = (Grade)int.Parse(parameters[2]);
            IStudent student = new Student(studentFirstName, studentLastName, studentGrade);

            Engine.Students.Add(id, student);
            var result = $"A new student with name {studentFirstName} {studentLastName}, grade {studentGrade} and ID {id++} was created.";

            return result;
        }
    }
}
