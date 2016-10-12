using System.Collections.Generic;
using SchoolSystemLogic.Core;
using SchoolSystemLogic.Models;
using SchoolSystemLogic.Models.Contracts;

namespace SchoolSystemLogic.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var teecherid = int.Parse(parameters[0]);
            var studentid = int.Parse(parameters[1]);

            var student = Engine.Students[studentid];
            var teacher = Engine.Teachers[teecherid];

            var markValue = float.Parse(parameters[2]);
            var teacherSubject = teacher.Subject;

            IMark mark = new Mark(teacherSubject, markValue);

            teacher.AddMark(student, mark);

            var result = $"Teacher {teacher.FirstName} {teacher.LastName} added mark {float.Parse(parameters[2])} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
            return result;
        }
    }
}
