namespace School
{
    using System;

    public class Student
    {
        private const int MinValidIdValue = 10000;
        private const int MaxValidIdValue = 99999;

        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
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
                    throw new ArgumentNullException("The name ccannot be null or empty!");
                }

                this.name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (value > MaxValidIdValue || value < MinValidIdValue)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The student id must be between {0} and {1}", MinValidIdValue, MaxValidIdValue));
                }

                this.id = value;
            }
        }

        public void AttendCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course cannot be null.");
            }

            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course cannot be null.");
            }

            course.RemoveStudent(this);
        }
    }
}
