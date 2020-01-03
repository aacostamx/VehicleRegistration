using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/Model")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ModelController : ApiController
    {
        [HttpPost]
        [Route("createmodel")]
        public IHttpActionResult CreateModel([FromBody] ModelCustom viewModel)
        {
            ModelApiBLO apiBiz = new ModelApiBLO();
            ObjectResult<Model> output = new ObjectResult<Model>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Content(HttpStatusCode.Created, apiBiz.CreateModel(viewModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getallmodels")]
        public IHttpActionResult GetAllModels()
        {
            ModelApiBLO apiBiz = new ModelApiBLO();

            try
            {
                return Ok(apiBiz.GetAllModels());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getmodel/{modelId}")]
        public IHttpActionResult GetModel(int modelId)
        {
            ModelApiBLO apiBiz = new ModelApiBLO();

            try
            {
                return Ok(apiBiz.GetModel(modelId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("deletemodel/{modelId}")]
        public IHttpActionResult DeleteModel(int modelId)
        {
            ModelApiBLO apiBiz = new ModelApiBLO();

            try
            {
                return Ok(apiBiz.DeleteModel(modelId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("updatemodel/{modelId}")]
        public IHttpActionResult UpdateModel(int modelId, [FromBody]  ModelCustom viewModel)
        {
            ModelApiBLO apiBiz = new ModelApiBLO();
            ObjectResult<Model> output = new ObjectResult<Model>();

            try
            {
                if (!ModelState.IsValid)
                {
                    output.Message = "INVALID_CONTENT: A Required Field Or Parameter For The Resource Has Not Been Set";
                    return Content((HttpStatusCode)422, output);
                }
                return Ok(apiBiz.UpdateModel(modelId, viewModel));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }

        }
    }
}
