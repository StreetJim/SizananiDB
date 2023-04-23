using System;
using System.Collections.Generic;

#nullable disable

namespace SizananiDB.Data
{
    public partial class ContractorVehicle
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public int? ContactorId { get; set; }

        public virtual Contractor Contactor { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
