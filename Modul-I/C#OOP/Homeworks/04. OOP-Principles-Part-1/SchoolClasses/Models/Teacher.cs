namespace SchoolClasses.Models
{
    using System.Collections.Generic;

    using SchoolClasses.Contracts;

    public class Teacher : Person, IPerson, ICommentable
    {
        public Teacher(string name, IList<Discipline> disciplines) : base(name)
        {
            this.Disciplines = disciplines;
        }

        public IList<Discipline> Disciplines { get; set; }

        public string Comment { get; set; }
    }
}
