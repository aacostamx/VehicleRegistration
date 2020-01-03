using System;
using Inkript.VR.Business.DataAccessLayer;

namespace Inkript.VR.Business.BusinessLayer
{
    public class SectorVehicleTypeRelBLO
    {

        private SectorVehicleTypeRelDAO _da { get; set; }

        public SectorVehicleTypeRelBLO()
        {
            _da = new SectorVehicleTypeRelDAO();
        }

        public int GetSectorVehicleTypeRef(int? sectorId, int? vehicleTypeId)
        {
            return _da.GetSectorVehicleTypeRef(sectorId, vehicleTypeId);
        }
    }
}
