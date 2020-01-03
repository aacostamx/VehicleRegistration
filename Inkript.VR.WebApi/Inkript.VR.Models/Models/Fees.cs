using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Inkript.VR.Models
{
    public class Fees
    {
        public Fees()
        {
            BPFee = new List<BPFee>();
            ExemptedFees = new List<ExemptedFees>();
        }
        public virtual long FeeId { get; set; }
        public virtual long? FeeCode { get; set; }
        public virtual FeeCategory FeeCategory { get; set; }
        public virtual Status Status { get; set; }
        public virtual string FeeNameEn { get; set; }
        public virtual string FeeNameAr { get; set; }
        public virtual int? FeeType { get; set; }
        public virtual float? FeeValue { get; set; }
        public virtual string FeeSP { get; set; }
        public virtual string Api { get; set; }
        public float? FeeTotal { get; set; }
        [IgnoreDataMember]
        public decimal? TaxPercentageApplicable { get; set; }
        public virtual IList<BPFee> BPFee { get; set; }
        public virtual IList<ExemptedFees> ExemptedFees { get; set; }
    }
}