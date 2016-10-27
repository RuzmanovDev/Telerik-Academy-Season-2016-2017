using StudentSystem.Models.Models;
using System.Data.Entity;

namespace StudentSystem.Data
{
    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
            : base("StudentSystemHW")
        {
        }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public virtual IDbSet<Student> Students { get; set; }
    }
}
