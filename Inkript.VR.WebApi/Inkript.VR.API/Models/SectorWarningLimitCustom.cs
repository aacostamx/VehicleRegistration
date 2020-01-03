using System;
using System.Text;
using System.Collections.Generic;


namespace Inkript.VR.API.Models {
    
    public class SectorWarningLimitCustom {
        public int VehicleTypeId { get; set; }
        public int SectorId { get; set; }
        public int PlateCodeId { get; set; }
        public string WarningLimit { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj) {
			if (obj == null) return false;
			var t = obj as SectorWarningLimitCustom;
			if (t == null) return false;
			if (VehicleTypeId == t.VehicleTypeId
			 && SectorId == t.SectorId
			 && PlateCodeId == t.PlateCodeId)
				return true;

			return false;
        }
        public override int GetHashCode() {
			int hash = GetType().GetHashCode();
			hash = (hash * 397) ^ VehicleTypeId.GetHashCode();
			hash = (hash * 397) ^ SectorId.GetHashCode();
			hash = (hash * 397) ^ PlateCodeId.GetHashCode();

			return hash;
        }
        #endregion
    }
}
