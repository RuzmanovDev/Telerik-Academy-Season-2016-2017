using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperheroesUniverse.Models
{
    public class City
    {
        private ICollection<Superhero> superheroes;

        public City()
        {
            this.superheroes = new HashSet<Superhero>();
        }

        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public int CountryId { get; set; }

        public virtual ICollection<Superhero> Superheroes
        {
            get { return this.superheroes; }

            set { this.superheroes = value; }
        }
    }
}