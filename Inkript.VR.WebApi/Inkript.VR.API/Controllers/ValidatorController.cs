using Inkript.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/validator")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValidatorController : ApiController
    {
        [HttpGet]
        [Route("regularrufcheck/{applicationId}/{cun}")]
        public IHttpActionResult RegularRufCheck(int applicationId, int? cun)
        {
            ValidatorApiBLO apiBiz = new ValidatorApiBLO();
            RUFApiBLO rufApiBiz = new RUFApiBLO();

            try
            {
                return Ok(apiBiz.RegularRufCheck(rufApiBiz.GetRUFDues(applicationId,0)));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}