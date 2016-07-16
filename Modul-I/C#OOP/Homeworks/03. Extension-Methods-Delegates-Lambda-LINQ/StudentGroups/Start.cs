// Problem 9. Student groups
// Problem 10. Student groups extensions
// Problem 11. Extract students by email
// Problem 12. Extract students by phone
// Problem 13. Extract students by marks
// Problem 14. Extract students with two marks
// Problem 15. Extract marks
// Problem 16.* Groups
// Problem 18. Grouped by GroupNumber
// Problem 19. Grouped by GroupName extensions
namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Start
    {
        static void Main(string[] args)
        {
            List<int> grades = new List<int>() { 5, 2, 2 };
            List<int> anotherGrades = new List<int>() { 2, 2, 3, 5, 5, 5, 6 };
            List<int> yetAnotherGrades = new List<int>() { 4, 6, 3, 5, 5, 5, 2 };
            List<int> yetYeAnotherGrades = new List<int>() { 2, 2, 2, 2, 3, 5, 5, 5, 2 };

            var pesho = new Student("Petar", "Dimov", "13110580", "08922222", "pesho@abv.bg", grades, 2);
            var stoyan = new Student("Stoyan", "Petrov", "131106080", "02/922222", "stoyan@gmail.com", anotherGrades, 10);
            var dimitar = new Student("Dimitar", "Ivanov", "13118080", "089695222", "dimitar@abv.bg", yetAnotherGrades, 2);
            var georgi = new Student("Georgi", "Petrov", "13118080", "02/924892", "georgi@gmail.com", yetYeAnotherGrades, 2);

            var listOfStudents = new List<Student>()
            {
                pesho,georgi,dimitar,stoyan
            };

            // Use LINQ query. Order the students from group 2  by FirstName.
            var studentFromGroupTwo = from st in listOfStudents
                                      where st.GroupNumber == 2
                                      orderby st.FirstName
                                      select st;

            foreach (var st in studentFromGroupTwo)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " " + st.GroupNumber);
            }

            Seperator();

            // Implement the previous using the same query expressed with extension methods.
            var groupTwoStudents = listOfStudents
                                    .Where(st => st.GroupNumber == 2)
                                    .OrderBy(st => st.FirstName)
                                    .ToList();

            var studetnsWithAbvEmail = from st in listOfStudents
                                       where st.Email.Substring(st.Email.IndexOf('@')) == "@abv.bg"
                                       select st;

            foreach (var st in studetnsWithAbvEmail)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " " + st.Email);
            }

            Seperator();

            // Extract all students with phones in Sofia.
            var studentsFromSofia = from st in listOfStudents
                                    where st.Tel.Substring(0, 2) == "02"
                                    select st;

            foreach (var st in studentsFromSofia)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " " + st.Tel);
            }

            Seperator();

            // Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks.
            var studentsWithAtLeastOneExc = from st in listOfStudents
                                            where st.Marks.Any(m => m.Equals(6))
                                            select new
                                            {
                                                FullName = st.FirstName + " " + st.LastName,
                                                Marks = st.Marks
                                            };

            foreach (var st in studentsWithAtLeastOneExc)
            {
                Console.WriteLine(st.FullName + " " + string.Join(",", st.Marks));
            }

            Seperator();

            // Write down a similar program that extracts the students with exactly two marks "2". Use extension methods.
            var studentsWithTwomarks = listOfStudents
                                        .Where(st => st.Marks.FindAll(m => m == 2).Count == 2);

            foreach (var st in studentsWithTwomarks)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " " + string.Join(", ", st.Marks));
            }

            Seperator();

            // Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).

            var studentsFrom05Or06 = listOfStudents
                .Where(st => st.FN.Substring(4, 2) == "05"
                        || st.FN.Substring(4, 2) == "06");

            foreach (var st in studentsFrom05Or06)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName + " " + st.FN);
            }

            Seperator();

            // Problem 16.* Groups Use the Join operator.
            var departements = new List<Group>()
            {
            new Group(2, "Mathematics"),
            new Group(10, "IT")
            };

            var mathStudents = from st in listOfStudents
                               join gn in departements on st.GroupNumber equals gn.GroupNumber
                               where gn.GroupNumber == 2
                               select new
                               {
                                   FullName = st.FirstName + " " + st.LastName,
                                   Departement = gn.Departement
                               };

            foreach (var st in mathStudents)
            {
                Console.WriteLine(st.FullName + " " + st.Departement);
            }

            Seperator();

            // Create a program that extracts all students grouped by GroupNumber and then prints them to the console.

            var groupedByGropNumber = from st in listOfStudents
                                      orderby st.GroupNumber
                                      select new
                                      {
                                          FullName = st.FirstName + " " + st.LastName,
                                          GroupNumber = st.GroupNumber
                                      };

            foreach (var st in groupedByGropNumber)
            {
                Console.WriteLine(st.FullName + " " + st.GroupNumber);
            }

            Seperator();

            // Rewrite the previous using extension methods.
            var groupedByGN = listOfStudents
                                .OrderBy(st => st.GroupNumber)
                                .Select(st => new
                                {
                                    FullName = st.FirstName + " " + st.LastName,
                                    GroupNumber = st.GroupNumber
                                });

            foreach (var st in groupedByGN)
            {
                Console.WriteLine(st.FullName + " " + st.GroupNumber);
            }


        }

        private static void Seperator()
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }
    }
}