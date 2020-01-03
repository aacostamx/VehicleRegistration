using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/businessprocesses")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BusinessProcessesController : ApiController
    {
        [HttpGet]
        [Route("getallbusinessprocessespaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllBusinessProcessesPaged(int pageNumber, int pageSize)
        {
            BusinessProcessesApiBLO apiBiz = new BusinessProcessesApiBLO();

            try
            {
               return Ok(apiBiz.GetAllBusinessProcessesPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getallbusinessprocesses")]
        public IHttpActionResult GetAllBusinessProcesses()
        {
            BusinessProcessesApiBLO apiBiz = new BusinessProcessesApiBLO();

            try
            {
                return Ok(apiBiz.GetAllBusinessProcesses());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getbusinessprocessdeliverables/{businessProcessId}")]
        public IHttpActionResult GetBusinessProcessDeliverables(int businessProcessId)
        {
            BusinessProcessesApiBLO apiBiz = new BusinessProcessesApiBLO();

            try
            {
                return Ok(apiBiz.GetBusinessProcessDeliverables(businessProcessId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getbybusinessprocessid/{businessProcessId}")]
        public IHttpActionResult GetByBusinessProcessId(int businessProcessId)
        {
            BusinessProcessesApiBLO apiBiz = new BusinessProcessesApiBLO();

            try
            {
                return Ok(apiBiz.GetByBusinessProcessId(businessProcessId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpGet]
        [Route("getsecondarybusinessprocessesby/{businessProcessId}")]
        public IHttpActionResult GetByBusinessProcessesBy
            (int businessProcessId, int? sectorId = null, int? vehicleTypeId = null, int? carUniqueNumber = null)
        {
            BusinessProcessesApiBLO apiBiz = new BusinessProcessesApiBLO();

            try
            {
                return Ok(apiBiz.GetSecondaryBusinessProcessesBy(businessProcessId, sectorId, vehicleTypeId, carUniqueNumber));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpGet]
        [Route("businessprocessesfilter/{search}")]
        public IHttpActionResult BusinessProcessesFilter(string search)
        {
            BusinessProcessesApiBLO apiBiz = new BusinessProcessesApiBLO();

            try
            {
                return Ok(apiBiz.BusinessProcessesFilter(search));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getprimarybusinessprocesses")]
        public IHttpActionResult GetPrimaryBusinessProcesses()
        {
            BusinessProcessesApiBLO apiBiz = new BusinessProcessesApiBLO();

            try
            {
                return Ok(apiBiz.GetPrimaryBusinessProcesses());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("createbusinessprocess")]
        public IHttpActionResult CreateBusinessProcess([FromBody] BusinessProcessesCustom businessProcess)
        {
            ObjectResult<BusinessProcesses> output = new ObjectResult<BusinessProcesses>();
            BusinessProcessesApiBLO apiBiz = new BusinessProcessesApiBLO();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateBusinessProcess(businessProcess));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("updatebusinessprocess/{businessProcessesId}")]
        public IHttpActionResult UpdateBusinessProcess(int businessProcessesId, 
            [FromBody] BusinessProcessesCustom businessProcess)
        {
            ObjectResult<BusinessProcesses> output = new ObjectResult<BusinessProcesses>();
            BusinessProcessesApiBLO apiBiz = new BusinessProcessesApiBLO();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.UpdateBusinessProcess(businessProcessesId, businessProcess));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpPut]
        [Route("changestatusbusinessprocess/{businessProcessId}")]
        public IHttpActionResult ChangeStatusBusinessProcess(int businessProcessId)
        {
            BusinessProcessesApiBLO apiBiz = new BusinessProcessesApiBLO();

            try
            {
                return Ok(apiBiz.ChangeStatusBusinessProcess(businessProcessId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

    }

}
