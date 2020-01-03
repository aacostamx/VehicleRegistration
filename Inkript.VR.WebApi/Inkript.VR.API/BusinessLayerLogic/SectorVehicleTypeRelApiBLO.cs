using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inkript.VR.API.BusinessLayerLogic
{
    public class SectorVehicleTypeRelApiBLO
    {
        public ObjectResult<int> GetSectorVehicleTypeRef(int? sectorId, int? vehicleTypeId)
        {
            SectorVehicleTypeRelBLO biz = new SectorVehicleTypeRelBLO();
            ObjectResult<int> output = new ObjectResult<int>();

            try
            {
                output.Result = biz.GetSectorVehicleTypeRef(sectorId, vehicleTypeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = 0;
                output.Success = false;
                output.Message = "Failed to Get Sector Vehicle Type Ref";
            }
            return output;
        }
    }
}