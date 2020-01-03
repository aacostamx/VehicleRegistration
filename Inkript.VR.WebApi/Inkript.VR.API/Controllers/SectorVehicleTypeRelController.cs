using Inkript.Logging;
using Inkript.VR.API.BusinessLayerLogic;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/sectorvehicletypeRel")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SectorVehicleTypeRelController : ApiController
    {
        [HttpGet]
        [Route("getsectorvehicletyperef")]
        public IHttpActionResult GetSectorVehicleTypeRef(int? sectorId = null, int? vehicleTypeId = null)
        {
            SectorVehicleTypeRelApiBLO apiBiz = new SectorVehicleTypeRelApiBLO();
            ObjectResult<SectorVehicleTypeRel> output = new ObjectResult<SectorVehicleTypeRel>();

            try
            {
                if (sectorId == null && vehicleTypeId == null)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }

                if (sectorId == null || vehicleTypeId == null)
                {
                    return Ok(output);
                }

                return Ok(apiBiz.GetSectorVehicleTypeRef(sectorId, vehicleTypeId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
