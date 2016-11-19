using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Fraction
    {
        private ICollection<Planet> planetsUnderProtection;
        private ICollection<Superhero> members;

        public Fraction()
        {
            this.planetsUnderProtection = new HashSet<Planet>();
            this.members = new HashSet<Superhero>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public AlignmentType Alignment { get; set; }

        public virtual ICollection<Planet> PlanetsUnderProtection
        {
            get { return this.planetsUnderProtection; }
            set { this.planetsUnderProtection = value; }
        }

        public virtual ICollection<Superhero> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }


    }
}