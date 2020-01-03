using System;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class ImportCustomFilter
    {
        [Required]
        public DateTime YearFrom { get; set; }
        [Required]
        public DateTime YearTo { get; set; }
        public string OperationType { get; set; }
        public string Chassis { get; set; }
        public string MotorNumber { get; set; }
        public string BrandId { get; set; }
        public int? ModelId { get; set; }
        public int? ColorId { get; set; }
        public int? Cylinders { get; set; }
        public int? OfficeId { get; set; }
        public int? ProductionYear { get; set; }
        public string CertificateId { get; set; }
        public string ImporterCode { get; set; }
        public string ImporterName { get; set; }
        public bool? Discounted { get; set; }
    }
}