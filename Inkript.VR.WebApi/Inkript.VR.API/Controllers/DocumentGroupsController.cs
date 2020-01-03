using Inkript.Logging;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/documentgroups")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DocumentGroupsController : ApiController
    {
        [HttpPost]
        [Route("getdocumentgroups")]
        public IHttpActionResult GetDocumentGroups([FromBody] List<DocumentCustom> documents)
        {
            DocumentGroupsApiBLO apiBiz = new DocumentGroupsApiBLO();

            try
            {
                return Ok(apiBiz.GetDocumentGroups(documents));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
