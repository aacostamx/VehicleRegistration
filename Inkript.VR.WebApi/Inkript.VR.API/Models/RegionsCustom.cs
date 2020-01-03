using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.API.Models {
    
    public class RegionsCustom {
        public RegionsCustom() { }
        public int RegionId { get; set; }
        public string RegionNameEn { get; set; }
        public string RegionNameAr { get; set; }
        public int DistrictId { get; set; }
    }
}
