using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class PlateRangesCustom
    {
        public PlateRangesCustom() { }

        [JsonIgnore]
        public int PlateRangeId { get; set; }
        [Required]
        public string RangeName { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int StartNumber { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int EndNumber { get; set; }
        [JsonIgnore]
        public int? TotalAvailable { get; set; }
        [Required]
        public int SectorId { get; set; }
        [Required]
        public int VehicleTypeId { get; set; }
        public int PlateCodeId { get; set; }
        [Required]
        public int BranchId { get; set; }
        public string SQLSequence { get; set; }
        [Required]
        public int StatusId { get; set; }
        public int? PriorityLevel { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? ModifiedDate { get; set; }
        public string Prefix { get; set; }
        public string DiplomaticLevel { get; set; }
    }
}
