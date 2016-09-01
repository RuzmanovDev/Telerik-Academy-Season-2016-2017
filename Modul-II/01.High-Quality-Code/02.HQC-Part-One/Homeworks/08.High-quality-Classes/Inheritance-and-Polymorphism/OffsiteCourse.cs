using System;
using System.Collections.Generic;
using System.Text;

using InheritanceAndPolymorphism.Contracts;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, string teachersName, ICollection<string> students, string town)
            : base(name, teachersName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The town cannot be null or empty!!!");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Town: {this.Town}");

            var result = base.ToString() + builder.ToString();
            return result;
        }
    }
}
