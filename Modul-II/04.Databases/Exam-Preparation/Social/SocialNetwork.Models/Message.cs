using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Message
    {
        public int Id { get; set; }

        public  virtual Friendship Friendship { get; set; }

        public int  FriendshipId { get; set; }

        public virtual UserProfile Author { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime SendDate { get; set; }

        public DateTime? SeenDate { get; set; }
    }
}
