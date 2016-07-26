namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private ICollection<Student> students;
        private ICollection<Course> courses;
        private string name;

        public School(string name, ICollection<Course> courses)
        {
            this.Name = name;
            this.students = new List<Student>();
            this.Courses = courses;
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
                    throw new ArgumentNullException("The name of the school can't be null or empty");
                }

                this.name = value;
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The courses in the school cannot be null!");
                }

                this.courses = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student can' be null!");
            }

            if (this.Students.Any(st => st.Id == student.Id))
            {
                throw new InvalidOperationException("There already is student with this ID");
            }

            this.students.Add(student);
        }
    }
}

