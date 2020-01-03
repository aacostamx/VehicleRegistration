using Inkript.Logging;
using Inkript.VR.API.BusinessLayerLogic;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/utilization")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UtilizationController : ApiController
    {
        [HttpGet]
        [Route("getutilizationby/{sectorId}/{vehicleTypeId}")]
        public IHttpActionResult GetUtilizationby(int sectorId, int vehicleTypeId)
        {
            UtilizationApiBLO apiBiz = new UtilizationApiBLO();

            try
            {
                return Ok(apiBiz.GetUtilizationby(sectorId, vehicleTypeId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
