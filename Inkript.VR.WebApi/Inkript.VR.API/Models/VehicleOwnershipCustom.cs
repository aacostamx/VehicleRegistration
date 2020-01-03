using System;

namespace Inkript.VR.API.Models
{
    public class VehicleOwnershipCustom {
        public int VehicleOwnershipId { get; set; }
        public int? OwnerId { get; set; }
        public int? OwnerTypeId { get; set; }
        public int? RegisteredCarId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? AcquisitionDate { get; set; }
    }
}
