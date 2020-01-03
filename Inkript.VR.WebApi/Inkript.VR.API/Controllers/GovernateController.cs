using Inkript.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/governate")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GovernateController : ApiController
    {
        [HttpGet]
        [Route("getallgovernates")]
        public IHttpActionResult GetAllGovernates()
        {
            GovernateApiBLO apiBiz = new GovernateApiBLO();

            try
            {
                return Ok(apiBiz.GetAllGovernates());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
