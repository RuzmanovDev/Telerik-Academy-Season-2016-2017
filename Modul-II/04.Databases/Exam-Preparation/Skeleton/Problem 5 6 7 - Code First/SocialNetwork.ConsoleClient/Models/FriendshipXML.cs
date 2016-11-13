using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.Models
{
    [Serializable]
    [XmlType("Friendship")]
    public class FriendshipXML
    {
        public DateTime? FriendsSince { get; set; }

        public UserProfileXML FirstUser { get; set; }

        public UserProfileXML SecondUser { get; set; }

        [XmlAttribute]
        public bool Approved { get; set; }

        [XmlArrayItem(ElementName = "Message")]
        public List<MessageXML> Messages { get; set; }
    }
}
