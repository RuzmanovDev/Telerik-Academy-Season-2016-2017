using System;
using System.Collections.Generic;
using System.Text;

using InheritanceAndPolymorphism.Contracts;

namespace InheritanceAndPolymorphism
{
    public abstract class Course : ICourse
    {
        private string name;
        private string teacherName;
        private ICollection<string> students;

        public Course(string name, string teacherName, ICollection<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("THe name of the course cannot be null or empy!!!");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("THe name of the teacher cannot be null or empy!!!");
                }

                this.teacherName = value;
            }
        }

        public ICollection<string> Students
        {
            get
            {
                return this.students;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The students cannot be null!!");
                }

                this.students = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{this.GetType().Name} Name = {this.Name}");
            builder.AppendLine($"Students = {string.Join(", ", this.Students)} ");
            builder.AppendLine($"Teacher = {this.TeacherName}");

            return builder.ToString();
        }
    }
}
