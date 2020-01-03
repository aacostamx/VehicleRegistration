using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class TRIM {
        public virtual int TrimId { get; set; }
        public virtual string TrimNameEn { get; set; }
        public virtual string TrimNameAr { get; set; }
        public virtual int ModelId { get; set; }
        public virtual int StatusId { get; set; }
    }
}
