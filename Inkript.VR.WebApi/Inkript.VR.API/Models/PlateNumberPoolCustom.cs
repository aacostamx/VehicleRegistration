using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.API.Models {
    
    public class PlateNumberPoolCustom {
        public int PlateNumberPoolId { get; set; }
        public int? PlateCodeId { get; set; }
        public int? PlateRangeId { get; set; }
        public int StatusId { get; set; }
        public string PlateNumber { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
