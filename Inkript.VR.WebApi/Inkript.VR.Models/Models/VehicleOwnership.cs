using System;

namespace Inkript.VR.Models
{
    public class VehicleOwnership
    {
        public virtual int VehicleOwnershipId { get; set; }
        public virtual int? OwnerId { get; set; }
        public virtual int? OwnerTypeId { get; set; }
        public virtual int? RegisteredVehicleId { get; set; }
        public virtual int? StatusId { get; set; }
        public virtual DateTime? AcquisitionDate { get; set; }
    }
}
