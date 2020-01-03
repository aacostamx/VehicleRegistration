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
    [Route("api/importinspections")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ImportInspectionsController : ApiController
    {
        #region Methods
        [HttpGet]
        [Route("getallimportinspectionspaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllImportInspectionsPaged(int pageNumber, int pageSize)
        {
            ImportInspectionsApiBLO apiBiz = new ImportInspectionsApiBLO();

            try
            {
                return Ok(apiBiz.GetAllImportInspectionsPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getbyimportinspectionsid/{importInspectsId}")]
        public IHttpActionResult GetByImportInspectionsId(int importInspectsId)
        {
            ImportInspectionsApiBLO apiBiz = new ImportInspectionsApiBLO();

            try
            {
                return Ok(apiBiz.GetByImportInspectionsId(importInspectsId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("importinspectionsfilter/")]
        public IHttpActionResult ImportInspectionsFilter([FromBody] ImportInspectionsFilter filter)
        {
            ImportInspectionsApiBLO apiBiz = new ImportInspectionsApiBLO();
            ObjectResult<List<ImportInspections>> output = new ObjectResult<List<ImportInspections>>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.ImportInspectionsFilter(filter));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("deleteimportinspections/{importInspectsId}")]
        public IHttpActionResult DeleteImportInspections(int importInspectsId)
        {
            ImportInspectionsApiBLO apiBiz = new ImportInspectionsApiBLO();

            try
            {
                return Ok(apiBiz.DeleteImportInspections(importInspectsId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("createimportinspections")]
        public IHttpActionResult CreateImportInspections([FromBody] ImportInspectionsCustom importInspections)
        {
            ObjectResult<FileInfoCustoms> output = new ObjectResult<FileInfoCustoms>();
            ImportInspectionsApiBLO apiBiz = new ImportInspectionsApiBLO();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateImportInspections(importInspections));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("checkinspection/{carUniqueNumber}")]
        public IHttpActionResult CheckInspection(int carUniqueNumber)
        {
            ImportInspectionsApiBLO apiBiz = new ImportInspectionsApiBLO();

            try
            {
                return Ok(apiBiz.CheckInspection(carUniqueNumber));
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