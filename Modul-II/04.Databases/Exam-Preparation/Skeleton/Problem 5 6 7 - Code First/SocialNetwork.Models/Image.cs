using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string FileExtension { get; set; }

        public virtual UserProfile User { get; set; }

        public int UserId { get; set; }
    }
}