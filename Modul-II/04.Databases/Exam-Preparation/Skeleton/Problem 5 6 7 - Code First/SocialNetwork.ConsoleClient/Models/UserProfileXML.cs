using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.Models
{
    [Serializable]
    public class UserProfileXML
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }

        [XmlArrayItem(ElementName = "Image")]
        public List<ImageXML> Images;
    }
}
