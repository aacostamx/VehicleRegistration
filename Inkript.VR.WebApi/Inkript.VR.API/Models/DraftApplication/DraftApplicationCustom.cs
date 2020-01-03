using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class DraftApplicationCustom
    {
        [Required]
        public int BranchId { get; set; }
        public string CarDetails { get; set; }
        public string OwnerType { get; set; }
        public string OwnersInfo { get; set; }
        public string CarPlateInformation { get; set; }
        public string InsuranceCompany { get; set; }
        public string Fees { get; set; }
        public string BusinessProcess { get; set; }
        public string AutomaticallyCalculatedFees { get; set; }
        public string OutputDocuments { get; set; }
        public int? SectionId { get; set; }
        [Required]
        public int StatusId { get; set; }
        public int? DepartmentId { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}