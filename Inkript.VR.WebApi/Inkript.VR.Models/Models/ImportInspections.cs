using System;
using System.Runtime.Serialization;

namespace Inkript.VR.Models
{

    public class ImportInspections {
        public virtual int ImportInspectionId { get; set; } 
        [IgnoreDataMember]
        public int FileInfoInspectionId { get; set; }
        public virtual FileInfoInspections FileInfoInspections { get; set; }
        public virtual int? CarUniqueNumber { get; set; }
        public virtual DateTime InspectionDate { get; set; }
        public virtual string PlateNumber { get; set; }
        public virtual int PlateCodeId { get; set; }
        public virtual string CertificateNo { get; set; }
        public virtual string Result { get; set; }
        public virtual DateTime ImportDate { get; set; }
        public virtual int? CreatedBy { get; set; }
        public virtual string Chassis { get; set; }
    }
}
