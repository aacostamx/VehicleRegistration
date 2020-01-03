using Inkript.Logging;
using Inkript.VR.API.BusinessLayerLogic;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/trunktype")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TrunkTypeController : ApiController
    {
        [HttpGet]
        [Route("getalltrunktypes")]
        public IHttpActionResult GetAllTrunkTypes()
        {
            TrunkTypeApiBLO apiBiz = new TrunkTypeApiBLO();

            try
            {
                return Ok(apiBiz.GetAllTrunkTypes());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
