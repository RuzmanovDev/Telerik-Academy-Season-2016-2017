using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.ConsoleClient.Models
{
    [Serializable]
    public class ImageXML
    {
        public string ImageUrl { get; set; }

        public string FileExtension { get; set; }
    }
}
