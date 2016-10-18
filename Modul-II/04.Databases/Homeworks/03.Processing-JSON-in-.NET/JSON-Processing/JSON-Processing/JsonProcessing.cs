using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JSON_Processing
{
    public class JsonProcessing
    {
        public static object JsonConvert { get; private set; }

        static void Main(string[] args)
        {
            var rssUrl = @"https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            var client = new WebClient();
            var urlForDowloadedXml = @"../../data.xml";

            // ex 2 Dowload the file
            client.DownloadFile(rssUrl, urlForDowloadedXml);

            // ex 3 Parse it to JSON
            var urlForParsedJson = @"../../data.json";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(urlForDowloadedXml);

            string jsonText = Newtonsoft.Json.JsonConvert.SerializeXmlNode(xmlDoc);
            File.WriteAllText(urlForParsedJson, jsonText);

            // ex 4 Select all videos titles and print them on the console and ex 5 parse them to POCO
            var jsonObj = JObject.Parse(jsonText);

            var videos = jsonObj["feed"]["entry"]
                .Select(entry => Newtonsoft.Json.JsonConvert.DeserializeObject<Video>(entry.ToString()));

            foreach (var video in videos)
            {
                Console.WriteLine(video.Title);
            }

        }
    }
}
