namespace SuperheroesUniverse.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    public class Fraction
    {
        private ICollection<Planet> planets;
        private ICollection<Superhero> superheroes;

        public Fraction()
        {
            this.planets = new HashSet<Planet>();
            this.superheroes = new HashSet<Superhero>();
        }

        public int Id { get; set; }

        public Alignment Alignment { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        [Required]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Planet> Planets
        {
            get { return this.planets; }
            set { this.planets = value; }
        }

        public virtual ICollection<Superhero> Superheroes
        {
            get { return this.superheroes; }
            set { this.superheroes = value; }
        }
    }
}
