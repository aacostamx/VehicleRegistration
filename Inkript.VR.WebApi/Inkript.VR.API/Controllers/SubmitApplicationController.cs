using Inkript.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/submitapplication")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SubmitApplicationController : ApiController
    {
        [HttpPost]
        [Route("submitapplication/{applicationId}")]
        public IHttpActionResult SubmitApplication(int applicationId)
        {
            SubmitApplicationApiBLO apiBiz = new SubmitApplicationApiBLO();

            try
            {
                return Ok(apiBiz.SubmitApplication(applicationId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}