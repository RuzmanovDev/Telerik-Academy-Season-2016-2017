using System;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models.Models
{
    public class Homework
    {
        public int Id { get; set; }

        [MinLength(5)]
        [MaxLength(40)]
        [Required]
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public virtual Student Student { get; set; }

        public int StudentId { get; set; }

        public virtual Course Course { get; set; }

        public int CourseId { get; set; }

    }
}
