using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;

namespace Inkript.VR.API.Controllers
{
    [Route("api/fileinoinspections")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FileInfoInspectionsController : ApiController
    {
        #region Methods
        [HttpGet]
        [Route("getallfileinspectionspaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllFileInspectionsPaged(int pageNumber, int pageSize)
        {
            FileInfoInspectionsApiBLO apiBiz = new FileInfoInspectionsApiBLO();

            try
            {
                return Ok(apiBiz.GetAllFileInspectionsPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getfileinspectionsby/{fileInspectionsId}")]
        public IHttpActionResult GetByFileInspectionsId(int fileInspectionsId)
        {
            FileInfoInspectionsApiBLO apiBiz = new FileInfoInspectionsApiBLO();

            try
            {
                return Ok(apiBiz.GetByFileInspectionsId(fileInspectionsId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("deletefileinspections/{fileInspectionsId}")]
        public IHttpActionResult DeleteFileInspections(int fileInspectionsId)
        {
            FileInfoInspectionsApiBLO apiBiz = new FileInfoInspectionsApiBLO();

            try
            {
                return Ok(apiBiz.DeleteFileInspections(fileInspectionsId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        [Route("createfileinfoinspections")]
        public IHttpActionResult CreateFileInfoInspections([FromBody] FileInfoInspectionsCustom fileInfoInspections)
        {
            FileInfoInspectionsApiBLO apiBiz = new FileInfoInspectionsApiBLO();
            ObjectResult<FileInfoInspections> output = new ObjectResult<FileInfoInspections>();

            try
            {
                if (!ModelState.IsValid)
                {
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateFileInfoInspections(fileInfoInspections));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
        #endregion
    }
}