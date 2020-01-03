using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/ruf")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RUFController : ApiController
    {
        [HttpGet]
        [Route("getrufdues/{applicationId}/{currentYearIncluded}")]
        public IHttpActionResult GetRUFDues(int applicationId, int currentYearIncluded)
        {
            RUFApiBLO apiBiz = new RUFApiBLO();

            try
            {
                return Ok(apiBiz.GetRUFDues(applicationId, currentYearIncluded));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}