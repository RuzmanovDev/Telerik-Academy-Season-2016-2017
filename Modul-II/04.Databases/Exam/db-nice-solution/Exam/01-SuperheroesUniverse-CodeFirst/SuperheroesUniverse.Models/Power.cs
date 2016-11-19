namespace SuperheroesUniverse.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Power
    {
        private ICollection<Superhero> superheroes;

        public Power()
        {
            this.superheroes = new HashSet<Superhero>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(35)]
        [Index(IsUnique = true)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Superhero> Superheroes
        {
            get { return this.superheroes; }
            set { this.superheroes = value; }
        }
    }
}
