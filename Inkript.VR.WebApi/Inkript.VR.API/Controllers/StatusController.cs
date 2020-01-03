using Inkript.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Inkript.VR.API.Controllers
{
    [Route("api/status")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StatusController : ApiController
    {
        [HttpGet]
        [Route("getallstatus")]
        public IHttpActionResult GetAllStatus()
        {
            StatusApiBLO apiBiz = new StatusApiBLO();

            try
            {
                return Ok(apiBiz.GetAllStatus());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getstatus/{statusId}")]
        public IHttpActionResult GetStatus(int statusId)
        {
            StatusApiBLO apiBiz = new StatusApiBLO();

            try
            {
                return Ok(apiBiz.GetStatus(statusId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
