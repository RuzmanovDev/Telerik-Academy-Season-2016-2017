using System;
using System.Collections.Generic;
using System.Linq;
using SchoolSystemLogic.Models.Abstract;
using SchoolSystemLogic.Models.Contracts;

namespace SchoolSystemLogic.Models
{
    public class Student : Human, IStudent
    {
        private Grade grade;
        private ICollection<IMark> marks;

        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
            this.marks = new List<IMark>();
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if ((int)value < 1 || (int)value > 12)
                {
                    throw new ArgumentException("The grade of the student must be between 1 and 12");
                }

                this.grade = value;
            }
        }

        public ICollection<IMark> Marks
        {
            get
            {
                return this.marks;
            }

            set
            {
                this.marks = value;
            }
        }

        public string ListMarks()
        {
            var marksToBeListed = this.marks.Select(m => $"{m.SubjectType} => {m.MarkValue}");

            return string.Join(Environment.NewLine, marksToBeListed);
        }
    }
}
