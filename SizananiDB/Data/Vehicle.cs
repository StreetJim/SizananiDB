using System;
using System.Collections.Generic;

#nullable disable

namespace SizananiDB.Data
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            ContractorVehicles = new HashSet<ContractorVehicle>();
            Contractors = new HashSet<Contractor>();
        }

        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }
        public int? Weight { get; set; }

        public virtual ICollection<ContractorVehicle> ContractorVehicles { get; set; }
        public virtual ICollection<Contractor> Contractors { get; set; }
    }
}
