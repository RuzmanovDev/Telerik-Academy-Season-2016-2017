using System;
using System.Text.RegularExpressions;
using SchoolSystemLogic.Models.Contracts;

namespace SchoolSystemLogic.Models.Abstract
{
    public abstract class Human : IHuman
    {
        private const int NameMinimumLength = 2;
        private const int NameMaximumLength = 31;

        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.ValidateName(value);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.ValidateName(value);

                this.lastName = value;
            }
        }

        private void ValidateName(string value)
        {
            Match match = Regex.Match(value, @"^[A-Za-z]+", RegexOptions.None);

            if (!match.Success)
            {
                throw new ArgumentException("The name must contains only lattin letters!");
            }

            if (value.Length < NameMinimumLength || value.Length > NameMaximumLength)
            {
                throw new ArgumentException($"The name  must be between {NameMinimumLength} and {NameMaximumLength} chars long!");
            }
        }
    }
}
