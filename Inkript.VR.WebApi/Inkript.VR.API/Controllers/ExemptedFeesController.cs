using Inkript.Logging;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/exemptedfees")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExemptedFeesController : ApiController
    {
        [HttpGet]
        [Route("getallexemptedfees")]
        public IHttpActionResult GetExemptedFees()
        {
            ExemptedFeesApiBLO apiBiz = new ExemptedFeesApiBLO();

            try
            {
                return Ok(apiBiz.GetExemptedFees());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("returnexemptedfees")]
        public IHttpActionResult ReturnExemptedFees([FromUri] List<int> exemptionCategoriesIds = null)
        {
            ExemptedFeesApiBLO apiBiz = new ExemptedFeesApiBLO();

            try
            {
                return Ok(apiBiz.ReturnExemptedFees(exemptionCategoriesIds));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
