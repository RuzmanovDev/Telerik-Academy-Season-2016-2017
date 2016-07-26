namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxStudentsPerCourse = 30;

        private ICollection<Student> students;
        private string name;

        public Course(string name)
        {
            this.students = new List<Student>();
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name of the course can't be null or empty");
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

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student can't be null");
            }

            if(this.students.Count + 1 > MaxStudentsPerCourse)
            {
                throw new InvalidOperationException(string.Format("Can't add more students to the course! Maximum of {0} reached!", MaxStudentsPerCourse));
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student can't be null");
            }

            this.students.Remove(student);
        }
    }
}
