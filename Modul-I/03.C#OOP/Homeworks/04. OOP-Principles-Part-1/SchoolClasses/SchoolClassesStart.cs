namespace SchoolClasses
{
    using System.Collections.Generic;

    using SchoolClasses.Models;

    public class SchoolClassesStart
    {
        public static void Main(string[] args)
        {
            // creating students
            var stu = new Student("Pesho Petrov", "13");
            var gosho = new Student("Georgi Ivanov", "4");
            var stoyan = new Student("Mitko Mitkov", "15");
            var dragan = new Student("Dragan Cankov", "16");

            // creating disciplines 
            var math = new Discipline("Mathematics", 2, 2);
            var geogrpahy = new Discipline("Geography", 1, 1);
            var iT = new Discipline("IT", 3, 4);
            var pE = new Discipline("Physycial education", 1, 3);

            // creating teachers
            var genev = new Teacher("Genev", new List<Discipline>() { math, geogrpahy });
            var nonkov = new Teacher("Nonkov", new List<Discipline>() { iT, pE });

            // adding optional comment to teahcer
            nonkov.Comment = "Хем програмира, хем играе тенис на маса и футбол";

            // creating class
            var bestClass = new ClassOfStudents(new List<Teacher>() { genev, nonkov }, "12a");

            // creating school
            var school = new School("DreamSchool", new List<ClassOfStudents>() { bestClass });
        }
    }
}
