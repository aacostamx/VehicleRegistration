using System;

namespace Inkript.VR.Models
{
    public class VehicleSearch : VehicleDetails
    {
        public int? CreatedBy { get; set; }
        public int? BranchId { get; set; }

        public DateTime? CertificateDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DateModified { get; set; }
        public int? FiscalYear { get; set; }
        public string ImporterCode { get; set; }
        public int? OfficeId { get; set; }
    }
}
