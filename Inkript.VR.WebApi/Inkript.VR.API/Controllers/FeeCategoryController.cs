using Inkript.Logging;
using Inkript.VR.API.BusinessLayerLogic;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/feecategory")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FeeCategoryController : ApiController
    {
        [HttpGet]
        [Route("getallfeecategories")]
        public IHttpActionResult GetAllFeeCategories()
        {
            FeeCategoryApiBLO apiBiz = new FeeCategoryApiBLO();

            try
            {
                return Ok(apiBiz.GetAllFeeCategories());
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getfeecategory/{feeCategoryId}")]
        public IHttpActionResult GetFeecategory(int feeCategoryId)
        {
            FeeCategoryApiBLO apiBiz = new FeeCategoryApiBLO();

            try
            {
                return Ok(apiBiz.GetFeecategory(feeCategoryId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("calculatefeebycategory/{applicationId}")]
        public IHttpActionResult CalculateFeeByCategory(int applicationId)
        {
            FeesApiBLO apiBiz = new FeesApiBLO();
            List<FeeCategory> result = new List<FeeCategory>();
            ObjectResult<List<FeeCategory>> output = new ObjectResult<List<FeeCategory>>();

            try
            {
                ObjectResult<List<Fees>> fees = apiBiz.CalculateFees(applicationId, false);

                if (fees != null
                    && fees.Result != null
                    && fees.Result.Count > 0)
                {
                    foreach (var item in fees.Result)
                    {
                        FeeCategory feeCategory = item.FeeCategory;

                        if (!result.Any(c => c.FeeCategoryId == feeCategory.FeeCategoryId))
                        {
                            feeCategory.Fees = fees.Result.Where(c => c.FeeCategory.FeeCategoryId == item.FeeCategory.FeeCategoryId).ToList();
                            result.Add(feeCategory);
                        }
                    }
                }

                output.Message = fees.Message;
                output.Success = fees.Success;
                output.Result = result;

                return Ok(output);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}