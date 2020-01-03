using Inkript.Logging;
using Inkript.VR.API.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/caruniquenumber")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CarUniqueNumberController : ApiController
    {
        [HttpPost]
        [Route("generatecaruniquenumber")]
        public IHttpActionResult GenerateCarUniqueNumber([FromBody] CarUniqueNumberCustom carUniqueNumber)
        {
            ObjectResult<int> output = new ObjectResult<int>();
            CarUniqueNumberApiBLO apiBiz = new CarUniqueNumberApiBLO();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }

                return Ok(apiBiz.GenerateCarUniqueNumber(carUniqueNumber));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getcaruniquenumber/{chassisNumber}")]
        public IHttpActionResult GetCarUniqueNumberByChassisNumber(string chassisNumber)
        {
            ObjectResult<int> output = new ObjectResult<int>();
            CarUniqueNumberApiBLO apiBiz = new CarUniqueNumberApiBLO();

            try
            {
                return Ok(apiBiz.GetCarUniqueNumberByChassisNumber(chassisNumber));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
