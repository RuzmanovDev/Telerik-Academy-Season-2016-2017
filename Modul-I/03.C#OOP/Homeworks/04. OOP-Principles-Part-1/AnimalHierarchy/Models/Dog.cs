namespace AnimalHierarchy.Models
{
    using Contracts;

    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, Gender gender) : base(name, age, gender)
        {
        }

        public override string Sound()
        {
            return "Baau!";
        }
    }
}
