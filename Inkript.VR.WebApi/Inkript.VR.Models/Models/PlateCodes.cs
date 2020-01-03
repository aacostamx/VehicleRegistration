using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class PlateCodes {
        public virtual int PlateCodeId { get; set; }
        public virtual string CodeDescEn { get; set; }
        public virtual string CodeDescAr { get; set; }
        public virtual int BranchId { get; set; }
    }
}
