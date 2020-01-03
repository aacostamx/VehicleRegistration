using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class Districts {
        public virtual int DistrictId { get; set; }
        public virtual string DistrictNameEn { get; set; }
        public virtual string DistrictNameAr { get; set; }
        public virtual int GovernateId { get; set; }
        //public virtual IList<Cities> Cities { get; set; }
    }
}
