namespace AnimalHierarchy.Models
{
    using Contracts;

    public class Cat : Animal, ISound
    {
        public Cat(string name, int age, Gender gender) : base(name, age, gender)
        {
        }

        public Cat(string name, int age) : base(name, age)
        {
        }

        public override string Sound()
        {
            return "Myaaau!";
        }
    }
}
