using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class Colors {
        public virtual int ColorId { get; set; }
        public virtual string ColorNameEn { get; set; }
        public virtual string ColorNameAr { get; set; }
        public virtual Status Status { get; set; }
    }
}
