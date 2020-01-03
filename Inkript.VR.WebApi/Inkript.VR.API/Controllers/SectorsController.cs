using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/sectors")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SectorsController : ApiController
    {
        [HttpGet]
        [Route("getallsectorspaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllSectorsPaged(int pageNumber, int pageSize)
        {
            SectorApiBLO apiBiz = new SectorApiBLO();

            try
            {
                return Ok(apiBiz.GetAllSectorsPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getallsectors")]
        public IHttpActionResult GetAllSectors()
        {
            SectorApiBLO apiBiz = new SectorApiBLO();

            try
            {
                return Ok(apiBiz.GetAllSectors());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getsectorsbyvehicletype/{vehicleTypeId}")]
        public IHttpActionResult GetSectorsByVehicleType(int vehicleTypeId)
        {
            SectorApiBLO apiBiz = new SectorApiBLO();

            try
            {
                return Ok(apiBiz.GetSectorsByVehicleType(vehicleTypeId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getbysectorid/{sectorId}")]
        public IHttpActionResult GetBySectorId(int sectorId)
        {
            SectorApiBLO apiBiz = new SectorApiBLO();

            try
            {
                return Ok(apiBiz.GetBySectorId(sectorId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("sectorsfilter/{search}")]
        public IHttpActionResult SectorFilter(string search)
        {
            SectorApiBLO apiBiz = new SectorApiBLO();

            try
            {
                return Ok(apiBiz.SectorFilter(search));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("createsector")]
        public IHttpActionResult CreateSector([FromBody] SectorsCustom sector)
        {
            SectorApiBLO apiBiz = new SectorApiBLO();
            ObjectResult<Sectors> output = new ObjectResult<Sectors>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateSector(sector));

            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("updatesector/{sectorId}")]
        public IHttpActionResult UpdateSector(int sectorId, [FromBody] SectorsCustom sector)
        {
            SectorApiBLO apiBiz = new SectorApiBLO();
            ObjectResult<Sectors> output = new ObjectResult<Sectors>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.UpdateSector(sectorId, sector));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("deletesector/{sectorId}")]
        public IHttpActionResult DeleteSector(int sectorId)
        {
            SectorApiBLO apiBiz = new SectorApiBLO();

            try
            {
                return Ok(apiBiz.DeleteSector(sectorId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getsectorsatrisk")]
        public IHttpActionResult GetSectorsAtRisk(int sectorId, int? vehicleTypeId = null, int? plateCodeId = null, int? branchId = null)
        {
            SectorApiBLO apiBiz = new SectorApiBLO();

            try
            {
                return Ok(apiBiz.GetSectorsAtRisk(sectorId, vehicleTypeId, plateCodeId, branchId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }        
    }
}
