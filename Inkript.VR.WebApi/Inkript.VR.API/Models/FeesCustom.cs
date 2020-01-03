using Newtonsoft.Json;
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
        [JsonIgnore]
        public int FeeId { get; set; }
        public long? FeeCode { get; set; }
        public string FeeNameEn { get; set; }
        public string FeeNameAr { get; set; }
        public int? FeeType { get; set; }
        public float? FeeValue { get; set; }
        [JsonIgnore]
        public float? FeeTotal { get; set; }
        public string FeeSP { get; set; }
        public string Api { get; set; }
        [Required]
        public int FeeCategoryId { get; set; }
        [Required]
        public int StatusId { get; set; }

        public IList<BPFeeCustom> BPFee { get; set; }
    }
}
