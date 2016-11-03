using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(4)]
        public string FileExtension { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }
    }
}
