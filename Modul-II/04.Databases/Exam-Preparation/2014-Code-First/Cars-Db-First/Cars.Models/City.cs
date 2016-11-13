using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars.Models
{
    public class City
    {
        private ICollection<Dealer> dealers;

        public City()
        {
            this.dealers = new HashSet<Dealer>();
        }

        public ICollection<Dealer> Dealers
        {
            get { return this.dealers; }

            set { this.dealers = value; }
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

    }
}