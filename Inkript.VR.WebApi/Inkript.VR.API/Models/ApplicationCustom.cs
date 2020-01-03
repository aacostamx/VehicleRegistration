using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class ApplicationCustom
    {
        public ApplicationCustom() { }
        [JsonIgnore]
        public int ApplicationId { get; set; }
        [Required]
        public int BranchId { get; set; }
        public int? SectionId { get; set; }
        public string BusinessProcess { get; set; }
        public string CarPlateInfo { get; set; }
        public int CarUniqueNumber { get; set; }
        public string CarDetails { get; set; }
        public int? OwnerType { get; set; }
        public string OwnersInfo { get; set; }
        public string Fees { get; set; }
        public string Documents { get; set; }
        public string AutomaticallyCalculatedFees { get; set; }
        public string OutputDocuments { get; set; }
        public int? CreatedBy { get; set; }
        public string ProcessedBy { get; set; }
        public string InvoicesNumbers { get; set; }
        [Required]
        public int StatusId { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
