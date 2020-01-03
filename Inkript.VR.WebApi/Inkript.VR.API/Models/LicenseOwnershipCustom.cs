using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.API.Models {
    
    public class LicenseOwnershipCustom {
        public int LicenseOwnershipId { get; set; }
        public int? OwnerId { get; set; }
        public int? OwnerTypeId { get; set; }
        public string PlateNumber { get; set; }
        public int? PlateCodeId { get; set; }
        public int? SectorId { get; set; }
        public int? VehicleTypeId { get; set; }
        public int? PassengersNo { get; set; }
        public int? NetWeight { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Comments { get; set; }
    }
}
