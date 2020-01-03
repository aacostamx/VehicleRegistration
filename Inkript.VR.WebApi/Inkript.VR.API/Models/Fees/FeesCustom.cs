using Inkript.VR.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inkript.VR.API.Models
{
    public class FeesCustom
    {
        public FeesCustom()
        {
            BPFee = new List<BPFeeCustom>();
        }

        [Required]
        public string FeeNameEn { get; set; }
        [Required]
        public string FeeNameAr { get; set; }
        public string ExemptionLevel { get; set; }
        public int? FeeType { get; set; }
        public float? FeeValue { get; set; }
        public string FeeSP { get; set; }
        [Required]
        public int FeeCategoryId { get; set; }
        public bool? Active { get; set; }

        public IList<BPFeeCustom> BPFee { get; set; }
    }
}