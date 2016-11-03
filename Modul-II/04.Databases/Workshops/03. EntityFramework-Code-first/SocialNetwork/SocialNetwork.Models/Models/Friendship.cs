using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Models.Models
{
    public class Friendship
    {
        private ICollection<Message> messages;

        public Friendship()
        {
            this.messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        [Index]
        public bool Approved { get; set; }

        public DateTime? FriendShipSince { get; set; }

        public virtual User FirstUser { get; set; }

        public virtual User SecondUser { get; set; }

        [ForeignKey("FirstUser")]
        public int FirstUserId { get; set; }

        [ForeignKey("SecondUser")]
        public int SecondUserId { get; set; }

        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }
    }
}
