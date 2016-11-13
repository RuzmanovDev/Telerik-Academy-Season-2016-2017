using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class Car
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Model { get; set; }

        [Required]
        public TransmitionType Transmition { get; set; }

        [Required]
        public string Year { get; set; }

        public decimal Price { get; set; }

        public virtual Dealer Dealer { get; set; }

        public int DealerId { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
