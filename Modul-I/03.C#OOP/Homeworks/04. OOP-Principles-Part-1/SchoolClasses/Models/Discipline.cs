namespace SchoolClasses.Models
{
    using System;

    using SchoolClasses.Contracts;

    public class Discipline : ICommentable
    {
        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfExercises = numberOfExercises;
            this.NumberOfLectures = numberOfLectures;
        }

        public string Name { get; private set; }

        public int NumberOfLectures { get; private set; }

        public int NumberOfExercises { get; private set; }

        public string Comment { get; set; }
    }
}
