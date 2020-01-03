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
    [Route("api/fileinfocustoms")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FileInfoCustomsController : ApiController
    {
        #region Methods
        [HttpGet]
        [Route("getallfileinfocustomspaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllFileInfoCustomsPaged(int pageNumber, int pageSize)
        {
            FileInfoCustomsApiBLO apiBiz = new FileInfoCustomsApiBLO();

            try
            {
                return Ok(apiBiz.GetAllFileInfoCustomsPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getfileinfocustomby/{fileInfoCustomId}")]
        public IHttpActionResult GetByFileInfoCustomId(int fileInfoCustomId)
        {
            FileInfoCustomsApiBLO apiBiz = new FileInfoCustomsApiBLO();

            try
            {
                return Ok(apiBiz.GetByFileInfoCustomId(fileInfoCustomId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getfileinfoname/{name}")]
        public IHttpActionResult GetByFileInfoName(string name)
        {
            FileInfoCustomsApiBLO apiBiz = new FileInfoCustomsApiBLO();

            try
            {
                return Ok(apiBiz.GetByFileInfoCustomName(name));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("deletefileinfocustom/{fileInfoCustomId}")]
        public IHttpActionResult DeleteFileInfoCustom(int fileInfoCustomId)
        {
            FileInfoCustomsApiBLO apiBiz = new FileInfoCustomsApiBLO();

            try
            {
                return Ok(apiBiz.DeleteFileInfo(fileInfoCustomId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("createfileinfocustom")]
        public IHttpActionResult CreateFileInfoCustom([FromBody] FileInfoCustomsCustom fileInfo)
        {
            FileInfoCustomsApiBLO apiBiz = new FileInfoCustomsApiBLO();
            ObjectResult<FileInfoCustoms> output = new ObjectResult<FileInfoCustoms>();

            try
            {
                if (!ModelState.IsValid)
                {
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateFileInfoCustom(fileInfo));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("updatefileinfo/")]
        public IHttpActionResult UpdateFileInfo([FromBody] FileInfoCustoms fileInfo)
        {
            FileInfoCustomsApiBLO apiBiz = new FileInfoCustomsApiBLO();
            ObjectResult<FileInfoCustoms> output = new ObjectResult<FileInfoCustoms>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.UpdateFileInfoCustom(fileInfo));
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