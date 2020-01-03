using Inkript.Logging;
using Inkript.VR.API.Models;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/vehicleregistration")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleRegistrationController:ApiController
    {
        [HttpGet]
        [Route("newvehicleregistration/{certificateId}")]
        public IHttpActionResult NewVehicleRegistration(string certificateId)
        {
            VehicleRegistrationApiBLO apiBiz = new VehicleRegistrationApiBLO();

            try
            {
                return Ok(apiBiz.NewVehicleRegistration(certificateId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("newvehicleregistrationfee/{certificateId}")]
        public IHttpActionResult NewVehicleRegistrationFee(string certificateId)
        {
            VehicleRegistrationApiBLO apiBiz = new VehicleRegistrationApiBLO();

            try
            {
                return Ok(apiBiz.NewVehicleRegistrationFee(certificateId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getroadusagefee")]
        public IHttpActionResult GetRoadUsageFee()
        {
            FeesApiBLO apiBiz = new FeesApiBLO();
            ObjectResult<double> output = new ObjectResult<double>();

            try
            {
                //TODO: remove hard-coded
                Random random = new Random();
                output.Result = random.NextDouble() * (300000.00 - 100000.00) + 100000.00;
                return Ok(output);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}