namespace Task2
{
    public class Entrypoint
    {
        public static void Main(string[] args)
        {
            var personFactory = new PersonFactory();
            var pesho = personFactory.CreatePerson(2);
            var marrika = personFactory.CreatePerson(1);
        }
    }
}
