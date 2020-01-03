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
    [Route("api/registeredvehicles")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegisteredVehiclesController : ApiController
    {
        [HttpGet]
        [Route("getregisteredvehiclestatus/{carUniqueNumber}")]
        public IHttpActionResult GetRegisteredVehicleStatus(int carUniqueNumber)
        {
            RegisteredVehiclesApiBLO apiBiz = new RegisteredVehiclesApiBLO();

            try
            {
                return Ok(apiBiz.GetRegisteredVehicleStatus(carUniqueNumber));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        //[HttpGet]
        //[Route("getregisteredvehicleby")]
        //public IHttpActionResult GetRegisteredVehicleBy
        //    (int? plateNumber = null, int? plateCodeId = null, int? carUniqueNumber = null, int? carStatusId = null)
        //{
        //    RegisteredVehiclesApiBLO apiBiz = new RegisteredVehiclesApiBLO();
        //    ObjectResult<RegisteredVehicles> output = new ObjectResult<RegisteredVehicles>();

        //    try
        //    {
        //        if (plateNumber == null && plateCodeId == null
        //            && carUniqueNumber == null && carStatusId == null)
        //        {
        //            output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
        //            return Content((HttpStatusCode)422, output);
        //        }

        //        return Ok(apiBiz.GetRegisteredVehicleBy(plateNumber, plateCodeId, carUniqueNumber, carStatusId));
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex);
        //        return InternalServerError(ex);
        //    }
        //}

        [HttpGet]
        [Route("getregisteredvehicles")]
        public IHttpActionResult GetRegisteredVehicles(int? carUniqueNumber = null, string plateNumber = null, int? plateCodeId = null)
        {
            RegisteredVehiclesApiBLO apiBiz = new RegisteredVehiclesApiBLO();
            ObjectResult<List<RegisteredVehicles>> output = new ObjectResult<List<RegisteredVehicles>>();

            try
            {
                if (plateNumber == null && plateCodeId == null && carUniqueNumber == null)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }

                return Ok(apiBiz.GetRegisteredVehicles(carUniqueNumber, plateNumber, plateCodeId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getallregisteredvehiclespaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllRegisteredVehiclesPaged(int pageNumber, int pageSize)
        {
            RegisteredVehiclesApiBLO apiBiz = new RegisteredVehiclesApiBLO();

            try
            {

                return Ok(apiBiz.GetAllRegisteredVehiclesPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        //[HttpGet]
        //[Route("getvehiclevalueandstamp")]
        //public IHttpActionResult GetVehicleValueAndStamp(int carUniqueNumber)
        //{
        //    RegisteredVehiclesApiBLO apiBiz = new RegisteredVehiclesApiBLO();

        //    try
        //    {
        //        return Ok(apiBiz.GetVehicleValueAndStamp(carUniqueNumber);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex);
        //        return InternalServerError(ex);
        //    }
        //}
    }
}