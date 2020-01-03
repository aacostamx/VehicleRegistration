using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using InkriptRest;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Inkript.VR.API
{
    public class VehicleApiBLO
    {
        public ObjectResult<VehicleDetails> GetVehicleValue(VehicleDetails vehicleInfo)
        {
            VehicleBLO biz = new VehicleBLO();
            ObjectResult<VehicleDetails> output = new ObjectResult<VehicleDetails>();

            try
            {
                output.Result = biz.GetVehicleValue(vehicleInfo);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Vehicle Value";
            }
            return output;
        }

        public ObjectResult<VehicleSearch> VehicleSearch(int? carUniqueNumber, string certificateId)
        {
            VehicleBLO biz = new VehicleBLO();
            ObjectResult<VehicleSearch> output = new ObjectResult<VehicleSearch>();

            try
            {
                output.Result = biz.VehicleSearch(carUniqueNumber, certificateId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Vehicle Search";
            }
            return output;
        }
    }
}