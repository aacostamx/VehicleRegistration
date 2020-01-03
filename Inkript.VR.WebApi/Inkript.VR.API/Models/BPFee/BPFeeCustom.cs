
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class BPFeeCustom
    {
        [Required]
        public int BPId { get; set; }
        [Required]
        public int SectorId { get; set; }
        [Required]
        public int VTId { get; set; }
        public decimal? TaxPercentageApplicable { get; set; }
    }
}