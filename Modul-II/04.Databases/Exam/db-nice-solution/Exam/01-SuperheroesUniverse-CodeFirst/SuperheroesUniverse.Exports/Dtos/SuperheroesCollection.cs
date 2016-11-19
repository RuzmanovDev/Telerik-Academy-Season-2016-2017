namespace SuperheroesUniverse.Exports.Dtos
{
    using System.Xml.Serialization;

    [XmlRoot("superheroes")]
    public class SuperheroesCollection
    {
        [XmlArray("superheroes")]
        [XmlArrayItem("superhero")]
        public SuperheroDto[] Superheroes { get; set; }

        public SuperheroDto this[int i]
        {
            get { return Superheroes[i]; }
        }
    }
}
