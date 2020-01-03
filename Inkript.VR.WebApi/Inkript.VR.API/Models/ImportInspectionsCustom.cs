using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models {
    
    public class ImportInspectionsCustom {
        [JsonIgnore]
        public int ImportInspectionId { get; set; }
        public int FileInfoInspectionId { get; set; }
        public int? CarUniqueNumber { get; set; }
        [Required]
        public DateTime InspectionDate { get; set; }
        [Required]
        public string PlateNumber { get; set; }
        [Required]
        public int PlateCodeId { get; set; }
        [Required]
        public string CertificateNo { get; set; }
        [StringLength(1)]
        [Required]
        public string Result { get; set; }
        [JsonIgnore]
        public DateTime ImportDate { get; set; }
        public int? CreatedBy { get; set; }
        public string Chassis { get; set; }
    }
}
