namespace AnimalHierarchy.Models
{
    using Contracts;

    public abstract class Animal : ISound
    {
        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public virtual Gender Gender { get; protected set; }

        public abstract string Sound();
    }
}
