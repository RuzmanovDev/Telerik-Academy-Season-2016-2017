using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroesUniverse.Models
{
    public class Superhero
    {
        private ICollection<Fraction> fractions;
        private ICollection<Power> powers;

        public Superhero()
        {
            this.fractions = new HashSet<Fraction>();
            this.powers = new HashSet<Power>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        [Required]
        public string SecretIdentity { get; set; }

        public AlignmentType Alignment { get; set; }

        [Required]
        [MinLength(1)]
        public string Story { get; set; }

        public virtual City City { get; set; }

        public int CityId { get; set; }

        public virtual ICollection<Fraction> Fraction
        {
            get { return this.fractions; }
            set { this.fractions = value; }
        }

        public virtual ICollection<Power> Powers
        {
            get { return this.powers; }
            set { this.powers = value; }
        }
    }
}
