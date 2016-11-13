using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    public class UserProfile
    {
        private ICollection<Image> images;
        private ICollection<Post> posts;
        private ICollection<Message> messages;

        public UserProfile()
        {
            this.images = new HashSet<Image>();
            this.posts = new HashSet<Post>();
            this.messages = new HashSet<Message>();

            this.RegistrationDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string FristName { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Post> Posts
        {
            get { return posts; }

            set { posts = value; }
        }

        public virtual ICollection<Message> Messages
        {
            get
            {
                return messages;
            }

            set
            {
                messages = value;
            }
        }
    }
}
