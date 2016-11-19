namespace SuperheroesUniverse.Importer.Dto
{
    using System.Collections.Generic;

    public class Superhero
    {
        public string Name { get; set; }
        public string SecretIdentity { get; set; }
        public string Alignment { get; set; }
        public string Story { get; set; }
        public City City { get; set; }
        public ICollection<string> Powers { get; set; }
        public ICollection<string> Fractions { get; set; }
    }
}
