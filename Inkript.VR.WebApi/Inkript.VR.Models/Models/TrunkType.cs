using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class TrunkType {
        public virtual int TrunkTypeId { get; set; }
        public virtual string TrunkTypeDescEn { get; set; }
        public virtual string TrunkTypeDescAr { get; set; }
        public virtual Status Status { get; set; }
    }
}
