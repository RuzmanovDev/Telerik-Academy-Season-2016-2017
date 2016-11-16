using System;

using SchoolSystem.Framework.Models.Abstractions;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Factories;

namespace SchoolSystem.Framework.Models
{
    public class Teacher : Person, ITeacher
    {
        public const int MaxStudentMarksCount = 20;
        private readonly IMarkFactory markFactory;

        public Teacher(string firstName, string lastName, Subject subject, IMarkFactory markFactory)
            : base(firstName, lastName)
        {
            this.Subject = subject;
            if(markFactory == null)
            {
                throw new ArgumentNullException("The mark factory can not be null!");
            }

            this.markFactory = markFactory;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float value)
        {
            if (student.Marks.Count >= MaxStudentMarksCount)
            {
                throw new ArgumentException($"The student's marks count exceed the maximum count of {MaxStudentMarksCount} marks");
            }

            var newMark = this.markFactory.CreateMark(this.Subject, value);
            student.Marks.Add(newMark);
        }
    }
}
