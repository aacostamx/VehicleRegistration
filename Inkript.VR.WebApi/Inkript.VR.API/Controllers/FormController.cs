using Inkript.Logging;
using Inkript.VR.API.BusinessLayerLogic;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/form")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FormController : ApiController
    {
        [HttpGet]
        [Route("getallform")]
        public IHttpActionResult GetAllForms()
        {
            FormApiBLO apiBiz = new FormApiBLO();

            try
            {
                return Ok(apiBiz.GetAllForms());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
