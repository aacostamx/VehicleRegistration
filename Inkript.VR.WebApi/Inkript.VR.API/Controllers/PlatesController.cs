using Inkript.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/plates")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlatesController : ApiController
    {
        [HttpGet]
        [Route("getplatesnumbertodeliver")]
        public IHttpActionResult GetPlatesNumberToDeliver(int carUniqueNumber, int vehicleTypeId, int? trunkTypeId = null)
        {
            PlatesApiBLO apiBiz = new PlatesApiBLO();

            try
            {
                return Ok(apiBiz.GetPlatesNumberToDeliver(carUniqueNumber, vehicleTypeId, trunkTypeId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("generaterandomnumber/{branchId}/{sectorId}/{vehicleTypeId}")]
        public IHttpActionResult GenerateRandomNumber(int branchId, int sectorId, int vehicleTypeId)
        {
            PlatesApiBLO apiBiz = new PlatesApiBLO();

            try
            {
                return Ok(apiBiz.GenerateRandomNumber(branchId, sectorId, vehicleTypeId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
