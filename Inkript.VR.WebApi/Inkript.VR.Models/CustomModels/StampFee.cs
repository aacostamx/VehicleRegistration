using System.Runtime.Serialization;

namespace Inkript.VR.Models
{
    public class StampFee
    {
        public int FeeId { get; set; }
        public FeeCategory FeeCategory { get; set; }
        public Status Status { get; set; }
        public string FeeNameEn { get; set; }
        public string FeeNameAr { get; set; }
        public int? FeeType { get; set; }
        public float? FeeValue { get; set; }
        public string FeeSP { get; set; }
        public string Api { get; set; }
        public float? FeeTotal { get; set; }
        public string FeeMessageEn { get; set; }
        public string FeeMessageAr { get; set; }
        [IgnoreDataMember]
        public int StatusId { get; set; }
        [IgnoreDataMember]
        public int FeeCategoryId { get; set; }
    }
}
