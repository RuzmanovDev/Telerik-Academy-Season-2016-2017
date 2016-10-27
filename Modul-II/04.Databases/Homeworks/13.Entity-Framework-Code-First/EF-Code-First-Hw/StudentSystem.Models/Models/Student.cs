using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Models.Models
{
    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [MaxLength(10)]
        [Required]
        [Index(IsUnique = true)]
        public string Number { get; set; }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return courses;
            }

            set
            {
                courses = value;
            }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get
            {
                return this.homeworks;
            }

            set
            {
                this.homeworks = value;
            }
        }
    }
}
