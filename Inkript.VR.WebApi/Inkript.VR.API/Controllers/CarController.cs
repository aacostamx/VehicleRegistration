using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;


namespace Inkript.VR.API.Controllers
{
    [Route("api/car")]
    public class CarController : ApiController
    {
        [HttpGet]
        [Route("getallcarspaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllCarsPaged(int pageNumber, int pageSize)
        {
            CarsApiBLO apiBiz = new CarsApiBLO();

            try
            {
                return Ok(apiBiz.GetAllCarsPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}