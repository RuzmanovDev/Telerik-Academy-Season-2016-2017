namespace SuperheroesUniverse.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    public class Superhero
    {
        private ICollection<Fraction> fractions;
        private ICollection<Power> powers;
        private ICollection<HeroRelationship> relationships;

        public Superhero()
        {
            this.fractions = new HashSet<Fraction>();
            this.powers = new HashSet<Power>();
            this.relationships = new HashSet<HeroRelationship>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        [Index(IsUnique = true)]
        public string SecretIdentity { get; set; }

        public Alignment Alignment { get; set; }

        [MinLength(1)]
        [DataType("ntext")]
        [Required]
        public string Story { get; set; }

        public int CityId { get; set; }

        [Required]
        public virtual City City { get; set; }

        public virtual ICollection<Power> Powers
        {
            get { return this.powers; }
            set { this.powers = value; }
        }

        public virtual ICollection<Fraction> Fractions
        {
            get { return this.fractions; }
            set { this.fractions = value; }
        }

        public virtual ICollection<HeroRelationship> Relationships
        {
            get { return this.relationships; }
            set { this.relationships = value; }
        }
    }
}
