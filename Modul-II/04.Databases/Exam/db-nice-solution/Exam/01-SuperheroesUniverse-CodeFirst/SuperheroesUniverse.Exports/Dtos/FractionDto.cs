namespace SuperheroesUniverse.Exports.Dtos
{
    using System.Xml.Serialization;

    public class FractionDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("membersCount")]
        public int MembersCount { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlArray("planets")]
        public string[] Planets { get; set; }
    }
}
