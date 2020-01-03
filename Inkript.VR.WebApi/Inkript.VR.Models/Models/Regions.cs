using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class Regions {
        public virtual int RegionId { get; set; }
        public virtual string RegionNameEn { get; set; }
        public virtual string RegionNameAr { get; set; }
        public virtual Districts Districts { get; set; }
    }
}
