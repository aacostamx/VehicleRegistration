using System.Collections.Generic;


namespace Inkript.VR.Models
{

    public class ExemptionCategories
    {
        public ExemptionCategories()
        {
            ExemptedFees = new List<ExemptedFees>();
        }
        public virtual int ExemptionCategoryId { get; set; }
        public virtual string ExemptionCategoryDescEn { get; set; }
        public virtual string ExemptionCategoryDescAr { get; set; }
        public virtual IList<ExemptedFees> ExemptedFees { get; set; }
    }
}

