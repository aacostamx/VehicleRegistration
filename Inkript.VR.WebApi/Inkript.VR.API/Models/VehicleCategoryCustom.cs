using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.API.Models {
    
    public class VehicleCategoryCustom {
        public VehicleCategoryCustom() { }
        public int VehicleCategoryId { get; set; }
        public string CategoryDescEn { get; set; }
        public int SectorId { get; set; }
        public int StatusId { get; set; }
    }
}
