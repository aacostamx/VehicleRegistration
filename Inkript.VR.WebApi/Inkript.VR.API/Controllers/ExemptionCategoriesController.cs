using Inkript.Logging;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/exemptioncategories")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExemptionCategoriesController : ApiController
    {
        [HttpGet]
        [Route("returnexemptioncategories")]
        public IHttpActionResult ReturnExemptionCategories([FromUri] List<int> feeIds = null)
        {
            ExemptionCategoriesApiBLO apiBiz = new ExemptionCategoriesApiBLO();

            try
            {
                return Ok(apiBiz.ReturnExemptionCategories(feeIds));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}