using System;

namespace Methods
{
    public class Student
    {
        private readonly DateTime dateOfBirth;

        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;

            this.dateOfBirth = this.CalculateDateOfBirth(otherInfo);
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string OtherInfo { get; private set; }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }
        }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = this.DateOfBirth;
            DateTime secondDate = other.DateOfBirth;

            bool isOlderThan  = firstDate > secondDate;

            return isOlderThan;
        }

        private DateTime CalculateDateOfBirth(string otherInfo)
        {
            DateTime dateOfBirth = DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));

            return dateOfBirth;
        }
    }
}
