using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.API.Models {
    
    public class VehicleHoldCustom {
        public int VehicleHoldId { get; set; }
        public int CarUniqueNumber { get; set; }
        public string PlateNumber { get; set; }
        public int PlateCodeId { get; set; }
        public int LockedCategoryId { get; set; }
        public int SourceId { get; set; }
        public int HoldTypeId { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public DateTime? DateSettled { get; set; }
        public string SettlementNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
