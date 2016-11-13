using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class Manufacturer
    {   
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}
