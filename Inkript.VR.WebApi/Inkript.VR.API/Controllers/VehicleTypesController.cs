using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/vehicletypes")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehicleTypesController : ApiController
    {
        [HttpGet]
        [Route("getallvehicletypespaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllVehicleTypesPaged(int pageNumber, int pageSize)
        {
            VehicleTypesApiBLO apiBiz = new VehicleTypesApiBLO();

            try
            {
                return Ok(apiBiz.GetAllVehicleTypesPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getallvehicletypes")]
        public IHttpActionResult GetAllVehicleTypes()
        {
            VehicleTypesApiBLO apiBiz = new VehicleTypesApiBLO();

            try
            {
                return Ok(apiBiz.GetAllVehicleTypes());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getbyvehicletypeid/{vehicleTypeId}")]
        public IHttpActionResult GetByVehicleTypeId(int vehicleTypeId)
        {
            VehicleTypesApiBLO apiBiz = new VehicleTypesApiBLO();

            try
            {
                return Ok(apiBiz.GetByVehicleTypeId(vehicleTypeId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("vehicletypefilter/{search}")]
        public IHttpActionResult VehicleTypeFilter(string search)
        {
            VehicleTypesApiBLO apiBiz = new VehicleTypesApiBLO();

            try
            {
                return Ok(apiBiz.VehicleTypeFilter(search));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("createvehicletype")]
        public IHttpActionResult CreateVehicleType([FromBody] VehicleTypesCustom vehicleType)
        {
            VehicleTypesApiBLO apiBiz = new VehicleTypesApiBLO();
            ObjectResult<VehicleTypes> output = new ObjectResult<VehicleTypes>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateVehicleType(vehicleType));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("updatevehicletype/{vehicleTypeId}")]
        public IHttpActionResult UpdateVehicleType(int vehicleTypeId, [FromBody] VehicleTypesCustom vehicleType)
        {
            VehicleTypesApiBLO apiBiz = new VehicleTypesApiBLO();
            ObjectResult<VehicleTypes> output = new ObjectResult<VehicleTypes>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.UpdateVehicleType(vehicleTypeId, vehicleType));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("deletevehicletype/{vehicleTypeId}")]
        public IHttpActionResult DeleteVehicleType(int vehicleTypeId)
        {
            VehicleTypesApiBLO apiBiz = new VehicleTypesApiBLO();

            try
            {
                return Ok(apiBiz.DeleteVehicleType(vehicleTypeId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

    }
}
