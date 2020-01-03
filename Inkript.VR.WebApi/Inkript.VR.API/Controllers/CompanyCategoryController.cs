using Inkript.Logging;
using Inkript.VR.API.BusinessLayerLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/companycategory")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CompanyCategoryController : ApiController
    {

        [HttpGet]
        [Route("getallcompanycategories")]
        public IHttpActionResult GetAllCompanyCategories()
        {
            CompanyCategoryApiBLO apiBiz = new CompanyCategoryApiBLO();

            try
            {
                return Ok(apiBiz.GetAllCompanyCategories());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
