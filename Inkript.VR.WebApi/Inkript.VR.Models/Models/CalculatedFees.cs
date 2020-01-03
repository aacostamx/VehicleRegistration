using System;

namespace Inkript.VR.Models
{
    public class CalculatedFees
    {
        public virtual int ApplicationId { get; set; }
        public virtual int FeeId { get; set; }
        public virtual string FeeNameEn { get; set; }
        public virtual string FeeNameAr { get; set; }
        public virtual int FeeType { get; set; }
        public virtual float FeeValue { get; set; }
        public virtual string FeeSP { get; set; }
        public virtual float FeeTotal { get; set; }
        public virtual int FeeCategoryId { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
        public virtual int StatusId { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as CalculatedFees;
            if (t == null) return false;
            if (ApplicationId == t.ApplicationId
             && FeeId == t.FeeId)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ ApplicationId.GetHashCode();
            hash = (hash * 397) ^ FeeId.GetHashCode();

            return hash;
        }
        #endregion
    }
}
