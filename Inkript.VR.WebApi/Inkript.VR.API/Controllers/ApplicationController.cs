using Inkript.Logging;
using Inkript.VR.API.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/application")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApplicationController : ApiController
    {
        [HttpPost]
        [Route("createapplication")]
        public IHttpActionResult CreateApplication([FromBody] ApplicationCustom application)
        {
            ApplicationApiBLO apiBiz = new ApplicationApiBLO();
            ObjectResult<int> output = new ObjectResult<int>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateApplication(application));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("updateapplicationstatus/{applicationId}/{statusId}")]
        public IHttpActionResult UpdateApplicationStatus(int applicationId, int statusId)
        {
            ApplicationApiBLO apiBiz = new ApplicationApiBLO();

            try
            {
                return Ok(apiBiz.UpdateApplicationStatus(applicationId, statusId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("updateapplication/{applicationId}")]
        public IHttpActionResult UpdateApplication(int applicationId, [FromBody] ApplicationCustom application)
        {
            ApplicationApiBLO apiBiz = new ApplicationApiBLO();

            try
            {
                return Ok(apiBiz.UpdateApplication(applicationId, application));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getallapplication")]
        public IHttpActionResult GetAllApplication()
        {
            ApplicationApiBLO apiBiz = new ApplicationApiBLO();

            try
            {
                return Ok(apiBiz.GetAllApplication());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getapplications/{statusId}")]
        public IHttpActionResult GetApplications
            (int statusId, bool? dateFlag = null, int? userId = null, int? branchId = null, int? sectionId = null)
        {
            ApplicationApiBLO apiBiz = new ApplicationApiBLO();

            try
            {
                return Ok(apiBiz.GetApplications(statusId, dateFlag, userId, branchId, sectionId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("applicationfilter")]
        public IHttpActionResult ApplicationFilter(int statusId, string userId = null)
        {
            ApplicationApiBLO apiBiz = new ApplicationApiBLO();

            try
            {
                return Ok(apiBiz.ApplicationFilter(statusId, userId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getapplication/{applicationId}")]
        public IHttpActionResult GetApplication(int applicationId)
        {
            ApplicationApiBLO apiBiz = new ApplicationApiBLO();

            try
            {
                return Ok(apiBiz.GetApplication(applicationId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("commitapplication/{applicationId}")]
        public IHttpActionResult CommitApplication(int applicationId, [FromBody] List<Receipts> receipts)
        {
            ApplicationApiBLO apiBiz = new ApplicationApiBLO();

            try
            {
                return Ok(apiBiz.CommitApplication(applicationId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("deleteapplication/{applicationId}")]
        public IHttpActionResult DeleteApplication(int applicationId)
        {
            ApplicationApiBLO apiBiz = new ApplicationApiBLO();

            try
            {
                return Ok(apiBiz.DeleteApplication(applicationId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
