using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inkript.VR.API.BusinessLayerLogic
{
    public class UtilizationApiBLO
    {
        public ObjectResult<int> GetUtilizationby(int sectorId, int vehicleTypeId)
        {
            UtilizationBLO biz = new UtilizationBLO();
            SectorsBLO sectorsBiz = new SectorsBLO();
            VehicleTypesBLO vehicleTypesBiz = new VehicleTypesBLO();

            ObjectResult<int> output = new ObjectResult<int>();

            try
            {
                if (!sectorsBiz.SectorExist(sectorId))
                {
                    output.Message = string.Format("Sector Id {0} Not Found", sectorId);
                    return output;
                }

                if (!vehicleTypesBiz.VehicleTypeExist(vehicleTypeId))
                {
                    output.Message = string.Format("VehicleType Id {0} Not Found", vehicleTypeId);
                    return output;
                }
                output.Result = biz.GetUtilizationby(sectorId, vehicleTypeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = 0;
                output.Success = false;
                output.Message = "Failed to Get Utilization by Sector and Vehicle Type";
            }
            return output;
        }
    }
}