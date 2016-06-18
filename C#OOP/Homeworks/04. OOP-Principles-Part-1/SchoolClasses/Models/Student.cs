namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;

    using SchoolClasses.Contracts;

    public class Student : Person, IPerson, ICommentable
    {
        private static HashSet<string> uniqueClassNumbers;

        private string classNumber;

        static Student()
        {
            uniqueClassNumbers = new HashSet<string>();
        }

        public Student(string name, string classNumber) : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public string ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            private set
            {
                if (uniqueClassNumbers.Contains(value))
                {
                    throw new ArgumentException("There already is student with this class number!");
                }

                this.classNumber = value;
                this.AddNumberToUniqueList(value);
            }
        }

        public string Comment { get; set; }

        private void AddNumberToUniqueList(string value)
        {
            uniqueClassNumbers.Add(value);
        }
    }
}
