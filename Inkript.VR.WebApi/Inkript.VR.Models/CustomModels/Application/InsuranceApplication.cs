using System;

namespace Inkript.VR.Models
{
    public class InsuranceApplication
    {
        public int? InsuranceCompanyCode { get; set; }
        public string InsuranceNumber { get; set; }
        public string InsuranceVignette { get; set; }
        public DateTime? InsuranceDate { get; set; }
        public DateTime? InsuranceExpiryDate { get; set; }
    }
}
