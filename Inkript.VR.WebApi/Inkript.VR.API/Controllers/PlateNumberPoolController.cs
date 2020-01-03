using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/platenumberpool")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlateNumberPoolController : ApiController
    {
        [HttpPut]
        [Route("activateplatenumberpool/{plateNumber}")]
        public IHttpActionResult ActivatePlateNumberPool(string plateNumber)
        {
            PlateNumberPoolApiBLO apiBiz = new PlateNumberPoolApiBLO();

            try
            {
                return Content(HttpStatusCode.Created, apiBiz.ActivatePlateNumberPool(plateNumber));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("platenumberpoolinfo")]
        public IHttpActionResult PlateNumberPoolInfo(int? plateRangeId = null, string rangeName = null)
        {
            PlateNumberPoolApiBLO apiBiz = new PlateNumberPoolApiBLO();
            ObjectResult<PoolInfo> output = new ObjectResult<PoolInfo>();
            try
            {
                if (plateRangeId == null && rangeName == null)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }

                return Ok(apiBiz.PlateNumberPoolInfo(plateRangeId, rangeName));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
