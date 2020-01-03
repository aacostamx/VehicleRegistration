using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/vehicle")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleController : ApiController
    {
        [HttpPost]
        [Route("getvehiclevalue")]
        public IHttpActionResult GetVehicleValue([FromBody] VehicleDetails vehicleInfo)
        {
            VehicleApiBLO apiBiz = new VehicleApiBLO();
            ObjectResult<VehicleDetails> output = new ObjectResult<VehicleDetails>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.GetVehicleValue(vehicleInfo));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("vehiclesearch")]
        public IHttpActionResult VehicleSearch(int? carUniqueNumber = null, string certificateId = null)
        {
            VehicleApiBLO apiBiz = new VehicleApiBLO();
            ObjectResult<VehicleDetails> output = new ObjectResult<VehicleDetails>();

            try
            {
                if (carUniqueNumber == null && certificateId == null)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }

                return Ok(apiBiz.VehicleSearch(carUniqueNumber, certificateId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}