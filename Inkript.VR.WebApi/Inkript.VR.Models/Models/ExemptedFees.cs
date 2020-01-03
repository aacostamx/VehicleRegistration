using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.Models {
    
    public class ExemptedFees {
        public virtual int ExemptedFeeId { get; set; }
        public virtual int ExemptedCategoryId { get; set; }
        public virtual int StatusId { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as ExemptedFees;
			if (t == null) return false;
			if (ExemptedFeeId == t.ExemptedFeeId
			 && ExemptedCategoryId == t.ExemptedCategoryId)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ ExemptedFeeId.GetHashCode();
			hash = (hash * 397) ^ ExemptedCategoryId.GetHashCode();

			return hash;
        }
        #endregion
    }
}
