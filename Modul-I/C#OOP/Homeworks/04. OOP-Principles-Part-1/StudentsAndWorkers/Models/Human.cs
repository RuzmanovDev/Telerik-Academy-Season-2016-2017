namespace StudentsAndWorkers.Models
{
    public abstract class Human
    {
        public Human(string firstname, string lastName)
        {
            this.FirstName = firstname;
            this.LastName = lastName;
        }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} - ";
        }
    }
}
