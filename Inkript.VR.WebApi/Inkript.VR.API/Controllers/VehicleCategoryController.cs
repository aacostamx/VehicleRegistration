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
    [Route("api/vehiclecategory")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleCategoryController : ApiController
    {
        [HttpGet]
        [Route("getallvehiclecategories")]
        public IHttpActionResult GetAllVehicleCategories()
        {
            VehicleCategoryApiBLO apiBiz = new VehicleCategoryApiBLO();

            try
            {
                return Ok(apiBiz.GetAllVehicleCategories());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
