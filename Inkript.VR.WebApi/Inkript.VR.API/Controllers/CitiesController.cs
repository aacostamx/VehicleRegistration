using Inkript.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/cities")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CitiesController : ApiController
    {
        [HttpGet]
        [Route("getallcities")]
        public IHttpActionResult GetAllCities()
        {
            CitiesApiBLO apiBiz = new CitiesApiBLO();

            try
            {
                return Ok(apiBiz.GetAllCities());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getcity/{cityId}")]
        public IHttpActionResult GetCity(int cityId)
        {
            CitiesApiBLO apiBiz = new CitiesApiBLO();

            try
            {
                return Ok(apiBiz.GetCity(cityId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

    }
}
