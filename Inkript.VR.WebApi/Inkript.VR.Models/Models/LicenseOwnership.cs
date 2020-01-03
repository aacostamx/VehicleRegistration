using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class LicenseOwnership {
        public virtual int LicenseOwnershipId { get; set; }
        public virtual int? OwnerId { get; set; }
        public virtual int? OwnerTypeId { get; set; }
        public virtual string PlateNumber { get; set; }
        public virtual int? PlateCodeId { get; set; }
        public virtual int? SectorId { get; set; }
        public virtual int? VehicleTypeId { get; set; }
        public virtual int? PassengersNo { get; set; }
        public virtual int? NetWeight { get; set; }
        public virtual int? StatusId { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? ExpiryDate { get; set; }
        public virtual string Comments { get; set; }
    }
}
