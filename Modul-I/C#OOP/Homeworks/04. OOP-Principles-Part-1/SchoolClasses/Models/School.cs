namespace SchoolClasses.Models
{
    using System.Collections.Generic;

    public class School
    {
        public School(string name, IList<ClassOfStudents> classOfStudents)
        {
            this.Name = name;
            this.ClassOfStudents = classOfStudents;
        }

        public IList<ClassOfStudents> ClassOfStudents { get; private set; }

        public string Name { get; private set; }
    }
}
