using Inkript.Logging;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{   
    [Route("api/paymentsubmit")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PaymentSubmitController : ApiController
    {
        [HttpPost]
        [Route("paymentSubmit")]
        public IHttpActionResult PaymentSubmit(List<SubmitOrder> paymentOrder)
        {
            PaymentSubmitApiBLO apiBiz = new PaymentSubmitApiBLO();

            try
            {
                return Ok(apiBiz.PaymentSubmit(paymentOrder));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}