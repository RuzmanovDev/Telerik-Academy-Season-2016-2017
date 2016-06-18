namespace AnimalHierarchy.Models
{
    using System;

    using Contracts;

    public class TomCat : Cat, ISound
    {
        public TomCat(string name, int age) : base(name, age)
        {
            this.Gender = Gender.Male;
        }

        public override Gender Gender { get; protected set; }

        public override string ToString()
        {
            return "Big MYAAU!!!";
        }
    }
}
