using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/plateranges")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlateRangesController : ApiController
    {
        [HttpGet]
        [Route("getallplaterangespaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllPlateRangesPaged(int pageNumber, int pageSize)
        {
            PlateRangesApiBLO apiBiz = new PlateRangesApiBLO();

            try
            {
                return Ok(apiBiz.GetAllPlateRangesPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("createplaterange")]
        public IHttpActionResult CreatePlateRange([FromBody] PlateRangesCustom plateRange)
        {
            PlateRangesApiBLO apiBiz = new PlateRangesApiBLO();
            ObjectResult<PlateRanges> output = new ObjectResult<PlateRanges>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreatePlateRange(plateRange));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("updateplaterangestatus/{plateRangeId}/{statusId}")]
        public IHttpActionResult UpdatePlateRangeStatus(int plateRangeId, int statusId)
        {
            PlateRangesApiBLO apiBiz = new PlateRangesApiBLO();
            ObjectResult<PlateRanges> output = new ObjectResult<PlateRanges>();

            try
            {
                return Ok(apiBiz.UpdatePlateRangeStatus(plateRangeId, statusId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getallrangesbystatus")]
        public IHttpActionResult GetAllRangesByStatus(int statusId)
        {
            PlateRangesApiBLO apiBiz = new PlateRangesApiBLO();
            ObjectResult<PlateRanges> output = new ObjectResult<PlateRanges>();

            try
            {
                return Ok(apiBiz.GetRangesByStatus(statusId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("platerangesfilter")]
        public IHttpActionResult PlateRangesFilter
            (int? sectorId = null, int? branchId = null, int? vehicleTypeId = null, int? plateCodeId = null)
        {
            PlateRangesApiBLO apiBiz = new PlateRangesApiBLO();
            ObjectResult<PlateRanges> output = new ObjectResult<PlateRanges>();

            try
            {
                if (sectorId == null && branchId == null && vehicleTypeId == null && plateCodeId == null)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }

                return Ok(apiBiz.PlateRangesFilter(sectorId, branchId, vehicleTypeId, plateCodeId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
