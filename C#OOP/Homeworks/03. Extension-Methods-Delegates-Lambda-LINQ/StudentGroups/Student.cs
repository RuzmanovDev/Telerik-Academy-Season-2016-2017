namespace StudentGroups
{
    using System.Collections.Generic;

    public class Student
    {
        // Create a class Student with properties FirstName, LastName, FN, Tel, Email, Marks (a List), GroupNumber.
        public Student(string firstName, string lastName, string fn, string tel, string email, List<int> marks, int group) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = group;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FN { get; private set; }

        public string Tel { get; private set; }

        public string Email { get; private set; }

        public List<int> Marks { get; private set; }

        public int GroupNumber { get; set; }
    }
}
