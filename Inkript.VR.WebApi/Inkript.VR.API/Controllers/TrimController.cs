using Inkript.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/Trim")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TrimController : ApiController
    {
        [HttpGet]
        [Route("getallTrims")]
        public IHttpActionResult GetAllTrims()
        {
            TrimApiBLO apiBiz = new TrimApiBLO();

            try
            {
                return Ok(apiBiz.GetAllTrims());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
