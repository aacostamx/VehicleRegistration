using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.API.Models {
    
    public class DocumentProcessRelationshipCustom {
        public int DPRId { get; set; }
        public int? DocumentId { get; set; }
        public int? BPId { get; set; }
        public int? SectorId { get; set; }
        public int? VehicleTypeId { get; set; }
    }
}
