using System;
using SchoolSystemLogic.Models.Abstract;
using SchoolSystemLogic.Models.Contracts;

namespace SchoolSystemLogic.Models
{
    public class Teacher : Human, ITeacher
    {
        private const int MaximumNumberOfMarksPerStudent = 20;

        private readonly SubjectType subject;

        public Teacher(string firstName, string lastName, SubjectType subject)
            : base(firstName, lastName)
        {
            this.subject = subject;
        }

        public SubjectType Subject
        {
            get
            {
                return this.subject;
            }
        }

        public void AddMark(IStudent student, IMark mark)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student to addMark is null!");
            }

            if (mark == null)
            {
                throw new ArgumentNullException("The mark to be added is null!");
            }

            var studentMarksCount = student.Marks.Count;

            if (studentMarksCount >= MaximumNumberOfMarksPerStudent)
            {
                throw new Exception($"The student can have max {MaximumNumberOfMarksPerStudent} marks");
            }

            student.Marks.Add(mark);
        }
    }
}
