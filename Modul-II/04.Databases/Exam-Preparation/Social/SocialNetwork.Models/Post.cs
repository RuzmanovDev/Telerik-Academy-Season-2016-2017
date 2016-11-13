using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Post
    {
        private ICollection<UserProfile> taggedUsers;

        public Post()
        {
            this.taggedUsers = new HashSet<UserProfile>();
        }

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public virtual ICollection<UserProfile> TaggedUsers
        {
            get { return taggedUsers; }

            set { taggedUsers = value; }
        }
    }
}
