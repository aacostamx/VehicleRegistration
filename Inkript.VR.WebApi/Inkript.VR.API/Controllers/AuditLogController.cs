using Inkript.Logging;
using Inkript.VR.API.BusinessLayerLogic;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/auditlog")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuditLogController : ApiController
    {
        [HttpPost]
        [Route("createauditlog")]
        public IHttpActionResult CreateAuditLog([FromBody] AuditLog auditLog)
        {
            AuditLogApiBLO apiBiz = new AuditLogApiBLO();

            try
            {
                return Content(HttpStatusCode.Created, apiBiz.CreateAuditLog(auditLog));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getallauditLogs")]
        public IHttpActionResult GetAllAuditLogs()
        {
            AuditLogApiBLO apiBiz = new AuditLogApiBLO();

            try
            {
                return Ok(apiBiz.GetAllAuditLogs());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
