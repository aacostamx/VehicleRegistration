using Inkript.Logging;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/platecodes")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlateCodesController : ApiController
    {
        [HttpGet]
        [Route("getallplatecodes")]
        public IHttpActionResult GetAllPlateCodes()
        {
            PlateCodesAPiBLO apiBiz = new PlateCodesAPiBLO();

            try
            {
                return Ok(apiBiz.GetAllPlateCodes());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}