using Inkript.Logging;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/appconfigcommit")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AppConfigCommitController : ApiController
    {
        [HttpGet]
        [Route("getallappconfigcommit")]
        public IHttpActionResult GetAllAppConfigCommit()
        {
            AppConfigCommitApiBLO apiBiz = new AppConfigCommitApiBLO();

            try
            {
                return Ok(apiBiz.GetAllAppConfigCommit());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
