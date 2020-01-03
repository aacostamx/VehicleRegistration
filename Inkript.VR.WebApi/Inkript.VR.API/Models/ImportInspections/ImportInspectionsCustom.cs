using System;

namespace Inkript.VR.API.Models
{
    public class ImportInspectionsCustom
    {
        public int FileInfoInspectionId { get; set; }
        public int CarUniqueNumberVal { get; set; }
        public DateTime InspectionDate { get; set; }
        public int PlateNumber { get; set; }
        public int PlateCodeId { get; set; }
        public string CertificateNo { get; set; }
        public string Result { get; set; }
        public string Chassis { get; set; }
        public DateTime ImportDate { get; set; }
    }
}