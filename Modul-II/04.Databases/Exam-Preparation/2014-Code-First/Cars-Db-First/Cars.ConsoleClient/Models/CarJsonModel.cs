using Cars.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.ConsoleClient.Models
{
    public class CarJsonModel
    {
        public string Year { get; set; }

        public TransmitionType TransmitionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DealerJsonModel Dealer { get; set; }
    }
}
