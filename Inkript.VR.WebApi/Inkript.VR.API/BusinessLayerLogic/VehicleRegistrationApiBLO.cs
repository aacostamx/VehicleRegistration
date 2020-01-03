using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;

namespace Inkript.VR.API
{
    public class VehicleRegistrationApiBLO
    {
        public ObjectResult<VehicleRegistration> NewVehicleRegistration(string certificateId)
        {
            VehicleRegistrationBLO biz = new VehicleRegistrationBLO();
            ObjectResult<VehicleRegistration> output = new ObjectResult<VehicleRegistration>();

            try
            {
                output.Result = biz.NewVehicleRegistration(certificateId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to add new Vehicle Registration";
            }
            return output;
        }

        public ObjectResult<VehicleRegistrationFee> NewVehicleRegistrationFee(string certificateId)
        {
            VehicleRegistrationBLO biz = new VehicleRegistrationBLO();
            ObjectResult<VehicleRegistrationFee> output = new ObjectResult<VehicleRegistrationFee>();

            try
            {
                output.Result = biz.NewVehicleRegistrationFee(certificateId);
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