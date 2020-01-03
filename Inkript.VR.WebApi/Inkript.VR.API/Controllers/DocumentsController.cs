using Inkript.Logging;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/documents")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DocumentsController : ApiController
    {
        [HttpGet]
        [Route("getdocuments/{bpId}/{sectorId}/{vehicleTypeId}")]
        public IHttpActionResult GetDocuments(int bpId, int sectorId, int vehicleTypeId)
        {
            DocumentsApiBLO apiBiz = new DocumentsApiBLO();

            try
            {
                return Ok(apiBiz.GetDocuments(bpId, sectorId, vehicleTypeId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("getdocuments")]
        public IHttpActionResult GetDocuments([FromBody] List<DocumentCustom> documents)
        {
            DocumentsApiBLO apiBiz = new DocumentsApiBLO();

            try
            {
                return Ok(apiBiz.GetDocuments(documents));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getalldocuments")]
        public IHttpActionResult GetAllDocuments()
        {
            DocumentsApiBLO apiBiz = new DocumentsApiBLO();

            try
            {
                return Ok(apiBiz.GetAllDocuments());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getbusinessprocessdocuments/{businessProcessId}")]
        public IHttpActionResult GetBusinessProcessDocuments(int businessProcessId)
        {
            DocumentsApiBLO apiBiz = new DocumentsApiBLO();

            try
            {
                return Ok(apiBiz.GetBusinessProcessDocuments(businessProcessId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

    }
}