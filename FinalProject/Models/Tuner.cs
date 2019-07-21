using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Tuner
    {
        public string Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string SubModel { get; set; }
         
        public string Color { get; set; }

        public string Picture { get; set; }
        public string Vin { get; set; }
        public int Year { get; set; } 
    }
}

