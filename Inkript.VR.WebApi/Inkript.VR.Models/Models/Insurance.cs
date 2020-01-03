using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class Insurance {
        public virtual int InsuranceId { get; set; }
        public virtual string InsuranceName { get; set; }
        public virtual int StatusId { get; set; }
    }
}
