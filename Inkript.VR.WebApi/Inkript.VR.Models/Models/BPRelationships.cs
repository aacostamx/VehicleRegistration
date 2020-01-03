using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class BPRelationships {
        public virtual int BPRelationshipsId { get; set; }
        public virtual int BPId { get; set; }
        public virtual int? AssociatedBP { get; set; }
        public virtual bool? Mandatory { get; set; }
    }
}
