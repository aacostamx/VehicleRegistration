using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class OutputGroup {
        public virtual int OutputGroupId { get; set; }
        public virtual int? BPId { get; set; }
        public virtual int? OutputDeliverableId { get; set; }
    }
}
