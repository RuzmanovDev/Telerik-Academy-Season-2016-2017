namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    public class StudentsAndWorkers
    {
        public static void Main(string[] args)
        {
            // creating students
            var pesho = new Student("Petar", "Ivanov", 3);
            var dimitar = new Student("Dimitar", "Iliev", 2);
            var stoyan = new Student("Stoyan", "Nikolov", 6);
            var dragan = new Student("Dragan", "Cankov", 2);
            var iliya = new Student("Iliya", "Petrov", 4);
            var mincho = new Student("Mincho", "Minchev", 5);
            var konstantin = new Student("Konstantin", "Konstantinov", 5);
            var ivan = new Student("Ivan", "Ivanov", 2);
            var gencho = new Student("Gencho", "Radenkov", 6);
            var pencho = new Student("Pencho", "Penchev", 6);

            var listOfStudents = new List<Student>()
            {
                pesho, dimitar, stoyan, dragan, iliya, mincho, konstantin, ivan, gencho, pesho
            };

            // Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension method).
            var sortedStudents = listOfStudents
                .OrderBy(st => st.Grade)
                .ToList();

            foreach (var st in sortedStudents)
            {
                Console.WriteLine(st);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // create workers
            var petko = new Worker("Petko", "Petkov", 150, 12);
            var doncho = new Worker("Doncho", "Ivanov", 120, 11);
            var kiro = new Worker("Kiro", "Skalata", 200, 8);
            var mitioOchite = new Worker("Mitio", "TheEyes", 999999, 2);
            var boiko = new Worker("Boiko", "Boikov", 50, 4);
            var darko = new Worker("Darko", "Voinov", 200, 12);
            var gosho = new Worker("Gosho", "Zidraya", 150, 12);
            var baiIvan = new Worker("Bai", "Ivan", 100, 8);
            var toncho = new Worker("Toncho", "Petkov", 175, 12);
            var manager = new Worker("Gospodin", "Merindjei", 1000, 2);

            var workers = new List<Worker>()
            {
                petko, doncho, kiro, mitioOchite, boiko, darko, gosho, baiIvan, toncho, manager
            };

            // Initialize a list of 10 workers and sort them by money per hour in descending order.
            var sortedWorders = workers
                .OrderBy(w => w.MoneyPerHour(w.WeekSalary, 5))
                .Select(
                w => new
                {
                    Info = w.ToString(),
                    MoneyPerHour = w.MoneyPerHour(w.WeekSalary, 5)
                });

            foreach (var worker in sortedWorders)
            {
                Console.WriteLine(worker.Info + " " + "Money per Hour: " + worker.MoneyPerHour);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            // Merge the lists and sort them by first name and last name.
            var mergedLiest = new List<Human>()
            {
                 pesho, dimitar, stoyan, dragan, iliya, mincho, konstantin, ivan, gencho,
                 petko, doncho, kiro, mitioOchite, boiko, darko, gosho, baiIvan, toncho, manager
            };

            var sortedMergedLis = mergedLiest
                .OrderBy(fn => fn.FirstName)
                .ThenBy(ln => ln.LastName)
                .Select(o => new
                {
                    FullName = o.FirstName + " " + o.LastName
                });

            foreach (var obj in sortedMergedLis)
            {
                Console.WriteLine(obj.FullName);
            }
        }
    }
}
