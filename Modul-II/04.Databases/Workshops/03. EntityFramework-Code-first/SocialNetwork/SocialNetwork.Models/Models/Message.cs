using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models.Models
{
    public class Message
    {
        public int Id { get; set; }

        public User Author { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public string Content { get; set; }

        [Index]
        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }

        public int FriendshipId { get; set; }

        public virtual Friendship Friendship { get; set; }
    }
}
