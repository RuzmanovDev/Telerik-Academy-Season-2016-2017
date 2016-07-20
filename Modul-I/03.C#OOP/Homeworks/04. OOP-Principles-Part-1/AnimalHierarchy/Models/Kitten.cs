namespace AnimalHierarchy.Models
{
    using Contracts;

    public class Kitten : Animal, ISound
    {
        public Kitten(string name, int age) : base(name, age)
        {
            this.Gender = Gender.Female;
        }

        public override Gender Gender { get; protected set; }

        public override string Sound()
        {
            return "Malko Mqqqqqy";
        }
    }
}
