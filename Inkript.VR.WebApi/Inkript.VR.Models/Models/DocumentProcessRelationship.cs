using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class DocumentProcessRelationship {
        public virtual int DPRId { get; set; }
        public virtual int? DocumentId { get; set; }
        public virtual int? BPId { get; set; }
        public virtual int? SectorId { get; set; }
        public virtual int? VehicleTypeId { get; set; }
        public virtual string Mandatory { get; set; }
    }
}
