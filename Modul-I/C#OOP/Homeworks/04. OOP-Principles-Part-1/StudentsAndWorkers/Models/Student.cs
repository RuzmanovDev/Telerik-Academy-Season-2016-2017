namespace StudentsAndWorkers.Models
{
    public class Student : Human
    {
        public Student(string firstname, string lastName, int grade)
            : base(firstname, lastName)
        {
            this.Grade = grade;
        }

        public int Grade { get; private set; }

        public override string ToString()
        {
            return base.ToString() + " " + this.Grade.ToString();
        }
    }
}
