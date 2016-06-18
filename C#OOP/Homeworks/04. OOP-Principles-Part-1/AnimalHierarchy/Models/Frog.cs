namespace AnimalHierarchy.Models
{
    using Contracts;

    public class Frog : Animal, ISound
    {
        public Frog(string name, int age, Gender gender) : base(name, age, gender)
        {
        }

        public override string Sound()
        {
            return "Kryaaq Kryqqq!";
        }
    }
}
