using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SizananiDB.Models
{
    public class ContractorVehicleIndexViewModel
    {
        public int Id { get; set; }

        public IEnumerable<SelectListItem> Contractors { get; set; }
    }

    public class LinkContractorViewModel
    {
        public string Contractor { get; set; }

        [Required]
        public int ContractorId { get; set; }

        [Required]
        public int VehicleId { get; set; }
        public IEnumerable<SelectListItem> Vehicles { get; set; }
    }
}
