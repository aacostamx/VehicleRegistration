using Inkript.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/districts")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DistrictsController : ApiController
    {
        [HttpGet]
        [Route("getalldistricts")]
        public IHttpActionResult GetAllDistricts()
        {
            DistrictsApiBLO apiBiz = new DistrictsApiBLO();

            try
            {
                return Ok(apiBiz.GetAllDistricts());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
