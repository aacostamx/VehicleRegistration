using Inkript.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/fueltypes")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FuelTypesController : ApiController
    {
        [HttpGet]
        [Route("getallfueltypes")]
        public IHttpActionResult GetAllFuelTypes()
        {
            FuelTypesApiBLO apiBiz = new FuelTypesApiBLO();

            try
            {
                return Ok(apiBiz.GetAllFuelTypes());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}