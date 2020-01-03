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
    [Route("api/auditactivities")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuditActivitiesController : ApiController
    {
        [HttpPost]
        [Route("createauditactivities")]
        public IHttpActionResult CreateAuditActivities([FromBody] AuditActivities auditActivity)
        {
            AuditActivitiesApiBLO apiBiz = new AuditActivitiesApiBLO();

            try
            {
                return Content(HttpStatusCode.Created, apiBiz.CreateAuditActivities(auditActivity));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getallauditactivities")]
        public IHttpActionResult GetAllAuditActivities()
        {
            AuditActivitiesApiBLO apiBiz = new AuditActivitiesApiBLO();

            try
            {
                return Ok(apiBiz.GetAllAuditActivities());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
