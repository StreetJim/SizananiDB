using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SizananiDB.Models
{
    public class CreateVehicleViewModel
    {
        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Weight { get; set; }
    }
}
