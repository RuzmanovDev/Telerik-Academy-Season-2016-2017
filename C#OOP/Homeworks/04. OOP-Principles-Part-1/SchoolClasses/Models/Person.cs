namespace SchoolClasses.Models
{
    using System;

    using SchoolClasses.Contracts;

    public abstract class Person : IPerson
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; protected set; }
    }
}
