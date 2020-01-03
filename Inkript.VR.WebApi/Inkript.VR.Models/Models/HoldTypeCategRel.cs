using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class HoldTypeCategRel {
        public virtual int HoldTypeId { get; set; }
        public virtual int LockedCategoryId { get; set; }
    }
}
