namespace SuperheroesUniverse.Exports.Dtos
{
    using System.Xml.Serialization;

    public class SuperheroDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("secretIdentity")]
        public string SecretIdentity { get; set; }

        [XmlArray("powers")]
        public string[] Powers { get; set; }

        [XmlElement("alignment")]
        public string Alignment { get; set; }

        [XmlElement("city")]
        public string City { get; set; }
    }
}
