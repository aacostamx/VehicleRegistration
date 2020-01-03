using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;

namespace Inkript.VR.API
{
    public class VehicleRegistrationFeeApiBLO
    {
        public ObjectResult<VehicleRegistrationFee> NewVehicleRegistrationFee(string certification_Id)
        {
            VehicleRegistrationBLO biz = new VehicleRegistrationBLO();
            ObjectResult<VehicleRegistrationFee> output = new ObjectResult<VehicleRegistrationFee>();

            try
            {
                output.Result = biz.NewVehicleRegistrationFee(certification_Id);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to add new Vehicle Registration Fee";
            }
            return output;
        }
    }
}