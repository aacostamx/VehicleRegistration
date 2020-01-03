using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.API.Models {
    
    public class SectorsLimitCustom {
        public int SectorId { get; set; }
        public string SectorNameEn { get; set; }
        public string SectorNameAr { get; set; }
        public int PlateCodeId { get; set; }
        public int? VehicleTypeId { get; set; }
        public int? BranchId { get; set; }
        public int? TotalAvailable { get; set; }
        public string WarningLimit { get; set; }
    }
}
