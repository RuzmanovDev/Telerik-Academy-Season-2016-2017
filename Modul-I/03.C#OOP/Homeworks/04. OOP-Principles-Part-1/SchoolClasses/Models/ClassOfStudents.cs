namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;

    using SchoolClasses.Contracts;

    public class ClassOfStudents : ICommentable
    {
        private static HashSet<string> uniqueTextId;
        private string textID;

        static ClassOfStudents()
        {
            uniqueTextId = new HashSet<string>();
        }

        public ClassOfStudents(IList<Teacher> teachers, string textId)
        {
            this.Teachers = teachers;
            this.TextId = textId;
        }

        public string Comment { get; set; }

        public IList<Teacher> Teachers { get; private set; }

        public string TextId
        {
            get
            {
                return this.TextId;
            }

            private set
            {
                if (uniqueTextId.Contains(value))
                {
                    throw new ArgumentException("There already is student with this class number!");
                }

                this.textID = value;
                this.AddTextIdTOUniqueList(value);
            }
        }

        private void AddTextIdTOUniqueList(string value)
        {
            uniqueTextId.Add(value);
        }
    }
}
