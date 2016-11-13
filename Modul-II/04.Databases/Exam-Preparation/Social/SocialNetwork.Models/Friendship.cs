using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public class Friendship
    {
        private ICollection<Message> messages;

        public Friendship()
        {
            this.messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        public UserProfile FirstUser { get; set; }

        [ForeignKey("FirstUser")]
        public int FirstUserId { get; set; }

        public UserProfile SecondUser { get; set; }

        [ForeignKey("SecondUser")]
        public int SecondUserId { get; set; }

        [Index]
        public bool Approved { get; set; }

        public DateTime? TimeOfApproval { get; set; }

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
