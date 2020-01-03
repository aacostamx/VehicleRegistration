using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class VehicleCategory {
        public virtual int VehicleCategoryId { get; set; }
        public virtual string CategoryDescEn { get; set; }
        public virtual int StatusId { get; set; }
    }
}
