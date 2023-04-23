using System;
using System.Collections.Generic;

#nullable disable

namespace SizananiDB.Data
{
    public partial class Contractor
    {
        public Contractor()
        {
            ContractorVehicles = new HashSet<ContractorVehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<ContractorVehicle> ContractorVehicles { get; set; }
    }
}
