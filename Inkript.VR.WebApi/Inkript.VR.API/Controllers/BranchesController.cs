using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/branches")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BranchesController : ApiController
    {
        [HttpPost]
        [Route("createbranch")]
        public IHttpActionResult CreateBranch([FromBody] BranchesCustom viewModel)
        {
            BranchesApiBLO apiBiz = new BranchesApiBLO();
            ObjectResult<Branches> output = new ObjectResult<Branches>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateBranch(viewModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getallbranches")]
        public IHttpActionResult GetAllBranches()
        {
            BranchesApiBLO apiBiz = new BranchesApiBLO();

            try
            {
                return Ok(apiBiz.GetAllBranches());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getbranch/{branchId}")]
        public IHttpActionResult GetBranch(int branchId)
        {
            BranchesApiBLO apiBiz = new BranchesApiBLO();

            try
            {
                return Ok(apiBiz.GetBranch(branchId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("deletebranch/{branchId}")]
        public IHttpActionResult DeleteBranch(int branchId)
        {
            BranchesApiBLO apiBiz = new BranchesApiBLO();

            try
            {
                return Ok(apiBiz.DeleteBranch(branchId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
