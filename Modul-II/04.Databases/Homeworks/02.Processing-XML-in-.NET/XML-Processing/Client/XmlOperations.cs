using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace Client
{
    public class XmlOperations
    {
        internal static void Main(string[] args)
        {
            var url = "../../Catalogue.xml";

            // ex 2
            ExtractUniqueArtistXMLDomParser(url);
            PrintSeperator();

            // ex 3
            ExtractUniqueArtistXpath(url);
            PrintSeperator();

            // ex 4
            DeleteAlbumsWithPriceHigherThan20(url);

            //ex 5
            PrintSongTitlesUsingXmlReader(url);
            PrintSeperator();

            // ex 6
            PrintSongsTitleWithLINQ(url);
            PrintSeperator();

            // ex 7
            CreatePersonFromTXT();

            // ex 8
            CreateAlbumsViaXmlWritter(url);

            // ex 9
            TraverseDirAndWriteInXmlUsingXmlWritter();

            // ex 10
            TraverseXDocument();

            // ex 11
            GetPriceForAlbumsFiveYearsAgo(url);
            PrintSeperator();

            //ex 12
            GetPriceForAlbumsFiveYearsAgoLINQ(url);
            PrintSeperator();

            // ex 14
            ApplyXslt(url);

            // ex 16 
            ValiateXml(url);

        }

        private static void ValiateXml(string url)
        {
            Console.WriteLine("Validating xml with xsd");
            var xdoc = XDocument.Load(url);
            var schemas = new XmlSchemaSet();
            schemas.Add("catalogue-academy-com:music", @"../../../Catalogue.xsd");

            xdoc.Validate(schemas, null);
        }

        private static void ApplyXslt(string url)
        {
            var xsltUrl = @"../../style.xslt";
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltUrl);
            xslt.Transform(url, "../../catalog.html");
        }

        private static void GetPriceForAlbumsFiveYearsAgoLINQ(string url)
        {
            Console.WriteLine("Price of albums 5 years ago with LINQ");

            var document = XDocument.Load(url);

            var filtered = from album in document.Descendants("album")
                           where int.Parse(album.Element("year").Value) < 2011
                           select album.Element("price").Value;

            PrintEnumerable(filtered);
        }

        private static void GetPriceForAlbumsFiveYearsAgo(string url)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);
            string xPathQuery = "/catalogue/album[year<=2011]/price";

            var albumsFrom5YearsAgo = xmlDoc.SelectNodes(xPathQuery);

            Console.WriteLine("Price for albums from 5 years ago: ");
            foreach (XmlNode album in albumsFrom5YearsAgo)
            {
                var albumName = album.InnerText;
                Console.WriteLine(albumName);
            }
        }

        private static void TraverseXDocument()
        {
            string dirPath = @"../../";

            var rootDir = Traverse(dirPath);
            rootDir.Save("../../dirXDocument.xml");

            var currentDir = Directory.GetCurrentDirectory();
            var savedDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug"));
            Console.WriteLine("result saved as " + savedDir + "dir.xml");
        }

        private static XElement Traverse(string dir)
        {
            var element = new XElement("dir", new XAttribute("path", dir));

            foreach (var directory in Directory.GetDirectories(dir))
            {
                element.Add(Traverse(directory));
            }

            foreach (var file in Directory.GetFiles(dir))
            {
                element.Add(new XElement("file",
                    new XAttribute("name", Path.GetFileNameWithoutExtension(file)),
                    new XAttribute("ext", Path.GetExtension(file))));
            }

            return element;
        }

        private static void TraverseDirAndWriteInXmlUsingXmlWritter()
        {
            string dirPath = @"../../";

            using (XmlTextWriter writer = new XmlTextWriter("../../dir.xml", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 4;

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                writer.WriteStartDocument();
                writer.WriteStartElement("root");

                foreach (var directory in Directory.GetDirectories(dirPath))
                {
                    writer.WriteStartElement("dir");
                    writer.WriteAttributeString("path", directory);
                    writer.WriteEndElement();
                }

                foreach (var file in Directory.GetFiles(dirPath))
                {
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("name", Path.GetFileNameWithoutExtension(file));
                    writer.WriteAttributeString("ext", Path.GetExtension(file));
                    writer.WriteEndElement();
                }

                writer.WriteEndDocument();
            }

            var currentDir = Directory.GetCurrentDirectory();
            var savedDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug"));
            Console.WriteLine("result saved as " + savedDir + "dir.xml");
        }

        private static void CreateAlbumsViaXmlWritter(string url)
        {
            using (XmlReader reader = XmlReader.Create(url))
            {
                using (var writer = new XmlTextWriter("../../albums.xml", Encoding.Default))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "album")
                        {
                            XmlReader subtree = reader.ReadSubtree();
                            while (subtree.Read())
                            {
                                if (subtree.NodeType == XmlNodeType.Element && subtree.Name == "name")
                                {
                                    writer.WriteElementString("name", subtree.ReadInnerXml());
                                }
                                else if (subtree.NodeType == XmlNodeType.Element && subtree.Name == "artist")
                                {
                                    writer.WriteElementString("artist", subtree.ReadInnerXml());
                                    writer.WriteStartElement("album");
                                }
                            }
                        }
                    }

                    writer.WriteEndDocument();
                }
            }
        }

        private static void CreatePersonFromTXT()
        {
            string[] data = File.ReadAllLines("../../PersonInfo.txt");
            string[] currentLine = new[] { "name", "address", "phone" };

            XElement root = new XElement("personInfo");
            XElement person = new XElement("person");
            for (int i = 0; i < data.Length; i++)
            {
                person.Add(new XElement(currentLine[i % 3], data[i]));

                if (i % 3 == 0)
                {
                    root.Add(person);
                }

            }

            root.Save("../../Person.Xml");
        }

        private static void PrintSongsTitleWithLINQ(string url)
        {
            XDocument xmlDoc = XDocument.Load(url);
            var allSongs = from album in xmlDoc.Descendants("album")
                           from songs in album.Descendants("songs")
                           from song in album.Descendants("song")
                           from title in song.Descendants("title")
                           select new
                           {
                               Title = title.Value
                           };

            foreach (var item in allSongs)
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintSongTitlesUsingXmlReader(string url)
        {
            using (XmlReader reader = XmlReader.Create(url))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "song")
                    {
                        XmlReader subtree = reader.ReadSubtree();
                        while (subtree.Read())
                        {
                            if (subtree.NodeType == XmlNodeType.Element && subtree.Name == "title")
                            {
                                Console.WriteLine(subtree.ReadInnerXml());
                            }
                        }
                    }
                }
            }
        }

        private static void DeleteAlbumsWithPriceHigherThan20(string url)
        {
            var doc = new XmlDocument();
            doc.Load(url);

            var root = doc.DocumentElement;

            foreach (XmlNode item in root.ChildNodes)
            {
                bool isHigherThan20 = false;
                foreach (XmlNode element in item.ChildNodes)
                {
                    if (element.Name == "price")
                    {
                        var price = int.Parse(element.InnerText);
                        if (price > 20)
                        {
                            isHigherThan20 = true;
                            break;
                        }
                    }
                }

                if (isHigherThan20)
                {
                    root.RemoveChild(item);
                }
            }
            doc.Save(url);
        }

        private static void ExtractUniqueArtistXpath(string url)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);
            string xPathQuery = "/catalogue/album/artist";

            XmlNodeList artistList = xmlDoc.SelectNodes(xPathQuery);
            var uniqueArtist = new HashSet<string>();

            foreach (XmlNode artist in artistList)
            {
                var currentArtist = artist.InnerText;
                if (!uniqueArtist.Contains(currentArtist))
                {
                    uniqueArtist.Add(currentArtist);
                }
            }

            PrintEnumerable(uniqueArtist);
        }

        private static void ExtractUniqueArtistXMLDomParser(string url)
        {
            var doc = new XmlDocument();
            doc.Load(url);

            XmlNode root = doc.DocumentElement;

            var artists = new HashSet<string>();

            foreach (XmlNode item in root.ChildNodes)
            {
                foreach (XmlNode element in item.ChildNodes)
                {
                    if (element.Name == "artist")
                    {
                        artists.Add(element.InnerText);
                    }
                }
            }

            PrintEnumerable(artists);
        }

        private static void PrintEnumerable(IEnumerable<string> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintSeperator()
        {
            Console.WriteLine(new string('-', 30));
        }
    }
}
