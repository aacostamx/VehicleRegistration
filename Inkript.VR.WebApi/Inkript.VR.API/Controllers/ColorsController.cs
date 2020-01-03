using Inkript.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/colors")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ColorsController: ApiController
    {
        [HttpGet]
        [Route("getallcolors")]
        public IHttpActionResult GetAllColors()
        {
            ColorsApiBLO apiBiz = new ColorsApiBLO();

            try
            {
                return Ok(apiBiz.GetAllColors());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}