using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers

{
    [Route("api/organization")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrganizationController : ApiController
    {
        [HttpGet]
        [Route("getallorganizations")]
        public IHttpActionResult GetAllOrganizations()
        {
            OrganizationApiBLO apiBiz = new OrganizationApiBLO();

            try
            {
                return Ok(apiBiz.GetAllOrganizations());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("filterorganizationsbyregisternumberregion")]
        public IHttpActionResult FilterOrganizationsByRegisterNumberRegion(string registrationNumber, int? region = null)
        {
            OrganizationApiBLO apiBiz = new OrganizationApiBLO();

            try
            {
                return Ok(apiBiz.FilterOrganizationsByRegisterNumberRegion(registrationNumber, region));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }


        [HttpGet]
        [Route("getorganizationsbycategory/{companycategoryId}")]
        public IHttpActionResult GetOrganizationsByCategory(int companycategoryId)
        {
            OrganizationApiBLO apiBiz = new OrganizationApiBLO();

            try
            {
                return Ok(apiBiz.GetOrganizationsByCategory(companycategoryId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("addneworganization")]
        public IHttpActionResult AddNewOrganization([FromBody] OrganizationCustom organization)
        {
            OrganizationApiBLO apiBiz = new OrganizationApiBLO();
            ObjectResult<Organization> output = new ObjectResult<Organization>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateOrganization(organization));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("updateorganization/{organizationId}")]
        public IHttpActionResult UpdateSector(int organizationId, [FromBody] OrganizationCustom organization)
        {
            OrganizationApiBLO apiBiz = new OrganizationApiBLO();
            ObjectResult<Organization> output = new ObjectResult<Organization>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.UpdateOrganization(organizationId, organization));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("deleteorganization/{organizationId}")]
        public IHttpActionResult DeleteOrganization(int organizationId)
        {
            OrganizationApiBLO apiBiz = new OrganizationApiBLO();

            try
            {
                return Ok(apiBiz.DeleteOrganization(organizationId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("organizationfilter/")]
        public IHttpActionResult OrganizationFilter(string search = "")
        {
            OrganizationApiBLO apiBiz = new OrganizationApiBLO();

            try
            {
                return Ok(apiBiz.OrganizationFilter(search));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getorganizationbyregistrationormof/search")]
        public IHttpActionResult GetOrganization(string search)
        {
            OrganizationApiBLO apiBiz = new OrganizationApiBLO();

            try
            {
                return Ok(apiBiz.GetOrganization(search));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
