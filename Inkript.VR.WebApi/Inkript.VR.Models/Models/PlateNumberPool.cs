using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Inkript.VR.Models {
    
    public class PlateNumberPool {
        public virtual int PlateNumberPoolId { get; set; }
        [IgnoreDataMember]
        public int? PlateCodeId { get; set; }
        public PlateCodes PlateCodes { get; set; }
        public virtual int? PlateRangeId { get; set; }
        public virtual int StatusId { get; set; }
        public virtual string PlateNumber { get; set; }
        public virtual int? UpdatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
    }
}
