using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class CarStatus {
        public virtual int CarStatusId { get; set; }
        public virtual string StatusNameEn { get; set; }
        public virtual string StatusNameAr { get; set; }
    }
}
