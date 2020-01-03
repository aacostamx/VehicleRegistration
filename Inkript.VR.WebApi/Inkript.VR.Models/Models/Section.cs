using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class Section {
        public virtual int SectionId { get; set; }
        public virtual string SectionNameEn { get; set; }
        public virtual string SectionNameAr { get; set; }
        public virtual int? BranchId { get; set; }
    }
}
