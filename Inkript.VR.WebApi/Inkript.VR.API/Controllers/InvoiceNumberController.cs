using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Models;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inkript.VR.API.Controllers
{
    [Route("api/invoicenumber")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InvoiceNumberController : ApiController
    {
        [HttpGet]
        [Route("generateinvoicenumber/{branchId}/{feeCategoryId}")]
        public IHttpActionResult GenerateInvoiceNumber(int branchId, int feeCategoryId)
        {
            InvoiceNumberApiBLO apiBiz = new InvoiceNumberApiBLO();

            try
            {
                return Ok(apiBiz.GenerateInvoiceNumber(branchId, feeCategoryId));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return InternalServerError(ex);
            }
        }
    }
}