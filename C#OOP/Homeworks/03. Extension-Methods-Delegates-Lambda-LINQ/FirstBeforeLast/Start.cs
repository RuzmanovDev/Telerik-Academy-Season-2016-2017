// Problem 3. First before last
// Problem 4. Age range
// Problem 5. Order students

namespace FirstBeforeLast
{
    using System;
    using System.Linq;

    public class Start
    {
        public static void Main(string[] args)
        {
            var pesho = new Student("Petar", "Dimov", 12);
            var stoyan = new Student("Stoyan", "Petrov", 18);
            var dimitar = new Student("Dimitar", "Ivanov", 22);
            var georgi = new Student("Georgi", "Petrov", 24);
            var dragan = new Student("Dragan", "Cankov", 25);
            var doncho = new Student("Doncho", "Minkov", 19);
            var stamat = new Student("Stamat", "Grozdanov", 21);
            var atanas = new Student("Atanas", "Zdravkokv", 15);
            var zdravko = new Student("Zdravko", "Atanasov", 13);

            var students = new[] { pesho, stoyan, dimitar, georgi, dragan, doncho, stamat, atanas, zdravko };

            var sorted = FirstNameBeforeLastName(students);
            foreach (var st in sorted)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();

            // Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
            var ageSorted = from st in students
                            where st.Age >= 18 && st.Age <= 24
                            select st;


            //  Extension Methods students.Where(s => s.Age >= 18 && s.Age <= 24).ToArray();
            foreach (var st in sorted)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " " + st.Age);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();

            // Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
            var nameSorted = students
                .OrderByDescending(st => st.FirstName)
                .ThenByDescending(st => st.LastName)
                .ToList();

            foreach (var st in nameSorted)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();

            // Rewrite the same with LINQ.
            var sortedByName = from st in students
                               orderby st.FirstName descending, st.LastName descending
                               select st;
            foreach (var st in nameSorted)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName);
            }
        }

        public static Student[] FirstNameBeforeLastName(Student[] students)
        {
            var result =
                  from st in students
                  where st.FirstName.CompareTo(st.LastName) < 0
                  select st;

            return result.ToArray();

            //students
            //    .Where(student => student.FirstName.CompareTo(student.LastName) < 0)
            //    .ToArray();
        }
    }
}
