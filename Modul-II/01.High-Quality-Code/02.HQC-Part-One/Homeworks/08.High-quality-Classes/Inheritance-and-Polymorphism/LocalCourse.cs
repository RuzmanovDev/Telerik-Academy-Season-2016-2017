using System;
using System.Collections.Generic;
using System.Text;

using InheritanceAndPolymorphism.Contracts;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, string teachersName, ICollection<string> students, string lab) 
            : base(name, teachersName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The lab cannot be null or empty!!!");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Lab: {this.Lab}");
            var result = base.ToString() + builder.ToString();

            return result.ToString();
        }
    }
}
