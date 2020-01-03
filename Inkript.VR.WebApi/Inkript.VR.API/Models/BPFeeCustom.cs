using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{

    public class BPFeeCustom {
        [JsonIgnore]
        public int BPFeeId { get; set; }
        [JsonIgnore]
        public int FeeId { get; set; }
        [Required]
        public int BPId { get; set; }
        [Required]
        public int SectorId { get; set; }
        [Required]
        public int VTId { get; set; }
        public decimal? TaxPercentageApplicable { get; set; }
    }
}
