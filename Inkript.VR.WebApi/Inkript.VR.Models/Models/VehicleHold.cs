using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class VehicleHold {
        public virtual int VehicleHoldId { get; set; }
        public virtual int CarUniqueNumber { get; set; }
        public virtual string PlateNumber { get; set; }
        public virtual int PlateCodeId { get; set; }
        public virtual int LockedCategoryId { get; set; }
        public virtual int SourceId { get; set; }
        public virtual int HoldTypeId { get; set; }
        public virtual string ReferenceNumber { get; set; }
        public virtual DateTime DateIssued { get; set; }
        public virtual DateTime EffectiveDate { get; set; }
        public virtual string Description { get; set; }
        public virtual int StatusId { get; set; }
        public virtual DateTime? DateSettled { get; set; }
        public virtual string SettlementNumber { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
    }
}
