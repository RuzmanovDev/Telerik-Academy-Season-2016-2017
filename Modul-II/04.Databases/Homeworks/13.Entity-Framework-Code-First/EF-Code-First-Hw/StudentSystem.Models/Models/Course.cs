using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models.Models
{
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Homework> homeworks;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        public string Description { get; set; }

        public string Materials { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
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
