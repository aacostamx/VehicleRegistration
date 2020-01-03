using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/bluebook")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BlueBookController : ApiController
    {
        [HttpGet]
        [Route("getbluebookvalue")]
        public IHttpActionResult GetBlueBookValue()
        {
            BlueBookApiBLO apiBiz = new BlueBookApiBLO();
            try
            {
                return Ok(apiBiz.GetBlueBookValue());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
