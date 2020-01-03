using System.Collections.Generic;

namespace Inkript.VR.Models
{
    public class FeeCategory
    {
        public FeeCategory()
        {
            Fees = new List<Fees>();
        }
        public virtual int FeeCategoryId { get; set; }
        public virtual string FeeCategoryNameEn { get; set; }
        public virtual string FeeCategoryNameAr { get; set; }
        public virtual int FeeCategorySequence { get; set; }
        public virtual IList<Fees> Fees { get; set; }
    }
}

