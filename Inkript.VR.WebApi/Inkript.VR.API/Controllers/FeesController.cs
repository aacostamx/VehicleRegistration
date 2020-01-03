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
    [Route("api/fees")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FeesController : ApiController
    {
        [HttpGet]
        [Route("getallfeespaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllFeesPaged(int pageNumber, int pageSize)
        {
            FeesApiBLO apiBiz = new FeesApiBLO();

            try
            {
                return Ok(apiBiz.GetAllFeesPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getallfees")]
        public IHttpActionResult GetAllFees()
        {
            FeesApiBLO apiBiz = new FeesApiBLO();

            try
            {
                return Ok(apiBiz.GetAllFees());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getbyfeeid/{feeId}")]
        public IHttpActionResult GetByFeeId(int feeId)
        {
            FeesApiBLO apiBiz = new FeesApiBLO();

            try
            {
                return Ok(apiBiz.GetByFeeId(feeId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("feesfilter/{search}")]
        public IHttpActionResult FeesFilter(string search)
        {
            FeesApiBLO apiBiz = new FeesApiBLO();
            ObjectResult<List<Fees>> output = new ObjectResult<List<Fees>>();

            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.FeesFilter(search));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("createfee")]
        public IHttpActionResult CreateFee([FromBody] FeesCustom viewModel)
        {
            FeesApiBLO apiBiz = new FeesApiBLO();
            ObjectResult<Fees> output = new ObjectResult<Fees>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateFee(viewModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("updatefee/{feeId}")]
        public IHttpActionResult UpdateFee(int feeId, [FromBody] Fees fee)
        {
            FeesApiBLO apiBiz = new FeesApiBLO();
            ObjectResult<Fees> output = new ObjectResult<Fees>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.UpdateFee(feeId, fee));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }

        }

        [HttpDelete]
        [Route("deletefee/{feeId}")]
        public IHttpActionResult DeleteFee(int feeId)
        {
            FeesApiBLO apiBiz = new FeesApiBLO();

            try
            {
                return Ok(apiBiz.DeleteFee(feeId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("calculatefees/{applicationId}")]
        public IHttpActionResult CalculateFees(int applicationId, bool saveFee = false)
        {
            FeesApiBLO apiBiz = new FeesApiBLO();

            try
            {
                return Ok(apiBiz.CalculateFees(applicationId, saveFee));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("storedproceduresfees")]
        public IHttpActionResult StoredProceduresFees()
        {
            FeesApiBLO apiBiz = new FeesApiBLO();

            try
            {
                return Ok(apiBiz.StoredProceduresFees());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("stampfee")]
        public IHttpActionResult StampFee([FromBody] VehicleDetails vehicleInfo, int calledFromUI = 0)
        {
            FeesApiBLO apiBiz = new FeesApiBLO();

            try
            {
                return Ok(apiBiz.StampFee(vehicleInfo, calledFromUI));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
