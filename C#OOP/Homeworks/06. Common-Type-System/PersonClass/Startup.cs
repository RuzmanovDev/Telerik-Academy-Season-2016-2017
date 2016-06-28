namespace PersonClass
{
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            var pesho = new Person("Pesho");
            var stoyan = new Person("Stoyan", 21);

            Console.WriteLine(pesho);
            Console.WriteLine(stoyan);
        }
    }
}
