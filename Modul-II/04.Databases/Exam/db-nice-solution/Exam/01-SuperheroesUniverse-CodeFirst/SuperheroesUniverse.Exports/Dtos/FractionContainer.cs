namespace SuperheroesUniverse.Exports.Dtos
{
    using System.Xml.Serialization;

    [XmlRoot("fractions")]
    public class FractionContainer
    {
        [XmlArray("fractions")]
        [XmlArrayItem("fraction")]
        public FractionDto[] Fractions { get; set; }

        public FractionDto this[int i]
        {
            get { return Fractions[i]; }
        }
    }
}
