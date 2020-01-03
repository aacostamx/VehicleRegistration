using Inkript.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/expiration")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExpirationController : ApiController
    {
        [HttpGet]
        [Route("dateExpired/{date}/{verificationMethod}")]
        public IHttpActionResult DateExpired(DateTime date, string verificationMethod)
        {
            ExpirationApiBLO apiBiz = new ExpirationApiBLO();

            try
            {
                return Ok(apiBiz.DateExpired(date, verificationMethod));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}