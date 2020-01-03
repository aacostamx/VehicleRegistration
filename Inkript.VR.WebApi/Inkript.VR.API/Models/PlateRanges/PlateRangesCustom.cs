using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class PlateRangesCustom
    {
        [Required]
        public string RangeName { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int StartNumber { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int EndNumber { get; set; }
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
        public int PriorityLevel { get; set; }
        public string Prefix { get; set; }
        public string DiplomaticLevel { get; set; }
    }
}