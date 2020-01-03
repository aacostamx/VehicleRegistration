using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/brand")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BrandController : ApiController
    {
        [HttpPost]
        [Route("createbrand")]
        public IHttpActionResult CreateBrand([FromBody] BrandCustom viewModel)
        {
            BrandApiBLO apiBiz = new BrandApiBLO();
            ObjectResult<Brand> output = new ObjectResult<Brand>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateBrand(viewModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getallbrand")]
        public IHttpActionResult GetAllBrands()
        {
            BrandApiBLO apiBiz = new BrandApiBLO();

            try
            {
                return Ok(apiBiz.GetAllBrands());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getbrand/{brandId}")]
        public IHttpActionResult GetBrand(int brandId)
        {
            BrandApiBLO apiBiz = new BrandApiBLO();

            try
            {
                return Ok(apiBiz.GetBrand(brandId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("deletebrand/{brandId}")]
        public IHttpActionResult DeleteBrand(int brandId)
        {
            BrandApiBLO apiBiz = new BrandApiBLO();

            try
            {
                return Ok(apiBiz.DeleteBrand(brandId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}
