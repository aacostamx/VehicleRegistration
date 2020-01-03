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
    [Route("api/importcustoms")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ImportCustomsController : ApiController
    {
        #region Methods
        [HttpGet]
        [Route("getallimportcustomspaged/{pageNumber}/{pageSize}")]
        public IHttpActionResult GetAllImportCustomsPaged(int pageNumber, int pageSize)
        {
            ImportCustomsApiBLO apiBiz = new ImportCustomsApiBLO();

            try
            {
                return Ok(apiBiz.GetAllImportCustomsPaged(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getbyimportcustomsid/{importCustomsId}")]
        public IHttpActionResult GetByImportCustomsId(int importCustomsId)
        {
            ImportCustomsApiBLO apiBiz = new ImportCustomsApiBLO();

            try
            {
                return Ok(apiBiz.GetByImportCustomsId(importCustomsId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getbycertificationid/{certificationId}")]
        public IHttpActionResult GetByCertificationId(string certificationId)
        {
            ImportCustomsApiBLO apiBiz = new ImportCustomsApiBLO();

            try
            {
                return Ok(apiBiz.GetByCertificationId(certificationId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getbyfileinfoid/{fileInfoId}")]
        public IHttpActionResult GetByFileInfoId(int fileInfoId)
        {
            ImportCustomsApiBLO apiBiz = new ImportCustomsApiBLO();

            try
            {
                return Ok(apiBiz.GetByFileInfoId(fileInfoId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("importcustomsfilter/")]
        public IHttpActionResult ImportCustomsFilter([FromBody] ImportCustomFilter filter)
        {
            ImportCustomsApiBLO apiBiz = new ImportCustomsApiBLO();
            ObjectResult<List<ImportCustoms>> output = new ObjectResult<List<ImportCustoms>>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.ImportCustomsFilter(filter));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("createimportcustom/{fileInfoId}")]
        public IHttpActionResult CreateImportCustom(int fileInfoId, [FromBody] ImportCustomsCustom importCustom)
        {
            ImportCustomsApiBLO apiBiz = new ImportCustomsApiBLO();

            try
            {
                return Content(HttpStatusCode.Created, apiBiz.CreateImportCustom(fileInfoId, importCustom));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("updateimportcustom/{importCustomsId}")]
        public IHttpActionResult UpdateImportCustom(int importCustomsId, [FromBody] ImportCustomsCustom importCustom)
        {
            ImportCustomsApiBLO apiBiz = new ImportCustomsApiBLO();

            try
            {
                return Ok(apiBiz.UpdateImportCustom(importCustomsId, importCustom));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("deleteimportcustom/{importCustomsId}")]
        public IHttpActionResult DeleteImportCustom(int importCustomsId)
        {
            ImportCustomsApiBLO apiBiz = new ImportCustomsApiBLO();

            try
            {
                return Ok(apiBiz.DeleteImportCustom(importCustomsId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getcarvaluebycustomscertificate/{certificationId}")]
        public IHttpActionResult GetCarValueByCustomsCertificate(string certificationId)
        {
            ImportCustomsApiBLO apiBiz = new ImportCustomsApiBLO();

            try
            {
                return Ok(apiBiz.GetCarValueByCustomsCertificate(certificationId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getcarvalueestimationbycarspecs/{brand}/{model}/{trim}/{cc}/{numberHorses}/{chassisNumber}")]
        public IHttpActionResult GetCarValueEstimationByCarSpecs(
            string brand, int model, string trim, double cc, double numberHorses, string chassisNumber)
        {
            ImportCustomsApiBLO apiBiz = new ImportCustomsApiBLO();

            try
            {
                return Ok(apiBiz.GetCarValueEstimationByCarSpecs(brand, model, trim, cc, numberHorses, chassisNumber));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getcustomsinfo/{chassis}")]
        public IHttpActionResult GetCustomsInfo(string chassis)
        {
            ImportCustomsApiBLO apiBiz = new ImportCustomsApiBLO();

            try
            {
                return Ok(apiBiz.GetCustomsInfo(chassis));
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