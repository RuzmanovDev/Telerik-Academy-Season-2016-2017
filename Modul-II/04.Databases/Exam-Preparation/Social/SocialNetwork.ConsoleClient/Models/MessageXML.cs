using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.ConsoleClient.Models
{
    [Serializable]
    public class MessageXML
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }
    }
}
