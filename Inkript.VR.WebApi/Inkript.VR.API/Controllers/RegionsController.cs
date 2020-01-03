using Inkript.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/regions")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegionsController : ApiController
    {
        [HttpGet]
        [Route("getallregions")]
        public IHttpActionResult GetAllRegions()
        {
            RegionsApiBLO apiBiz = new RegionsApiBLO();

            try
            {
                return Ok(apiBiz.GetAllRegions());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

    }
}
