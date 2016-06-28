namespace PersonClass
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name)
        {
            this.Name = name;
            this.Age = null;
        }

        public string Name { get; private set; }

        public int? Age { get; private set; }

        public override string ToString()
        {
            var age = this.Age == null ? "not specified" : this.Age.ToString();

            return $"Name: {this.Name} Age: {age}";
        }
    }
}
